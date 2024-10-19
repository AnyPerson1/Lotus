using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotus.Classes
{
    internal class Recieve_Send
    {
        public static void SendMessage(string message, int serverAdress, int roomAdress)
        {

        }
        public void SendMessage(string message)
        {
            try
            {
                string fullMessage = message;
                byte[] data = Encoding.UTF8.GetBytes(fullMessage);
                StaticV.stream.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Mesaj gönderme hatası: {ex.Message}");
            }
        }

    }
}
