using Newtonsoft.Json.Linq;
using WebSocketSharp;

namespace ServerUdpRemake.command
{
    class RestartCommand : Command
    {
        public void Apply(WebSocket webSocket, JObject messageJson)
        {
            //context.Send(context.DataFrame);
            //Process.Start("shutdown", "/r /t 0");
        }
    }
}
