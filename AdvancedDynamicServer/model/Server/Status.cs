using AdvancedDynamicServer.model.Sql;
using AdvancedDynamicServer.Network;
namespace AdvancedDynamicServer.model.Server;

public class Status
{
    public static void Refresh()
    {
        //循环打印Network.Server的oldClients
        while (true)
        {
            User.Userinfo();
<<<<<<< HEAD
            foreach (var client in NetworkServer.atcUser)
            {
                Console.WriteLine(client.Key);
                //打印结构体内的数据
                Console.WriteLine(client.Value.Callsign);
                Console.WriteLine(client.Value.Latitude);
                Console.WriteLine(client.Value.Longitude);
                Console.WriteLine(client.Value.Visualrange);
                Console.WriteLine(client.Value.Facility);
                Console.WriteLine(client.Value.Frequency);
                Console.WriteLine(client.Value.Name);
                Console.WriteLine(client.Value.Cid);
                Console.WriteLine(client.Value.Rating);
                Console.WriteLine(client.Value.Server);
                Console.WriteLine(client.Value.TextAtis);
                Console.WriteLine(client.Value.LogonTime);
                
            }
=======
>>>>>>> 7332b56 (完成ATC登陆)
            Thread.Sleep(10000);
        }
    }
}