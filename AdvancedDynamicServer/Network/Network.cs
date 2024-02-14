using AdvancedDynamicServer.model;
using System.Net;
using System.Net.Sockets;
using System.Text;
using AdvancedDynamicServer.model.Server;



namespace AdvancedDynamicServer.Network
{
    class NetworkServer
    {
        private static Dictionary<IPEndPoint, TcpClient> oldClients = new Dictionary<IPEndPoint, TcpClient>();
        private static object lockObject = new object();
        public static Dictionary<string, TcpClient> newClients = new Dictionary<string, TcpClient>();
        public static Dictionary<string, Tuple<string, string>> user = new Dictionary<string, Tuple<string, string>>();
<<<<<<< HEAD
        public static Dictionary<string,AtcInfo.Atcuser> atcUser = new Dictionary<string, AtcInfo.Atcuser>();
        public static Dictionary<string,PilotInfos.PilotInfo> pilotUser = new Dictionary<string, PilotInfos.PilotInfo>();
=======
>>>>>>> 7332b56 (完成ATC登陆)
        public static void Networkmain()
        {
            // 设置服务器的IP地址和端口号
            IPAddress ipAddress = IPAddress.Parse("0.0.0.0");
            int port = 6809;
            IPEndPoint ipEndpoint = new IPEndPoint(ipAddress, port);

            // 创建一个TCP监听器
            TcpListener listener = new TcpListener(ipEndpoint);
            listener.Start();
            Console.WriteLine("Server listening on port 6809...");

            // 创建一个线程用于检查超时连接

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                IPEndPoint clientAddress = (IPEndPoint)client.Client.RemoteEndPoint!;
                Console.WriteLine($"Connected with {clientAddress}");

                // 为每个连接的客户端创建一个单独的线程
                Thread clientThread = new Thread(() => HandleClient(client, clientAddress));
                clientThread.Start();
            }
        }
        

        static void HandleClient(TcpClient client, IPEndPoint clientAddress)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int byteCount;
            try
            {
                while ((byteCount = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string data = Encoding.UTF8.GetString(buffer, 0, byteCount);;

                    // 处理数据
                    BaseData.Splitdata(data, client);
                }
            }
            catch (Exception e)
            {
                //忽略异常
                Console.WriteLine(e);
            }
            
        }
        public static void SendMsg(string msg, string user)                                                                                       
        {
<<<<<<< HEAD
            try
            {
                TcpClient client = newClients[user];
                byte[] initialData = Encoding.UTF8.GetBytes(msg+"\r\n");
                NetworkStream stream = client.GetStream();
                stream.Write(initialData, 0, initialData.Length);
                Console.WriteLine($"Send {msg} to {user}");
            }
            catch (Exception)
            {
                return;
            }
            
        }
        public static void SendMsgnative(string msg, TcpClient address)
        {
            try
            {;
                byte[] initialData = Encoding.UTF8.GetBytes(msg + "\r\n");
                NetworkStream stream = address.GetStream();
                stream.Write(initialData, 0, initialData.Length);
                Console.WriteLine($"Send {msg} to {user}");
            }
            catch (Exception)
            {
                return;
            }

        }
        static void DeleteClient(string callsign)
        {
            newClients.Remove(callsign);
        }

        private static void DelnativeClient(IPEndPoint address)
        {
            string callsign = "";
            TcpClient infoclient = oldClients[address];
            foreach (var client in newClients)
            {
                if (client.Value == infoclient)
                {
                    callsign = client.Key;
                }
            }
            //判断callsign是否在AtcUser内
            if (atcUser.ContainsKey(callsign))
            {
                atcUser.Remove(callsign);
            }
            {
                oldClients.Remove(address);
            }
=======
            TcpClient client = newClients[user];
            byte[] initialData = Encoding.UTF8.GetBytes(msg);
            NetworkStream stream = client.GetStream();
            stream.Write(initialData, 0, initialData.Length);
            Console.WriteLine($"Send {msg} to {user}");
>>>>>>> 7332b56 (完成ATC登陆)
        }
    }
}
