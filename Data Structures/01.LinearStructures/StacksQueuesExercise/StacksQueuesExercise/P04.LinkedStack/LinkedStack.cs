using System;
using System.Collections.Generic;

public class LinkedStack<T>
{
    private Node<T> firstNode;
    public int Count { get; private set; }

    public void Push(T element)
    {
        this.firstNode = new Node<T>(element, this.firstNode);
        this.Count++;
    }
    public T Pop()
    {
        if (this.firstNode == null)
        {
            throw new InvalidOperationException();
        }
        T element = firstNode.value;
        firstNode = firstNode.NextNode;
        this.Count--;
        return element;
        
    }

    private class Node<T>
    {
        public T value;
        public Node<T> NextNode { get; set; }
        public Node(T value, Node<T> nextNode = null)
        {
            this.value = value;
            this.NextNode = nextNode;
        }
    }

    public T[] ToArray()
    {
        List<T> list = new List<T>();
        list.Add(firstNode.value);
        Node<T> current = this.firstNode.NextNode;
        while (current != null)
        {
            list.Add(current.value);
            current = current.NextNode;
        }
        return list.ToArray();
    }
}