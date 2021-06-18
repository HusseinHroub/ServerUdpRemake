using Alchemy.Classes;
using Newtonsoft.Json;


namespace ServerUdpRemake.utils
{
    class SendUtils
    {
        public static void sendAsJson<T>(UserContext context, T objectToSend)
        {
            string jsonString = JsonConvert.SerializeObject(objectToSend);
            context.Send(jsonString);
            System.Console.WriteLine("sent: " + jsonString + " to client");

        }
    }
}
