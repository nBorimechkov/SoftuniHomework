using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;
    private Dictionary<string, bool> visited;
    private Stack<string> sorted;
    private HashSet<string> vertices;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
        this.visited = new Dictionary<string, bool>();
        this.sorted = new Stack<string>();
        this.vertices = new HashSet<string>();

        // had to manually set all nodes to be unvisited 
        // because I used a dictionary to track visited nodes
        foreach (var node in graph.Keys)
        {
            if (!visited.ContainsKey(node))
            {
                visited.Add(node, false);
            }
        }

        foreach (var node in graph.Values)
        {
            foreach (var child in node)
            {
                if (!visited.ContainsKey(child))
                {
                    visited.Add(child, false);
                }
            }
        }
    }

    public ICollection<string> TopSort()
    {
        foreach (var node in graph.Keys)
        {
            if (!visited[node])
            {
                TopSortUtil(node);
            }
        }

        return sorted.ToList();
    }

    // very much looks like DFS
    void TopSortUtil(string node)
    {
        visited[node] = true;

        if (graph.ContainsKey(node))
        {
            foreach (var child in graph[node])
            {
                // cycle detection
                if (vertices.Contains(child + node))
                {
                    throw new InvalidOperationException();
                }
                vertices.Add(node + child);
                vertices.Add(child + node);

                if (!visited[child])
                {
                    TopSortUtil(child);
                }
            }
        }

        sorted.Push(node);
    }
}
