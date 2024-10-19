using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Server.Passive;

namespace Server.Stage2.Orientation
{
    internal sealed class Distribution : Broadcasting
    {
        private TcpClient _tcpClient;
        public void DefineMessage(string[] data,TcpClient sender, bool Addressing)
        {

            _tcpClient = sender;
            if (StaticVariables.StaticVariables.status)
            {
                switch (data[0])
                {
                    case "Report":
                        ReportMessage(data[1], _tcpClient);
                        break;
                    case "Message":
                        SendMessage(data, Addressing);
                        break;
                    case "Voice":
                        SendVoice(data, Addressing);
                        break;
                    default:
                        break;

                }
            }
        }
        private void ReportMessage(string code, TcpClient client)
        {
            ServerWarningCode warning = new ServerWarningCode(code);
            Logger.Logger.Log(client.Client.RemoteEndPoint + " : " + code, Logger.Logger.LogLayer.Layer3);
        }
        private void SendVoice(string[] data, bool addressing) // adresleme şuan çalışmıyor
        {
            string dataToGo = "Voice;" + data[1];
            Broadcast(dataToGo,_tcpClient);
        }
        private void SendMessage(string[] data, bool addressing) // adresleme şuan çalışmıyor
        {
            string dataToGo = "Message;" + data[1];
            Broadcast(dataToGo, _tcpClient);
        }
    }
}
