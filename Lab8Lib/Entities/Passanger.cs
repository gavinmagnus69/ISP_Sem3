namespace Lab8Lib;

public class Passanger
{
    public int id = new();
    public string name = "";
    public bool luggage = false;

    public Passanger(int id, string name, bool lug)
    {
        this.id = id;
        this.name = name;
        this.luggage = lug;
    }

    public Passanger()
    {
    }
}