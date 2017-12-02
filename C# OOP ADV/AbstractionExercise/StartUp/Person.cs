using System;

public class Person : IAnthropomorphicEntity, IBiologicalEntity, IBuyer
{
    private string name;
    private int  age;
    private string id;
    private string birthdate;
    private int food = 0;

    public Person(string name, int age, string id, string birthdate)
    {
        this.name = name;
        this.age = age;
        this.id = id;
        this.birthdate = birthdate;
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }


    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Birthdate
    {
        get { return birthdate; }
        set { birthdate = value; }
    }

    public int Food {
        get
        {
            return this.food;
        }
        set { food = value; } }

    public void BuyFood()
    {
        this.Food += 10;
    }
}


