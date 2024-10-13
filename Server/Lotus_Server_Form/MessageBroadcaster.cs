using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Lotus_Server_Form
{
    internal class MessageBroadcaster
    {
        public void Broadcast(string message, List<ClientHandler> clients, TcpClient sender)
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
    }
}
