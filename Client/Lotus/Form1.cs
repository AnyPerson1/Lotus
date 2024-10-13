using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Lotus
{
    public partial class Form1 : Form
    {
        Form2 frm2;
        public string KullaniciAdi { get; private set; }
        string UserName, UserPassword;

        //private FormWindowState previousWindowState;
        //private FormBorderStyle previousBorderStyle;
        //private bool isMaximized = false;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        private bool isPanelOpen = true;
        private int panelMaxHeight = 532;
        private int panelMinHeight = 36;

        public Form1()
        {
            InitializeComponent();
            pnl1.Height = panelMaxHeight;
            tb_sifre.PasswordChar = '*';
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btn_max_Click(object sender, EventArgs e)
        {
            //if (isMaximized)
            //{
            //    this.WindowState = previousWindowState;
            //    this.FormBorderStyle = previousBorderStyle;
            //    this.TopMost = false;
            //    isMaximized = false;
            //}
            //else
            //{
            //    previousWindowState = this.WindowState;
            //    previousBorderStyle = this.FormBorderStyle;

            //    this.WindowState = FormWindowState.Maximized;
            //    this.FormBorderStyle = FormBorderStyle.None;
            //    this.TopMost = true;
            //    isMaximized = true;
            //}
        }

        private void btn_min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();   
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void tm1_pnl1_Tick(object sender, EventArgs e)
        {
            if (isPanelOpen)
            {
                // Paneli kapat
                if (pnl2.Height > panelMinHeight)
                {
                    pnl2.Height -= 10; // 10 piksel küçült
                    if (pnl2.Height <= panelMinHeight)
                    {
                        tm1_pnl1.Stop();
                        isPanelOpen = false;
                    }
                }
            }
            else
            {
                // Paneli aç
                if (pnl2.Height < panelMaxHeight)
                {
                    pnl2.Height += 10; // 10 piksel büyüt
                    if (pnl2.Height >= panelMaxHeight)
                    {
                        tm1_pnl1.Stop();
                        isPanelOpen = true;
                    }
                }
            }
        }

        private void btn_Bitir_Click(object sender, EventArgs e)
        {
            UserName = tb_kAdi.Text;
            UserPassword = tb_sifre.Text;
            this.KullaniciAdi = UserName;
            frm2 = new Form2(UserName);
            frm2.Show();
            this.Hide();
        }

        private void btn_geri1_Click(object sender, EventArgs e)
        {

        }

        private void btn_kOlustur_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_kAdi.Text))
            {
                MessageBox.Show("Sana '         ' diye hitap edemem! Adını gir.");
            }
            else if (tb_kAdi.Text.Length < 5)
            {
                MessageBox.Show("Üzgünüm ancak kullanıcı adın 'biraz' daha uzun olmalı");
            }
            else if (string.IsNullOrEmpty(tb_sifre.Text))
            {
                MessageBox.Show("Dostum şifre girmezsen hesabın çalınabilir. Bu olsun istemeyiz, dimi?");
            }
            else if (tb_sifre.Text.Length < 8)
            {
                MessageBox.Show("Gerçekten " + tb_sifre.Text.Length + " haneli bir şifre mi koyacaksın? Biraz basit olmaz mı?");
            }
            else
            {
                tm1_pnl1.Start();
            }
        }

        private void topPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // kayıt Ekranı
        {

        }

        private void cb_sifregg_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_sifregg.Checked)
            {
                tb_sifre.PasswordChar = '\0';
                cb_sifregg.Text = "Gizle";
            }
            else
            {
                tb_sifre.PasswordChar = '*';
                cb_sifregg.Text = "Göster";

            }
        }
    }
}
