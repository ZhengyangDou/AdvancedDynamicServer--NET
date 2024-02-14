namespace AdvancedDynamicServer.model.Server;

public class Requests
{
    public static void RequestsMsg(string[] tokens, string rawData)
    {
        if (tokens[0].Contains("$AX"))
        {
            return;
        }

        if (tokens[0].Contains("$CQ"))
        {
            return;
        }

        if (tokens[0].Contains("$CR"))
        {
            return;
        }

        if (tokens[0].Contains("$FP"))
        {
            return;
        }

        if (tokens[0].Contains("$AM"))
        {
            return;
        }

        if (tokens[0].Contains("$HO"))
        {
            return;
        }

        if (tokens[0].Contains("$HA"))
        {
            return;
        }

        if (tokens[0].Contains("$!!"))
        {
            return;
        }
    }
}