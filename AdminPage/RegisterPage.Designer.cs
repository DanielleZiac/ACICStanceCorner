namespace AdminPage
{
    partial class RegisterPage
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
            this.ShowPassReg = new System.Windows.Forms.CheckBox();
            this.Reg_Btn = new System.Windows.Forms.Button();
            this.BackLog = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NameRegBox = new System.Windows.Forms.TextBox();
            this.SRRegBox = new System.Windows.Forms.TextBox();
            this.PassRegBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ShowPassReg
            // 
            this.ShowPassReg.AutoSize = true;
            this.ShowPassReg.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowPassReg.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.ShowPassReg.Location = new System.Drawing.Point(928, 478);
            this.ShowPassReg.Name = "ShowPassReg";
            this.ShowPassReg.Size = new System.Drawing.Size(158, 25);
            this.ShowPassReg.TabIndex = 11;
            this.ShowPassReg.Text = "Show Password";
            this.ShowPassReg.UseVisualStyleBackColor = true;
            this.ShowPassReg.CheckedChanged += new System.EventHandler(this.ShowPassReg_CheckedChanged);
            // 
            // Reg_Btn
            // 
            this.Reg_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(107)))), ((int)(((byte)(175)))));
            this.Reg_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Reg_Btn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reg_Btn.ForeColor = System.Drawing.Color.White;
            this.Reg_Btn.Location = new System.Drawing.Point(861, 520);
            this.Reg_Btn.Name = "Reg_Btn";
            this.Reg_Btn.Size = new System.Drawing.Size(225, 43);
            this.Reg_Btn.TabIndex = 10;
            this.Reg_Btn.Text = "Register";
            this.Reg_Btn.UseVisualStyleBackColor = false;
            this.Reg_Btn.Click += new System.EventHandler(this.Reg_Btn_Click);
            // 
            // BackLog
            // 
            this.BackLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BackLog.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(107)))), ((int)(((byte)(175)))));
            this.BackLog.Location = new System.Drawing.Point(613, 520);
            this.BackLog.Name = "BackLog";
            this.BackLog.Size = new System.Drawing.Size(230, 43);
            this.BackLog.TabIndex = 9;
            this.BackLog.Text = "Back";
            this.BackLog.UseVisualStyleBackColor = true;
            this.BackLog.Click += new System.EventHandler(this.BackLog_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::AdminPage.Properties.Resources.Register1;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1130, 634);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::AdminPage.Properties.Resources.Register;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1130, 634);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // NameRegBox
            // 
            this.NameRegBox.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameRegBox.ForeColor = System.Drawing.SystemColors.MenuText;
            this.NameRegBox.Location = new System.Drawing.Point(682, 210);
            this.NameRegBox.Name = "NameRegBox";
            this.NameRegBox.Size = new System.Drawing.Size(389, 30);
            this.NameRegBox.TabIndex = 12;
            // 
            // SRRegBox
            // 
            this.SRRegBox.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SRRegBox.ForeColor = System.Drawing.SystemColors.MenuText;
            this.SRRegBox.Location = new System.Drawing.Point(682, 308);
            this.SRRegBox.MaxLength = 8;
            this.SRRegBox.Name = "SRRegBox";
            this.SRRegBox.Size = new System.Drawing.Size(389, 30);
            this.SRRegBox.TabIndex = 13;
            // 
            // PassRegBox
            // 
            this.PassRegBox.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassRegBox.ForeColor = System.Drawing.SystemColors.MenuText;
            this.PassRegBox.Location = new System.Drawing.Point(682, 407);
            this.PassRegBox.Name = "PassRegBox";
            this.PassRegBox.Size = new System.Drawing.Size(389, 30);
            this.PassRegBox.TabIndex = 14;
            this.PassRegBox.UseSystemPasswordChar = true;
            this.PassRegBox.TextChanged += new System.EventHandler(this.PassRegBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(634, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "FULL NAME";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(634, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "SR-CODE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(634, 372);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 19);
            this.label3.TabIndex = 17;
            this.label3.Text = "PASSWORD";
            // 
            // RegisterPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 634);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PassRegBox);
            this.Controls.Add(this.SRRegBox);
            this.Controls.Add(this.NameRegBox);
            this.Controls.Add(this.ShowPassReg);
            this.Controls.Add(this.Reg_Btn);
            this.Controls.Add(this.BackLog);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterPage";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox ShowPassReg;
        private System.Windows.Forms.Button Reg_Btn;
        private System.Windows.Forms.Button BackLog;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox NameRegBox;
        private System.Windows.Forms.TextBox SRRegBox;
        private System.Windows.Forms.TextBox PassRegBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}