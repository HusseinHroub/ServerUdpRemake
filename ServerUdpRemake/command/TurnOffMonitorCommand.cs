using Alchemy.Classes;
using System.Runtime.InteropServices;

namespace ServerUdpRemake.command
{
    class TurnOffMonitorCommand :  BasicCommand
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);
        private const int MonitorStateOff = 2;
       
        protected override void doApply(UserContext context)
        {
            SendMessage(0xFFFF, 0x112, 0xF170, MonitorStateOff);
        }
    }
}
