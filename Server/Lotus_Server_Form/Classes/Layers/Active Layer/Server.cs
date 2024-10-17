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

namespace Server
{
    internal class Server
    {
        private Action<TcpClient> addClientToList;
        private Action<TcpClient> removeClientFromList;
        public Server(int port, Action<TcpClient> addClientAction, Action<TcpClient> removeClientAction)
        {
            StaticVariables.StaticVariables.Listener = new TcpListener(IPAddress.Any, port);
            StaticVariables.StaticVariables.Clients = new System.Collections.Concurrent.ConcurrentBag<TcpClient>();
            addClientToList = addClientAction;
            removeClientFromList = removeClientAction;
        }
        public void Start()
        {
            try
            {
                StaticVariables.StaticVariables.Listener.Start();
                ClientManager cm = new ClientManager();
                cm.GetClientAsync();
                Logger.Logger.Log($"Sunucu başlatıldı | {DateTime.Now}", Logger.Logger.LogLayer.Layer3);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log($"Sunucu başlatılamadı : {ex.ToString()} | {DateTime.Now}", Logger.Logger.LogLayer.Layer3);
            }
            
        }
        public async Task StartAsync()
        {
            try
            {
                StaticVariables.StaticVariables.Listener.Start();
                Logger.Logger.Log($"Sunucu başlatıldı | {DateTime.Now}", Logger.Logger.LogLayer.Layer3);
                ClientManager cm = new ClientManager();
                await cm.GetClientAsync();
            }
            catch (Exception ex)
            {
                Logger.Logger.Log($"Sunucu başlatılamadı: {ex} | {DateTime.Now}", Logger.Logger.LogLayer.Layer3);
                System.Windows.Forms.MessageBox.Show(ex.ToString());
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
