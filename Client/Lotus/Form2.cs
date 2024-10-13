using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lotus.Data;

namespace Lotus
{
    public partial class Form2 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private Thread receiveThread;
        LotusData data;

        public Form2(string UserName)
        {
            InitializeComponent();

            if (client == null || !client.Connected)
            {
                data = new LotusData("193.106.196.207", 53447, listBoxMessages, textBoxMessage, UserName);
                listBoxMessages.Items.Add("Sunucuya bağlanıldı.");
                data.SendMessage(UserName+ " sunucuya katıldı.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (client == null || !client.Connected)
            {
                data.SendMessage();
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (stream != null) stream.Close();
            if (client != null) client.Close();
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
