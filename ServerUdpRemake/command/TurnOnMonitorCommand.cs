using WebSocketSharp;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace ServerUdpRemake.command
{
    class TurnOnMonitorCommand : BasicCommand
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(Int32 dwFlags, Int32 dx, Int32 dy, Int32 dwData, UIntPtr dwExtraInfo);

        private const int MOUSEEVENTF_MOVE = 0x0001;
        protected override void doApply(WebSocket webSocket)
        {
            mouse_event(MOUSEEVENTF_MOVE, 0, 1, 0, UIntPtr.Zero);
            Thread.Sleep(40);
            mouse_event(MOUSEEVENTF_MOVE, 0, -1, 0, UIntPtr.Zero);
        }
    }
}
