namespace Akhmetov_253502_Lab1.Entities;
using Akhmetov_253502_Lab1.Contracts;
public class Client
{
    public string name = "";
    public List<Services> services;
    //public event Action<string>? ev; 
    public Client() {
        name = "";
        services = new List<Services>();
    }
    public Client(string name) {
        this.name = name;
        services = new List<Services>();
        //ev += s => Console.WriteLine(s);
    }

    public void add_service(Services serv)
    {
        services.Add(serv);
    }

    public int sum_services() {
        int accum = 0;
        /*if (services.Count() == 1)
        {
            return services[0].obj;
        }
        for (int i = 0; i < services.Count(); ++i)
        {
            if (i != 0)
            {
                accum += services[i] + services[i - 1];
            }
        }*/
        var sum = from i in services select i.obj;
        foreach (var i in sum)
        {
            accum += i;
        }
        return accum;
    
    
    
    
    
    }



}