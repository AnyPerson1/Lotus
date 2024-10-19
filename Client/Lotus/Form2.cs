using Lotus.Classes;
using NAudio.Wave;
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
using Whispry.Data;

namespace Lotus
{
    public partial class Form2 : Form
    {
        #region Yazı
        private TcpClient client;
        private NetworkStream stream;
        private Thread receiveThread;
        WhispryData data;

        public Form2(string UserName)
        {
            InitializeComponent();

            if (client == null || !client.Connected)
            {
                data = new WhispryData("192.168.1.104", 51776, listBoxMessages, textBoxMessage, UserName);
                listBoxMessages.Items.Add("Sunucuya bağlanıldı.");
                data.SendMessage(UserName+ " sunucuya katıldı.");
                data.KaydiBaslat();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (client == null || !client.Connected)
            {
                data.SendMessage();
            }
        }
        
        #endregion
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Reporter.Report("W00001");
            if (stream != null) stream.Close();
            if (client != null) client.Close();
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private TcpClient VoiceClient;
        private NetworkStream VoiceStream;
        WhispryData VoiceData;
        private void button2_Click(object sender, EventArgs e)
        {
            
            
        }
        
    }
}
