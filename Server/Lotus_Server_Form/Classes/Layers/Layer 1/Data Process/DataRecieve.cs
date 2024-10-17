using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Server.Stage1.Libraries;
using Server.Passive;
using Server.Logger;

namespace Server.Stage1.DataRecieve
{
    internal class DataRecieve : Data
    {
        private bool Run;
        private NetworkStream clientStream;
        private TcpClient client;

        public DataRecieve(TcpClient client)
        {
            if (client != null)
            {
                this.client = client;
                clientStream = this.client.GetStream();
            }
            else
            {

            }
            if (SetClient(client, clientStream))
            {
                ServerWarningCode warning = new ServerWarningCode("W0002");
            }
        }

        protected void SetStatus(bool status)
        {
            Run = status;
        } // döngünün çalışma izni olup olmadığını belirle

        protected async Task<string[]> StartListeningClientAsync()
        {
            if (!Run)
            {
                Logger.Logger.Log($"Client dinleme işlemi için izin yok! {client.Client.RemoteEndPoint}",Logger.Logger.LogLayer.Layer2);
                return null;
            }

            while (true)
            {
                string[] dataToGo = await RecieveAsync();
                if (dataToGo != null)
                {
                    return dataToGo;
                }
            }
        }
    }

}
