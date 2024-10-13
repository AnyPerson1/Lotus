using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotus.Data
{
    public class LotusData
    {
        private string kullaniciAdi;
        private TcpClient client;
        private NetworkStream stream;
        private Thread receiveThread;
        private ListBox listBoxMessages;
        private TextBox textBoxMessage;
        private string KullaniciAdi;
        public LotusData(string ip, int port, ListBox listBox, TextBox textBox, string kullaniciAdi)
        {
            listBoxMessages = listBox;
            try
            {
                client = new TcpClient(ip, port);
                stream = client.GetStream();

                receiveThread = new Thread(() => ReceiveMessages(listBoxMessages));
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bağlantı hatası: {ex.Message}");
            }

            this.textBoxMessage = textBox;
            KullaniciAdi = kullaniciAdi;
        }
        public LotusData()
        {

        }

        public void ReceiveMessages(ListBox listBoxMessages)
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

                        listBoxMessages.Invoke((MethodInvoker)delegate
                        {
                            listBoxMessages.Items.Add(receivedMessage);
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sunucu ile bağlantı kesildi: " + ex.Message);
                Application.Exit();
            }
        }
        public void SendMessage()
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxMessage.Text))
                {
                    string fullMessage = $"{KullaniciAdi}: {textBoxMessage.Text}";
                    byte[] data = Encoding.UTF8.GetBytes(fullMessage);
                    stream.Write(data, 0, data.Length);
                    listBoxMessages.Items.Add(fullMessage);
                    textBoxMessage.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Mesaj gönderme hatası: {ex.Message}");
            }
        }
        public void SendMessage(string message)
        {
            try
            {
                string fullMessage = message;
                byte[] data = Encoding.UTF8.GetBytes(fullMessage);
                stream.Write(data, 0, data.Length);
                listBoxMessages.Items.Add(fullMessage);
                textBoxMessage.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Mesaj gönderme hatası: {ex.Message}");
            }
        }

    }
}
