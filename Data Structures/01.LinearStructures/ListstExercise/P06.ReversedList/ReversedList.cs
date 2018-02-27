using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class ReversedList<T> : IEnumerable<T>
    {
        private T[] arr;

        public int Count { get; private set; }
        public int Capacity { get; private set; }

        public ReversedList(int capacity = 2)
        {
            this.Capacity = capacity;
            this.Count = 0;
            this.arr = new T[this.Capacity];
        }

        public T this[int index]
        {
            get
            {
                Array.Reverse(arr);
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return this.arr[index];
            }

            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.arr[index] = value;
            }
        }

        public void Add(T item)
        {
            if (this.Count + 1 >= this.Capacity)
            {
                this.Grow();
            }
            this.arr[this.Count] = item;
            this.Count++;
        }

        public T RemoveAt(int index)
        {
            T item = this[index];
            this[index] = default(T);
            this.ShiftLeft(index);
            this.Count--;
            return item;
        }

        private void Grow()
        {
            T[] newArr = new T[this.Capacity * 2];
            this.Capacity = newArr.Length;
            this.arr.CopyTo(newArr, 0);
            this.arr = newArr;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < this.Count; i++)
            {
                this.arr[i] = this.arr[i + 1];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in arr.Reverse())
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

