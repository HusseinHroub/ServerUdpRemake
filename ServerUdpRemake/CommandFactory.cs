using Newtonsoft.Json.Linq;
using ServerUdpRemake.command;
using System;

namespace ServerUdpRemake
{
    class CommandFactory
    {
        public static Command get(string type)
        {
            Console.WriteLine(type);
            switch (type)
            {
                case "launchChrome":
                    return new ChromeCommand();
                case "turnOffMonitor":
                    return new TurnOffMonitorCommand();
                case "turnOnMonitor":
                    return new TurnOnMonitorCommand();
                case "restart":
                    return new RestartCommand();
                case "captureDesktopScreenshot":
                    return new TakeScreenShotCommand();
                case "getCpuUsage":
                    return new GetCpuUsageCommand();
                default:
                    throw new Exception("Not valid command: " + type);
            }
        }
    }
}
