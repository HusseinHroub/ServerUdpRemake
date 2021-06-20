using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace ServerUdpRemake.command
{
    class FileReceiverManagerCommand : Command
    {
        private Dictionary<long, FileStream> fileStreams;

        public FileReceiverManagerCommand()
        {
            fileStreams = new Dictionary<long, FileStream>();
        }
        public void Apply(WebSocket webSocket, JObject messageJson)
        {
            long id = (long) messageJson["id"];
            Console.WriteLine("received id: " + id);
            FileStream fileStream;
            if (fileStreams.ContainsKey(id))
            {
                fileStream = fileStreams[id];
            }
            else
            {
                fileStream = new FileStream(@"D:\tmp\" + messageJson["fileName"], FileMode.Create, FileAccess.Write);
                fileStreams.Add(id, fileStream);
                Console.WriteLine("Created new file stream for location:" + @"D:\tmp\" + messageJson["fileName"]);
            }
            long frame = (long)messageJson["frame"];
            long latestFrame = (long)messageJson["latestFrame"];
            byte[] byteArray = Convert.FromBase64String((string)messageJson["data"]);
            fileStream.Write(byteArray, 0, byteArray.Length);
            if (frame == latestFrame)
            {
                fileStream.Close();
                fileStreams.Remove(id);
                Console.WriteLine("Closed stream and finished file writing, and removed from map");
            }

        }
    }
}
