using Lotus.Classes;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using NAudio;

namespace Whispry.Data
{
    public class WhispryData
    {
        private TcpClient client;
        private NetworkStream stream;
        private Thread receiveThread;
        private ListBox listBoxMessages;
        private System.Windows.Forms.TextBox textBoxMessage;
        public string KullaniciAdi;
        public WhispryData(string ip, int port, ListBox listBox, System.Windows.Forms.TextBox textBox, string kullaniciAdi)
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
        public WhispryData()
        {

        }
        private WaveInEvent waveIn;
        public void KaydiBaslat()
        {
            waveIn = new WaveInEvent();

            // Kayıt formatını belirleyin (44.1 kHz, 16-bit, Mono)
            waveIn.WaveFormat = new WaveFormat(44100, 1);


            // Yeni ses verisi geldiğinde tetiklenen olay
            waveIn.DataAvailable += (sender, e) =>
            {
                stream.Write(e.Buffer, 0, e.BytesRecorded);
            };

            // Kayıt durdurulduğunda tetiklenen olay
            waveIn.RecordingStopped += (sender, e) =>
            {
                waveIn.Dispose();
            };

            // Kaydı başlat
            waveIn.StartRecording();
            Console.WriteLine("Kayıt başladı...");
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
                        string[] seperatedMessage = Seperate.Data(receivedMessage);
                        if (seperatedMessage[0] == "Message")
                        {
                            listBoxMessages.Invoke((MethodInvoker)delegate
                            {
                                listBoxMessages.Items.Add(receivedMessage);
                            });
                        }
                        else
                        {
                            byte[] audiobytes = Convert.FromBase64String(seperatedMessage[1]);
                            PlayAudioFromBytes(audiobytes);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sunucu ile bağlantı kesildi: " + ex.Message);
                Application.Exit();
            }
        }
        private void PlayAudioFromBytes(byte[] audioBytes)
        {
            using (var ms = new MemoryStream(audioBytes))
            using (var waveOut = new WaveOutEvent())
            using (var waveProvider = new WaveFileReader(ms))
            {
                waveOut.Init(waveProvider);
                waveOut.Play();
            }
        }

        public void SendMessage()
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxMessage.Text))
                {
                    string fullMessage = $"{KullaniciAdi}: {textBoxMessage.Text}";
                    
                    string dataToGo = "Message;"+fullMessage+";"+"0;"+"0";
                    byte[] data = Encoding.UTF8.GetBytes(dataToGo);
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
        public void SendMessage(string message,string type)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxMessage.Text))
                {
                    string fullMessage = $"{KullaniciAdi}: {textBoxMessage.Text}";

                    string dataToGo = type+";" + fullMessage + ";" + "0;" + "0";
                    byte[] data = Encoding.UTF8.GetBytes(dataToGo);
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



    }
}
