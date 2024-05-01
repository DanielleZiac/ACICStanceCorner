namespace AdminPage.User_Controls
{
    partial class UC_About
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DownloadBtn = new System.Windows.Forms.PictureBox();
            this.aboutBG = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DownloadBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aboutBG)).BeginInit();
            this.SuspendLayout();
            // 
            // DownloadBtn
            // 
            this.DownloadBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(234)))), ((int)(((byte)(239)))));
            this.DownloadBtn.Image = global::AdminPage.Properties.Resources.downloadbtn;
            this.DownloadBtn.Location = new System.Drawing.Point(636, 283);
            this.DownloadBtn.Name = "DownloadBtn";
            this.DownloadBtn.Size = new System.Drawing.Size(364, 111);
            this.DownloadBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DownloadBtn.TabIndex = 4;
            this.DownloadBtn.TabStop = false;
            this.DownloadBtn.Click += new System.EventHandler(this.DownloadBtn_Click);
            // 
            // aboutBG
            // 
            this.aboutBG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aboutBG.Image = global::AdminPage.Properties.Resources.AboutBG;
            this.aboutBG.Location = new System.Drawing.Point(0, 0);
            this.aboutBG.Name = "aboutBG";
            this.aboutBG.Size = new System.Drawing.Size(1060, 581);
            this.aboutBG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.aboutBG.TabIndex = 3;
            this.aboutBG.TabStop = false;
            // 
            // UC_About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DownloadBtn);
            this.Controls.Add(this.aboutBG);
            this.Name = "UC_About";
            this.Size = new System.Drawing.Size(1060, 581);
            ((System.ComponentModel.ISupportInitialize)(this.DownloadBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aboutBG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox aboutBG;
        private System.Windows.Forms.PictureBox DownloadBtn;
    }
}
