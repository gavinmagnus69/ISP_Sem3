using Akhmetov_253502_Lab1.Entities;

namespace _253502_AKHMETOV_LAB1;

public static class Starup
{
    public  static void SetupData(GIES<Services, Client> gek)
    {
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
    }
}