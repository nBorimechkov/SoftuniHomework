using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedQueue<T>
{
    public int Count { get; private set; }

    private QueueNode<T> head;
    private QueueNode<T> tail;

    private class QueueNode<T>
    {
        public T Value { get; private set; }

        public QueueNode<T> NextNode { get; set; }
        public QueueNode<T> PrevNode { get; set; }

        public QueueNode(T value)
        {
            this.Value = value;
        }
    }

    public void Enqueue(T item)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new QueueNode<T>(item);
        }
        else
        {
            QueueNode<T> newTail = new QueueNode<T>(item);
            newTail.PrevNode = this.tail;
            this.tail.NextNode = newTail;
            this.tail = newTail;
        }
        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        T element = this.head.Value;
        if (this.Count == 1)
        {
            this.head = null;
            this.tail = null;
        }
        else
        {
            this.head = this.head.NextNode;
            this.head.PrevNode = null;
        }
        this.Count--;
        return element;
    }



    public T[] ToArray()
    {
        List<T> list = new List<T>();

        QueueNode<T> current = this.head;
        while (current != null)
        {
            list.Add(current.Value);
            current = current.NextNode;
        }
        return list.ToArray();
    }
}