using ServerUdpRemake.command;

namespace ServerUdpRemake
{
    class CommandFactory
    {
        public static Command get(string message)
        {
            switch (message)
            {
                case "launchChrome":
                    return new ChromeCommand();
                case "turnOffMonitor":
                    return new TurnOffMonitorCommand();
                case "turnOnMonitor":
                    return new TurnOnMonitorCommand();
                case "restart":
                    return new RestartCommand();
                case "takeDesScreenshot":
                    return new TakeScreenShotCommand();
                default:
                    return null;
            }
        }
    }
}
