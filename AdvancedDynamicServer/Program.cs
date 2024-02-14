using System;
using System.Data.SqlTypes;
using AdvancedDynamicServer.Network;
using AdvancedDynamicServer.model.Server;


namespace AdvancedDynamicServer
{
    class Program
    {
        static void Main()
        {
            Thread refresh = new Thread(() => Status.Refresh());
            refresh.Start();
            NetworkServer.Networkmain();
            
            
        }
    }
}