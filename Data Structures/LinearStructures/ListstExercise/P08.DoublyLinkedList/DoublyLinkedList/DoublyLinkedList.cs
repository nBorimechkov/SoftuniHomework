using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    public int Count { get; private set; }

    private class ListNode<T>
    {
        public T Value { get; private set; }

        public ListNode<T> Next { get; set; }

        public ListNode<T> Prev { get; set; }

        public ListNode(T value)
        {
            this.Value = value;
        }
    }

    private ListNode<T> head;
    private ListNode<T> tail;

    public void AddFirst(T item)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new ListNode<T>(item);
        }
        else
        {
            ListNode<T> newHead = new ListNode<T>(item);
            newHead.Next = this.head;
            this.head.Prev = newHead;
            this.head = newHead;
        }
        this.Count++;
    }

    public void AddLast(T item)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new ListNode<T>(item);
        }
        else
        {
            ListNode<T> newTail = new ListNode<T>(item);
            newTail.Prev = this.tail;
            this.tail.Next = newTail;
            this.tail = newTail;
        }
        this.Count++;
    }

    public T RemoveFirst()
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
            this.head = this.head.Next;
            this.tail.Prev = null;
        }
        this.Count--;
        return element;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        T element = this.tail.Value;
        if (this.Count == 1)
        {
            this.head = null;
            this.tail = null;
        }
        else
        {
            this.tail = this.tail.Prev;
            this.tail.Next = null;
        }
        this.Count--;
        return element;
    }

    public void ForEach(Action<T> action)
    {
        ListNode<T> current = this.head;
        while (current != null)
        {
            action(current.Value);
            current = current.Next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        ListNode<T> current = this.head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        T[] arr = new T[this.Count];
        List<T> list = new List<T>();
        this.ForEach(list.Add);
        arr = list.ToArray();
        return arr;
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
