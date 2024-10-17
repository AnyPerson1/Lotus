using Server.Stage1.DataRecieve;
using Server.Stage1.Libraries;
using Server.StaticVariables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Server.Stage2.Orientation;
using System.Diagnostics;

namespace Lotus_Server_Form.Stage_1.Client
{
    internal class Client
    {
        // Constructor
        TcpClient client;
        public Client(TcpClient client) // DataRecieve sınıfının constructor'ını çağır
        {
            DataRecieve dr = new DataRecieve();
            this.client = client;
            _ = StartListeningAsync(); // Asenkron dinlemeyi başlat
        }

        // Asenkron dinleme metodu
        private async Task StartListeningAsync()
        {
            DataSetStatus(true);
            Distribution distribution = new Distribution();
            while (true)
            {
                try
                {
                    var data = await StartListeningClientAsync();
                    if (data != null)
                    {
                        distribution.DefineMessage(data,client,false);
                    }
                }
                catch (Exception ex)
                {
                    // Hata mesajını loglayabilir veya işleyebilirsiniz
                    Console.WriteLine($"Hata: {ex.Message}");
                    break; // Hata durumunda döngüden çık
                }
            }
        }

        protected async Task<TcpClient> AcceptClientAsync()
        {
            while (true)
            {
                TcpClient clientToAccept = await StaticVariables.Listener.AcceptTcpClientAsync();
                if (clientToAccept != null)
                {
                    return clientToAccept;
                }
            }
        }
    }

}
