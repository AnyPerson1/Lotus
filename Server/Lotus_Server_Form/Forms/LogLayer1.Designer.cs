namespace Lotus_Server_Form.Forms
{
    partial class LogLayer1
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
            this.lb_LogLayer1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lb_LogLayer1
            // 
            this.lb_LogLayer1.BackColor = System.Drawing.SystemColors.MenuText;
            this.lb_LogLayer1.ForeColor = System.Drawing.Color.Lime;
            this.lb_LogLayer1.FormattingEnabled = true;
            this.lb_LogLayer1.ItemHeight = 16;
            this.lb_LogLayer1.Location = new System.Drawing.Point(13, 13);
            this.lb_LogLayer1.Name = "lb_LogLayer1";
            this.lb_LogLayer1.Size = new System.Drawing.Size(286, 532);
            this.lb_LogLayer1.TabIndex = 0;
            // 
            // LogLayer1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(317, 560);
            this.Controls.Add(this.lb_LogLayer1);
            this.ForeColor = System.Drawing.Color.Green;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LogLayer1";
            this.Text = "LOG LAYER1";
            this.Load += new System.EventHandler(this.LogLayer1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lb_LogLayer1;
    }
}