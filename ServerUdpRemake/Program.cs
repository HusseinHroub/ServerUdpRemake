using System;
using System.Net;
using Alchemy;
using Alchemy.Classes;

namespace ServerUdpRemake
{
    class Program
    {
        
        static void Main(string[] args)
        {
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
            MessagingSocket messagingSocket = new MessagingSocket(9722);
            while (true)
            {
                messagingSocket.ReceiveAndPing();
            }
        }

        public static void OnReceive(UserContext context)
        {
            try
            {
            CommandFactory.get(context.DataFrame.ToString()).Apply(context);
            context.Send(context.DataFrame);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong.");
            }
        }

    }
}
