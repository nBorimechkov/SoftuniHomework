using System;
using System.Collections.Generic;

public class Node : IComparable<Node>
{
    public Node(int row, int col)
    {
        this.Row = row;
        this.Col = col;
    }

    public int Row { get; set; }
    public int Col { get; set; }
    public int F { get; set; }

    public IEnumerable<Node> GetNeighbours(char[,] map)
    {
        List<Node> neighbours = new List<Node>();

        List<Node> candidates = new List<Node>()
        {
            new Node(this.Row + 1, this.Col),
            new Node(this.Row - 1, this.Col),
            new Node(this.Row, this.Col + 1),
            new Node(this.Row, this.Col - 1)
        };

        foreach (var item in candidates)
        {
            if (withinBounds(map, item))
            {
                neighbours.Add(item);
            }
        }
        return neighbours;
    }

    public bool withinBounds(char[,] map, Node node)
    {
        int mapX = map.GetLength(0);
        int mapY = map.GetLength(1);
        if ((node.Col >= 0 && node.Col < mapY) && (node.Row >= 0 && node.Row < mapX))
        {
            if (map[node.Row, node.Col] != 'W')
            {
                return true;
            }
        }
        return false;
    }

    public int CompareTo(Node other)
    {
        return this.F.CompareTo(other.F);
    }

    public override bool Equals(object obj)
    {
        var other = (Node)obj;
        return this.Col == other.Col && this.Row == other.Row;
    }

    public override int GetHashCode()
    {
        var hash = 17;
        hash = 31 * hash + this.Row.GetHashCode();
        hash = 31 * hash + this.Col.GetHashCode();
        return hash;
    }

    public override string ToString()
    {
        return this.Row + " " + this.Col;
    }
}
