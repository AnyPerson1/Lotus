namespace Lotus_Server_Form.Forms
{
    partial class LogLayer2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_LogLayer2 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lb_LogLayer2
            // 
            this.lb_LogLayer2.BackColor = System.Drawing.Color.Black;
            this.lb_LogLayer2.ForeColor = System.Drawing.Color.Lime;
            this.lb_LogLayer2.FormattingEnabled = true;
            this.lb_LogLayer2.Location = new System.Drawing.Point(10, 11);
            this.lb_LogLayer2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lb_LogLayer2.Name = "lb_LogLayer2";
            this.lb_LogLayer2.Size = new System.Drawing.Size(923, 121);
            this.lb_LogLayer2.TabIndex = 0;
            // 
            // LogLayer2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(944, 143);
            this.Controls.Add(this.lb_LogLayer2);
            this.ForeColor = System.Drawing.Color.Lime;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "LogLayer2";
            this.Text = "LOG LAYER 2";
            this.Load += new System.EventHandler(this.LogLayer2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lb_LogLayer2;
    }
}