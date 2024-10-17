using Lotus_Server_Form;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.StaticVariables
{
    static class StaticVariables
    {
        public static TcpListener Listener { get; set; }
        //public static List<ClientHandler> Clients { get; set; }
        public static ConcurrentBag<TcpClient> Clients { get; set; }
        public static ListBox Log1 { get; set; }
        public static ListBox Log2 { get; set; }
        public static ListBox Log3 { get; set; }


    }
}
