using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        Console.ReadLine();
        string input = Console.ReadLine();
        List<IBuyer> entities = new List<IBuyer>();
        List<string> buyers = new List<string>();
        int food = 0;

        while (input != "End")
        {
            string[] arguments = input.Split(' ');
            if (arguments.Length == 4)
            {
                Person citizen = new Person(arguments[0], int.Parse(arguments[1]), arguments[2], arguments[3]);
                entities.Add(citizen);
            }
            else if (arguments.Length == 3)
            {
                Rebel rebel = new Rebel(arguments[0], int.Parse(arguments[1]), arguments[2]);
                entities.Add(rebel);
            }
            else if (arguments.Length == 1)
            {
                foreach (var entity in entities)
                {
                    if ((entity.Name == arguments[0]) && entity.GetType() == typeof(Person))
                    {
                        entity.Food += 10;
                    }
                    else if ((entity.Name == arguments[0]) && entity.GetType() == typeof(Rebel))
                    {
                        entity.Food += 5;
                    }
                }
            }
            input = Console.ReadLine();
        }

        foreach (var entity in entities)
        {
            food += entity.Food;
        }

        Console.WriteLine(food);
        Console.ReadLine();
    }
}

