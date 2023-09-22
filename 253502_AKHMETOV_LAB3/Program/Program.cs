// See https://aka.ms/new-console-template for more information
using Akhmetov_253502_Lab1.Entities;

 var journal = new Journal();
 var gek = new GIES<Services, Client>();


 gek.Notify += journal.add_event;
 gek.NotifyClient += (string s) => Console.WriteLine(s); 
 
 gek.Add_Client_Info(new Client("Roma"));
 gek.Add_Client_Info(new Client("Nikita"));
 gek.Add_Client_Info(new Client("Vadim"));
 gek.Add_Tarif(new Services("electricity", 500) );
 gek.Add_Tarif(new Services("water", 250));
 gek.Add_Tarif(new Services("gas", 300));
 gek.Add_Client_Tarif("Roma", "water");
 gek.Add_Client_Tarif("Nikita", "water");
 gek.Add_Client_Tarif("Vadim", "water");
 gek.Add_Client_Tarif("Nikita", "gas");
 gek.Give_All_Services();
 //Console.WriteLine(gek.Higher_than(500));
 gek.List_of_sum();
 //journal.get_events();

/*MyList<int> l = new MyList<int>();
l.Add(3);
l.Add(5);
l.Add(6);
l.Add(7);
l.Add(8);
foreach (var i in l)
{
 Console.WriteLine(i);
}*/


 