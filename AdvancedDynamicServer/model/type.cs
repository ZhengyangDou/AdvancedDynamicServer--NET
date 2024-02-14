<<<<<<< HEAD
﻿namespace AdvancedDynamicServer.model;

public class AtcInfo
{
    public struct Atcuser
    {
        public string Callsign;
        public string Cid;
        public string Name;
        public string Frequency;
        public int Facility;
        public double Latitude;
        public double Longitude;
        public int Rating;
        public string Server;
        public int Visualrange;
        public string[] TextAtis;
        public string LogonTime;
    }
    
}
public class Senduser
{
    public struct SendUser
    {
        public string Callsign;
        public double Latitude;
        public double Longitude;
        public int Visualrange;

    }
}

public class FlightPlans
{
    public struct FlightPlan
    {
        public string Aircraft;
        public string CruisingSpeed;
        public string Departure;
        public string Arrival;
        public string Alternate;
        public string FlightRules;
        public string DepartureTime;
        public string EnrouteTime;
        public string FuelTime;
        public string AlternateTime;
        public string Remarks;
        public string Route;
    }
}

public class PilotInfos
{
    public struct PilotInfo
    {
        public string Callsign;
        public string Cid;
        public string Name;
        public int Visualrange;
        public string LogonTime;
        public string Server;
        public double Latitude;
        public double Longitude;
        public int Altitude;
        public int Groundspeed;
        public int Transponder;
        public float Heading;
        public float Pitch;
        public float Bank;
        public FlightPlans.FlightPlan FlightPlan;
    }
=======
﻿using System.Net.Sockets;

namespace AdvancedDynamicServer.model;

public struct UserInfo
{
    public string Password;
    public string Username;
    public string Level;
    public UserInfo(string username, string password, string level)
    {
        Username = username;
        Password = password;
        Level = level;
    }
}
public struct NewClient
{
    public string Callsign;
    public TcpClient ClientAddress;
>>>>>>> 7332b56 (完成ATC登陆)
}