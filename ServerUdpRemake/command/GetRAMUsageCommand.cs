using Alchemy.Classes;
using Newtonsoft.Json.Linq;
using ServerUdpRemake.models;
using ServerUdpRemake.utils;
using System.Diagnostics;


namespace ServerUdpRemake.command
{
    class GetRAMUsageCommand : Command
    {
        public void Apply(UserContext context, JObject messageJson)
        {
            PerformanceCounter cpuCounter = new PerformanceCounter("Memory", "Available MBytes");
            SendUtils.sendAsJson(context,
                new CPUCommandOutput()
                {
                    type = messageJson["type"].ToString(),
                    value = cpuCounter.NextValue() + "%"
                });
        }
    }
}
