using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServerUdpRemake.socket
{
    class MessegingManagment
    {
        private MessagingSocket socket;
        private int sendingPort;
        public MessegingManagment(int recevingPort, int sendingPort)
        {
           this.socket = new MessagingSocket(recevingPort);
           this.sendingPort = sendingPort;
        }

        public void ReceiveAndPing()
        {
            SocketMessage socketMessage= socket.Receive();
            var endpoint = new IPEndPoint(IPAddress.Any, sendingPort);
            endpoint.Address = socketMessage.GetAddress();
            socket.Send(socketMessage.GetMessage(), endpoint);
        }
    }
}
