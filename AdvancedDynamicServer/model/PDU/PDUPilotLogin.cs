using System.Net.Sockets;
using AdvancedDynamicServer.Network;
namespace AdvancedDynamicServer.model.PDU;

public class PDUPilotLogin
{
    public static void PilotLogin(string[] tokens, string rawData, TcpClient clientAddress)
    {
        string userId = tokens[2];
        string userPassword = tokens[3];
        string level = tokens[4];
        string callsign = tokens[0].Substring(3);
        //通过userid获取NetworkServer.user的key
        string password = NetworkServer.user[userId].Item1;
        string userlevel = NetworkServer.user[userId].Item2;
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
                    PilotLogin(tokens, clientAddress);
                }
                else
                {
                    //权限不足
                    NetworkServer.SendMsgnative("The rating is too high", clientAddress);

                }
            }else
            {
                NetworkServer.SendMsgnative("The password is wrong", clientAddress);
            }
        }
    }
    static void PilotLogin(string[] tokens, TcpClient clientAddress)
    {
        NetworkServer.newClients.Add(tokens[0].Substring(3), clientAddress);
        AddPilot(tokens);
        PDUTextmessage.ServerTextmessage(tokens[0].Substring(3), "Welcome to SKYline Dynamic Flight Server .NET8 edition version 1.0");

    }
    private static void AddPilot(string[] tokens)
    {
        string callsign = tokens[0].Substring(3);
        string logonTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        PilotInfos.PilotInfo pilotInfo = new PilotInfos.PilotInfo();
        pilotInfo.Callsign = callsign;
        pilotInfo.LogonTime = logonTime;
        pilotInfo.Name = tokens[tokens.Length - 1];
        pilotInfo.Visualrange = 40;
        pilotInfo.Server = "SKYline Dynamic Flight Server .NET8 edition version 1.0";
        NetworkServer.pilotUser.Add(callsign, pilotInfo);
    }
}