using System;
public interface ICustomList<T>
{
    void Add(T element);
    T Remove(int index);
    bool Contains(T element);
    void Swap(int index1, int index2);
    int CountGreaterThan(T element);
    void Print();
    T Max();
    T Min();
}
