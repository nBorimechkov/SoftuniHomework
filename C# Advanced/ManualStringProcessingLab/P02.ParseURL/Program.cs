using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.ParseURL
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = Console.ReadLine();
            int protocolIndex = url.IndexOf("://");
            string protocol = "";
            string serverAndResources = "";

            if (protocolIndex != -1)
            {
                protocol = url.Substring(0, protocolIndex);
                serverAndResources = url.Substring(protocolIndex + 3);
                if (serverAndResources.Contains("://"))
                {
                    Console.WriteLine("Invalid URL");
                }
                else
                {
                    string server = serverAndResources.Substring(0, serverAndResources.IndexOf("/"));
                    string resource = serverAndResources.Substring(serverAndResources.IndexOf("/") + 1);
                    Console.WriteLine(protocol);
                    Console.WriteLine(server);
                    Console.WriteLine(resource);
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid URL");
            }
        }
    }
}
