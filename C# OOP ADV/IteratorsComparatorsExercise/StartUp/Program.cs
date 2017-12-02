using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        string inputLine;
        ListyIterator<string> list = new ListyIterator<string>();
        while ((inputLine = Console.ReadLine()) != "END")
        {
            var tokens = inputLine.Split(' ').ToList();
            switch (tokens[0])
            {
                case "Create":
                    tokens.RemoveAt(0);
                    list = new ListyIterator<string>(tokens);
                    break;
                case "Move":
                    Console.WriteLine(list.Move());
                    break;
                case "HasNext":
                    Console.WriteLine(list.HasNext());
                    break;
                case "Print":
                    list.Print();
                    break;
            }
        }
    }
}

