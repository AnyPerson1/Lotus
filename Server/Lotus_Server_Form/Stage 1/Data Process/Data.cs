using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Server.Stage1.Libraries
{
    internal class Data
    {
        TcpClient dataClient; NetworkStream dataStream;
        protected virtual bool SetClient(TcpClient client, NetworkStream stream)
        {
            dataClient = client;
            dataStream = stream;
            if (dataClient != null && dataStream != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        protected string[] Recieve() //type, message, serverCode, RoomCode
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = dataStream.Read(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                    {
                        return null;
                    }

                    string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    string[] splitMessage = receivedMessage.Split(';');
                    if (splitMessage.Length == 4)
                    {
                        return splitMessage;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Hata: {ex.Message}");
                return null;
                throw;
            }

        }


    }
}
