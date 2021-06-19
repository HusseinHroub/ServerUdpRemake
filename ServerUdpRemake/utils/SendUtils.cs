using Newtonsoft.Json;
using WebSocketSharp;

namespace ServerUdpRemake.utils
{
    class SendUtils
    {
        public static void sendAsJson<T>(WebSocket webSocket, T objectToSend)
        {
            string jsonString = JsonConvert.SerializeObject(objectToSend);
            webSocket.Send(jsonString);
            System.Console.WriteLine("sent: " + jsonString + " to client");

        }
    }
}
