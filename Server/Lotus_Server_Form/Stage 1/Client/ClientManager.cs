using Server.StaticVariables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Lotus_Server_Form.Stage_1.Client
{
    internal class ClientManager : Client
    {
        TcpClient client;
        public ClientManager() : base (new TcpClient())
        {
            
        }
        public void GetClients()
        {
            client = AcceptClient();
            if (client != null)
            {
                Client clientInstance = new Client(client);
                StaticVariables.Clients.Add(client);
            }
        }
    }
}
