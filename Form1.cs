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

               // Method for executing a request (conversion type)
               string Handle(string request, double convertToNewMetric);
          }

          // Handler Abstract Class
          public abstract class AbstractHandler : IHandlerInterface
          {
               protected IHandlerInterface nextObject;

               //Set next objects in chain of responsibility (COR)
               public IHandlerInterface SetNextObject(IHandlerInterface handler)
               {
                    nextObject = handler;
                    return handler;
               }

               // Pass through all in COR
               public virtual string Handle(string request, double convertToNewMetric)
               {
                    if (nextObject != null)
                    {
                         return nextObject.Handle(request, convertToNewMetric);
                    }
                    else
                    {
                         return null;
                    }
               }
          }

          // Concrete Handler 1
          // Convert from kilometers to miles
          private class KilometersToMiles : AbstractHandler
          {
               public override string Handle(string request, double convertToNewMetric)
               {
                    if ((request as string) == "miles")
                    {
                         var output = (convertToNewMetric / 1.609).ToString();
                         return output;
                    }
                    else
                    {
                         return base.Handle(request, convertToNewMetric);
                    }
               }
          }

          // Concrete Handler 2
          // Convert from kilometers to yards
          private class KilometersToYards : AbstractHandler
          {
               public override string Handle(string request, double convertToNewMetric)
               {
                    if ((request as string) == "yards")
                    {
                         var output = (convertToNewMetric * 1093.61).ToString();
                         return output;
                    }
                    else
                    {
                         return base.Handle(request, convertToNewMetric);
                    }
               }
          }

          // Concrete Handler 3
          // Convert from kilometers to feet
          private class KilometersToFeet : AbstractHandler
          {
               public override string Handle(string request, double convertToNewMetric)
               {
                    if ((request as string) == "feet")
                    {
                         var output = (convertToNewMetric * 3280.84).ToString();
                         return output;
                    }
                    else
                    {
                         return base.Handle(request, convertToNewMetric);
                    }
               }
          }

          // Decorator Abstract Class
          // Extends AbstractHandler class to be interchangeable with
          // its concrete decorators
          public abstract class Decorator : AbstractHandler
          {
               public abstract override string Handle(string request, double convertToNewMetric);
          }

          // Concrete Decorator 1
          // Round output to 2nd decimal (e.g., 218.723 to 218.72)
          public class Rounded2DecimalPlaces : Decorator
          {
               private AbstractHandler handler;

               public Rounded2DecimalPlaces()
               {
               }

               public Rounded2DecimalPlaces(AbstractHandler handler)
               {
                    this.handler = handler;
               }

               public override string Handle(string request, double convertToNewMetric)
               {
                    string token = handler.Handle(request, convertToNewMetric).ToString();
                    decimal newToken = decimal.Parse(token);
                    string output = newToken.ToString("F2");
                    return output;
               }
          }

          // Concrete Decorator 2
          // Write output in exp.notation(e.g., 218.72 to 2.1872e2 )
          public class ExpNotation : Decorator
          {
               private AbstractHandler handler;

               public ExpNotation()
               {
               }

               public ExpNotation(AbstractHandler handler)
               {
                    this.handler = handler;
               }

               public override string Handle(string request, double convertToNewMetric)
               {
                    string token = handler.Handle(request, convertToNewMetric).ToString();
                    decimal newToken = decimal.Parse(token);
                    string output = newToken.ToString("#0.0e0");
                    return output;
               }
          }

          // Concrete Decorator 3
          // Add the unit name to the converted amount (e.g., 2.1872e2 to 2.1872e2 Yards)
          public class AddUnitName : Decorator
          {
               private AbstractHandler handler;

               public AddUnitName()
               {
               }

               public AddUnitName(AbstractHandler handler)
               {
                    this.handler = handler;
               }

               public override string Handle(string request, double convertToNewMetric)
               {
                    string token = handler.Handle(request, convertToNewMetric).ToString();
                    return token + " " + request;
               }
          }

          // Client
          public class ClientRequest
          {
               public static string ClientInput(AbstractHandler handler, string conversionType, double userInput)
               {
                    //Console.WriteLine($"Client wants to convert {userInput} kilometers to {conversionType} \n");
                    object result = handler.Handle(conversionType, userInput);

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
          
          // Label1 on the GUI that states the metric type: kilometers
          private void label1_Click(object sender, EventArgs e)
          {
          }

          // Convert button on the GUI
          private void button1_Click(object sender, EventArgs e)
          {
               textBox2.Text = string.Empty; // clear textbox2
               double input = double.Parse(textBox1.Text); // get user input kilometers
               string text = comboBox1.GetItemText(comboBox1.SelectedItem); //get item the user selects in the combo box

               //Create the chain links
               AbstractHandler miles = new KilometersToMiles();
               AbstractHandler yards = new KilometersToYards();
               AbstractHandler feet = new KilometersToFeet();
               miles.SetNextObject(yards).SetNextObject(feet);

               //string finalResult = ClientRequest.ClientInput(miles, text, input); //no decorators, only chain of responsibility
               //textBox2.AppendText(finalResult); //output to textbox

               miles = new Rounded2DecimalPlaces(miles); //add decorator 1
               miles = new ExpNotation(miles); //add decorator 2
               miles = new AddUnitName(miles); //add decorator 3
               string finalResult = ClientRequest.ClientInput(miles, text, input); //all three decorators
               textBox2.AppendText(finalResult); //output to textbox
          }

          // Combobox on GUI: {miles, yards, feet}
          private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
          {

          }

          // Textbox1 on the GUI that accepts user input
          private void textBox1_TextChanged(object sender, EventArgs e)
          {

          }

          // Textbox2 on the GUI that displays the conversion result
          private void textBox2_TextChanged(object sender, EventArgs e)
          {

          }
     }
}
