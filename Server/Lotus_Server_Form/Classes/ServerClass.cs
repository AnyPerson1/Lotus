using Lotus_Server_Form;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Whispery.Server.StaticVariables
{
    static partial class ServerHandler
    {
        public static TcpListener messageListener { get; set; }
        public static TcpListener reportListener { get; set; }
        public static TcpListener voiceListener { get; set; }
        public static List<ClientHandler> messageClients { get; set; }
        public static List<ClientHandler> reportClients { get; set; }
        public static List<ClientHandler> voiceClients { get; set; }
        public static EventLogger eventLogger { get; set; }
        public static DataBroadcaster broadcaster { get; set; }

    }
}
