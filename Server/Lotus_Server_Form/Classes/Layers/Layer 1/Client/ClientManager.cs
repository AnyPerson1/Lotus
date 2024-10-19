using Google.Protobuf.WellKnownTypes;
using Server.Logger;
using Server.Stage2.Orientation;
using Server.StaticVariables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lotus_Server_Form.Stage_1.Client
{
    internal partial class ClientManager
    {
        private Thread dataThread;
        private CancellationTokenSource dcts;
        private TcpClient client;
        private NetworkStream stream;

        public ClientManager(TcpClient client) 
        {
            this.client = client;
            stream = client.GetStream();
        }
        public void StartThread()
        {
            dataThread = new Thread(Recieve);
            dataThread.Start(); // clientten gelen veriyi okuma işlemine başla
            if (StaticVariables.Log1.InvokeRequired)
            {
                StaticVariables.Log1.Invoke(new Action(() =>
                {
                    Logger.Log("Yeni bir client için thread başlatıldı : " + DateTime.Now, Logger.LogLayer.Layer3);
                }));
            }
            else
            {
                Logger.Log("Yeni bir client için thread başlatıldı : " + DateTime.Now, Logger.LogLayer.Layer3);
            }
        }
        private void Recieve()
        {
            dcts = new CancellationTokenSource();
            var token = dcts.Token;
            try
            {
                if (StaticVariables.status)
                {
                    while (true)
                    {
                        byte[] buffer = new byte[1024];
                        using (var memoryStream = new MemoryStream())
                        {
                            int bytesRead = stream.Read(buffer, 0, buffer.Length);

                            if (bytesRead > 0)
                            {
                                DateTime startTime = DateTime.Now;
                                memoryStream.Write(buffer, 0, bytesRead);
                                string receivedMessage = Encoding.UTF8.GetString(memoryStream.ToArray());

                                string[] splitMessage = receivedMessage.Split(';');
                                Distribution distribution = new Distribution();
                                distribution.DefineMessage(splitMessage, client, false);
                                DateTime endTime = DateTime.Now;
                                TimeSpan duration = endTime - startTime;
                                if (StaticVariables.Log1.InvokeRequired)
                                {
                                    StaticVariables.Log1.Invoke(new Action(() =>
                                    {
                                        Logger.Log($"Data received from {client.Client.RemoteEndPoint}: {memoryStream.Length} bytes. ({duration.TotalMilliseconds}ms)", Logger.LogLayer.Layer1);
                                    }));
                                }
                                else
                                {
                                    Logger.Log($"Data received from {client.Client.RemoteEndPoint}: {memoryStream.Length} bytes. ({duration.TotalMilliseconds}ms)", Logger.LogLayer.Layer1);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (StaticVariables.Log2.InvokeRequired)
                {
                    StaticVariables.Log2.Invoke(new Action(() =>
                    {
                        Logger.Log(client.Client.RemoteEndPoint + " bağlantısı kesildi.", Logger.LogLayer.Layer2);
                        Logger.Log("Thread disposed : " + dataThread, Logger.LogLayer.Layer2);
                    }));
                }
                else
                {
                    Logger.Log(client.Client.RemoteEndPoint + " bağlantısı kesildi.", Logger.LogLayer.Layer2);
                    Logger.Log("Thread disposed : " + dataThread, Logger.LogLayer.Layer2);
                }
                client.Close();
                System.Windows.Forms.MessageBox.Show("ClientManager :"+ex.ToString());
                dcts.Cancel();
                dataThread.Join();
            }
        }
    }

}
