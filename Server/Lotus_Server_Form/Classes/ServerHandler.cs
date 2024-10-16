using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Server.StaticVariables;

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
            StaticVariables.messageListener = new TcpListener(IPAddress.Any, port);
            StaticVariables.reportListener = new TcpListener(IPAddress.Any, reportPort);
            StaticVariables.messageClients = new List<ClientHandler>();
            StaticVariables.eventLogger = new EventLogger(logEventAction);
            StaticVariables.broadcaster = new DataBroadcaster();
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
                StaticVariables.messageListener.Start();
                StaticVariables.eventLogger.Log("Mesaj portu dinleniliyor.");
                status = true;
            }
            catch (Exception ex)
            {
                StaticVariables.eventLogger.Log("Mesaj portu başlatılamadı : " + ex.ToString());
                status = false;
            }
            try
            {
                StaticVariables.reportListener.Start();
                StaticVariables.eventLogger.Log("Report portu dinleniliyor");
                status = true;
            }
            catch (Exception ex)
            {
                StaticVariables.eventLogger.Log("Reporter portu başlatılamadı : " + ex.ToString());
                status = false;
            }
            if (status)
            {
                isRunning = true;
                serverThread = new Thread(ListenForClients);
                serverThread.Start();
                StaticVariables.eventLogger.Log("Sunucu başarıyla başlatıldı.");
            }
            return status;
        }

        public void Stop()
        {
            isRunning = false;
            foreach (var client in StaticVariables.messageClients)
            {
                client.Disconnect();
            }
            StaticVariables.messageListener.Stop();
            StaticVariables.reportListener.Stop(); // Rapor dinleyicisini durdur
            StaticVariables.eventLogger.Log("Sunucu kapatıldı.");
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
                    TcpClient tcpClient = StaticVariables.messageListener.AcceptTcpClient();
                    ClientHandler clientHandler = new ClientHandler(tcpClient, this,"bok");
                    lock (Server.StaticVariables.StaticVariables.messageClients)
                    {
                        Server.StaticVariables.StaticVariables.messageClients.Add(clientHandler);
                    }
                    clientHandler.Start();
                    addClientToList(tcpClient);
                    Server.StaticVariables.StaticVariables.eventLogger.Log("Yeni mesaj istemcisi katıldı.");
                }
                catch (SocketException ex)
                {
                    if (isRunning)
                    {
                        Server.StaticVariables.StaticVariables.eventLogger.Log($"SocketException: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    Server.StaticVariables.StaticVariables.eventLogger.Log($"Hata: {ex.Message}");
                }
            }
        }

        private void ListenForReportClients()
        {
            while (isRunning)
            {
                try
                {
                    TcpClient reportClient = Server.StaticVariables.StaticVariables.reportListener.AcceptTcpClient();
                    // Rapor istemcisi için yeni bir ClientHandler oluşturma
                    ClientHandler reportClientHandler = new ClientHandler(reportClient, this,"Report");
                    lock (Server.StaticVariables.StaticVariables.reportClients)
                    {
                        Server.StaticVariables.StaticVariables.reportClients.Add(reportClientHandler);
                    }
                    reportClientHandler.Start();
                    Server.StaticVariables.StaticVariables.eventLogger.Log("Yeni rapor istemcisi katıldı.");
                }
                catch (SocketException ex)
                {
                    if (isRunning)
                    {
                        StaticVariables.eventLogger.Log($"SocketException: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    StaticVariables.eventLogger.Log($"Hata: {ex.Message}");
                }
            }
        }

        public void RemoveClient(ClientHandler clientHandler)
        {
            TcpClient client = clientHandler.GetClient();
            removeClientFromList(client);
            client.Dispose();
            StaticVariables.eventLogger.Log("İstemci bağlantısı kapatıldı : " + client.ToString());
        }

        public void RemoveClient(TcpClient client)
        {
            removeClientFromList(client);
            client.Dispose();
            StaticVariables.eventLogger.Log("İstemci bağlantısı kapatıldı : " + client.ToString());
        }
        #endregion

        #region Message
        public void BroadcastMessage(string message, TcpClient senderClient)
        {
            StaticVariables.broadcaster.MessageBroadcast(message, StaticVariables.messageClients, senderClient);
        }

        public void AddMessageToChat(string message)
        {
            addMessageToChat(message);
        }
        #endregion
    }
}
