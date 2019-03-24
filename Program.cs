using System;
using System.Collections.Generic;

namespace Project2
{
     internal class Program
     {
          // Handler Interface
          public interface IHandlerInterface
          {
               // Method for building the chain of responsibility
               IHandlerInterface SetNextObject(IHandlerInterface handler);

               //  Method for executing a request (conversion type)
               object Handle(object request, double changeMe);
          }

          // Handler Abstract Class
          private abstract class AbstractHandler : IHandlerInterface
          {
               protected IHandlerInterface nextObject;

               public IHandlerInterface SetNextObject(IHandlerInterface handler)
               {
                    nextObject = handler;
                    return handler;
               }

               public virtual object Handle(object request, double changeMe)
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
          class KilometersToMiles : AbstractHandler
          {
               public override object Handle(object request, double changeMe)
               {
                    if ((request as string) == "miles")
                    {
                         return (changeMe/1.609) + " miles\n";
                    }
                    else
                    {
                         return base.Handle(request, changeMe);
                    }
               }
          }

          // Concrete clsas to handle kilometer to yards conversion
          class KilometersToYards : AbstractHandler
          {
               public override object Handle(object request, double changeMe)
               {
                    if ((request as string) == "yards")
                    {
                         return (changeMe*1093.61) + " yards\n";
                    }
                    else
                    {
                         return base.Handle(request, changeMe);
                    }
               }
          }

          // Concrete clsas to handle kilometer to feet conversion
          class KilometersToFeet : AbstractHandler
          {
               public override object Handle(object request, double changeMe)
               {
                    if ((request as string) == "feet")
                    {
                         return (changeMe*3280.84) + " feet\n";
                    }
                    else
                    {
                         return base.Handle(request, changeMe);
                    }
               }
          }

          // Details of Client Request
          private class ClientRequest
          {
               // Overloaded Constructor
               public static void ClientInput(AbstractHandler handler)
               {
                    foreach (string ConversionType in new List<string> { "miles", "yards", "feet" })
                    {
                         double dummyValue = 4.4;

                         Console.WriteLine($"Client wants to convert {dummyValue} kilometers to {ConversionType} \n");
                         object result = handler.Handle(ConversionType, dummyValue);

                         if (result != null)
                         {
                              Console.Write($"Result: {result}\n");
                         }
                         else
                         {
                              Console.WriteLine($"{ConversionType} was not utilized.\n");
                         }

                    }
               }
          }

          private static void Main(string[] args)
          {
               //Create the chain links
               var miles = new KilometersToMiles();
               var yards = new KilometersToYards();
               var feet = new KilometersToFeet();

               miles.SetNextObject(yards).SetNextObject(feet);

               ClientRequest.ClientInput(miles);
               Console.WriteLine();
          }
     }
}
