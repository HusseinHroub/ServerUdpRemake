using System;
using System.Runtime.Serialization;

namespace ServerUdpRemake
{
    [Serializable]
    internal class ClientOfflineException : Exception
    {
        public ClientOfflineException()
        {
        }

        public ClientOfflineException(string message) : base(message)
        {
        }

        public ClientOfflineException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClientOfflineException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}