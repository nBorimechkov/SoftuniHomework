using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ListyIterator<T> : IEnumerable<T>
{
    private int currentIndex = 0;
    private List<T> list;

    public ListyIterator(List<T> list)
    {
        this.list = list;
    }
    public ListyIterator()
    {

    }

    public bool Move()
    {
        if (currentIndex < list.Count - 1)
        {
            currentIndex++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool HasNext()
    {
        if (currentIndex == list.Count - 1)
        {           
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Print()
    {
        if (list.Count == 0)
        {
            Console.WriteLine("Invalid operation!");
        }
        else
        {
            Console.WriteLine(list[currentIndex]);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

