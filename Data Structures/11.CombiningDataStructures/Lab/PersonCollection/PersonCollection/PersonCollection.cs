using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private Dictionary<string, Person> byEmail = new Dictionary<string, Person>();

    private Dictionary<string, SortedDictionary<string, Person>> byDomain = 
        new Dictionary<string, SortedDictionary<string, Person>>();

    private Dictionary<string, SortedDictionary<string, Person>> byNameAndTown =
       new Dictionary<string, SortedDictionary<string, Person>>();

    private OrderedDictionary<int, SortedDictionary<string, Person>> byAge =
      new OrderedDictionary<int, SortedDictionary<string, Person>>();

    private Dictionary<string, OrderedDictionary<int, SortedDictionary<string, Person>>> byTownAndAge =
        new Dictionary<string, OrderedDictionary<int, SortedDictionary<string, Person>>>();

    public bool AddPerson(string email, string name, int age, string town)
    {
        Person person = new Person(email, name, age, town);
        if (byEmail.ContainsKey(email))
        {
            return false;
        }
        this.byEmail.Add(email, person);
        this.AddByDomain(email, person);
        this.AddByNameAndTown(person);
        this.AddByAge(person);
        this.AddByTownAndAge(person);
        return true;
    }

    private void AddByTownAndAge(Person person)
    {
        string town = person.Town;
        int age = person.Age;

        if (!this.byTownAndAge.ContainsKey(town))
        {
            this.byTownAndAge[town] = new OrderedDictionary<int, SortedDictionary<string, Person>>();
        }

        if (!this.byTownAndAge[town].ContainsKey(age))
        {
            this.byTownAndAge[town][age] = new SortedDictionary<string, Person>();
        }

        this.byTownAndAge[town][age].Add(person.Email, person);
    }

    private void AddByAge(Person person)
    {
        int age = person.Age;

        if (!this.byAge.ContainsKey(age))
        {
            this.byAge[age] = new SortedDictionary<string, Person>();
        }
        this.byAge[age].Add(person.Email, person);
    }

    private void AddByNameAndTown(Person person)
    {
        string key = person.Town + " " + person.Name;

        if (!this.byNameAndTown.ContainsKey(key))
        {
            this.byNameAndTown[key] = new SortedDictionary<string, Person>();
        }
        this.byNameAndTown[key].Add(person.Email, person);
    }

    private void AddByDomain(string email, Person person)
    {
        string domain = email.Split('@')[1];
        if (!this.byDomain.ContainsKey(domain))
        {
            this.byDomain[domain] = new SortedDictionary<string, Person>();
        }
        this.byDomain[domain].Add(email, person);
    }

    public int Count
    {
        get
        {
            return byEmail.Count;
        }
    }

    public Person FindPerson(string email)
    {
        if (!byEmail.Keys.Contains(email))
        {
            return null;
        }
        return this.byEmail[email];
    }

    public bool DeletePerson(string email)
    {
        if (!byEmail.ContainsKey(email))
        {
            return false;
        }
        string domain = email.Split('@')[1];
        string townName = this.byEmail[email].Town + " " + this.byEmail[email].Name;
        string town = this.byEmail[email].Town;
        int age = this.byEmail[email].Age;


        this.byEmail.Remove(email);
        this.byDomain[domain].Remove(email);
        this.byNameAndTown[townName].Remove(email);
        this.byAge[age].Remove(email);
        this.byTownAndAge[town][age].Remove(email);
        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        if (!byDomain.ContainsKey(emailDomain))
        {
            return new Person[] { };
        }
        return byDomain[emailDomain].Values;
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        string key = town + " " + name;

        if (!byNameAndTown.ContainsKey(key))
        {
            return new Person[] { };
        }
        return byNameAndTown[key].Values;
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
       var result = this.byAge.Range(startAge, true, endAge, true);

        foreach (var item in result)
        {
            foreach (var subItem in item.Value)
            {
                yield return subItem.Value;
            }
        }
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
    {
        if (this.byTownAndAge.ContainsKey(town))
        {
            var result = this.byTownAndAge[town].Range(startAge, true, endAge, true);
            foreach (var item in result)
            {
                foreach (var subItem in item.Value)
                {
                    yield return subItem.Value;
                }
            }
        }
        else
        {
            var result = new OrderedDictionary<int, SortedDictionary<string, Person>>();
        }
    }
}
