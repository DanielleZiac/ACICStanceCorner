namespace aCICSistanceCorner
{
    partial class StartingPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UserName = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.usernameBG = new System.Windows.Forms.PictureBox();
            this.passwordBG = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.usernameBG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordBG)).BeginInit();
            this.SuspendLayout();
            // 
            // UserName
            // 
            this.UserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UserName.Location = new System.Drawing.Point(69, 530);
            this.UserName.Name = "UserName";
            this.UserName.PlaceholderText = "Username";
            this.UserName.Size = new System.Drawing.Size(255, 29);
            this.UserName.TabIndex = 0;
            this.UserName.Tag = "";
            this.UserName.TextChanged += new System.EventHandler(this.UserName_TextChanged);
            // 
            // Password
            // 
            this.Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Password.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Password.Location = new System.Drawing.Point(69, 609);
            this.Password.Name = "Password";
            this.Password.PlaceholderText = "Password";
            this.Password.Size = new System.Drawing.Size(255, 29);
            this.Password.TabIndex = 0;
            this.Password.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // usernameBG
            // 
            this.usernameBG.BackColor = System.Drawing.Color.Transparent;
            this.usernameBG.Image = global::aCICSistanceCorner.Properties.Resources.whiteBox;
            this.usernameBG.Location = new System.Drawing.Point(45, 512);
            this.usernameBG.Name = "usernameBG";
            this.usernameBG.Size = new System.Drawing.Size(309, 73);
            this.usernameBG.TabIndex = 2;
            this.usernameBG.TabStop = false;
            this.usernameBG.Click += new System.EventHandler(this.Password_TextChanged);
            // 
            // passwordBG
            // 
            this.passwordBG.BackColor = System.Drawing.Color.Transparent;
            this.passwordBG.Image = global::aCICSistanceCorner.Properties.Resources.whiteBox;
            this.passwordBG.Location = new System.Drawing.Point(45, 592);
            this.passwordBG.Name = "passwordBG";
            this.passwordBG.Size = new System.Drawing.Size(309, 64);
            this.passwordBG.TabIndex = 3;
            this.passwordBG.TabStop = false;
            // 
            // StartingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 844);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.usernameBG);
            this.Controls.Add(this.passwordBG);
            this.Name = "StartingPage";
            this.Text = "StartingPage";
            this.Load += new System.EventHandler(this.startingPage);
            ((System.ComponentModel.ISupportInitialize)(this.usernameBG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordBG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private TextBox UserName;
        private TextBox Password;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox usernameBG;
        private PictureBox passwordBG;
        private PictureBox pictureBox3;
    }
}