using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Lotus_Server_Form
{
    internal class ClientHandler
    {
        private TcpClient client;
        private ServerHandler server;
        private NetworkStream stream;
        private Thread clientThread;
        private string workType;

        public ClientHandler(TcpClient tcpClient, ServerHandler serverInstance,string type)
        {
            client = tcpClient;
            server = serverInstance;
            stream = client.GetStream();
            workType = type;
        }

        public void Start()
        {
            if (workType == "Report")
            {
                clientThread = new Thread(HandleCode);
            }
            else
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
                Disconnect();
            }
        }

        public void HandleCode()
        {
            byte[] buffer = new byte[1024];
            int bytesRead;
            try
            {
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    switch (message)
                    {
                        case "W00001":
                            Whispery.Server.StaticVariables.ServerHandler.eventLogger.Log("****REPORT**** " + client.ToString() + ": W00001 (Sunucu bağlantısı kesildi)");
                            Disconnect();
                            break;
                        default:
                            throw new Exception("Bilinmeyen kod alındı.");
                    }
                }
            }
            catch (Exception ex)
            {

                Whispery.Server.StaticVariables.ServerHandler.eventLogger.Log("Report portundan veri dinlenirken bir hata oluştu : " + ex.ToString());
                System.Windows.Forms.MessageBox.Show("Report portundan veri dinlenirken bir hata oluştu " + ex.ToString());
            }

        }

        public void Disconnect()
        {
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
