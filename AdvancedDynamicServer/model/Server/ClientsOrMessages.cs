using System.Net.Sockets;
using AdvancedDynamicServer.model.PDU;
namespace AdvancedDynamicServer.model.Server;

public class ClientsOrMessages
{
    public static void DataJudgment(string[] tokens, string rawData, TcpClient clientAddress)
    {
        if (tokens.Contains("#AA"))
        {
            PDUATCLogin.ATCLogin(tokens, rawData, clientAddress);
            return;

        }

        if (tokens.Contains("#AP"))
        {
            PDUPilotLogin.PilotLogin(tokens, rawData, clientAddress);
            return;
        }

        if (tokens.Contains("#TM"))
        {
            return;
        }

        if (tokens.Contains("DA"))
        {
            return;
        }

        if (tokens.Contains("DP"))
        {
            return;
        }

        if (tokens.Contains("PC"))
        {
            return;
        }
    }
}