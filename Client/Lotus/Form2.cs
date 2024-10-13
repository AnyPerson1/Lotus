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

namespace Lotus
{
    public partial class Form2 : Form
    {
        private string kullaniciAdi;
        private TcpClient client;
        private NetworkStream stream;
        private Thread receiveThread;

        public Form2(string UserName)
        {
            InitializeComponent();
            this.kullaniciAdi = UserName;
            ConnectToServer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (client == null || !client.Connected)
            {
                ConnectToServer();
            }
            SendMessage();
        }
        private void ConnectToServer()
        {
            try
            {
                // Sunucuya bağlan
                client = new TcpClient("193.106.196.207", 53447);
                stream = client.GetStream();

                // Sunucudan mesaj alacak thread başlat
                receiveThread = new Thread(ReceiveMessages);
                receiveThread.IsBackground = true;
                receiveThread.Start();

                // Bağlantı durumunu yazdır
                listBoxMessages.Items.Add("Sunucuya bağlanıldı.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bağlantı hatası: {ex.Message}");
            }
        }
        private void ReceiveMessages()
        {
            try
            {
                while (client.Connected)
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                        // Mesajı ListBox'a ekle
                        Invoke(new Action(() =>
                        {
                            listBoxMessages.Items.Add(receivedMessage);
                        }));
                    }
                }
            }
            catch (Exception)
            {
                Invoke(new Action(() =>
                {
                    listBoxMessages.Items.Add("Sunucuyla bağlantı kesildi.");
                }));
            }
        }
        private void SendMessage()
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxMessage.Text))
                {
                    // Kullanıcı adı ile mesajı birleştir
                    string fullMessage = $"{kullaniciAdi}: {textBoxMessage.Text}";

                    // Mesajı byte dizisine çevir ve gönder
                    byte[] data = Encoding.UTF8.GetBytes(fullMessage);
                    stream.Write(data, 0, data.Length);

                    // ListBox'a mesajı ekle
                    listBoxMessages.Items.Add(fullMessage);

                    // Mesaj kutusunu temizle
                    textBoxMessage.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Mesaj gönderme hatası: {ex.Message}");
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (stream != null) stream.Close();
            if (client != null) client.Close();
            Form1 frm1 = new Form1();
            frm1.Show();
        }
    }
}
