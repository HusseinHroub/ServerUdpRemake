using System;
using WebSocketSharp;
using WebSocketSharp.Server;
using Newtonsoft.Json.Linq;
using ServerUdpRemake.socket;
using System.Net;
using ServerUdpRemake.utils;

namespace ServerUdpRemake
{
    public class RootBehaviour : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs messageEventArgs)
        {
            try
            {
                string messageString = messageEventArgs.Data;
                var messageJson = JObject.Parse(messageString);
                CommandFactory.get(messageJson["type"].ToString()).Apply(Context.WebSocket, messageJson);
            }
            catch (Exception e)
            {
                LogUtilty.log("Something went wrong: " + e);
            }
        }
        protected override void OnOpen()
        {
            LogUtilty.log("opened!");
        }
    }
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
            var wssv = new WebSocketServer(IPAddress.Any, 9721, true);
            wssv.AddWebSocketService<RootBehaviour>("/");
            wssv.Start();

        }

        private static void initUDPServer()
        {
            var messegingManagment = new MessegingManagment(9722, 9622);
            while (true)
            {
                messegingManagment.ReceiveAndPing();
            }
        }

    }
}
