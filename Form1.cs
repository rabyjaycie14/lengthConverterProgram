using System;
using System.Windows.Forms;

namespace LengthConverter
{
     public partial class Form1 : Form
     {
          public Form1()
          {
               InitializeComponent();
          }

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
                         double result = (changeMe / 1.609);
                         string result1 = result.ToString();
                         return result1;
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
                         double result = (changeMe * 1093.61);
                         string result1 = result.ToString();
                         return result1;
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
                         double result = (changeMe * 3280.84);
                         string result1 = result.ToString();
                         return result1;
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
               public static string ClientInput(AbstractHandler handler, string conversionType, double dummyValue)
               {
                    Console.WriteLine($"Client wants to convert {dummyValue} kilometers to {conversionType} \n");
                    object result = handler.Handle(conversionType, dummyValue);

                    if (result != null)
                    {
                         return ($"{result}");
                    }
                    else
                    {
                         return ($"{conversionType} was not utilized.\n");
                    }
               }
          }

          public abstract class Decorator : AbstractHandler
          {
               protected AbstractHandler _handler;

               public Decorator(AbstractHandler handler)
               {
                    _handler = handler;
               }

               public override string Handle(string request, double changeMe)
               {
                    if (_handler != null)
                    {
                         return _handler.Handle(request, changeMe);
                    }
                    else
                    {
                         return string.Empty;
                    }
               }
          }

          public class roundedDecorator : Decorator
          {
               public roundedDecorator(AbstractHandler handler) : base(handler)
               {
               }

               public override string Handle(string request, double changeMe)
               {
                    return $"roundedDecorator({base.Handle(request, changeMe)})";
               }
          }

          public class exponentDecorator : Decorator
          {
               public exponentDecorator(AbstractHandler handler) : base(handler)
               {
               }

               public override string Handle(string request, double changeMe)
               {
                    return $"exponentDecorator({base.Handle(request, changeMe)})";
               }
          }

          public class addUnitNameDecorator : Decorator
          {
               public addUnitNameDecorator(AbstractHandler handler) : base(handler)
               {
               }

               public override string Handle(string request, double changeMe)
               {
                    return $"addUnitNameDecorator({base.Handle(request, changeMe)})";

               }
          }

          private void label1_Click(object sender, EventArgs e)
          {
          }

          private void button1_Click(object sender, EventArgs e)
          {
               textBox2.Text = string.Empty;
               double input = double.Parse(textBox1.Text); // get user input kilometers
               string text = comboBox1.GetItemText(comboBox1.SelectedItem); //get item the user selects in the combo box

               //Create the chain links
               KilometersToMiles miles = new KilometersToMiles();
               KilometersToYards yards = new KilometersToYards();
               KilometersToFeet feet = new KilometersToFeet();

               miles.SetNextObject(yards).SetNextObject(feet);
               string finalResult = ClientRequest.ClientInput(miles, text, input);
               textBox2.AppendText(finalResult);



          }

          private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
          {

          }

          private void textBox1_TextChanged(object sender, EventArgs e)
          {

          }

          private void textBox2_TextChanged(object sender, EventArgs e)
          {

          }
     }
}
