using System.Net.Sockets;
using AdvancedDynamicServer.model.PDU;

namespace AdvancedDynamicServer.model.Server;

public class Server
{
    public static void Command(string[] tokens, string rawData, TcpClient clientAddress)
    {
        //判断tokens[0]是否有￥这个符号
        if (tokens[0].Contains("$"))
        {
            //TODO:预留Requests
        }else if (tokens[0].Contains("#"))
        {
<<<<<<< HEAD
            ClientsOrMessages.DataJudgment(tokens, rawData, clientAddress);
        }
        else if (tokens[0].Contains("@"))
=======
            if (tokens[0].Contains("#AA"))
            {
                PDUATCLogin.ATCLogin(tokens, rawData, clientAddress);
            }
        }else if (tokens[0].Contains("@"))
>>>>>>> 7332b56 (完成ATC登陆)
        {
            PDUPilotPosition.BroadcastLocationPilot(tokens, rawData);
        }else if (tokens[0].Contains("%"))
        {
            PDUATCPosition.BroadcastLocationATC(tokens, rawData);

        }
    }
}