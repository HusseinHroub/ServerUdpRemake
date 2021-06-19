using Newtonsoft.Json.Linq;
using ServerUdpRemake.models;
using ServerUdpRemake.utils;
using WebSocketSharp;

namespace ServerUdpRemake.command
{
    abstract class BasicCommand : Command
    {
        public void Apply(WebSocket webSocket, JObject messageJson)
        {
            doApply(webSocket);
            SendUtils.sendAsJson(webSocket, new BasicCommandOutput() { type = messageJson["type"].ToString() });
        }

        abstract protected void doApply(WebSocket webSocket);
    }
}
