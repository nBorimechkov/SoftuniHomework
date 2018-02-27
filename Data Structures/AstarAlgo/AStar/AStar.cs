using System;
using System.Collections.Generic;

public class AStar
{
    char[,] Map;

    public AStar(char[,] map)
    {
        this.Map = map;
    }

    public static int GetH(Node current, Node goal)
    {
        int deltaX = Math.Abs(current.Col - goal.Col);
        int deltaY = Math.Abs(current.Row - goal.Row);

        return deltaX + deltaY;
    }

    public IEnumerable<Node> GetPath(Node start, Node goal)
    {
        List<Node> path = new List<Node>();
        PriorityQueue<Node> open = new PriorityQueue<Node>();
        Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
        Dictionary<Node, int> costSoFar = new Dictionary<Node, int>();
        open.Enqueue(start);
        cameFrom[start] = null;
        costSoFar[start] = 0;

        while (open.Count > 0)
        {
            Node current = open.Dequeue();
            if (current.Equals(goal))
            {
                break;
            }
            foreach (var neighbour in current.GetNeighbours(Map))
            {
                int cost = costSoFar[current] + 1;
                if (!costSoFar.ContainsKey(neighbour) || cost < costSoFar[neighbour])
                {
                    costSoFar[neighbour] = cost;
                    neighbour.F = cost + GetH(neighbour, goal);
                    open.Enqueue(neighbour);
                    cameFrom[neighbour] = current;
                }
            }              
        }
        if (!cameFrom.ContainsKey(goal))
        {
            path.Add(start);
        }
        else
        {
            path.Add(goal);
            Node pathPiece = cameFrom[goal];
            while (true)
            {
                path.Add(pathPiece);
                pathPiece = cameFrom[pathPiece];
                if (pathPiece.Equals(start))
                {
                    break;
                }
            }
            path.Add(start);
        }

        path.Reverse();
        return path;
    }
}

