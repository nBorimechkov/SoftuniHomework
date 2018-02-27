// Java program for implementation of Heap Sort
using System;

public class HeapSort
{
    static void printArray(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; ++i)
            System.Console.WriteLine(arr[i] + " ");
        System.Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        int[] arr = { 12, 11, 13, 5, 6, 7 };


        Heap<int>.Sort(arr);
        printArray(arr);
        Console.WriteLine();

        Console.ReadLine();
    }
}