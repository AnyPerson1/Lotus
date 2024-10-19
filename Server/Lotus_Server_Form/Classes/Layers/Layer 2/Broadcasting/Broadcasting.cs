using Lotus_Server_Form.Stage_1.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Server.StaticVariables;
using Server.Logger;
using Google.Protobuf.WellKnownTypes;
using Org.BouncyCastle.Utilities;

namespace Server.Stage2.Orientation
{
    internal class Broadcasting
    {
        protected void Broadcast(string message, int serverCode, int roomCode,TcpClient sender)
        {

        }
        protected void Broadcast(string message , TcpClient sender)
        {
            try
            {
                if (StaticVariables.StaticVariables.status)
                {
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    List<byte> bytes = new List<byte>(data);
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
                    if (StaticVariables.StaticVariables.Log1.InvokeRequired)
                    {
                        StaticVariables.StaticVariables.Log1.Invoke(new Action(() =>
                        {
                            Logger.Logger.Log($"Broadcasting finished : {bytes.Count} bytes. ({duration.TotalMilliseconds}ms)", Logger.Logger.LogLayer.Layer1);
                        }));
                    }
                    else
                    {
                        Logger.Logger.Log($"Broadcasting finished : {bytes.Count} bytes. ({duration.TotalMilliseconds}ms)", Logger.Logger.LogLayer.Layer1);
                    }

                }
            }
            catch (Exception)
            {

                Logger.Logger.Log($"Broadcast failed.", Logger.Logger.LogLayer.Layer1);
            }
        }
    }
}
