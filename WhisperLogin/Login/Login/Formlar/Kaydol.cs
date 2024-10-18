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
using Login.Formlar;
using Login.Classlar;

namespace Login
{
    public partial class Kaydol : Form
    {
        string acName, usName, password, cPassword, email, ip;
        private Form1 frm1;
        private chat ch1;
        private LoadingForm loadingForm;
        #region dll-falan-sıkıntı-dokanma
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;

        public const int HTCAPTION = 0x2;
        #endregion

        public Kaydol()
        {
            InitializeComponent();
            setPlaceHolder();
        }
        private void Kaydol_Load(object sender, EventArgs e)
        {
            loadingForm = new LoadingForm(); 
            loadingForm.Show();              
            this.Hide();
        }
        private void Kaydol_Shown(object sender, EventArgs e)
        {
            loadingForm.Close(); 
            this.Show();
        }

        #region textB-placeHolder
        private void tb_acName_Enter(object sender, EventArgs e)
        {
            if (tb_acName.Text == "Hesap adınızı girin")
            {
                tb_acName.Text = "";
                tb_acName.ForeColor = Color.Black;
            }
        }

        private void tb_usName_Enter(object sender, EventArgs e)
        {
            if (tb_usName.Text == "Kullanıcı adınızı girin")
            {
                tb_usName.Text = "";
                tb_usName.ForeColor = Color.Black;
            }
           
        }

        private void tb_pass_Enter(object sender, EventArgs e)
        {
            if (tb_pass.Text == "Şifrenizi girin")
            {
                tb_pass.PasswordChar = '*';
                tb_pass.Text = "";
                tb_pass.ForeColor = Color.Black;
            }
        }

        private void tb_cPass_Enter(object sender, EventArgs e)
        {
            if (tb_cPass.Text == "Şifrenizi doğrulayın")
            {
                tb_cPass.PasswordChar = '*';
                tb_cPass.Text = "";
                tb_cPass.ForeColor = Color.Black;
            }
        }

        private void tb_email_Enter(object sender, EventArgs e)
        {
            if (tb_email.Text == "Mail adresinizi girin")
            {
                tb_email.Text = "";
                tb_email.ForeColor = Color.Black;
            }
        }

        private void setPlaceHolder()
        {
            tb_pass.PasswordChar = '\0';
            tb_cPass.PasswordChar = '\0';
            tb_pass.Text = "Şifrenizi girin";
            tb_cPass.Text = "Şifrenizi doğrulayın";
            tb_acName.Text = "Hesap adınızı girin";
            tb_usName.Text = "Kullanıcı adınızı girin";
            tb_email.Text = "Mail adresinizi girin";
            tb_pass.ForeColor = Color.Gray;
            tb_cPass.ForeColor = Color.Gray;
            tb_acName.ForeColor = Color.Gray;
            tb_usName.ForeColor = Color.Gray;
            tb_email.ForeColor = Color.Gray;
        }

        #endregion
        #region random
        private void btn_reset_Click(object sender, EventArgs e)
        {
            setPlaceHolder();
            lbl_hataSifre.Visible = false;
            lbl_hataKulAdi.Visible = false;
            lbl_hataMail.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            acName = tb_acName.Text;
            usName = tb_usName.Text;
            password = tb_pass.Text;
            cPassword = tb_cPass.Text;
            email = tb_email.Text;

            if (tb_acName.Text == "Hesap adınızı girin" || tb_usName.Text == "Kullanıcı adınız girin" || tb_pass.Text == "Şifrenizi girin" || tb_cPass.Text == "Şifrenizi doğrulayın" || tb_email.Text == "Mail adresinizi girin")
            {
                MessageBox.Show("Amq malı boş yer bırakmasana");
            }
            else
            {
                if (string.IsNullOrEmpty(acName) || string.IsNullOrEmpty(usName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(cPassword) || string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Amq malı boş yer bırakmasana");
                }
                else
                {
                    if (tb_pass.Text == "Şifrenizi girin" && tb_cPass.Text == "Şifrenizi doğrulayın")
                    {
                        lbl_hataSifre.Visible = true;
                    }
                    else if (password.Length < 8 && cPassword.Length < 6)
                    {
                        lbl_hataSifre.Text = "Şifreniz 8 harften kısa olamaz.";
                        lbl_hataSifre.Visible = true;
                    }
                    else if (password != cPassword)
                    {
                        lbl_hataSifre.Text = "Şifreleriniz aynı olmalıdır.";
                        lbl_hataSifre.Visible = true;
                    }
                    else if (password.Contains(" ") && cPassword.Contains(" "))
                    {
                        lbl_hataSifre.Text = "Şifreniz boşluk içeremez.";
                        lbl_hataSifre.Visible = true;
                    }
                    if (usName.Contains(" ") && acName.Contains(" "))
                    {
                        lbl_hataKulAdi.Text = "Kullanıcı/Hesap Adınız boşluk içeremez.";
                        lbl_hataKulAdi.Visible = true;
                    }
                    if (usName.Length < 8 && acName.Length < 8)
                    {
                        lbl_hataKulAdi.Text = "Kullanıcı/Hesap Adınız 8 harften kısa olamaz.";
                        lbl_hataKulAdi.Visible = true;
                    }
                    if (!email.Contains("@gmail.com"))
                    {
                        lbl_hataMail.Visible = true;
                    }
                    else
                    {
                        StaticDegiskenler.HesapAdi = this.acName;
                        StaticDegiskenler.GorunenAd = this.usName;
                        StaticDegiskenler.Email = this.email;
                        ch1 = new chat();
                        ch1.Show();
                        this.Hide();
                    }
                }
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
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

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void btn_min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion
    }
}
