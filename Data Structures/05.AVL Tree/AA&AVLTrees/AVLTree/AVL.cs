using System;

public class AVL<T> where T : IComparable<T>
{
    private Node<T> root;

    public Node<T> Root
    {
        get
        {
            return this.root;
        }
    }

    public bool Contains(T item)
    {
        var node = this.Search(this.root, item);
        return node != null;
    }

    public void Insert(T item)
    {
        this.root = this.Insert(this.root, item);
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    private Node<T> Insert(Node<T> node, T item)
    {
        if (node == null)
        {
            return new Node<T>(item);
        }

        int cmp = item.CompareTo(node.Value);
        if (cmp < 0)
        {
            node.Left = this.Insert(node.Left, item);

        }
        else if (cmp > 0)
        {
            node.Right = this.Insert(node.Right, item);
        }

        // Balancing
        UpdateHeight(node);

        int balance = this.Height(node.Left) - this.Height(node.Right);

        //Left subtree is bigger
        if (balance > 1)
        {
            int childBalnace = this.Height(node.Left.Left) - this.Height(node.Left.Right);
            if (childBalnace < 0)
            {
                node.Left = this.RotateLeft(node.Left);
            }
            node = this.RotateRight(node);
        } // Right subtree is bigger
        else if (balance < -1)
        {
            int childBalance = this.Height(node.Right.Left) - this.Height(node.Right.Right);
            if (childBalance > 0)
            {
                node.Right = this.RotateRight(node.Right);
            }
            node = this.RotateLeft(node);
        }

        return node;
    }

    private int Height(Node<T> node)
    {
        if (node == null)
        {
            return 0;
        }
        return node.Height;
    }

    private void UpdateHeight(Node<T> node)
    {
        node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
    }

    private Node<T> RotateLeft(Node<T> node)
    {
        Node<T> newRoot = node.Right;
        node.Right = newRoot.Left;
        newRoot.Left = node;

        UpdateHeight(node);
        UpdateHeight(newRoot);

        return newRoot;
    }

    private Node<T> RotateRight(Node<T> node)
    {
        Node<T> newRoot = node.Left;
        node.Left = newRoot.Right;
        newRoot.Right = node;

        UpdateHeight(node);
        UpdateHeight(newRoot);

        return newRoot;
    }

    private Node<T> Balance(Node<T> node)
    {
        int balance = Height(node.Left) - (Height(node.Right));

        // left subtree is bigger
        if (balance > 1)
        {
            int childBalance = Height(node.Left.Left) - (Height(node.Left.Right));
            if (childBalance < 0)
            {
                node.Left = RotateLeft(node.Left);
            }
            node = RotateRight(node);
        }
        // right subtree is bigger
        else if (balance < -1)
        {
            int childBalance = Height(node.Right.Left) - (Height(node.Right.Right));
            if (childBalance > 0)
            {
                node.Right = RotateRight(node.Right);
            }
            node = RotateLeft(node);
        }

        return node;
    }

    private Node<T> Search(Node<T> node, T item)
    {
        if (node == null)
        {
            return null;
        }

        int cmp = item.CompareTo(node.Value);
        if (cmp < 0)
        {
            return Search(node.Left, item);
        }
        else if (cmp > 0)
        {
            return Search(node.Right, item);
        }

        return node;
    }

    private void EachInOrder(Node<T> node, Action<T> action)
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
