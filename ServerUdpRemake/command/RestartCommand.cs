using Alchemy.Classes;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace ServerUdpRemake.command
{
    class RestartCommand : Command
    {
        public void Apply(UserContext context, JObject messageJson)
        {
            context.Send(context.DataFrame);
            //Process.Start("shutdown", "/r /t 0");
        }
    }
}
