using Alchemy.Classes;
using System;
using System.Runtime.InteropServices;

namespace ServerUdpRemake.command
{
    class TurnOnMonitorCommand : Command
    {
        [DllImport("user32.dll")]
        public static extern void mouseEvent(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        private const int MOUSE_EVENT_MOVE = 0x0001;
        public void Apply(UserContext context)
        {
            mouseEvent(MOUSE_EVENT_MOVE, 0, 1, 0, (int)UIntPtr.Zero);
        }
    }
}
