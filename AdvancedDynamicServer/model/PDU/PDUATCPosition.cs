using AdvancedDynamicServer.Network;
using AdvancedDynamicServer.model;
namespace AdvancedDynamicServer.model.PDU;

public class PDUATCPosition
{
    public static void BroadcastLocationATC(string[] tokens, string rawdata)
    {
        PDUTextmessage.SendToAll.sendTouser(tokens[0].Substring(1), rawdata);
        UpdateATCPosition(tokens);
    }
    static void UpdateATCPosition(string[] tokens)
    {
        string callsign = tokens[0].Substring(1);
        AtcInfo.Atcuser atc = NetworkServer.atcUser[callsign];
        atc.Frequency = tokens[1];
        atc.Latitude = double.Parse(tokens[5]);
        atc.Longitude = double.Parse(tokens[6]);
        atc.Visualrange = int.Parse(tokens[3]);
        atc.Facility = int.Parse(tokens[2]);
        //更新数据
        NetworkServer.atcUser[callsign] = atc;
    }
}