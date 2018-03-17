using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomList<T> : ICustomList<T>, IEnumerable
    where T : IComparable<T>
{
    private readonly IList<T> list;

    public IList<T> Elements
    {
        get
        {
            return list;
        }
    }

    public CustomList() : this(Enumerable.Empty<T>())
    {
    }

    public CustomList(IEnumerable<T> collection)
    {
        this.list = new List<T>(collection);
    }

    public void Add(T element)
    {
        this.list.Add(element);
    }

    public void Print()
    {
        foreach (var item in this.list)
        {
            Console.WriteLine(item);
        }
    }

    public bool Contains(T element)
    {
        return this.list.Contains(element);
    }

    public int CountGreaterThan(T element)
    {
        int counter = 0;
        foreach (var item in this.list)
        {
            int result = item.CompareTo(element) > 0 ? 1 : -1;
            if (result > 0)
            {
                counter++;
            }
        }
        return counter;
    }

    public T Max()
    {
        return this.list.Max(el => el);
    }

    public T Min()
    {
        return this.list.Min(el => el);
    }

    public T Remove(int index)
    {
        T temp = this.list[index];
        this.list.RemoveAt(index);
        return temp;
    }

    public void Swap(int index1, int index2)
    {
        T current = this.list[index1];
        this.list[index1] = this.list[index2];
        this.list[index2] = current;
    }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
