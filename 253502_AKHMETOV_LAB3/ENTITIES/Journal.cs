namespace Akhmetov_253502_Lab1.Entities;


public class Journal
{
    private List<string> list;
    public Journal() => list = new List<string>();
    public void add_event(string s) => list.Add(s);

    public void get_events()
    {
        foreach (var s in list)
        {
            Console.WriteLine(s);
            
        }
        
        
    }


}