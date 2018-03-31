using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class LimitedMemoryCollection<K, V> : ILimitedMemoryCollection<K, V>
{
    private List<Pair<K, V>> list = new List<Pair<K, V>>();
    private Queue<Pair<K, V>> queue = new Queue<Pair<K, V>>();

    public int Capacity { get; set; }

    public int Count
    {
        get
        {
            return this.list.Count;
        }
    }

    public LimitedMemoryCollection(int capacity)
    {
        this.Capacity = capacity;
    }

    public V Get(K key)
    {
        Pair<K, V> pair = list.First(x => x.Key.Equals(key));
        queue.Enqueue(pair);
        if (queue.Peek().Equals(pair))
        {
            queue.Dequeue();
        }
        return pair.Value;
    }


    public void Set(K key, V value)
    {
        Pair<K, V> pair = new Pair<K, V>(key, value);
        if (this.list.Count < this.Capacity)
        {
            this.queue.Enqueue(pair);
            list.Add(pair);
        }
        else
        {
            Pair<K, V> toRemove = queue.Dequeue();
            while (queue.Contains(toRemove))
            {
                queue.Dequeue();
            }
            this.list.Remove(toRemove);
            this.list.Add(pair);
            queue.Enqueue(pair);
        }
    }

    public IEnumerator<Pair<K, V>> GetEnumerator()
    {
        foreach (var item in this.queue)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

