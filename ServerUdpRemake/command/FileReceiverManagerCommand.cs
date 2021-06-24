using Newtonsoft.Json.Linq;
using ServerUdpRemake.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace ServerUdpRemake.command
{
    class FileReceiverManagerCommand
    {
        private Dictionary<long, FileStream> fileStreams;

        public FileReceiverManagerCommand()
        {
            fileStreams = new Dictionary<long, FileStream>();
        }
        public void Apply(BinaryInfo binaryInfo)
        {
            var messageJson = binaryInfo.jsonFormat;
            long id = (long)messageJson["id"];
            LogUtilty.log("received id: " + id);
            FileStream fileStream;
            if (fileStreams.ContainsKey(id))
            {
                fileStream = fileStreams[id];
            }
            else
            {
                fileStream = new FileStream(@"D:\tmp\okay test\" + messageJson["fileName"], FileMode.Create, FileAccess.Write);
                fileStreams.Add(id, fileStream);
                LogUtilty.log("Created new file stream for location:" + @"D:\tmp\" + messageJson["fileName"]);
            }
            long frame = (long)messageJson["frame"];
            long latestFrame = (long)messageJson["latestFrame"];
            byte[] binaryData = binaryInfo.binaryData;
            fileStream.Write(binaryData, binaryInfo.lengthToBody, binaryData.Length - binaryInfo.lengthToBody);
            if (frame == latestFrame)
            {
                fileStream.Close();
                fileStreams.Remove(id);
                LogUtilty.log("Closed stream and finished file writing, and removed from map");
            }

        }
    }
}
