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
using Google.Protobuf.WellKnownTypes;
using Org.BouncyCastle.Utilities;

namespace Server
{
    internal class Server
    {
        private Action<TcpClient> addClientToList;
        private Action<TcpClient> removeClientFromList;
        private TcpClient dataClient;
        private NetworkStream dataStream;
        static CancellationTokenSource cts;
        Thread listeningThread;

        public Server(int port, Action<TcpClient> addClientAction, Action<TcpClient> removeClientAction)
        {
            StaticVariables.StaticVariables.Listener = new TcpListener(IPAddress.Any, port);
            StaticVariables.StaticVariables.Clients = new System.Collections.Concurrent.ConcurrentBag<TcpClient>();
            addClientToList = addClientAction;
            removeClientFromList = removeClientAction;
        }
        private static void ListenClients()
        {
            cts = new CancellationTokenSource();
            var token = cts.Token;
            while (true)
            {
                if (StaticVariables.StaticVariables.status)
                {
                    try
                    {
                        TcpClient clientToAccept = StaticVariables.StaticVariables.Listener.AcceptTcpClient();
                        ClientManager cm = new ClientManager(clientToAccept);
                        if (StaticVariables.StaticVariables.Log1.InvokeRequired)
                        {
                            StaticVariables.StaticVariables.Log1.Invoke(new Action(() =>
                            {
                                Logger.Logger.Log("Yeni bir istemci bağlandı : " + clientToAccept.Client.RemoteEndPoint, Logger.Logger.LogLayer.Layer1);
                            }));
                        }
                        else
                        {
                            Logger.Logger.Log("Yeni bir istemci bağlandı : " + clientToAccept.Client.RemoteEndPoint, Logger.Logger.LogLayer.Layer1);
                        }
                        lock (StaticVariables.StaticVariables.Clients)
                        {
                            StaticVariables.StaticVariables.Clients.Add(clientToAccept);
                        }
                        cm.StartThread(); // veri alımı başladı.
                    }
                    catch (SocketException ex)
                    {
                        // Bu hata, dinleyici durdurulursa beklenen bir durumdur
                        if (!StaticVariables.StaticVariables.status)
                        {
                            return; // Dinleyici kapatılmış, normal sonlandırma
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show(ex.ToString());
                        }
                        throw; // Diğer hataları yeniden fırlat
                    }
                }
            }
            

        }
        public void Start()
        {
            try
            {
                StaticVariables.StaticVariables.status = true;
                StaticVariables.StaticVariables.Listener.Start();
                listeningThread = new Thread(ListenClients);
                listeningThread.Start();
                if (StaticVariables.StaticVariables.Log3.InvokeRequired)
                {
                    StaticVariables.StaticVariables.Log3.Invoke(new Action(() =>
                    {
                        Logger.Logger.Log($"Sunucu başlatıldı | {DateTime.Now}", Logger.Logger.LogLayer.Layer3);
                    }));
                }
                else
                {
                    Logger.Logger.Log($"Sunucu başlatıldı | {DateTime.Now}", Logger.Logger.LogLayer.Layer3);
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Log($"Sunucu başlatılamadı : {ex} | {DateTime.Now}", Logger.Logger.LogLayer.Layer3);
            }
        }

        public void Stop()
        {
            StaticVariables.StaticVariables.status &= false;
            foreach (var client in StaticVariables.StaticVariables.Clients)
            {
                client.Dispose();
            }
            StaticVariables.StaticVariables.Listener.Stop();
            cts.Cancel();
            listeningThread.Join();
            if (StaticVariables.StaticVariables.Log3.InvokeRequired)
            {
                StaticVariables.StaticVariables.Log3.Invoke(new Action(() =>
                {
                    Logger.Logger.Log($"Sunucu kapatıldı | {DateTime.Now}", Logger.Logger.LogLayer.Layer3);
                }));
            }
            else
            {
                Logger.Logger.Log($"Sunucu kapatıldı | {DateTime.Now}", Logger.Logger.LogLayer.Layer3);
            }
        }
    }

}
