using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, bool> tester = CreateTester(condition, age);


            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);

            PrintFilteredStudent(people, tester, printer);
        }

        public static Func<int, bool> CreateTester






(string condition, int age)


        {


            switch (condition)


            {


                case "younger": return x => x < age;


                case "older": return x => x > age;


                default: return null;


            }


        }

        public static Action<KeyValuePair<string, int>>


CreatePrinter(string format)


        {


            switch (format)


case "name":


                return person => Console.WriteLine($"{person.Key}");


            case "age":


                return person => Console.WriteLine($"{person.Value}");


            case "name age":


                return person =>


                Console.WriteLine($"{person.Key} – {person.Value}");


            default: return null;


            }


            Check your
    }
}
