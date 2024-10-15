using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Whispery.Server.StaticVariables;

namespace Lotus_Server_Form
{
    partial class ServerHandler
    {
        private bool isRunning;
        private Thread serverThread;
        private Action<string> updateEventLog;
        private Action<TcpClient> addClientToList;
        private Action<TcpClient> removeClientFromList;
        private Action<string> addMessageToChat;

        public ServerHandler(int port, int reportPort, Action<string> logEventAction, Action<TcpClient> addClientAction, Action<TcpClient> removeClientAction, Action<string> addChatMessageAction)
        {
            Whispery.Server.StaticVariables.ServerHandler.messageListener = new TcpListener(IPAddress.Any, port);
            Whispery.Server.StaticVariables.ServerHandler.reportListener = new TcpListener(IPAddress.Any, reportPort);
            Whispery.Server.StaticVariables.ServerHandler.messageClients = new List<ClientHandler>();
            Whispery.Server.StaticVariables.ServerHandler.eventLogger = new EventLogger(logEventAction);
            Whispery.Server.StaticVariables.ServerHandler.broadcaster = new DataBroadcaster();
            updateEventLog = logEventAction;
            addClientToList = addClientAction;
            removeClientFromList = removeClientAction;
            addMessageToChat = addChatMessageAction;
        }

        public ServerHandler() { }

        #region ServerStatus
        public bool Start()
        {
            bool status = true;
            try
            {
                Whispery.Server.StaticVariables.ServerHandler.messageListener.Start();
                Whispery.Server.StaticVariables.ServerHandler.eventLogger.Log("Mesaj portu dinleniliyor.");
                status = true;
            }
            catch (Exception ex)
            {
                Whispery.Server.StaticVariables.ServerHandler.eventLogger.Log("Mesaj portu başlatılamadı : " + ex.ToString());
                status = false;
            }
            try
            {
                Whispery.Server.StaticVariables.ServerHandler.reportListener.Start();
                Whispery.Server.StaticVariables.ServerHandler.eventLogger.Log("Report portu dinleniliyor");
                status = true;
            }
            catch (Exception ex)
            {
                Whispery.Server.StaticVariables.ServerHandler.eventLogger.Log("Reporter portu başlatılamadı : " + ex.ToString());
                status = false;
            }
            if (status)
            {
                isRunning = true;
                serverThread = new Thread(ListenForClients);
                serverThread.Start();
                Whispery.Server.StaticVariables.ServerHandler.eventLogger.Log("Sunucu başarıyla başlatıldı.");
            }
            return status;
        }

        public void Stop()
        {
            isRunning = false;
            foreach (var client in Whispery.Server.StaticVariables.ServerHandler.messageClients)
            {
                client.Disconnect();
            }
            Whispery.Server.StaticVariables.ServerHandler.messageListener.Stop();
            Whispery.Server.StaticVariables.ServerHandler.reportListener.Stop(); // Rapor dinleyicisini durdur
            Whispery.Server.StaticVariables.ServerHandler.eventLogger.Log("Sunucu kapatıldı.");
        }
        #endregion

        #region ClientProgress
        private void ListenForClients()
        {
            Thread messageListenerThread = new Thread(ListenForMessageClients);
            Thread reportListenerThread = new Thread(ListenForReportClients);
            messageListenerThread.Start();
            reportListenerThread.Start();
        }

        private void ListenForMessageClients()
        {
            while (isRunning)
            {
                try
                {
                    TcpClient tcpClient = Whispery.Server.StaticVariables.ServerHandler.messageListener.AcceptTcpClient();
                    ClientHandler clientHandler = new ClientHandler(tcpClient, this,"bok");
                    lock (Whispery.Server.StaticVariables.ServerHandler.messageClients)
                    {
                        Whispery.Server.StaticVariables.ServerHandler.messageClients.Add(clientHandler);
                    }
                    clientHandler.Start();
                    addClientToList(tcpClient);
                    Whispery.Server.StaticVariables.ServerHandler.eventLogger.Log("Yeni mesaj istemcisi katıldı.");
                }
                catch (SocketException ex)
                {
                    if (isRunning)
                    {
                        Whispery.Server.StaticVariables.ServerHandler.eventLogger.Log($"SocketException: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    Whispery.Server.StaticVariables.ServerHandler.eventLogger.Log($"Hata: {ex.Message}");
                }
            }
        }

        private void ListenForReportClients()
        {
            while (isRunning)
            {
                try
                {
                    TcpClient reportClient = Whispery.Server.StaticVariables.ServerHandler.reportListener.AcceptTcpClient();
                    // Rapor istemcisi için yeni bir ClientHandler oluşturma
                    ClientHandler reportClientHandler = new ClientHandler(reportClient, this,"Report");
                    lock (Whispery.Server.StaticVariables.ServerHandler.reportClients)
                    {
                        Whispery.Server.StaticVariables.ServerHandler.reportClients.Add(reportClientHandler);
                    }
                    reportClientHandler.Start();
                    Whispery.Server.StaticVariables.ServerHandler.eventLogger.Log("Yeni rapor istemcisi katıldı.");
                }
                catch (SocketException ex)
                {
                    if (isRunning)
                    {
                        Whispery.Server.StaticVariables.ServerHandler.eventLogger.Log($"SocketException: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    Whispery.Server.StaticVariables.ServerHandler.eventLogger.Log($"Hata: {ex.Message}");
                }
            }
        }

        public void RemoveClient(ClientHandler clientHandler)
        {
            TcpClient client = clientHandler.GetClient();
            removeClientFromList(client);
            client.Dispose();
            Whispery.Server.StaticVariables.ServerHandler.eventLogger.Log("İstemci bağlantısı kapatıldı : " + client.ToString());
        }

        public void RemoveClient(TcpClient client)
        {
            removeClientFromList(client);
            client.Dispose();
            Whispery.Server.StaticVariables.ServerHandler.eventLogger.Log("İstemci bağlantısı kapatıldı : " + client.ToString());
        }
        #endregion

        #region Message
        public void BroadcastMessage(string message, TcpClient senderClient)
        {
            Whispery.Server.StaticVariables.ServerHandler.broadcaster.MessageBroadcast(message, Whispery.Server.StaticVariables.ServerHandler.messageClients, senderClient);
        }

        public void AddMessageToChat(string message)
        {
            addMessageToChat(message);
        }
        #endregion
    }
}
