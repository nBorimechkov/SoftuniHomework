using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{
    private Node root;

    public BinarySearchTree()
    {
        this.root = null;
    }

    private BinarySearchTree(Node node)
    {
        this.Copy(node);
    }

    private void Copy(Node node)
    {
        if (node == null)
        {
            return;
        }

        this.Insert(node.Value);
        this.Copy(node.Left);
        this.Copy(node.Right);
    }

    private class Node
    {
        public Node(T value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }

        public T Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }


    public void Insert(T value)
    {
        this.root = this.Insert(this.root, value);
    }
      
    private Node Insert(Node node, T value)
    {
        if (node == null)
        {
            return new Node(value);
        }

        int compare = node.Value.CompareTo(value);
        if (compare > 0)
        {
            node.Left = this.Insert(node.Left, value);
        }

        if (compare < 0)
        {
            node.Right = this.Insert(node.Right, value);
        }

        return node;
    }


    public bool Contains(T value)
    {
        Node current = this.root;

        while (current != null)
        {
            int compare = current.Value.CompareTo(value);

            if (compare > 0)
            {
                // current.Value > value
                current = current.Left;
            }
            else if (compare < 0)
            {
                // current.Value < value
                current = current.Right;
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    public void DeleteMin()
    {
        if (this.root == null)
        {
            return;
        }
        else if ((this.root.Left == null && this.root.Right == null))
        {
            this.root = null;
            return;
        }

        Node parent = null;
        Node current = this.root;

        while (current.Left != null)
        {
            parent = current;
            current = current.Left;
        }

        if (current.Right != null)
        {
            parent.Left = current.Right;
        }
        else
        {
            parent.Left = null;
        }
    }

    public BinarySearchTree<T> Search(T item)
    {
        Node current = this.root;

        while (current != null)
        {
            int compare = current.Value.CompareTo(item);

            if (compare > 0)
            {
                // current.Value > value
                current = current.Left;
            }
            else if (compare < 0)
            {
                // current.Value < value
                current = current.Right;
            }
            else
            {
                return new BinarySearchTree<T>(current);
            }
        }

        return new BinarySearchTree<T>();
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        IList<T> result = new List<T>();

        this.Range(this.root, result, startRange, endRange);

        return result;
    }

    private void Range(Node node, IList<T> result, T startRange, T endRange)
    {
        if (node == null)
        {
            return;
        }

        int compareLow = node.Value.CompareTo(startRange);
        int compareHigh = node.Value.CompareTo(endRange);

        if (compareLow >= 0 && compareHigh <= 0)
        {

        }
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    private void EachInOrder(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Value);
        this.EachInOrder(node.Right, action);
    }
}

public class Launcher
{
    public static void Main(string[] args)
    {
        
    }
}
