using Login.Classlar;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login.Formlar
{
    public partial class chat : Form
    {
        string mesaj;
        string KulAdi;

        bool isopenTXT = false;
        bool isopenVC = false;
        bool isPanelOpen = false;

        private float easeAmount = 0.0287f; 
        private float progress = 0;       
        private int startHeight, endHeight;

        int pnlMaxHeight = 615;
        int pnlMinHeight = 90;

        private static WaveInEvent waveSource;
        private static WaveOutEvent waveOut;
        private static BufferedWaveProvider waveProvider;
        private bool isRecording = false;

        #region dll-falan-sıkıntı-dokanma

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;

        public const int HTCAPTION = 0x2;
        #endregion

        public chat()
        {
            InitializeComponent();
            btnBorder();
            KulAdi = StaticDegiskenler.GorunenAd;
        }

        private void btnBorder()
        {
            btn_text.FlatAppearance.BorderSize = 0;
            btn_voiceChat.FlatAppearance.BorderSize = 0;
            btn_min.FlatAppearance.BorderSize = 0;
            btn_close.FlatAppearance.BorderSize = 0;
            btn_sncAyar.FlatAppearance.BorderSize = 0;
            btn_gonder.FlatAppearance.BorderSize = 0;
            

            btn_txtchat1.FlatAppearance.BorderSize = 0;
            btn_txtchat1.BackColor = Color.Transparent;
            btn_txtchat1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_txtchat1.FlatAppearance.MouseDownBackColor = Color.Transparent;

            btn_txtchat2.FlatAppearance.BorderSize = 0;
            btn_txtchat2.BackColor = Color.Transparent;
            btn_txtchat2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_txtchat2.FlatAppearance.MouseDownBackColor = Color.Transparent;

            btn_txtchat3.FlatAppearance.BorderSize = 0;
            btn_txtchat3.BackColor = Color.Transparent;
            btn_txtchat3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_txtchat3.FlatAppearance.MouseDownBackColor = Color.Transparent;

            btn_VoiceChat1.FlatAppearance.BorderSize = 0;
            btn_VoiceChat1.BackColor = Color.Transparent;
            btn_VoiceChat1.FlatAppearance.MouseOverBackColor= Color.Transparent;
            btn_VoiceChat1.FlatAppearance.MouseDownBackColor= Color.Transparent;

            btn_VoiceChat2.FlatAppearance.BorderSize = 0;
            btn_VoiceChat2.BackColor = Color.Transparent;
            btn_VoiceChat2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_VoiceChat2.FlatAppearance.MouseDownBackColor = Color.Transparent;

            btn_VoiceChat3.FlatAppearance.BorderSize = 0;
            btn_VoiceChat3.BackColor = Color.Transparent;
            btn_VoiceChat3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_VoiceChat3.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void btn_VoiceChat1_Click(object sender, EventArgs e)
        {
            int selectedInputDeviceIndex = cmbInputDevices.SelectedIndex;
            int selectedOutputDeviceIndex = cmbOutputDevices.SelectedIndex;

            waveSource = new WaveInEvent
            {
                DeviceNumber = selectedInputDeviceIndex,  // Seçilen giriş cihazı
                WaveFormat = new WaveFormat(48000, 24, 2) // 48 kHz, 24-bit, stereo
            };

            waveOut = new WaveOutEvent
            {
                DeviceNumber = selectedOutputDeviceIndex // Seçilen çıkış cihazı
            };

            waveProvider = new BufferedWaveProvider(waveSource.WaveFormat);
            waveOut.Init(waveProvider);

            waveSource.DataAvailable += OnDataAvailable;
            waveSource.RecordingStopped += OnRecordingStopped;

            waveSource.StartRecording();
            waveOut.Play();
            isRecording = true;
            MessageBox.Show("Ses kaydı başladı");
        }
        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            waveProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }

        private void OnRecordingStopped(object sender, StoppedEventArgs e)
        {
            waveOut.Stop();
        }

        private void btn_endCall_Click(object sender, EventArgs e)
        {
            if (isRecording)
            {
                waveSource.StopRecording();
                isRecording = false;
                MessageBox.Show("Ses kaydı durduruldu");
            }
        }
        private void btn_scShare_Click(object sender, EventArgs e)
        {
            
        }
        private void chat_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                var deviceInfo = WaveIn.GetCapabilities(i);
                cmbInputDevices.Items.Add(deviceInfo.ProductName);
            }

            
            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                var deviceInfo = WaveOut.GetCapabilities(i);
                cmbOutputDevices.Items.Add(deviceInfo.ProductName);
            }

            if (cmbInputDevices.Items.Count > 0)
                cmbInputDevices.SelectedIndex = 0; 
            if (cmbOutputDevices.Items.Count > 0)
                cmbOutputDevices.SelectedIndex = 0;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            progress += easeAmount;

            float easedProgress = (float)(-Math.Cos(progress * Math.PI) / 2 + 0.5);
         
            pnl_kulMenu.Height = (int)(startHeight + (endHeight - startHeight) * easedProgress);
            
            if (progress >= 1)
            {
                timer1.Stop();
                isPanelOpen = !isPanelOpen; 
                progress = 0;               
            }
        }

        private void btn_KulMenu_Click(object sender, EventArgs e)
        {
            if (isPanelOpen)
            {
                startHeight = pnlMaxHeight; 
                endHeight = pnlMinHeight;  
            }
            else
            {
                startHeight = pnlMinHeight; 
                endHeight = pnlMaxHeight;
            }

            timer1.Start();
        }

        #region basic
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void btn_gonder_Click(object sender, EventArgs e)
        {
            mesaj = textBox1.Text;
            if (!string.IsNullOrEmpty(mesaj))
            {
                lbChat.Items.Add(KulAdi + ": " + mesaj);
                textBox1.Clear();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            lbl_menu.Text = "Arkadaşlar";
            pnl_üyeler.Visible = false;
            pnl_snc.Visible = false;
        }

        private void btn_s1_Click(object sender, EventArgs e)
        {
            btn_sncAyar.Text = "Sunucu 1";
            pnl_üyeler.Visible = true;
            pnl_snc.Visible = true;
        }

        private void btn_SncEkle_Click(object sender, EventArgs e)
        {

        }

        private void lbl_ark1_Click(object sender, EventArgs e)
        {
            lbl_dmArk.Text = lbl_ark1.Text;
            lbl_dmArk.Visible = true;
        }

        private void lbl_ark2_Click(object sender, EventArgs e)
        {
            lbl_dmArk.Text = lbl_ark2.Text;
            lbl_dmArk.Visible = true;
        }

        private void lbl_ark3_Click(object sender, EventArgs e)
        {
            lbl_dmArk.Text = lbl_ark3.Text;
            lbl_dmArk.Visible = true;
        }

        private void lbl_ark4_Click(object sender, EventArgs e)
        {
            lbl_dmArk.Text = lbl_ark4.Text;
            lbl_dmArk.Visible = true;
        }

        private void btn_text_Click(object sender, EventArgs e)
        {
            if (!isopenTXT)
            {
                pnl_textChat.Visible = true;
                isopenTXT = true;
            }
            else
            {
                pnl_textChat.Visible = false;
                isopenTXT = false;
            }
        }

        private void cbKhzBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbKhzBit.SelectedItem.ToString())
            {
                case "Düşük":
                    StaticDegiskenler.kHz = 8000;
                    StaticDegiskenler.bit = 8;

                    break;
                case "Orta":
                    break;
                case "Yüksek":
                    break;
                case "Ultra":
                    break;
            }
        }

        private void btn_voiceChat_Click(object sender, EventArgs e)
        {
            if (!isopenVC)
            {
                pnl_voice.Visible = true;
                isopenVC = true;
            }
            else
            {
                pnl_voice.Visible = false;
                isopenVC = false;
            }
        }





        #endregion

        
    }
}
