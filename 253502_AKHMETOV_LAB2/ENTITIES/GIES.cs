//namespace Akhmetov_253502_Lab1.Entities;

using System.Collections;
using Akhmetov_253502_Lab1.Contracts;
using Akhmetov_253502_Lab1.Collections;using Akhmetov_253502_Lab1.Entities;
public class GIES<Serv, Cli> : IGIES<Serv, Cli> where Serv : Services where Cli : Client/*, IEnumerable<Serv>*/
{



    //public delegate void add_tarif_delegate(string s);

    public event Action<string>? Notify;
    private MyList<Serv> services;
    private MyList<Cli> clients;
    public GIES() { 
        services = new MyList<Serv>();
        clients = new MyList<Cli>();
    }

    public void show_clients()
    {
        for (int i = 0; i < clients.Count(); ++i)
        {
            Console.WriteLine(clients[i].name);
            
            
        }


    }

    public void Add_Tarif(Serv obj) { 
        services.Add(obj);
        Notify?.Invoke("new tarif added");
    }
    public void Add_Client_Info(Cli obj) {
        clients.Add(obj);
        Notify?.Invoke("new client added");
    }
    public int Show_Sum(string name)
    {
        for(int i = 0; i < clients.Count(); ++i)
        {
            Console.WriteLine(clients[i].name);
            if (name == clients[i].name)
            {
                
                return clients[i].sum_services();
            }
        }



        throw new Exception("no user was found");

    }

    public int Sum_Of_All()
    {
        int ans = 0;
        for (int i = 0; i < clients.Count(); ++i)
        {
            ans += clients[i].sum_services();
        }

        return ans;
    }

    public int Count_Of_Clients(string name_of_service)
    {
        int cnt = 0;
        for (int i = 0; i < clients.Count(); ++i)
        {
            for (int j = 0; j < clients[i].services.Count(); ++j)
            {
                if (name_of_service == clients[i].services[j].name)
                {
                    ++cnt;
                    break;
                }
            }
        }

        return cnt;




    }
    
    /*public IEnumerator<Services> GetEnumerator()
    {
        return new IServiceEnumerator(services);
    }

    // Must also implement IEnumerable.GetEnumerator, but implement as a private method.
    private IEnumerator GetEnumerator1()
    {
        return this.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator1();
    }*/
    
    

}