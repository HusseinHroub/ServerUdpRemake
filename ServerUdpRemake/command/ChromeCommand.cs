using Alchemy.Classes;
using Newtonsoft.Json.Linq;
using System.Diagnostics;


namespace ServerUdpRemake.command
{
    class ChromeCommand : Command
    {
        public void Apply(UserContext context, JObject messageJson)
        {
            Process.Start("chrome.exe");
        }
    }
}
