
public class Pet : IBiologicalEntity
{
    private string birthdate;
    private string name;

    public Pet(string name, string birthdate)
    {
        this.name = name;
        this.birthdate = birthdate;
    }

    public string Birthdate
    {
        get { return birthdate; }
        private set { birthdate = value; }
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }
}

