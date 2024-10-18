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

namespace Login
{
    public partial class Form1 : Form
    {
        string usName, password;
        Kaydol kyt = new Kaydol();
        Forgetpassword frgPass = new Forgetpassword();

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;

        public const int HTCAPTION = 0x2;

        public Form1()
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

        private void tb_acName_Enter(object sender, EventArgs e)
        {
            tb_acName.Text = "";
            tb_acName.ForeColor = Color.Black;
        }

        private void tb_acName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_acName.Text))
            {
                setPlaceHolder();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_pass.Text))
            {
                setPlaceHolder();
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            tb_pass.PasswordChar = '*';
            tb_pass.Text = "";
            tb_pass.ForeColor = Color.Black;
        }

        private void cb_pass_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_pass.Checked)
            {
                tb_pass.PasswordChar = '\0';
                cb_pass.Text = "Gizle";
            }
            else
            {
                tb_pass.PasswordChar = '*';
                cb_pass.Text = "Göster";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            kyt.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frgPass.Show();
            this.Hide();
        }

        private void setPlaceHolder()
        {
            tb_pass.PasswordChar = '\0';
            tb_acName.Text = "Hesap adınızı giriniz";
            tb_acName.ForeColor = Color.Gray;
            tb_pass.Text = "Şifrenizi giriniz";
            tb_pass.ForeColor = Color.Gray;
        }

    }
}
