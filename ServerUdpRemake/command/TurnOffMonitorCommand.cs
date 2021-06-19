using System.Runtime.InteropServices;
using WebSocketSharp;
namespace ServerUdpRemake.command
{
    class TurnOffMonitorCommand :  BasicCommand
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);
        private const int MonitorStateOff = 2;
       
        protected override void doApply(WebSocket webSocket)
        {
            SendMessage(0xFFFF, 0x112, 0xF170, MonitorStateOff);
        }
    }
}
