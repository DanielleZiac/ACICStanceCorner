namespace aCICSistanceCorner
{
    partial class Profile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profile));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            transactions = new Button();
            profilepic = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(34, 394);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(325, 50);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(34, 450);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(325, 50);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(34, 506);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(325, 50);
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // transactions
            // 
            transactions.BackColor = Color.Transparent;
            transactions.FlatAppearance.BorderSize = 0;
            transactions.FlatAppearance.MouseDownBackColor = Color.Transparent;
            transactions.FlatAppearance.MouseOverBackColor = Color.Transparent;
            transactions.FlatStyle = FlatStyle.Flat;
            transactions.ForeColor = Color.Transparent;
            transactions.Image = (Image)resources.GetObject("transactions.Image");
            transactions.Location = new Point(34, 562);
            transactions.Name = "transactions";
            transactions.Size = new Size(325, 58);
            transactions.TabIndex = 24;
            transactions.UseVisualStyleBackColor = false;
            transactions.Click += transactions_Click;
            // 
            // profilepic
            // 
            profilepic.BackColor = Color.Transparent;
            profilepic.FlatAppearance.BorderSize = 0;
            profilepic.FlatAppearance.MouseDownBackColor = Color.Transparent;
            profilepic.FlatAppearance.MouseOverBackColor = Color.Transparent;
            profilepic.FlatStyle = FlatStyle.Flat;
            profilepic.ForeColor = Color.Transparent;
            profilepic.Image = Properties.Resources.profile_icon;
            profilepic.Location = new Point(34, 114);
            profilepic.Name = "profilepic";
            profilepic.Size = new Size(325, 274);
            profilepic.TabIndex = 25;
            profilepic.UseVisualStyleBackColor = false;
            // 
            // Profile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(383, 844);
            Controls.Add(profilepic);
            Controls.Add(transactions);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "Profile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Profile";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox6;
        private Button transaction;
        private Button transactions;
        private Button profilepic;
    }
}