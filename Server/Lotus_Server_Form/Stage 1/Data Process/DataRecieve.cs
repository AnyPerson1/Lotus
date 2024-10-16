using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Server.Stage1.Libraries;
using Server.Passive;

namespace Server.Stage1.DataRecieve
{
    class DataRecieve : Data
    {
        private bool Run;
        private NetworkStream clientStream;
        private TcpClient client;
        

        public DataRecieve(TcpClient client)
        {
            this.client = client;
            clientStream = this.client.GetStream();
            if (SetClient(client,clientStream))
                return;
            else
            {
                ServerWarningCode warning = new ServerWarningCode("W0002");
            }

        }
        
        public void SetStatus(bool status)
        {
            Run = status;
        } // döngünün çalışma izni olup olmadığını belirle

        public string[] StartListeningClient()
        {
            string[] dataToGo = new string[4];
            if (!Run)
            {
                ServerConsole.Log($"Client dinleme işlemi için izin yok! {client.ToString()}");
                return null;
            }
            else
            {
                while (true)
                {
                    dataToGo = Recieve();
                    if (dataToGo != null)
                    {
                        return dataToGo;
                    }
                }
            }
        } // istemciyi dinle

    }
}
