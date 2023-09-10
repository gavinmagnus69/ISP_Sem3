namespace Akhmetov_253502_Lab1.Entities;
using Akhmetov_253502_Lab1.Contracts;
using Akhmetov_253502_Lab1.Collections;
public class Client
{
    public string name = "";
    public MyList<Services> services;
    public Client() {
        name = "";
        services = new MyList<Services>();
    }
    public Client(string name) {
        this.name = name;
        services = new MyList<Services>();
    }
    public void add_service(Services serv) {
        services.Add(serv);
    }
    public int sum_services() {
        int accum = 0;
        if (services.Count() == 1)
        {
            return services[0].obj;
        }
        for (int i = 0; i < services.Count(); ++i)
        {
            if (i != 0)
            {
                accum += services[i] + services[i - 1];
            }

           
        }
        return accum;
    
    
    
    
    
    }



}