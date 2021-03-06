﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P09.UserLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new SortedDictionary<string, Dictionary<string, int>>();
            string line = Console.ReadLine();

            while (line != "end")
            {
                var messageTokens = line
                    .Split(' ');

                var ip = messageTokens[0].Replace("IP=", "");
                var username = messageTokens[2].Replace("user=", "");

                if (users.ContainsKey(username))
                {
                    if (users[username].ContainsKey(ip))
                    {
                        users[username][ip] += 1;
                    }
                    else
                    {
                        users[username][ip] = 1;
                    }
                }
                else
                {
                    users[username] = new Dictionary<string, int>() { { ip, 1 } };
                }
                line = Console.ReadLine();
                Console.WriteLine($"{ip}, {username}");
            }

            PrintUsersAndIps(users);
            Console.ReadLine();
        }

        private static void PrintUsersAndIps(SortedDictionary<string, Dictionary<string, int>> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key}:");
                Console.WriteLine("{0}.", string.Join(", ", user.Value.Select(a => $"{a.Key} => {a.Value}")));
            }
        }
    }
}
