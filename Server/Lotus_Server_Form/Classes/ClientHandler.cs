using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Lotus_Server_Form
{
    internal class ClientHandler
    {
        private TcpClient client;
        private TcpClient reportClient;
        private ServerHandler server;
        private NetworkStream stream;
        private NetworkStream reportStream;
        private Thread clientThread;

        public ClientHandler(TcpClient tcpClient, TcpClient reportClient, ServerHandler serverInstance)
        {
            client = tcpClient;
            this.reportClient = reportClient;
            server = serverInstance;
            stream = client.GetStream();
            reportStream = reportClient.GetStream();
        }

        public void Start()
        {
            clientThread = new Thread(HandleClient);
            clientThread.Start();
        }

        private void HandleClient()
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            try
            {
                // Mesaj istemcisi için dinleme döngüsü
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    server.AddMessageToChat(message);
                    server.BroadcastMessage(message, client);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                Disconnect(); // Bağlantı kesildiğinde Disconnect metodunu çağır
            }
        }

        // Rapor istemcisinden gelen kodları işle
        public void HandleCode(string code)
        {
            switch (code)
            {
                case "W00001": // Sunucu bağlantısı beklenmedik şekilde kesildi.
                    Whispery.Server.StaticVariables.ServerHandler.eventLogger.Log("****REPORT**** " + reportClient.ToString() + ": W00001 (Sunucu bağlantısı kesildi)");
                    Disconnect(); // Bağlantıyı kes
                    break;
                default:
                    throw new Exception("Bilinmeyen kod alındı.");
            }
        }

        public void Disconnect()
        {
            // Rapor istemcisi varsa bağlantıyı kapat
            if (reportClient != null)
            {
                reportClient.Close();
            }

            // Mesaj istemcisi için bağlantıyı kapat
            if (client != null)
            {
                client.Close();
            }

            if (clientThread != null && clientThread.IsAlive)
            {
                clientThread.Join();
            }
        }

        public TcpClient GetClient()
        {
            return client;
        }
    }
}
