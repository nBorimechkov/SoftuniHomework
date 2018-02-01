using System;

public class CircularQueue<T> { 

    private T[] array;
    private const int DefaultCapacity = 4;
    private int head;

    public int Capacity { get; private set; }

    public int Count { get; private set; }

    public CircularQueue(int capacity = DefaultCapacity)
    {
        this.Capacity = capacity;
        this.head = 0;
        this.array = new T[this.Capacity];
        this.Count = 0;
    }

    public void Enqueue(T element)
    {
        if (this.Count >= this.Capacity)
        {
            this.Resize();
        }
        int index = this.Count % this.Capacity;
        this.array[index] = element;
        this.Count++;
    }

    // Should throw InvalidOperationException if the queue is empty
    public T Dequeue()
    {
        if (this.Count== 0)
        {
            throw new InvalidOperationException();
        }
        T element = this.array[this.head];
        this.head = (this.head + 1) % this.Capacity;
        this.Count--;
        return element;
    }

    private void Resize()
    {
        T[] newArr = new T[this.Capacity * 2];
        this.Capacity = newArr.Length;
        this.CopyAllElements(newArr);
        this.array = newArr;
    }

    private void CopyAllElements(T[] newArray)
    {
        int current = 0;
        for (int i = this.head; i < this.Count; i++)
        {
            current = (i + this.head) % this.Capacity;
            newArray[current] = this.array[i];
        }
    }

    public T[] ToArray()
    {
        T[] newArray = new T[this.Count];
        this.CopyAllElements(newArray);
        return newArray;
    }
}


public class Example
{
    public static void Main()
    {

        CircularQueue<int> queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        int first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}
