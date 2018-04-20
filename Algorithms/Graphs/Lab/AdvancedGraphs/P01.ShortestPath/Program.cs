using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.ShortestPath
{
    class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> pairs;
        private static List<string> children;
        private static HashSet<string> visited;

        static void Main(string[] args)
        {
            graph = new Dictionary<string, List<string>>();
            pairs = new Dictionary<string, int>();
            children = new List<string>();
            visited = new HashSet<string>();

            graph = ReadGraph();
            FindShortestPath();
            PrintShortestPaths();
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            int numberOfEdges = int.Parse(Console.ReadLine());
            int numberOfPairs = int.Parse(Console.ReadLine());

           
            

            for (int i = 0; i < numberOfEdges; i++)
            {
                string[] inputLine = Console.ReadLine().Split(':');
                string parent = inputLine[0];

                if (inputLine.Length > 1)
                {
                    children = inputLine[1].Split(' ').ToList();
                }

                if (!graph.ContainsKey(parent))
                {
                    graph.Add(parent, children);
                }
                else
                {
                    graph[parent] = children;
                }
            }

            for (int i = 0; i < numberOfPairs; i++)
            {
                string pair = Console.ReadLine();
                pairs.Add(pair, Int32.MaxValue);
            }

            return graph;
        }

        private static void FindShortestPath()
        {
            var pairsList = new List<string>(pairs.Keys);
            foreach (var pair in pairsList)
            {
                int shortestPath = 0;
                string[] pairElements = pair.Split('-');
                string startNode = pairElements[0];
                string endNode = pairElements[1];
                BFS(startNode, startNode, endNode, shortestPath);
            }
        }

        private static void BFS(string startNode, string currentNode, string endNode, int pathLength)
        {
            // mark current node to be visited
            visited.Add(currentNode);
            if (currentNode == "")
            {
                return;
            }
            string pair = startNode + "-" + endNode;

            // check if any of the children of the current node is the endNode, the one we're looking for
            foreach (var child in graph[currentNode])
            {
                if (child == endNode)
                {
                    pathLength++;
                    if (pathLength < pairs[pair])
                    {
                        pairs[pair] = pathLength;
                    }
                }
                else
                {
                    pathLength++;
                }

                // if we don't find the endNode in the current's children, 
                // recursively check the children of any unvisited child
                if (!visited.Contains(child))
                {
                    BFS(startNode, child, endNode, pathLength);
                }
                // as we go back any given path (after the recursion), decrease current path's length 
                // and mark child as unvisited
                pathLength--;
                visited.Remove(child);
            }
            return;
        }

        private static void PrintShortestPaths()
        {
            foreach (var pair in pairs)
            {
                string[] splitPair = pair.Key.Split('-');
                string startNode = splitPair[0];
                string endNode = splitPair[1];

                if (pair.Value == 0 || pair.Value == Int32.MaxValue)
                {
                    Console.WriteLine($"{{{startNode}, {endNode}}} -> {-1}");
                }
                else
                {
                    Console.WriteLine($"{{{startNode}, {endNode}}} -> {pair.Value}");
                }
            }
        }
    }
}
