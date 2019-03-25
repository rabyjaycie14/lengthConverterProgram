using System;


namespace addDecorator
{
     internal class Program
     {
          // Handler Interface
          public interface IHandlerInterface
          {
               // Method for building the chain of responsibility
               IHandlerInterface SetNextObject(IHandlerInterface handler);

               //  Method for executing a request (conversion type)
               string Handle(string request, double changeMe);
          }

          // Handler Abstract Class
          public abstract class AbstractHandler : IHandlerInterface
          {
               protected IHandlerInterface nextObject;

               public IHandlerInterface SetNextObject(IHandlerInterface handler)
               {
                    nextObject = handler;
                    return handler;
               }

               public virtual string Handle(string request, double changeMe)
               {
                    if (nextObject != null)
                    {
                         return nextObject.Handle(request, changeMe);
                    }
                    else
                    {
                         return null;
                    }
               }
          }

          // Concrete class to handle kilometer to miles conversion
          private class KilometersToMiles : AbstractHandler
          {
               public override string Handle(string request, double changeMe)
               {
                    if ((request as string) == "miles")
                    {
                         var output = (changeMe / 1.609).ToString();
                         return output ;
                    }
                    else
                    {
                         return base.Handle(request, changeMe);
                    }
               }
          }

          // Concrete clsas to handle kilometer to yards conversion
          private class KilometersToYards : AbstractHandler
          {
               public override string Handle(string request, double changeMe)
               {
                    if ((request as string) == "yards")
                    {
                         var output = (changeMe * 1093.61).ToString();
                         return output;
                    }
                    else
                    {
                         return base.Handle(request, changeMe);
                    }
               }
          }

          // Concrete clsas to handle kilometer to feet conversion
          private class KilometersToFeet : AbstractHandler
          {
               public override string Handle(string request, double changeMe)
               {
                    if ((request as string) == "feet")
                    {
                         var output = (changeMe * 3280.84).ToString();
                         return output;
                    }
                    else
                    {
                         return base.Handle(request, changeMe);
                    }
               }
          }

          // Decorator Abstract Class
          // Extends AbstractHandler class to be interchangeable with
          // its concrete decorators
          public abstract class Decorator : AbstractHandler
          {
               public abstract override string Handle(string request, double changeMe);
          }

          // Concrete decorator class used to round output to 2 decimal places
          public class rounded2DecimalPlaces : Decorator
          {
               private AbstractHandler handler;

               public rounded2DecimalPlaces()
               {
               }

               public rounded2DecimalPlaces(AbstractHandler handler)
               {
                    this.handler = handler;
               }

               public override string Handle(string request, double changeMe)
               {
                    string token = handler.Handle(request, changeMe).ToString();
                    decimal newToken = decimal.Parse(token);
                    string output = newToken.ToString("F2");
                    return output;
               }
          }

          // Concrete decorator class used to convert output to exponential notation
          public class expNotation : Decorator
          {
               private AbstractHandler handler;

               public expNotation()
               {
               }

               public expNotation(AbstractHandler handler)
               {
                    this.handler = handler;
               }

               public override string Handle(string request, double changeMe)
               {
                    string token = handler.Handle(request, changeMe).ToString();
                    decimal newToken = decimal.Parse(token);
                    string output = newToken.ToString("#0.0e0");
                    return output;
               }
          }

          public class addUnitName : Decorator
          {
               private AbstractHandler handler;

               public addUnitName()
               {
               }

               public addUnitName(AbstractHandler handler)
               {
                    this.handler = handler;
               }

               public override string Handle(string request, double changeMe)
               {
                    string token = handler.Handle(request, changeMe).ToString();
                    return token + " " + request;
               }
          }


          // Details of Client Request
          public class ClientRequest
          {
               // Overloaded Constructor
               public static void ClientInput(AbstractHandler handler, string conversionType, double dummyValue)
               {
                    Console.WriteLine($"Client wants to convert {dummyValue} kilometers to {conversionType} \n");
                    object result = handler.Handle(conversionType, dummyValue);

                    if (result != null)
                    {
                         Console.Write($"Result: {result}\n");
                    }
                    else
                    {
                         Console.WriteLine($"{conversionType} was not utilized.\n");
                    }
               }
          }

          private static void Main(string[] args)
          {
               //Create the chain links
               AbstractHandler miles = new KilometersToMiles();
               AbstractHandler yards = new KilometersToYards();
               AbstractHandler feet = new KilometersToFeet();

               miles.SetNextObject(yards).SetNextObject(feet);

               ClientRequest.ClientInput(miles, "miles", 1);
               Console.WriteLine();

               miles = new rounded2DecimalPlaces(miles);
               miles = new expNotation(miles);
               miles = new addUnitName(miles);
               ClientRequest.ClientInput(miles, "miles", 47);
          }
     }
}
