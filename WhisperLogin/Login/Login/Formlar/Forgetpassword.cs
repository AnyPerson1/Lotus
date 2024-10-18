using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Login
{
    public partial class Forgetpassword : Form
    {

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;

        public const int HTCAPTION = 0x2;

        public Forgetpassword()
        {
            InitializeComponent();
            setPlaceHolder();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void btn_min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void setPlaceHolder()
        {
            tb_pass.PasswordChar = '\0';
            tb_cPass.PasswordChar = '\0';
            tb_pass.Text = "Yeni şifrenizi girin";
            tb_cPass.Text = "Yeni şifrenizi doğrulayın";
            tb_acName.Text = "Hesap adınızı girin";
            tb_pass.ForeColor = Color.Gray;
            tb_cPass.ForeColor = Color.Gray;
            tb_acName.ForeColor = Color.Gray;
        }

        private void tb_acName_Enter(object sender, EventArgs e)
        {
            if (tb_acName.Text == "Hesap adınızı girin")
            {
                tb_acName.Text = "";
                tb_acName.ForeColor = Color.Black;
            }
        }

        private void tb_pass_Enter(object sender, EventArgs e)
        {
            if (tb_pass.Text == "Yeni şifrenizi girin")
            {
                tb_pass.PasswordChar = '*';
                tb_pass.Text = "";
                tb_pass.ForeColor = Color.Black;
            }
        }

        private void tb_cPass_Enter(object sender, EventArgs e)
        {
            if (tb_cPass.Text == "Yeni şifrenizi doğrulayın")
            {
                tb_cPass.PasswordChar = '*';
                tb_cPass.Text = "";
                tb_cPass.ForeColor = Color.Black;
            }
        }

        private void cb_pass_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_pass.Checked)
            {
                tb_pass.PasswordChar = '\0';
                tb_cPass.PasswordChar = '\0';
                cb_pass.Text = "Gizle";
            }
            else
            {
                tb_pass.PasswordChar = '*';
                tb_cPass.PasswordChar = '*';
                cb_pass.Text = "Göster";
            }
        }
    }
}
