namespace Lotus_Server_Form
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbl_durum = new System.Windows.Forms.Label();
            this.btn_SunucuAc = new System.Windows.Forms.Button();
            this.gb_Sunucu = new System.Windows.Forms.GroupBox();
            this.pb_sDurum = new System.Windows.Forms.PictureBox();
            this.gb_bilgiler = new System.Windows.Forms.GroupBox();
            this.lb_bilgiler = new System.Windows.Forms.ListBox();
            this.lb_kullanıcılar = new System.Windows.Forms.ListBox();
            this.gb_kullanıcılar = new System.Windows.Forms.GroupBox();
            this.gb_chat = new System.Windows.Forms.GroupBox();
            this.lb_chat = new System.Windows.Forms.ListBox();
            this.gb_Sunucu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_sDurum)).BeginInit();
            this.gb_bilgiler.SuspendLayout();
            this.gb_kullanıcılar.SuspendLayout();
            this.gb_chat.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_durum
            // 
            this.lbl_durum.AutoSize = true;
            this.lbl_durum.ForeColor = System.Drawing.Color.GreenYellow;
            this.lbl_durum.Location = new System.Drawing.Point(73, 50);
            this.lbl_durum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_durum.Name = "lbl_durum";
            this.lbl_durum.Size = new System.Drawing.Size(126, 16);
            this.lbl_durum.TabIndex = 0;
            this.lbl_durum.Text = "Sunucu Şuan Kapalı";
            // 
            // btn_SunucuAc
            // 
            this.btn_SunucuAc.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_SunucuAc.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_SunucuAc.Location = new System.Drawing.Point(60, 89);
            this.btn_SunucuAc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_SunucuAc.Name = "btn_SunucuAc";
            this.btn_SunucuAc.Size = new System.Drawing.Size(135, 39);
            this.btn_SunucuAc.TabIndex = 1;
            this.btn_SunucuAc.Text = "Suncuyu Başlat";
            this.btn_SunucuAc.UseVisualStyleBackColor = false;
            this.btn_SunucuAc.Click += new System.EventHandler(this.btn_SunucuAc_Click);
            // 
            // gb_Sunucu
            // 
            this.gb_Sunucu.Controls.Add(this.pb_sDurum);
            this.gb_Sunucu.Controls.Add(this.lbl_durum);
            this.gb_Sunucu.Controls.Add(this.btn_SunucuAc);
            this.gb_Sunucu.ForeColor = System.Drawing.Color.GreenYellow;
            this.gb_Sunucu.Location = new System.Drawing.Point(16, 15);
            this.gb_Sunucu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_Sunucu.Name = "gb_Sunucu";
            this.gb_Sunucu.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_Sunucu.Size = new System.Drawing.Size(257, 162);
            this.gb_Sunucu.TabIndex = 2;
            this.gb_Sunucu.TabStop = false;
            this.gb_Sunucu.Text = "Sunucu Durum";
            // 
            // pb_sDurum
            // 
            this.pb_sDurum.BackColor = System.Drawing.Color.Red;
            this.pb_sDurum.Location = new System.Drawing.Point(39, 49);
            this.pb_sDurum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pb_sDurum.Name = "pb_sDurum";
            this.pb_sDurum.Size = new System.Drawing.Size(20, 18);
            this.pb_sDurum.TabIndex = 2;
            this.pb_sDurum.TabStop = false;
            // 
            // gb_bilgiler
            // 
            this.gb_bilgiler.Controls.Add(this.lb_bilgiler);
            this.gb_bilgiler.ForeColor = System.Drawing.Color.GreenYellow;
            this.gb_bilgiler.Location = new System.Drawing.Point(805, 15);
            this.gb_bilgiler.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_bilgiler.Name = "gb_bilgiler";
            this.gb_bilgiler.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_bilgiler.Size = new System.Drawing.Size(257, 524);
            this.gb_bilgiler.TabIndex = 3;
            this.gb_bilgiler.TabStop = false;
            this.gb_bilgiler.Text = "Sunucu Bilgileri";
            // 
            // lb_bilgiler
            // 
            this.lb_bilgiler.FormattingEnabled = true;
            this.lb_bilgiler.ItemHeight = 16;
            this.lb_bilgiler.Location = new System.Drawing.Point(23, 25);
            this.lb_bilgiler.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lb_bilgiler.Name = "lb_bilgiler";
            this.lb_bilgiler.Size = new System.Drawing.Size(212, 484);
            this.lb_bilgiler.TabIndex = 0;
            // 
            // lb_kullanıcılar
            // 
            this.lb_kullanıcılar.FormattingEnabled = true;
            this.lb_kullanıcılar.ItemHeight = 16;
            this.lb_kullanıcılar.Location = new System.Drawing.Point(23, 31);
            this.lb_kullanıcılar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lb_kullanıcılar.Name = "lb_kullanıcılar";
            this.lb_kullanıcılar.Size = new System.Drawing.Size(212, 308);
            this.lb_kullanıcılar.TabIndex = 1;
            // 
            // gb_kullanıcılar
            // 
            this.gb_kullanıcılar.Controls.Add(this.lb_kullanıcılar);
            this.gb_kullanıcılar.ForeColor = System.Drawing.Color.GreenYellow;
            this.gb_kullanıcılar.Location = new System.Drawing.Point(16, 185);
            this.gb_kullanıcılar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_kullanıcılar.Name = "gb_kullanıcılar";
            this.gb_kullanıcılar.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_kullanıcılar.Size = new System.Drawing.Size(257, 354);
            this.gb_kullanıcılar.TabIndex = 4;
            this.gb_kullanıcılar.TabStop = false;
            this.gb_kullanıcılar.Text = "Kullanıcı Listesi";
            // 
            // gb_chat
            // 
            this.gb_chat.Controls.Add(this.lb_chat);
            this.gb_chat.ForeColor = System.Drawing.Color.GreenYellow;
            this.gb_chat.Location = new System.Drawing.Point(281, 16);
            this.gb_chat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_chat.Name = "gb_chat";
            this.gb_chat.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_chat.Size = new System.Drawing.Size(516, 523);
            this.gb_chat.TabIndex = 5;
            this.gb_chat.TabStop = false;
            this.gb_chat.Text = "Chat Data";
            // 
            // lb_chat
            // 
            this.lb_chat.FormattingEnabled = true;
            this.lb_chat.ItemHeight = 16;
            this.lb_chat.Location = new System.Drawing.Point(9, 23);
            this.lb_chat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lb_chat.Name = "lb_chat";
            this.lb_chat.Size = new System.Drawing.Size(497, 484);
            this.lb_chat.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1077, 550);
            this.Controls.Add(this.gb_chat);
            this.Controls.Add(this.gb_kullanıcılar);
            this.Controls.Add(this.gb_bilgiler);
            this.Controls.Add(this.gb_Sunucu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sunucu";
            this.gb_Sunucu.ResumeLayout(false);
            this.gb_Sunucu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_sDurum)).EndInit();
            this.gb_bilgiler.ResumeLayout(false);
            this.gb_kullanıcılar.ResumeLayout(false);
            this.gb_chat.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_durum;
        private System.Windows.Forms.Button btn_SunucuAc;
        private System.Windows.Forms.GroupBox gb_Sunucu;
        private System.Windows.Forms.GroupBox gb_bilgiler;
        private System.Windows.Forms.ListBox lb_bilgiler;
        private System.Windows.Forms.ListBox lb_kullanıcılar;
        private System.Windows.Forms.GroupBox gb_kullanıcılar;
        private System.Windows.Forms.GroupBox gb_chat;
        private System.Windows.Forms.ListBox lb_chat;
        private System.Windows.Forms.PictureBox pb_sDurum;
    }
}

