using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P01.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            var parking = new SortedSet<string>();
            string current = "";
            while (current != "END")
            {
                current = Console.ReadLine();
                string[] inputs = Regex.Split(current, ", ");

                if (inputs[0] == "END")
                {
                    break;
                }

                if (inputs[0] == "IN")
                {
                    parking.Add(inputs[1]);
                }
                else
                {
                    parking.Remove(inputs[1]);
                }
            }
            if (parking.Count > 0)
            {
                foreach (var car in parking)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }

            Console.ReadLine();
        }
    }
}
