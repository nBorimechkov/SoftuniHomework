using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = string.Empty;
            string name = string.Empty;
            string price = string.Empty;
            string producer = string.Empty;
            ShoppingCenter center = new ShoppingCenter();

            for (int line = 0; line < n; line++)
            {
                input = Console.ReadLine();
                List<string> arguments = input.Split(' ').ToList();
                string command = arguments[0];
                arguments.RemoveAt(0);
                string data = string.Join(" ", arguments);


                switch (command)
                {
                    case "AddProduct":
                        string[] argsToPass = data.Split(';');
                        center.Add(argsToPass[0], argsToPass[1], argsToPass[2]);
                        break;
                    case "FindProductsByName":
                        center.FindProductsByName(data);
                        break;
                    case "FindProductsByProducer":
                        center.FindProductsByProducer(data);
                        break;
                    case "DeleteProducts":
                        argsToPass = data.Split(';');
                        if (argsToPass.Length == 1)
                        {
                            center.DeleteProducts(argsToPass[0]);
                        }
                        else
                        {
                            center.DeleteProducts(argsToPass[0], argsToPass[1]);
                        }
                        break;
                    case "FindProductsByPriceRange":
                        argsToPass = data.Split(';');
                        center.FindProductsByPriceRange(argsToPass[0], argsToPass[1]);
                        break;
                }
            }

            Console.ReadLine();
        }
    }
}
