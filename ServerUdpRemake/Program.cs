using System;
using WebSocketSharp;
using WebSocketSharp.Server;
using Newtonsoft.Json.Linq;
using ServerUdpRemake.socket;
using System.Net;
using ServerUdpRemake.utils;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ServerUdpRemake
{
    public class RootBehaviour : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs messageEventArgs)
        {
            try
            {
                if (messageEventArgs.IsText)
                {
                    string messageString = messageEventArgs.Data;
                    var messageJson = JObject.Parse(messageString);
                    CommandFactory.get(messageJson["type"].ToString()).Apply(Context.WebSocket, messageJson);
                }
                else if (messageEventArgs.IsBinary)
                {
                    byte[] messageBinary = messageEventArgs.RawData;
                    var binaryInformation = getBinaryInformation(messageBinary);
                    BinaryCommandFactory.apply(binaryInformation);

                }

            }
            catch (Exception e)
            {
                LogUtilty.log("Something went wrong: " + e);
            }
        }

        private BinaryInfo getBinaryInformation(byte[] messageBinary)
        {
            byte[] sizeInBytes = new byte[4];
            Array.Copy(messageBinary, sizeInBytes, 4);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(sizeInBytes);
            var jsonSize = BitConverter.ToInt32(sizeInBytes, 0);
            Console.WriteLine("Received json size string of: " + jsonSize);
            var jsonBytes = new byte[jsonSize];
            Array.Copy(messageBinary, 4, jsonBytes, 0, jsonSize);
            var jsonFormat = JObject.Parse(Encoding.UTF8.GetString(jsonBytes));
            return new BinaryInfo() { jsonFormat = jsonFormat, lengthToBody = 4 + jsonSize, binaryData = messageBinary };
        }

        protected override void OnOpen()
        {
            Program.form.phone_id.BeginInvoke((MethodInvoker)delegate
            {
                Program.form.phone_id.Text = "Client ON!";
                Program.form.phone_id.ForeColor = System.Drawing.Color.Green;
            });
        }

        protected override void OnClose(CloseEventArgs e)
        {
            Program.form.phone_id.BeginInvoke((MethodInvoker)delegate
            {
                Program.form.phone_id.Text = "Client OFF!";
                Program.form.phone_id.ForeColor = System.Drawing.Color.Red;
            });
        }
    }
    class Program
    {
        public static Form1 form;
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new Form1();
            form.Text = "Server Brother";
            startWorkers();
            Application.Run(form);


        }

        private static void startWorkers()
        {
            new Thread(() =>
            {
                initWebSocketServer();
                initUDPServer();
            })
            { IsBackground = true }.Start();

        }

        private static void initWebSocketServer()
        {
            var wssv = new WebSocketServer(IPAddress.Any, 9721);
            wssv.AddWebSocketService<RootBehaviour>("/");
            wssv.Start();

        }

        private static void initUDPServer()
        {
            var messegingManagment = new MessegingManagment(9722, 9622);
            while (true)
            {
                messegingManagment.ReceiveAndPing();
            }
        }

    }
}
