using ServerUdpRemake.command;

namespace ServerUdpRemake
{
    class CommandFactory
    {
        public static Command get(string message)
        {
            switch (message)
            {
                case "chrome":
                    return new ChromeCommand();
                default:
                    return null;
            }
        }
    }
}
