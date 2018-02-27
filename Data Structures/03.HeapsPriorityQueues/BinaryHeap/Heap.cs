using System;
using System.Collections;

public static class Heap<T> where T : IComparable<T>
{
    public static void Sort(T[] arr)
    {
        int n = arr.Length;

        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(arr, n, i);

        for (int i = n - 1; i >= 0; i--)
        {
            Swap(arr, i, 0);

            Heapify(arr, i, 0);
        }
    }

    public static void Heapify(T[] arr, int border, int i)
    {
        int largest = i;
        int l = 2 * i + 1;
        int r = 2 * i + 2;

        if (l < border && arr[l].CompareTo(arr[largest]) > 0)
            largest = l;

        if (r < border && arr[r].CompareTo(arr[largest]) > 0)
            largest = r;

        if (largest != i)
        {
            Swap(arr, i, largest);

            Heapify(arr, border, largest);
        }
    }

    //private static void Heapify(int[] arr, int index)
    //{
    //    int max = index;
    //    int leftChild = 2 * index + 1;
    //    int rightChild = 2 * index + 2;

    //    if (leftChild < arr.Length && (arr[leftChild] > arr[max]))
    //    {
    //        max = leftChild;
    //    }

    //    if (rightChild < arr.Length && (arr[rightChild] > arr[max]))
    //    {
    //        max = rightChild;
    //    }

    //    if (max != index)
    //    {
    //        Swap(arr, index, max);
    //        Heapify(arr, max);
    //    }
    //}
    //private static void Down(T[] arr, int current, int border)
    //{
    //    while (current < border / 2)
    //    {
    //        int leftChild = (2 * current) + 1;
    //        int rightChild = (2 * current) + 2;
    //        int greaterChild;

    //        int compare = arr[leftChild].CompareTo(arr[rightChild]);

    //        greaterChild = compare > 0 ? leftChild : rightChild;

    //        if (arr[current].CompareTo(arr[greaterChild]) > 0)
    //        {
    //            return;
    //        }

    //        Swap(arr, current, greaterChild);
    //        current = greaterChild;
    //    }
    //}

    //private static void HeapifyDown(T[] arr, int parentIndex)
    //{
    //    int childIndex = (2 * parentIndex) + 1;

    //    if (HasGreaterRightChild(arr, childIndex))
    //    {
    //        childIndex = childIndex + 1;
    //        Swap(arr, parentIndex, childIndex);
    //        HeapifyDown(arr, childIndex);
    //    }
    //    if (arr[parentIndex].CompareTo(arr[childIndex]) < 0)
    //    {
    //        Swap(arr, parentIndex, childIndex);
    //        HeapifyDown(arr, childIndex);
    //    }
    //}

    //private static void HeapifyUp(T[]arr, int childIndex)
    //{
    //    int parentIndex = (childIndex - 1) / 2;

    //    int compare = arr[parentIndex].CompareTo(arr[childIndex]);

    //    if (compare < 0)
    //    {
    //        Swap(arr, parentIndex, childIndex);
    //        HeapifyUp(arr, parentIndex);
    //    }
    //    else
    //    {
    //        return;
    //    }
    //}

    //private static bool HasGreaterRightChild(T[] arr, int childIndex)
    //{
    //    if (arr.Length <= 2)
    //    {
    //        return false;
    //    }
    //    else if ((childIndex + 1) < arr.Length && arr[childIndex].CompareTo(arr[childIndex + 1]) < 0)
    //    {
    //        return true;
    //    }
    //    return false;
    //}

    public static void Swap(T[] arr, int parentIndex, int childIndex)
    {
        T temp = arr[parentIndex];
        arr[parentIndex] = arr[childIndex];
        arr[childIndex] = temp;
    }

}
