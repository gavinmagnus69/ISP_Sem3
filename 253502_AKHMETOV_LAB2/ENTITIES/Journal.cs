namespace Akhmetov_253502_Lab1.Entities;
using Akhmetov_253502_Lab1.Collections;

public class Journal
{
    private MyList<string> list;
    public Journal() => list = new MyList<string>();
    public void add_event(string s) => list.Add(s);

    public void get_events()
    {
        foreach (var s in list)
        {
            Console.WriteLine(s);
            
        }
        
        
    }


}