using Newtonsoft.Json.Linq;
using System.Diagnostics;
using WebSocketSharp;

namespace ServerUdpRemake.command
{
    class ChromeCommand : Command
    {
        public void Apply(WebSocket webSocket, JObject messageJson)
        {
            Process.Start("chrome.exe");
        }
    }
}
