using System;

using System.Drawing;
using Newtonsoft.Json;
using System.Windows.Forms;
using ServerUdpRemake.models;

namespace ServerUdpRemake
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            notifyIcon1.Icon = new Icon(SystemIcons.Application, 40, 40);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (Screen.GetWorkingArea(this).Contains(Cursor.Position) && WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                Hide();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sendTextToClient();
        }

        private void sendTextToClient()
        {
            String textToSend = textBox2.Text;
            if (textToSend.Trim().Length == 0)
            {
                textBox1.Text += "You must type something..\n";
            }
            try
            {
                string jsonString = JsonConvert.SerializeObject(new BasicDataCommandOutput()
                {
                    type = "putTextClipCommand",
                    data = textToSend
                });
                Program.sendToPhone(jsonString);
                textBox2.Text = "";
            }
            catch (ClientOfflineException)
            {
                textBox1.Text += "Couldn't send text because client is not online..\n";
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
