using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Organization : IOrganization
{
    private IList<Person> people = new List<Person>();
    private IDictionary<string, List<Person>> byName = new Dictionary<string, List<Person>>();
    private IDictionary<int, List<Person>> byNameLength = new Dictionary<int, List<Person>>();

    public IEnumerator<Person> GetEnumerator()
    {
        foreach (var person in people)
        {
            yield return person;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public int Count
    {
        get
        {
            return this.people.Count;
        }
    }

    public bool Contains(Person person)
    {
        return this.byName.ContainsKey(person.Name);
    }

    public bool ContainsByName(string name)
    {
        return this.byName.ContainsKey(name);
    }

    public void Add(Person person)
    {
        this.people.Add(person);

        if (!this.byName.ContainsKey(person.Name))
        {
            this.byName.Add(person.Name, new List<Person>());
        }
        this.byName[person.Name].Add(person);

        int nameLength = person.Name.Length;
        if (!this.byNameLength.ContainsKey(nameLength))
        {
            this.byNameLength.Add(nameLength, new List<Person>());
        }
        this.byNameLength[nameLength].Add(person);
    }

    public Person GetAtIndex(int index)
    {
        if (index >= this.people.Count)
        {
            throw new IndexOutOfRangeException();
        }
        return this.people[index];
    }

    public IEnumerable<Person> GetByName(string name)
    {
        return this.byName[name];
    }

    public IEnumerable<Person> FirstByInsertOrder(int count = 1)
    {
        return this.people.Take(count);
    }

    public IEnumerable<Person> SearchWithNameSize(int minLength, int maxLength)
    {
        List<Person> result = new List<Person>();
        for (int key = minLength + 1; key < maxLength; key++)
        {
            foreach (var person in this.byNameLength[key])
            {
                result.Add(person);
            }
        }
        return result;
    }

    public IEnumerable<Person> GetWithNameSize(int length)
    {
        if (!this.byNameLength.ContainsKey(length))
        {
            throw new ArgumentException();
        }
        return this.byNameLength[length];
    }

    public IEnumerable<Person> PeopleByInsertOrder()
    {
        return this.people.Take(people.Count);
    }
}