// See https://aka.ms/new-console-template for more information
using Akhmetov_253502_Lab1.Collections;
using Akhmetov_253502_Lab1.Entities;

 /*var gek = new GIES<Services, Client>();
 var serv1 = new Services("gas", 100);
 var serv2 = new Services("electricity", 200);
 var serv3 = new Services("water", 50);
gek.Add_Tarif(serv1);
gek.Add_Tarif(serv2);
gek.Add_Tarif(serv3);
 var client1 = new Client("Ivan");
 var client2 = new Client("Bogdan");
 var client3 = new Client("Vitaly");
client1.add_service(serv1);
client2.add_service(serv2);
client3.add_service(serv3);
 gek.Add_Client_Info(client1);
 gek.Add_Client_Info(client2);
 gek.Add_Client_Info(client3);
 gek.show_clients();
 Console.WriteLine(gek.Show_Sum("Bogdan"));
Console.WriteLine(gek.Sum_Of_All());
Console.WriteLine(gek.Count_Of_Clients("water"));*/
MyList<int> l = new MyList<int>();
l.Add(3);
l.Add(5);
l.Add(6);
l.Add(7);
l.Add(8);
foreach (var i in l)
{
 Console.WriteLine(i);
}


 