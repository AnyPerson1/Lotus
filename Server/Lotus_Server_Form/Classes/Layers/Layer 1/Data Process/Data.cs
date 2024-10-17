using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Server.Logger;

namespace Server.Stage1.Libraries
{
    internal class Data
    {
        TcpClient dataClient;
        NetworkStream dataStream;

        protected virtual bool SetClient(TcpClient client, NetworkStream stream)
        {
            dataClient = client;
            dataStream = stream;
            return dataClient == null || dataStream == null;
        }

        protected async Task<string[]> RecieveAsync() //type, message, serverCode, RoomCode
        {
            try
            {
                byte[] buffer = new byte[1024];
                using (var memoryStream = new MemoryStream())
                {
                    DateTime startTime = DateTime.Now;
                    int bytesRead = await dataStream.ReadAsync(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                    {
                        return null; // Bağlantı kapalı
                    }

                    memoryStream.Write(buffer, 0, bytesRead);
                    string receivedMessage = Encoding.UTF8.GetString(memoryStream.ToArray());

                    string[] splitMessage = receivedMessage.Split(';');
                    DateTime endTime = DateTime.Now;
                    TimeSpan duration = endTime - startTime;
                    Logger.Logger.Log($"Data recieved from {dataClient.Client.RemoteEndPoint}: {memoryStream.Length} bytes.({duration.TotalMilliseconds}ms)",Logger.Logger.LogLayer.Layer1);
                    return splitMessage.Length == 4 ? splitMessage : null;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Hata: {ex.Message}");
                return null;
            }
        }
    }

}
