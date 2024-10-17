using Server.Logger;
using Server.StaticVariables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Lotus_Server_Form.Stage_1.Client
{
    internal sealed class ClientManager : Client
    {
        TcpClient client;
        public ClientManager() : base(new TcpClient()) { }

        public async Task GetClientAsync() // işlemler başlarken kullanılacak method
        {
            client = await AcceptClientAsync();
            if (client != null)
            {
                Client clientInstance = new Client(client);
                StaticVariables.Clients.Add(client);
                Logger.Log($"{client.Client.RemoteEndPoint} bağlandı.",Logger.LogLayer.Layer1);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Client onaylama sırasında sıradışı bir hata meydana geldi.");
            }
        }
    }

}
