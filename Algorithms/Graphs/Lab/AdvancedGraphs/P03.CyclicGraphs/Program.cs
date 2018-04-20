using System;
using System.Collections.Generic;

namespace P03.CyclicGraphs
{
    class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited = new HashSet<string>();

        static void Main(string[] args)
        {
            graph = ReadGraph();
            visited = new HashSet<string>();

            Console.WriteLine(IsCyclic() ? "Acyclic: No" : "Acyclic: Yes");
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            string input = string.Empty;
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine().Trim()) != "")
            {

                string[] nodes = input.Split('-');
                if (nodes.Length < 2)
                {
                    break;
                }
                string node = nodes[0];
                string child = nodes[1];

                if (graph.ContainsKey(node))
                {
                    graph[node].Add(child);
                }
                else
                {
                    graph.Add(node, new List<string>());
                    graph[node].Add(child);
                }
            }

            return graph;
        }

        static bool IsCyclic()
        {
            foreach (var node in graph.Keys)
            {
                visited.Add(node);

                foreach (var child in graph[node])
                {
                    if (visited.Contains(child))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
