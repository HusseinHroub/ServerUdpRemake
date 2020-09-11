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
        private int portNumber;
        private static ConsoleCtrlHandlerDelegate consoleControlHandler;

        public MessagingSocket(int portNumber)
        {
            this.portNumber = portNumber;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            endpoint = new IPEndPoint(IPAddress.Any, portNumber);
            socket.Bind(endpoint);
            CloseSocketOnApplicationDestroy();
        }

        private void CloseSocketOnApplicationDestroy()
        {
            consoleControlHandler += s =>
            {

                SendBroadCast("shut");
                socket.Close();
                return false;
            };
            SetConsoleCtrlHandler(consoleControlHandler, true);
        }

        public SocketMessage Receive()
        {
            byte[] data = new byte[1024];
            EndPoint remote = (EndPoint) endpoint;
            int dataGram = socket.ReceiveFrom(data, ref remote);
            string message = Encoding.ASCII.GetString(data, 0, dataGram);
            return new SocketMessage(message, ((IPEndPoint)remote).Address); //don't use remove.address
        }

        public void Send(string message)
        {
            byte[] byteMessage = Encoding.ASCII.GetBytes(message);
            //endpoint.Address = senderAddress; //could make issues for this line!
            socket.SendTo(byteMessage, endpoint);

        }
        public void SendBroadCast(string message)
        {
            IPEndPoint destEndPoint = new IPEndPoint(GetBroadCastAdderss(), portNumber);
            //Socket udpSocket = new Socket(destAddress.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            byte[] dataMessage = Encoding.ASCII.GetBytes(message);
            socket.SendTo(dataMessage, destEndPoint);
            //udpSocket.Shutdown(SocketShutdown.Send);
            //udpSocket.Close();
        }

        private static IPAddress GetBroadCastAdderss()
        {
            return IPAddress.Parse("192.168.1.255");
        }
    }
}
