using System.Net.Sockets;
namespace AdvancedDynamicServer.model.Server;

public class BaseData
{
    public static void Splitdata(string data, TcpClient clientAddress)
    {
        //防止粘包
        string[] datalist = data.Split("\r\n");
        //删除最后一位空值
        Array.Resize(ref datalist, datalist.Length - 1);
        foreach (var item in datalist)
        {
            string[] itemlist = item.Split(":");
            Server.Command(itemlist, item, clientAddress);
        }
        
    }
}