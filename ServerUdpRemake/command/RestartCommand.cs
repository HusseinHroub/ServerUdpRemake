﻿using Newtonsoft.Json.Linq;
using System.Diagnostics;
using WebSocketSharp;

namespace ServerUdpRemake.command
{
    class RestartCommand : Command
    {
        public void Apply(WebSocket webSocket, JObject messageJson)
        {
            webSocket.Send(messageJson.ToString());
            Process.Start("shutdown", "/r /t 0");
        }
    }
}
