using Lotus_Server_Form;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.StaticVariables
{
    static partial class StaticVariables
    {
        public static TcpListener Listener { get; set; }
        //public static List<ClientHandler> Clients { get; set; }
        public static ConcurrentBag<TcpClient> Clients { get; set; }
        public static EventLogger eventLogger { get; set; }
        public static DataBroadcaster broadcaster { get; set; }

    }
}
