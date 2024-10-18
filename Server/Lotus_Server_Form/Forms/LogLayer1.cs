using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server.StaticVariables;

namespace Lotus_Server_Form.Forms
{
    public partial class LogLayer1 : Form
    {
        public LogLayer1()
        {
            InitializeComponent();
        }

        private void LogLayer1_Load(object sender, EventArgs e)
        {
            StaticVariables.Log1 = lb_LogLayer1;
        }
    }
}
