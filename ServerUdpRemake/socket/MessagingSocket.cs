using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace ServerUdpRemake
{
     class MessagingSocket
    {
        private delegate bool ConsoleCtrlHandlerDelegate(int sig);
        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(ConsoleCtrlHandlerDelegate handler, bool add);
        private Socket socket;
        private IPEndPoint endpoint;
        private static ConsoleCtrlHandlerDelegate consoleControlHandler;

        public MessagingSocket(int portNumber)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            endpoint = new IPEndPoint(IPAddress.Any, portNumber);
            socket.Bind(endpoint);
            CloseSocketOnApplicationDestroy();
        }

        private void CloseSocketOnApplicationDestroy()
        {
            consoleControlHandler += s =>
            {

                socket.Close();
                return false;
            };
            SetConsoleCtrlHandler(consoleControlHandler, true);
        }

        public void ReceiveAndPing()
        {
            byte[] data = new byte[1024];
            EndPoint remote = (EndPoint) endpoint;
            int dataGram = socket.ReceiveFrom(data, ref remote);
            string message = Encoding.ASCII.GetString(data, 0, dataGram);
            Send(message, (IPEndPoint)remote);
        }

        public void Send(string message, IPEndPoint endpoint)
        {
            byte[] byteMessage = Encoding.ASCII.GetBytes(message);
            socket.SendTo(byteMessage, endpoint);
        }
    }
}
