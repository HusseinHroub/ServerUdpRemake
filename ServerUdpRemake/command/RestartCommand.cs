using Alchemy.Classes;
using System.Diagnostics;

namespace ServerUdpRemake.command
{
    class RestartCommand : Command
    {
        public void Apply(UserContext context)
        {
            context.Send(context.DataFrame);
            Process.Start("shutdown", "/r /t 0");
        }
    }
}
