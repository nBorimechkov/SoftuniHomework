using System;

public class Rebel : IBuyer
{
    private string name;
    private int age;
    private string group;
    private int food = 0;

    public Rebel(string name, int age, string group)
    {
        this.name = name;
        this.age = age;
        this.group = group;
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

    public string Group
    {
        get { return group; }
        set { group = value; }
    }

    public int Food
    {
        get
        {
            return this.food;
        }
        set { food = value; }
    }

    public void BuyFood()
    {
        this.Food += 5;
    }
}

