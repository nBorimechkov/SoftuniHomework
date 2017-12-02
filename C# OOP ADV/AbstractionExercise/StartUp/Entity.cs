using System;
using System.Collections.Generic;

public class Entity : IAnthropomorphicEntity
{
    private string name;
    private string model;
    private int age;
    private string id;
    private string birthdate;

    public Entity(string model, string id)
    {
        this.model = model;
        this.id = id;
    }
    public Entity(string name, int age, string id, string birthdate)
    {
        this.name = name;
        this.age = age;
        this.id = id;
        this.birthdate = birthdate;
    }

    public int Age
    {
        get { return age; }
        private set { age = value; }
    }


    public string Model
    {
        get { return model; }
        private set { model = value; }
    }


    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public string Id
    {
        get { return id; }
        private set { name = value; }
    }

    public string Birthdate
    {
        get { return id; }
        private set { name = value; }
    }
}

