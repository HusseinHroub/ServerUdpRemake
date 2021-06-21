using Newtonsoft.Json.Linq;
using ServerUdpRemake.command;
using ServerUdpRemake.utils;
using System;

namespace ServerUdpRemake
{
    class BinaryCommandFactory
    {
        private static FileReceiverManagerCommand fileReceiverManagerCommand = new FileReceiverManagerCommand();
        public static void apply(BinaryInfo binaryInfo)
        {
            string type = (string)binaryInfo.jsonFormat["type"];
            switch (type)
            {
                case "fileTransfer":
                    fileReceiverManagerCommand.Apply(binaryInfo);
                    break;
                default:
                    throw new Exception("Not valid command: " + type);
            }
        }
    }
}
