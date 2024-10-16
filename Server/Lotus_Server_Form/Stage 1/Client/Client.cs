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

namespace Lotus_Server_Form.Stage_1.Client
{
    internal class Client : DataRecieve
    {
        private Thread clientThread;

        // Constructor
        public Client(TcpClient client) : base(client) // DataRecieve sınıfının constructor'ını çağır
        {
            clientThread = new Thread(StartListening);
            clientThread.Start();
        }

        // Dinleme metodu
        private void StartListening()
        {
            SetStatus(true);

            while (true)
            {
                try
                {
                    var data = StartListeningClient();
                    if (data != null)
                    {
                        // Veriyi işleme al
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
        protected TcpClient AcceptClient()
        {
            TcpClient clientToAccept;
            while (true)
            {
                clientToAccept = StaticVariables.Listener.AcceptTcpClient();
                if (clientToAccept != null) 
                { 
                    return clientToAccept;
                }
            }

        }
    }
}
