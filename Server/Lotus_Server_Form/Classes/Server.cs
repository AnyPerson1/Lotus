using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Whispery.Data;

namespace Lotus_Server_Form
{
    internal class Server
    {
        private TcpListener server;
        private List<ClientHandler> clients;
        private Thread serverThread;
        private bool isRunning;
        private EventLogger logger;
        private MessageBroadcaster broadcaster;
        private Action<string> updateEventLog;
        private Action<TcpClient> addClientToList;
        private Action<TcpClient> removeClientFromList;
        private Action<string> addMessageToChat;
        private bool userNameTaken = false;

        public Server(int port, Action<string> logEventAction, Action<TcpClient> addClientAction, Action<TcpClient> removeClientAction, Action<string> addChatMessageAction)
        {
            server = new TcpListener(IPAddress.Any, port);
            clients = new List<ClientHandler>();
            logger = new EventLogger(logEventAction);
            broadcaster = new MessageBroadcaster();
            updateEventLog = logEventAction;
            addClientToList = addClientAction;
            removeClientFromList = removeClientAction;
            addMessageToChat = addChatMessageAction;
        }

        public void Start()
        {
            server.Start();
            isRunning = true;
            logger.Log("Sunucu başlatıldı.");
            serverThread = new Thread(ListenForClients);
            serverThread.Start();
        }

        public void Stop()
        {
            isRunning = false;
            foreach (var client in clients)
            {
                client.Disconnect();
            }
            server.Stop();
            logger.Log("Sunucu kapatıldı.");
        }

        private void ListenForClients()
        {
            while (isRunning)
            {
                try
                {
                    TcpClient tcpClient = server.AcceptTcpClient();
                    ClientHandler clientHandler = new ClientHandler(tcpClient, this);
                    lock (clients)
                    {
                        clients.Add(clientHandler);
                    }
                    clientHandler.Start();
                    addClientToList(tcpClient);
                }
                catch (SocketException ex)
                {
                    if (isRunning)
                    {
                        logger.Log($"SocketException: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    logger.Log($"Hata: {ex.Message}");
                }
            }
        }

        public void BoardcastUser(string userName)
        {
            logger.Log($"{userName} sunucuya giriş yaptı.");
        }

        public void RemoveClient(ClientHandler clientHandler)
        {
            removeClientFromList(clientHandler.GetClient());
            logger.Log("İstemci bağlantısı kapatıldı.");
        }

        public void BroadcastMessage(string message, TcpClient senderClient)
        {
            broadcaster.Broadcast(message, clients, senderClient);
        }

        public void AddMessageToChat(string message)
        {
            addMessageToChat(message);
        }
    }
}
