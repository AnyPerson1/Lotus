using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lotus_Server_Form
{
    internal class ClientHandler
    {
        private TcpClient client;
        private Server server;
        private NetworkStream stream;
        private Thread clientThread;

        public ClientHandler(TcpClient tcpClient, Server serverInstance)
        {
            client = tcpClient;
            server = serverInstance;
            stream = client.GetStream();
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
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    server.AddMessageToChat(message);
                    server.BroadcastMessage(message, client);
                }
            }
            catch (Exception)
            {
                //server.RemoveClient(this);
                System.Windows.Forms.MessageBox.Show("Test");
            }
        }

        public void Disconnect()
        {
            client.Close();
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
