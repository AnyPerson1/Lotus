using Lotus_Server_Form.Stage_1.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Server.StaticVariables;
using Server.Logger;

namespace Server.Stage2.Orientation
{
    internal class Broadcasting
    {
        protected void Broadcast(string message, int serverCode, int roomCode,TcpClient sender)
        {

        }
        protected void Broadcast(string message , TcpClient sender)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            List<byte> bytes = new List<byte>(data);
            if (StaticVariables.StaticVariables.Clients.Count > 5)
            {
                DateTime startTime = DateTime.Now;
                foreach (var client in StaticVariables.StaticVariables.Clients)
                {
                    if (client != sender)
                    {
                        NetworkStream stream = client.GetStream();
                        stream.Write(data, 0, data.Length);
                    }
                }
                DateTime endTime = DateTime.Now;
                TimeSpan duration = endTime - startTime;
                Logger.Logger.Log($"Data broadcasted : {bytes.Count} bytes. ({duration.TotalMilliseconds}ms)",Logger.Logger.LogLayer.Layer1);
            }
            else
            {
                foreach (var client in StaticVariables.StaticVariables.Clients)
                {
                    DateTime startTime = DateTime.Now;
                    if (client != sender)
                    {
                        NetworkStream stream = client.GetStream();
                        stream.Write(data, 0, data.Length);
                    }
                    DateTime endTime = DateTime.Now;
                    TimeSpan duration = endTime - startTime;
                    Logger.Logger.Log($"Data sent to {client.Client.RemoteEndPoint}: {bytes.Count} bytes. ({duration.TotalMilliseconds}ms)", Logger.Logger.LogLayer.Layer1);
                }
            }
        }
    }
}
