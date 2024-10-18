using Server.StaticVariables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotus_Server_Form.Forms
{
    public partial class LogLayer3 : Form
    {
        public LogLayer3()
        {
            InitializeComponent();
        }

        private void LogLayer3_Load(object sender, EventArgs e)
        {
            StaticVariables.Log3 = lb_LogLayer3;
        }
    }
}
