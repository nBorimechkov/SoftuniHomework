using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ILimitedMemoryCollection<K, V> : IEnumerable<Pair<K, V>>
{
    int Capacity { get; }

    int Count { get; }

    void Set(K key, V value);

    V Get(K key);
}

