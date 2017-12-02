using System;

public class Robot : IAnthropomorphicEntity
{
    private string id;
    private string model;

    public Robot(string id, string model)
    {
        this.id = id;
        this.model = model;
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
}

