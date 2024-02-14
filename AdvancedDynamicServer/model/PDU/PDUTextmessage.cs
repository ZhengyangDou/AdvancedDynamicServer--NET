using AdvancedDynamicServer.Network;
<<<<<<< HEAD
=======

>>>>>>> 7332b56 (完成ATC登陆)
namespace AdvancedDynamicServer.model.PDU;

public class PDUTextmessage
{
    public static void ServerTextmessage(string callsign, string message)
    {
<<<<<<< HEAD
        string data = $"#TMSERVER:{callsign}:{message}";
        NetworkServer.SendMsg(data, callsign);
    }
    public class SendToAll
    {
        public static void sendTouser(string callsign, string message)
        {
            Senduser.SendUser sendMsgUser = new Senduser.SendUser();
            if (NetworkServer.atcUser.ContainsKey(callsign))
            {
                //获取发送者的用户信息
                AtcInfo.Atcuser atc = NetworkServer.atcUser[callsign];
                sendMsgUser.Callsign = atc.Callsign;
                sendMsgUser.Latitude = atc.Latitude;
                sendMsgUser.Longitude = atc.Longitude;
                sendMsgUser.Visualrange = atc.Visualrange;
            }
            Thread sendToUser = new Thread(() => sendToAtc(sendMsgUser, message));
            sendToUser.Start();
        }
        public static void sendToAtc(Senduser.SendUser sendMsgUser, string message)
        {
            foreach (var atcuser in NetworkServer.atcUser)
            {
                Console.WriteLine(atcuser.Key);
                NetworkServer.SendMsg(message, atcuser.Key);
            }
        }
    }
=======
        string data = $"#TMSERVER:{callsign}:{message}\r\n";
        NetworkServer.SendMsg(data, callsign);
    }
>>>>>>> 7332b56 (完成ATC登陆)
}