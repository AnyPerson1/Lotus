namespace Lotus
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
            this.components = new System.ComponentModel.Container();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_sifregg = new System.Windows.Forms.CheckBox();
            this.tb_sifre = new System.Windows.Forms.TextBox();
            this.tb_kAdi = new System.Windows.Forms.TextBox();
            this.btn_geri1 = new System.Windows.Forms.Button();
            this.btn_kOlustur = new System.Windows.Forms.Button();
            this.lbl_hosgeldin = new System.Windows.Forms.Label();
            this.btn_Bitir = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.btn_min = new System.Windows.Forms.Button();
            this.btn_max = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.tm1_pnl1 = new System.Windows.Forms.Timer(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pnl1.SuspendLayout();
            this.pnl2.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl1
            // 
            this.pnl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnl1.Controls.Add(this.pnl2);
            this.pnl1.Controls.Add(this.lbl_hosgeldin);
            this.pnl1.Controls.Add(this.btn_Bitir);
            this.pnl1.Location = new System.Drawing.Point(12, 75);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(973, 532);
            this.pnl1.TabIndex = 0;
            // 
            // pnl2
            // 
            this.pnl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnl2.Controls.Add(this.linkLabel1);
            this.pnl2.Controls.Add(this.label3);
            this.pnl2.Controls.Add(this.label2);
            this.pnl2.Controls.Add(this.label1);
            this.pnl2.Controls.Add(this.cb_sifregg);
            this.pnl2.Controls.Add(this.tb_sifre);
            this.pnl2.Controls.Add(this.tb_kAdi);
            this.pnl2.Controls.Add(this.btn_geri1);
            this.pnl2.Controls.Add(this.btn_kOlustur);
            this.pnl2.Location = new System.Drawing.Point(0, 0);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(973, 542);
            this.pnl2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(472, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Şifre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(445, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Kullanıcı Adı:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(332, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 74);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sana Nasıl Hitap Edelim?\r\n            \"Kullanıcı\"";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cb_sifregg
            // 
            this.cb_sifregg.AutoSize = true;
            this.cb_sifregg.Location = new System.Drawing.Point(588, 291);
            this.cb_sifregg.Name = "cb_sifregg";
            this.cb_sifregg.Size = new System.Drawing.Size(57, 17);
            this.cb_sifregg.TabIndex = 4;
            this.cb_sifregg.Text = "Göster";
            this.cb_sifregg.UseVisualStyleBackColor = true;
            this.cb_sifregg.CheckedChanged += new System.EventHandler(this.cb_sifregg_CheckedChanged);
            // 
            // tb_sifre
            // 
            this.tb_sifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_sifre.Location = new System.Drawing.Point(406, 284);
            this.tb_sifre.Name = "tb_sifre";
            this.tb_sifre.Size = new System.Drawing.Size(176, 26);
            this.tb_sifre.TabIndex = 3;
            // 
            // tb_kAdi
            // 
            this.tb_kAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_kAdi.Location = new System.Drawing.Point(406, 217);
            this.tb_kAdi.Name = "tb_kAdi";
            this.tb_kAdi.Size = new System.Drawing.Size(176, 26);
            this.tb_kAdi.TabIndex = 2;
            // 
            // btn_geri1
            // 
            this.btn_geri1.BackColor = System.Drawing.SystemColors.ControlText;
            this.btn_geri1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_geri1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_geri1.Location = new System.Drawing.Point(316, 367);
            this.btn_geri1.Name = "btn_geri1";
            this.btn_geri1.Size = new System.Drawing.Size(176, 59);
            this.btn_geri1.TabIndex = 1;
            this.btn_geri1.Text = "Geri Dön";
            this.btn_geri1.UseVisualStyleBackColor = false;
            this.btn_geri1.Click += new System.EventHandler(this.btn_geri1_Click);
            // 
            // btn_kOlustur
            // 
            this.btn_kOlustur.BackColor = System.Drawing.SystemColors.ControlText;
            this.btn_kOlustur.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_kOlustur.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_kOlustur.Location = new System.Drawing.Point(508, 368);
            this.btn_kOlustur.Name = "btn_kOlustur";
            this.btn_kOlustur.Size = new System.Drawing.Size(176, 59);
            this.btn_kOlustur.TabIndex = 1;
            this.btn_kOlustur.Text = "Giriş";
            this.btn_kOlustur.UseVisualStyleBackColor = false;
            this.btn_kOlustur.Click += new System.EventHandler(this.btn_kOlustur_Click);
            // 
            // lbl_hosgeldin
            // 
            this.lbl_hosgeldin.AutoSize = true;
            this.lbl_hosgeldin.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_hosgeldin.ForeColor = System.Drawing.Color.Navy;
            this.lbl_hosgeldin.Location = new System.Drawing.Point(345, 256);
            this.lbl_hosgeldin.Name = "lbl_hosgeldin";
            this.lbl_hosgeldin.Size = new System.Drawing.Size(282, 37);
            this.lbl_hosgeldin.TabIndex = 1;
            this.lbl_hosgeldin.Text = "LOTUS\'a HOŞGELDİN!\r\n";
            // 
            // btn_Bitir
            // 
            this.btn_Bitir.BackColor = System.Drawing.SystemColors.ControlText;
            this.btn_Bitir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Bitir.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Bitir.Location = new System.Drawing.Point(393, 368);
            this.btn_Bitir.Name = "btn_Bitir";
            this.btn_Bitir.Size = new System.Drawing.Size(176, 59);
            this.btn_Bitir.TabIndex = 0;
            this.btn_Bitir.Text = "Konuşmya Başla";
            this.btn_Bitir.UseVisualStyleBackColor = false;
            this.btn_Bitir.Click += new System.EventHandler(this.btn_Bitir_Click);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Black;
            this.topPanel.Controls.Add(this.btn_min);
            this.topPanel.Controls.Add(this.btn_max);
            this.topPanel.Controls.Add(this.btn_close);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(997, 52);
            this.topPanel.TabIndex = 1;
            this.topPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.topPanel_Paint);
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            // 
            // btn_min
            // 
            this.btn_min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_min.BackColor = System.Drawing.Color.Black;
            this.btn_min.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_min.Location = new System.Drawing.Point(898, 12);
            this.btn_min.Name = "btn_min";
            this.btn_min.Size = new System.Drawing.Size(25, 25);
            this.btn_min.TabIndex = 0;
            this.btn_min.Text = "-";
            this.btn_min.UseVisualStyleBackColor = false;
            this.btn_min.Click += new System.EventHandler(this.btn_min_Click);
            // 
            // btn_max
            // 
            this.btn_max.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_max.BackColor = System.Drawing.Color.Black;
            this.btn_max.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_max.Location = new System.Drawing.Point(929, 12);
            this.btn_max.Name = "btn_max";
            this.btn_max.Size = new System.Drawing.Size(25, 25);
            this.btn_max.TabIndex = 0;
            this.btn_max.Text = "#";
            this.btn_max.UseVisualStyleBackColor = false;
            this.btn_max.Click += new System.EventHandler(this.btn_max_Click);
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.BackColor = System.Drawing.Color.Black;
            this.btn_close.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_close.Location = new System.Drawing.Point(960, 12);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(25, 25);
            this.btn_close.TabIndex = 0;
            this.btn_close.Text = "X";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // tm1_pnl1
            // 
            this.tm1_pnl1.Interval = 10;
            this.tm1_pnl1.Tick += new System.EventHandler(this.tm1_pnl1_Tick);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(403, 325);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(121, 13);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Kayıt yok mu? Hesap ol.";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(997, 619);
            this.Controls.Add(this.pnl1);
            this.Controls.Add(this.topPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.pnl2.ResumeLayout(false);
            this.pnl2.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button btn_min;
        private System.Windows.Forms.Button btn_max;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_Bitir;
        private System.Windows.Forms.Timer tm1_pnl1;
        private System.Windows.Forms.Label lbl_hosgeldin;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Button btn_kOlustur;
        private System.Windows.Forms.Button btn_geri1;
        private System.Windows.Forms.TextBox tb_kAdi;
        private System.Windows.Forms.TextBox tb_sifre;
        private System.Windows.Forms.CheckBox cb_sifregg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

