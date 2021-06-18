using System;
using System.Net;
using Alchemy;
using Alchemy.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServerUdpRemake.socket;

namespace ServerUdpRemake
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            //string output = JsonConvert.SerializeObject(product);
            initWebSocketServer();
            initUDPServer();
        }

        private static void initWebSocketServer()
        {
            var aServer = new WebSocketServer(9721, IPAddress.Any)
            {
                OnReceive = OnReceive,
                //OnSend = OnSend,
                //OnConnected = OnConnect,
                //OnDisconnect = OnDisconnect,
                TimeOut = new TimeSpan(0, 5, 0)
            };
            aServer.Start();
        }

        private static void initUDPServer()
        {
            var messegingManagment = new MessegingManagment(9722, 9622);
            while (true)
            {
                messegingManagment.ReceiveAndPing();
            }
        }

        public static void OnReceive(UserContext context)
        {
            try
            {
                var messageJson = JObject.Parse(context.DataFrame.ToString());
                CommandFactory.get(messageJson["type"].ToString()).Apply(context, messageJson);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong: " + e);
            }
        }

    }
}
