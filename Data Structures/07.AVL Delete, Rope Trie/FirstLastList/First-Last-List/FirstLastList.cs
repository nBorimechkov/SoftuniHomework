using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class FirstLastList<T> : IFirstLastList<T> where T : IComparable<T>
{
    private LinkedList<T> byInsertion;
    private OrderedBag<T> byDefaultOrder;   

    public FirstLastList()
    {
        this.byInsertion = new LinkedList<T>();
        this.byDefaultOrder = new OrderedBag<T>();
    }

    public int Count
    {
        get
        {
            return byDefaultOrder.Count;
        }
    }

    public void Add(T element)
    {
        byInsertion.AddLast(element);
        byDefaultOrder.Add(element);
    }

    public void Clear()
    {
        this.byDefaultOrder.Clear();
        this.byInsertion.Clear();
    }

    public IEnumerable<T> First(int count)
    {
        if (!CountIsInBounds(count))
        {
            throw new ArgumentOutOfRangeException();
        }
        else
        {
            LinkedListNode<T> current = byInsertion.First;
            int counter = 0;
            while (counter < count)
            {
                yield return current.Value;
                current = current.Next;
                counter++;
            }   
        }
    }

    public IEnumerable<T> Last(int count)
    {
        if (!CountIsInBounds(count))
        {
            throw new ArgumentOutOfRangeException();
        }
        else
        {
            LinkedListNode<T> current = byInsertion.Last;
            int counter = 0;
            while (counter < count)
            {
                yield return current.Value;
                current = current.Previous;
                counter++;
            }
        }
    }

    public IEnumerable<T> Max(int count)
    {
        if (!CountIsInBounds(count))
        {
            throw new ArgumentOutOfRangeException();
        }

        return this.byDefaultOrder.Reversed().Take(count).Select(x => x);
    }

    public IEnumerable<T> Min(int count)
    {
        if (!CountIsInBounds(count))
        {
            throw new ArgumentOutOfRangeException();
        }

        return this.byDefaultOrder.Take(count).Select(x => x);
    }

    public int RemoveAll(T element)
    {
        while (this.byInsertion.Contains(element))
        {
            this.byInsertion.Remove(element);
        }
        return this.byDefaultOrder.RemoveAllCopies(element);
    }

    private bool CountIsInBounds(int count)
    {
        if (count <= this.Count)
        {
            return true;
        }
        return false;
    }
}
