using System.Net;

namespace ServerUdpRemake
{
    class SocketMessage
    {
        private string message;
        private IPAddress address;

        public SocketMessage(string message, IPAddress address)
        {
            this.message = message;
            this.address = address;
        }

        public string GetMessage()
        {
            return message;
        }

        public IPAddress GetAddress()
        {
            return address;
        }

        public override bool Equals(object obj)
        {
            if (obj is string)
            {
                return message.Equals(obj);
            }
            else if (obj is SocketMessage)
            {
                return message.Equals(((SocketMessage)obj).GetMessage());
            }
            else
            {
                return false;
            }
        }
    }
}
