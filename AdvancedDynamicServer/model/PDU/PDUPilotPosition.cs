using AdvancedDynamicServer.Network;

namespace AdvancedDynamicServer.model.PDU;

public class PDUPilotPosition
{
    public static void BroadcastLocationPilot(string[] tokens, string rawData)
    {
        Console.WriteLine(rawData);
        UpdataPilotPosition(tokens);
        string callsign = tokens[1];
        PDUTextmessage.SendToAll.sendTouser(callsign, rawData);
    }

    private static void UpdataPilotPosition(string[] tokens)
    {
        float[] unpackedValues  = UnpackPitchBankHeading(int.Parse(tokens[8]));
        string callsign = tokens[1];
        PilotInfos.PilotInfo pilot = NetworkServer.pilotUser[callsign];
        pilot.Latitude = double.Parse(tokens[4]);
        pilot.Longitude = double.Parse(tokens[5]);
        pilot.Altitude = int.Parse(tokens[6]);
        pilot.Groundspeed = int.Parse(tokens[7]);
        pilot.Heading = unpackedValues[2];
        pilot.Transponder = int.Parse(tokens[2]);
        pilot.Pitch = unpackedValues[0];
        pilot.Bank = unpackedValues[1];
        //更新数据
        NetworkServer.pilotUser[callsign] = pilot;
        
    }

    private static float[] UnpackPitchBankHeading(int pbh)
    {
        // 从整数中获取pitch值
        int pitchInt = pbh >> 22;

        // 将pitch转换为浮点数
        float pitch = (float)pitchInt / 1024.0f * -360.0f;
        if (pitch > 180.0f)
        {
            pitch -= 360.0f;
        }
        else if (pitch <= -180.0f)
        {
            pitch += 360.0f;
        }

        // 从整数中获取bank值
        int bankInt = (pbh >> 12) & 0x3FF;
        // 将bank转换为浮点数
        float bank = (float)bankInt / 1024.0f * -360.0f;
        if (bank > 180.0f)
        {
            bank -= 360.0f;
        }
        else if (bank <= -180.0f)
        {
            bank += 360.0f;
        }

        // 从整数中获取heading值
        int hdgInt = (pbh >> 2) & 0x3FF;
        // 将heading转换为浮点数
        float heading = (float)hdgInt / 1024.0f * 360.0f;
        if (heading < 0.0f)
        {
            heading += 360.0f;
        }
        else if (heading >= 360.0f)
        {
            heading -= 360.0f;
        }

        return new float[] { pitch, bank, heading };
    }
}