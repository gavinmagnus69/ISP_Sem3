//namespace Akhmetov_253502_Lab1.Entities;

using System.Diagnostics.CodeAnalysis;
using Akhmetov_253502_Lab1.Contracts;
using Akhmetov_253502_Lab1.Entities;
public class GIES<Serv, Cli> : IGIES<Serv, Cli> where Serv : Services where Cli : Client/*, IEnumerable<Serv>*/
{
    
    public event Action<string>? Notify;
    public event Action<string>? NotifyClient; 
    private Dictionary<string , Serv> services = new();
    private List<Cli> clients = new();

    public void show_clients()
    {
        for (int i = 0; i < clients.Count(); ++i)
        {
            Console.WriteLine(clients[i].name);
            
            
        }


    }

    public void Add_Tarif(Serv obj)
    {
        services[obj.name] = obj;
        Notify?.Invoke("new tarif added successfully");
    }

    public void Add_Client_Tarif(string client_name, string service_name)
    {
        if (!services.ContainsKey(service_name))
        {
            throw new Exception("no such tarif");
        }

        bool chk = false;
        
        foreach (var i in clients)
        {
            if (i.name == client_name)
            {
                //Console.WriteLine("true case");
                chk = true;
                i.add_service(services[service_name]);
            }
        }
        if (!chk)
        {
            throw new Exception("no such client");
        }
        

        NotifyClient?.Invoke("tarif added to client successfully");
    }



    public void Add_Client_Info(Cli obj) {
        clients.Add(obj);
        Notify?.Invoke("new client added");
    }
    
    
    public int Show_Sum(string name)
    {
       
        var clsum = from i in clients where i.name == name select i.sum_services();
        foreach (var i in clsum)
        {
            return i;
        }


        throw new Exception("no user was found");

    }

    public int Sum_Of_All()
    {
        int ans = 0;
        var accum = from i in clients select i.sum_services();
        foreach (var i in accum)
        {
            ans += i;
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

    public void Give_All_Services()
    {
        var s = from str in services orderby str.Value.obj select str;
        List<Services> ans = new List<Services>();
        foreach (var i in s)
        {
            ans.Add(i.Value);
        }
        Console.WriteLine();
        foreach (var i in ans)
        {
            Console.WriteLine("Serivce - {0}, price = {1}",i.name, i.obj );
            
        }
    }

    public string Get_Top()
    {
        var col = from i in clients orderby i.sum_services() select i;
        return col.Last().name;
    }

    public int Higher_than(int sum)
    {
        var ans = clients.Aggregate(0, (x, y) =>
        {
            if (y.sum_services() >= sum)
            {
                ++x;
            }
            return x;
        });
        
        return ans;

    }

    public void List_of_sum()
    {
        
            var ans = from cli in clients group cli by cli.services;
            foreach (var beb in ans)
            {

                foreach (var dad in beb)
                {
                    Console.WriteLine(dad.name);
                }
                foreach (var g in beb.Key)
                {
                    Console.WriteLine("{0} costs {1}", g.name, g.obj);
                }
                
                
                
                
                
                
            }

           
           

         
        
        
        
        
    }






}