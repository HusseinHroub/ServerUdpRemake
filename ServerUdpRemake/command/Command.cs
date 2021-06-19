using Newtonsoft.Json.Linq;
using WebSocketSharp;

namespace ServerUdpRemake.command
{
    interface Command
    {
        void Apply(WebSocket webSocket, JObject messageJson);
    }
}
