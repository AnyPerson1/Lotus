using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Passive
{
    internal class ServerWarningCode
    {
        public ServerWarningCode(string code) 
        {
            System.Windows.Forms.MessageBox.Show(code);
        }
    }
}
