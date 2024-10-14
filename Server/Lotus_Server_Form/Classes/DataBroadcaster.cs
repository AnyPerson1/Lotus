using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Lotus_Server_Form
{
    internal class DataBroadcaster
    {
        public void MessageBroadcast(string message, List<ClientHandler> clients, TcpClient sender)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);

            foreach (var client in clients)
            {
                if (client.GetClient() != sender)
                {
                    NetworkStream stream = client.GetClient().GetStream();
                    stream.Write(data, 0, data.Length);
                }
            }
        }
        public void VoiceBroadcast(string voiceData, List<ClientHandler> clients, TcpClient sender)
        {

        }
    }
}
