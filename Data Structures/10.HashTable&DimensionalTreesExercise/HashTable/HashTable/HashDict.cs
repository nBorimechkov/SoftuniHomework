using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace HashTable
{
    public class HashDict<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        private LinkedList<KeyValue<TKey, TValue>>[] slots;
        private const int InititalCapacity = 16;
        private const float LoadFactor = 0.75f;

        public int Count { get; private set; }

        public int Capacity
        {
            get
            {
                return this.slots.Length;
            }
        }

        public HashDict(int capacity = InititalCapacity)
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
            this.Count = 0;
        }

        public void Add(TKey key, TValue value)
        {
            GrowIfNeeded();
            int index = FindSlotIndex(key);
            if (this.slots[index] == null)
            {
                this.slots[index] = new LinkedList<KeyValue<TKey, TValue>>();
            }
            foreach (var element in this.slots[index])
            {
                if (element.Key.Equals(key))
                {
                    throw new ArgumentException("Key already exists : " + key);
                }
            }
            var newElement = new KeyValue<TKey, TValue>(key, value);
            this.slots[index].AddLast(newElement);
            this.Count++;
        }

        public bool AddOrReplace(TKey key, TValue value)
        {
            this.GrowIfNeeded();
            int index = this.FindSlotIndex(key);
            if (this.slots[index] == null)
            {
                this.slots[index] = new LinkedList<KeyValue<TKey, TValue>>();
            }
            foreach (var element in this.slots[index])
            {
                if (element.Key.Equals(key))
                {
                    element.Value = value;
                    return false;
                }
            }
            var newElement = new KeyValue<TKey, TValue>(key, value);
            this.slots[index].AddLast(newElement);
            this.Count++;
            return true;
        }

        public TValue Get(TKey key)
        {
            var element = this.Find(key);

            if (element == null)
            {
                throw new KeyNotFoundException();
            }
            return element.Value;
        }

        public TValue this[TKey key]
        {
            get
            {
                var value = this.Get(key);
                if (value != null)
                {
                    return value;
                }
                throw new KeyNotFoundException();
            }
            set
            {
                this.AddOrReplace(key, value);
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var element = this.Find(key);
            value = element.Value;

            return element != null ? true : false;
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            int index = this.FindSlotIndex(key);
            var elements = this.slots[index];
            if (elements != null)
            {
                foreach (var element in elements)
                {
                    if (element.Key.Equals(key))
                    {
                        return element;
                    }
                }
            }
            return null;
        }

        public bool ContainsKey(TKey key)
        {
            return this.Find(key) != null ? true : false;
        }

        public bool Remove(TKey key)
        {
            if (this.ContainsKey(key))
            {
                int keyIndex = this.FindSlotIndex(key);
                var element = this.Find(key);
                foreach (var item in this.slots[keyIndex])
                {
                    if (item.Key.Equals(key))
                    {
                        this.slots[keyIndex].Remove(item);
                        this.Count--;
                        return true;
                    }
                }
            }
            return false;
        }

        public void Clear()
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[this.Capacity];
            this.Count = 0;
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                return this.Select(x => x.Key);
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                return this.Select(x => x.Value);
            }
        }

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            foreach (var elements in this.slots)
            {
                if (elements != null)
                {
                    foreach (var element in elements)
                    {
                        yield return element;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void GrowIfNeeded()
        {
            if ((float)(this.Count + 1) / this.Capacity > LoadFactor)
            {

                this.Grow();
            }
        }

        private void Grow()
        {
            var newSlots = new HashDict<TKey, TValue>(this.Capacity * 2);
            foreach (var item in this)
            {
                newSlots.Add(item.Key, item.Value);
            }
            this.slots = newSlots.slots;
            this.Count = newSlots.Count;
        }

        private int FindSlotIndex(TKey key)
        {
            int index = Math.Abs(key.GetHashCode()) % this.slots.Length;
            return index;
        }
    }
}