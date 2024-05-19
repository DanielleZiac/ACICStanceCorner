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
            UserName = new TextBox();
            Password = new TextBox();
            usernameBG = new PictureBox();
            passwordBG = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)usernameBG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)passwordBG).BeginInit();
            SuspendLayout();
            // 
            // UserName
            // 
            UserName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            UserName.BorderStyle = BorderStyle.None;
            UserName.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            UserName.Location = new Point(69, 530);
            UserName.Name = "UserName";
            UserName.PlaceholderText = "SRCode";
            UserName.Size = new Size(255, 29);
            UserName.TabIndex = 0;
            UserName.Tag = "";
            // 
            // Password
            // 
            Password.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Password.BorderStyle = BorderStyle.None;
            Password.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            Password.Location = new Point(69, 609);
            Password.Name = "Password";
            Password.PlaceholderText = "Password";
            Password.Size = new Size(255, 29);
            Password.TabIndex = 0;
            Password.UseSystemPasswordChar = true;
            // 
            // usernameBG
            // 
            usernameBG.BackColor = Color.Transparent;
            usernameBG.Image = Properties.Resources.whiteBox;
            usernameBG.Location = new Point(45, 512);
            usernameBG.Name = "usernameBG";
            usernameBG.Size = new Size(309, 73);
            usernameBG.TabIndex = 2;
            usernameBG.TabStop = false;
            // 
            // passwordBG
            // 
            passwordBG.BackColor = Color.Transparent;
            passwordBG.Image = Properties.Resources.whiteBox;
            passwordBG.Location = new Point(45, 592);
            passwordBG.Name = "passwordBG";
            passwordBG.Size = new Size(309, 64);
            passwordBG.TabIndex = 3;
            passwordBG.TabStop = false;
            // 
            // StartingPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(390, 844);
            Controls.Add(Password);
            Controls.Add(UserName);
            Controls.Add(usernameBG);
            Controls.Add(passwordBG);
            Name = "StartingPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StartingPage";
            ((System.ComponentModel.ISupportInitialize)usernameBG).EndInit();
            ((System.ComponentModel.ISupportInitialize)passwordBG).EndInit();
            ResumeLayout(false);
            PerformLayout();
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