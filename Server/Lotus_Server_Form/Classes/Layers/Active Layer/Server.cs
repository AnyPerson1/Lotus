using Server.StaticVariables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Server.Logger;
using Lotus_Server_Form.Stage_1.Client;
using System.IO;
using System.Linq.Expressions;

namespace Server
{
    internal class Server
    {
        private Action<TcpClient> addClientToList;
        private Action<TcpClient> removeClientFromList;
        private TcpClient dataClient;
        private NetworkStream dataStream;

        public Server(int port, Action<TcpClient> addClientAction, Action<TcpClient> removeClientAction)
        {
            StaticVariables.StaticVariables.Listener = new TcpListener(IPAddress.Any, port);
            StaticVariables.StaticVariables.Clients = new System.Collections.Concurrent.ConcurrentBag<TcpClient>();
            addClientToList = addClientAction;
            removeClientFromList = removeClientAction;
        }
        private static void ListenClients()
        {
            if (StaticVariables.StaticVariables.status)
            {
                while (true)
                {
                    TcpClient clientToAccept = StaticVariables.StaticVariables.Listener.AcceptTcpClient();
                    ClientManager cm = new ClientManager(clientToAccept);
                    Logger.Logger.Log("Yeni bir istemci bağlandı : " + clientToAccept.Client.RemoteEndPoint, Logger.Logger.LogLayer.Layer1);
                    lock (StaticVariables.StaticVariables.Clients)
                    {
                        StaticVariables.StaticVariables.Clients.Add(clientToAccept);
                    }
                    cm.StartThread(); // veri alımı başladı.
                }
            }

        }
        public void Start()
        {
            try
            {
                StaticVariables.StaticVariables.status = true;
                StaticVariables.StaticVariables.Listener.Start();
                Thread listeningThread = new Thread(ListenClients);
                listeningThread.Start();
                Logger.Logger.Log($"Sunucu başlatıldı | {DateTime.Now}", Logger.Logger.LogLayer.Layer3);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log($"Sunucu başlatılamadı : {ex} | {DateTime.Now}", Logger.Logger.LogLayer.Layer3);
            }
        }

        public void Stop()
        {
            foreach (var client in StaticVariables.StaticVariables.Clients)
            {
                client.Dispose();
            }
            StaticVariables.StaticVariables.Listener.Stop();
            Logger.Logger.Log($"Sunucu kapatıldı | {DateTime.Now}", Logger.Logger.LogLayer.Layer3);
        }
    }

}
