namespace aCICSistanceCorner
{
    partial class HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            imagechanger = new Button();
            left = new Button();
            right = new Button();
            SuspendLayout();
            // 
            // imagechanger
            // 
            imagechanger.BackColor = Color.Transparent;
            imagechanger.FlatAppearance.BorderSize = 0;
            imagechanger.FlatAppearance.MouseDownBackColor = Color.Transparent;
            imagechanger.FlatAppearance.MouseOverBackColor = Color.Transparent;
            imagechanger.FlatStyle = FlatStyle.Flat;
            imagechanger.ForeColor = Color.Transparent;
            imagechanger.Image = (Image)resources.GetObject("imagechanger.Image");
            imagechanger.Location = new Point(22, 197);
            imagechanger.Name = "imagechanger";
            imagechanger.Size = new Size(343, 447);
            imagechanger.TabIndex = 27;
            imagechanger.UseVisualStyleBackColor = false;
            // 
            // left
            // 
            left.BackColor = Color.Transparent;
            left.FlatAppearance.BorderSize = 0;
            left.FlatAppearance.MouseDownBackColor = Color.Transparent;
            left.FlatAppearance.MouseOverBackColor = Color.Transparent;
            left.FlatStyle = FlatStyle.Flat;
            left.ForeColor = Color.Transparent;
            left.Image = (Image)resources.GetObject("left.Image");
            left.Location = new Point(64, 381);
            left.Name = "left";
            left.Size = new Size(57, 106);
            left.TabIndex = 25;
            left.UseVisualStyleBackColor = false;
            left.Click += left_Click;
            // 
            // right
            // 
            right.AccessibleRole = AccessibleRole.None;
            right.BackColor = Color.Transparent;
            right.FlatAppearance.BorderColor = SystemColors.ActiveBorder;
            right.FlatAppearance.BorderSize = 0;
            right.FlatAppearance.MouseDownBackColor = Color.Transparent;
            right.FlatAppearance.MouseOverBackColor = Color.Transparent;
            right.FlatStyle = FlatStyle.Flat;
            right.Image = (Image)resources.GetObject("right.Image");
            right.Location = new Point(271, 381);
            right.Margin = new Padding(0);
            right.Name = "right";
            right.Size = new Size(57, 106);
            right.TabIndex = 26;
            right.UseVisualStyleBackColor = false;
            right.Click += right_Click;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 248, 248);
            ClientSize = new Size(390, 844);
            Controls.Add(right);
            Controls.Add(left);
            Controls.Add(imagechanger);
            Name = "HomePage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home Page";
            TransparencyKey = SystemColors.ActiveBorder;
            ResumeLayout(false);
        }

        #endregion
        private Button basketball;
        private Button paper;
        private Button account;
        private Button logo;
        private Button button1;
        private Button getStarted;
        private Button left;
        private Button right;
        private Button imagechanger;
        private PictureBox pictureBox1;
    }
}