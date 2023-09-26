// See https://aka.ms/new-console-template for more information
using Akhmetov_253502_Lab1.Collections;
using Akhmetov_253502_Lab1;
using Akhmetov_253502_Lab1.Entities;

try
{
 var journal = new Journal();
 var gek = new GIES<Services, Client>();
 


 gek.Notify += journal.add_event;
 
 
 
 
 
 gek.show_clients();
 Console.WriteLine(gek.Show_Sum("Bogdan"));
 Console.WriteLine(gek.Sum_Of_All());
 Console.WriteLine(gek.Count_Of_Clients("water"));
 journal.get_events();
}
catch(Exception e){
 Console.WriteLine("где-то была ошибочка");

}
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


 