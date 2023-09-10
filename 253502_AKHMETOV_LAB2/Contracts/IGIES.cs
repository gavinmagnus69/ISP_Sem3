namespace Akhmetov_253502_Lab1.Contracts;
using Akhmetov_253502_Lab1.Entities;

public interface IGIES<Services, Client> 
{
    void Add_Tarif(Services obj);
    void Add_Client_Info(Client obj);
    int Show_Sum(string name);
    int Sum_Of_All();
    int Count_Of_Clients(string name_of_service);

}