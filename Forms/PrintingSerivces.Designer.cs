namespace aCICSistanceCorner
{
    partial class PrintingSerivces
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintingSerivces));
            addbutton = new Button();
            SuspendLayout();
            // 
            // addbutton
            // 
            addbutton.BackColor = Color.Transparent;
            addbutton.FlatAppearance.BorderSize = 0;
            addbutton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            addbutton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            addbutton.FlatStyle = FlatStyle.Flat;
            addbutton.ForeColor = Color.Transparent;
            addbutton.Image = (Image)resources.GetObject("addbutton.Image");
            addbutton.Location = new Point(-3, 600);
            addbutton.Name = "addbutton";
            addbutton.Size = new Size(398, 170);
            addbutton.TabIndex = 21;
            addbutton.UseVisualStyleBackColor = false;
            addbutton.Click += addbutton_Click;
            // 
            // PrintingSerivces
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(543, 915);
            Controls.Add(addbutton);
            Name = "PrintingSerivces";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PrintingSerivces";
            ResumeLayout(false);
        }



        #endregion

        private Button addbutton;
        private PictureBox pdfPending;
    }
}