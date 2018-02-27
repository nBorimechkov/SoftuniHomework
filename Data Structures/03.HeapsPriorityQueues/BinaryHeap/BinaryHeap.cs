using System;
using System.Collections.Generic;

public class BinaryHeap<T> where T : IComparable<T>
{
    private List<T> heap;

    public BinaryHeap()
    {
        this.heap = new List<T>();
    }

    public int Count
    {
        get
        {
            return this.heap.Count;
        }
    }

    public void Insert(T item)
    {
        this.heap.Add(item);
        this.HeapifyUp(this.heap.Count - 1);
    }

    //possibly broken
    public void DecreaseKey(T element)
    {
        int elementIndex = heap.IndexOf(element);
        int parentIndex = (elementIndex - 1) / 2;
        while (parentIndex < elementIndex)
        {
            Swap(elementIndex, parentIndex);
            elementIndex = heap.IndexOf(element);
            parentIndex = (elementIndex - 1) / 2;
        }
        
    }

    //recursive HeapifyUp
    private void HeapifyUp(int childIndex)
    {
        int parentIndex = (childIndex - 1) / 2;

        int compare = this.heap[parentIndex].CompareTo(this.heap[childIndex]);

        if (compare < 0)
        {
            this.Swap(parentIndex, childIndex);
            this.HeapifyUp(parentIndex);
        }
        else
        {
            return;
        }
    }

    //recursive HeapifyDown for Pull/Dequeue
    private void HeapifyDown(int parentIndex)
    {
        if (parentIndex >= this.Count / 2)
        {
            return;
        }

        int childIndex = (2 * parentIndex) + 1;

        if (HasGreaterRightChild(childIndex))
        {
            childIndex = childIndex + 1;
            this.Swap(parentIndex, childIndex);
            this.HeapifyDown(childIndex);
        }
        if (this.heap[parentIndex].CompareTo(this.heap[childIndex]) < 0)
        {
            this.Swap(parentIndex, childIndex);
            this.HeapifyDown(childIndex);
        }

    }

    public void Swap(int parentIndex, int childIndex)
    {
        T temp = this.heap[parentIndex];
        this.heap[parentIndex] = this.heap[childIndex];
        this.heap[childIndex] = temp;
    }

    public T Peek()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        return this.heap[0];
    }

    public T Pull()
    {
        if (this.Count <= 0)
        {
            throw new InvalidOperationException();
        }
        else
        {
            T element = this.heap[0];
            this.Swap(0, this.Count - 1);
            this.heap.RemoveAt(this.Count - 1);
            this.HeapifyDown(0);
            return element;
        }
    }

    private bool HasGreaterRightChild(int childIndex) 
    {
        if (this.Count <= 2)
        {
            return false;
        }
        else if ((childIndex + 1) < this.Count && this.heap[childIndex].CompareTo(this.heap[childIndex + 1]) < 0)
        {
            return true;
        }
        return false;
    }
}
