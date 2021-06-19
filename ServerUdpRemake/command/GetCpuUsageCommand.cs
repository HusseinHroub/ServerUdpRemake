

using Alchemy.Classes;
using Newtonsoft.Json.Linq;
using ServerUdpRemake.models;
using ServerUdpRemake.utils;
using System;
using System.Diagnostics;
using System.Threading;

namespace ServerUdpRemake.command
{
    class GetCpuUsageCommand : Command
    {
        public void Apply(UserContext context, JObject messageJson)
        {
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            cpuCounter.NextValue();
            Thread.Sleep(500);
            SendUtils.sendAsJson(context,
                new MonitorCommandOutput() { 
                    type = messageJson["type"].ToString(),
                    value = (int)cpuCounter.NextValue() + "%",
                    sequenceId = Convert.ToInt64(messageJson["sequenceId"].ToString()) + 1
                });
        }

    }
}

