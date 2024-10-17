namespace Lotus_Server_Form.Forms
{
    partial class LogLayer3
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
            this.lb_LogLayer3 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lb_LogLayer3
            // 
            this.lb_LogLayer3.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lb_LogLayer3.ForeColor = System.Drawing.Color.Lime;
            this.lb_LogLayer3.FormattingEnabled = true;
            this.lb_LogLayer3.ItemHeight = 16;
            this.lb_LogLayer3.Location = new System.Drawing.Point(13, 13);
            this.lb_LogLayer3.Name = "lb_LogLayer3";
            this.lb_LogLayer3.Size = new System.Drawing.Size(775, 420);
            this.lb_LogLayer3.TabIndex = 0;
            // 
            // LogLayer3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lb_LogLayer3);
            this.ForeColor = System.Drawing.Color.Lime;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LogLayer3";
            this.Text = "LOG LAYER 3";
            this.Load += new System.EventHandler(this.LogLayer3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lb_LogLayer3;
    }
}