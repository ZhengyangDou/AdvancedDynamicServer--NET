using System.Net.Sockets;
using AdvancedDynamicServer.Network;
using AdvancedDynamicServer.model.PDU;
<<<<<<< HEAD
using AdvancedDynamicServer.model;
=======
>>>>>>> 7332b56 (完成ATC登陆)


namespace AdvancedDynamicServer.model.PDU;

public class PDUATCLogin
{
    public static void ATCLogin(string[] tokens, string rawData, TcpClient clientAddress)
    {
<<<<<<< HEAD
=======
        Console.WriteLine("ATCLogin");
>>>>>>> 7332b56 (完成ATC登陆)
        string userId = tokens[3];
        string userPassword = tokens[4];
        string level = tokens[5];
        string callsign = tokens[0].Substring(3);
        string[] splitCallsign = callsign.Split('_');
        //通过userid获取NetworkServer.user的key
        string password = NetworkServer.user[userId].Item1;
        string userlevel = NetworkServer.user[userId].Item2;
<<<<<<< HEAD
=======
        Console.WriteLine(password);
        Console.WriteLine(userlevel);
>>>>>>> 7332b56 (完成ATC登陆)
        //先检测password是否为空
        if (password != "" && userlevel != "")
        {
            //检测password是否正确
            if (password == userPassword)
            {
                //检测level是小于或等于
                if (int.Parse(level) <= int.Parse(userlevel))
                {
                    //通过检测
                    AtcLogin(tokens, clientAddress);
                }
                else
                {
<<<<<<< HEAD
                    //权限不足
                    NetworkServer.SendMsgnative("The rating is too high", clientAddress);

                }
            }else
            {
                NetworkServer.SendMsgnative("The password is wrong", clientAddress);
=======


                }
            }
            else
            {
                //密码错误
>>>>>>> 7332b56 (完成ATC登陆)
            }
        }
    }

<<<<<<< HEAD
    private static void AtcLogin(string[] tokens,TcpClient clientAddress)
    {
        NetworkServer.newClients.Add(tokens[0].Substring(3), clientAddress);
        AddAtcInfo(tokens);
        PDUTextmessage.ServerTextmessage(tokens[0].Substring(3), "Welcome to SKYline Dynamic Flight Server .NET8 edition version 1.0");
        ControllersPdu(tokens);
    }

    private static void ControllersPdu(string[] tokens)
    {
        string server = "";
        string callsign = tokens[0].Substring(3);
        if (tokens[5] == "1")
        {
            server = "server";
        }
        else
        {
            server = "SERVER";
        }
        string pdu = $"""
                      $CR{server}:{callsign}:ATC:Y:{callsign}
                      $CR{server}:{callsign}:CAPS:ATCINFO=1:ICAOEQ=1:FASTPOS=1
                      $CR{server}:{callsign}:IP:{NetworkServer.newClients[callsign].Client.RemoteEndPoint}
                      """;
        NetworkServer.SendMsg(pdu,callsign);
    }

    private static void AddAtcInfo(string[] tokens)
    {
        string callsign = tokens[0].Substring(3);
        string frequency = "199.998";
        int rating = int.Parse(tokens[5]);
        string server = "SKYline Dynamic Flight Server .NET8 edition version 1.0";
        int visualrange = int.Parse(tokens[tokens.Length - 1]);
        string[] textAtis = new string[1];
        string logonTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        int facilitytype = 0;
        double latitude = 0;
        double longitude = 0;
        AtcInfo.Atcuser callsigns;
        callsigns.Callsign = callsign;
        callsigns.Cid = tokens[3];
        callsigns.Name = tokens[2];
        callsigns.Frequency = frequency;
        callsigns.Facility = facilitytype;
        callsigns.Latitude = latitude;
        callsigns.Longitude = longitude;
        callsigns.Rating = rating;
        callsigns.Server = server;
        callsigns.Visualrange = visualrange;
        callsigns.TextAtis = textAtis;
        callsigns.LogonTime = logonTime;
        NetworkServer.atcUser.Add(callsign, callsigns);
=======
    static void AtcLogin(string[] tokens,TcpClient clientAddress)
    {
        NetworkServer.newClients.Add(tokens[0].Substring(3), clientAddress);
        PDUTextmessage.ServerTextmessage(tokens[0].Substring(3), "Welcome to SKYline Dynamic Flight Server .NET8 edition version 1.0");

>>>>>>> 7332b56 (完成ATC登陆)
        
    }
}