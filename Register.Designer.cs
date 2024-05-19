namespace aCICSistanceCorner
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            createAcc = new Button();
            backmain = new Button();
            UserName = new TextBox();
            srcode = new TextBox();
            password = new TextBox();
            SuspendLayout();
            // 
            // createAcc
            // 
            createAcc.BackColor = Color.Transparent;
            createAcc.FlatAppearance.BorderSize = 0;
            createAcc.FlatAppearance.MouseDownBackColor = Color.Transparent;
            createAcc.FlatAppearance.MouseOverBackColor = Color.Transparent;
            createAcc.FlatStyle = FlatStyle.Flat;
            createAcc.ForeColor = Color.Transparent;
            createAcc.Image = (Image)resources.GetObject("createAcc.Image");
            createAcc.Location = new Point(42, 601);
            createAcc.Name = "createAcc";
            createAcc.Size = new Size(301, 71);
            createAcc.TabIndex = 24;
            createAcc.UseVisualStyleBackColor = false;
            createAcc.Click += createAcc_Click;
            // 
            // backmain
            // 
            backmain.BackColor = Color.Transparent;
            backmain.FlatAppearance.BorderSize = 0;
            backmain.FlatAppearance.MouseDownBackColor = Color.Transparent;
            backmain.FlatAppearance.MouseOverBackColor = Color.Transparent;
            backmain.FlatStyle = FlatStyle.Flat;
            backmain.ForeColor = Color.Transparent;
            backmain.Image = (Image)resources.GetObject("backmain.Image");
            backmain.Location = new Point(42, 678);
            backmain.Name = "backmain";
            backmain.Size = new Size(301, 75);
            backmain.TabIndex = 25;
            backmain.UseVisualStyleBackColor = false;
            backmain.Click += backmain_Click;
            // 
            // UserName
            // 
            UserName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            UserName.BackColor = Color.White;
            UserName.BorderStyle = BorderStyle.None;
            UserName.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            UserName.ForeColor = Color.Black;
            UserName.Location = new Point(65, 348);
            UserName.Name = "UserName";
            UserName.PlaceholderText = "Username";
            UserName.Size = new Size(334, 45);
            UserName.TabIndex = 26;
            UserName.Tag = "";
            // 
            // srcode
            // 
            srcode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            srcode.BackColor = Color.White;
            srcode.BorderStyle = BorderStyle.None;
            srcode.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            srcode.ForeColor = Color.Black;
            srcode.Location = new Point(65, 432);
            srcode.Name = "srcode";
            srcode.PlaceholderText = "SR Code";
            srcode.Size = new Size(334, 45);
            srcode.TabIndex = 27;
            srcode.Tag = "";
            // 
            // password
            // 
            password.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            password.BackColor = Color.White;
            password.BorderStyle = BorderStyle.None;
            password.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            password.ForeColor = Color.Black;
            password.Location = new Point(65, 514);
            password.Name = "password";
            password.PlaceholderText = "Password";
            password.Size = new Size(334, 45);
            password.TabIndex = 28;
            password.Tag = "";
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(463, 844);
            Controls.Add(password);
            Controls.Add(srcode);
            Controls.Add(UserName);
            Controls.Add(backmain);
            Controls.Add(createAcc);
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button createAcc;
        private Button backmain;
        private TextBox UserName;
        private TextBox srcode;
        private TextBox password;
    }
}