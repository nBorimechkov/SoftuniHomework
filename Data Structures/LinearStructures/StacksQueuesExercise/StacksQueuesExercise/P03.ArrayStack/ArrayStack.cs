using System;

class ArrayStack<T>
{
    private T[] elements;
    private const int DefaultCapacity = 16;
    public int Count { get; private set; }

    public ArrayStack(int capacity = DefaultCapacity)
    {
        this.elements = new T[capacity];
        this.Count = 0;
    }

    public void Push(T element)
    {
        if (this.Count == this.elements.Length)
        {
            this.Grow();
        }
        this.elements[this.Count] = element;
        this.Count++;
    }

    // Should throw InvalidOperationException if the queue is empty
    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        this.Count--;
        return this.elements[this.Count];
    }

    private void Grow()
    {
        T[] newArr = new T[this.elements.Length * 2];
        this.CopyAllElements(newArr);
        this.elements = newArr;
    }

    private void CopyAllElements(T[] newArr)
    {
        for (int i = 0; i < this.Count; i++)
        {
            newArr[i] = this.elements[i];
        }
    }

    public T[] ToArray()
    {
        T[] newArr = new T[this.Count];
        this.CopyAllElements(newArr);
        return newArr;
    }
}

