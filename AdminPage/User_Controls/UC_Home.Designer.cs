namespace AdminPage.User_Controls
{
    partial class UC_Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Home));
            this.TasksGroup = new System.Windows.Forms.GroupBox();
            this.DoneTask = new System.Windows.Forms.Button();
            this.CheckedTask = new System.Windows.Forms.CheckedListBox();
            this.TaskType = new System.Windows.Forms.TextBox();
            this.AddTaskBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.TasksGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // TasksGroup
            // 
            this.TasksGroup.Controls.Add(this.DoneTask);
            this.TasksGroup.Controls.Add(this.CheckedTask);
            this.TasksGroup.Font = new System.Drawing.Font("Century Gothic", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TasksGroup.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.TasksGroup.Location = new System.Drawing.Point(774, 56);
            this.TasksGroup.Name = "TasksGroup";
            this.TasksGroup.Size = new System.Drawing.Size(191, 378);
            this.TasksGroup.TabIndex = 2;
            this.TasksGroup.TabStop = false;
            this.TasksGroup.Text = "Tasks";
            // 
            // DoneTask
            // 
            this.DoneTask.Font = new System.Drawing.Font("Century Gothic", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoneTask.Location = new System.Drawing.Point(101, 345);
            this.DoneTask.Name = "DoneTask";
            this.DoneTask.Size = new System.Drawing.Size(75, 27);
            this.DoneTask.TabIndex = 3;
            this.DoneTask.Text = "Done";
            this.DoneTask.UseVisualStyleBackColor = true;
            this.DoneTask.Click += new System.EventHandler(this.DoneTask_Click);
            // 
            // CheckedTask
            // 
            this.CheckedTask.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CheckedTask.Font = new System.Drawing.Font("Century Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckedTask.ForeColor = System.Drawing.SystemColors.InfoText;
            this.CheckedTask.FormattingEnabled = true;
            this.CheckedTask.Location = new System.Drawing.Point(15, 27);
            this.CheckedTask.Name = "CheckedTask";
            this.CheckedTask.Size = new System.Drawing.Size(170, 294);
            this.CheckedTask.TabIndex = 2;
            this.CheckedTask.SelectedIndexChanged += new System.EventHandler(this.CheckedTask_SelectedIndexChanged);
            // 
            // TaskType
            // 
            this.TaskType.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskType.Location = new System.Drawing.Point(778, 458);
            this.TaskType.Name = "TaskType";
            this.TaskType.Size = new System.Drawing.Size(185, 26);
            this.TaskType.TabIndex = 3;
            this.TaskType.TextChanged += new System.EventHandler(this.TaskType_TextChanged);
            // 
            // AddTaskBtn
            // 
            this.AddTaskBtn.BackColor = System.Drawing.Color.LightSkyBlue;
            this.AddTaskBtn.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddTaskBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddTaskBtn.Location = new System.Drawing.Point(825, 499);
            this.AddTaskBtn.Name = "AddTaskBtn";
            this.AddTaskBtn.Size = new System.Drawing.Size(85, 31);
            this.AddTaskBtn.TabIndex = 4;
            this.AddTaskBtn.Text = "Add Task";
            this.AddTaskBtn.UseVisualStyleBackColor = false;
            this.AddTaskBtn.Click += new System.EventHandler(this.AddTaskBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(160)))), ((int)(((byte)(216)))));
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(88, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Pending Approvals";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(198)))), ((int)(((byte)(230)))));
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(319, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Approved";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1060, 581);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // UC_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddTaskBtn);
            this.Controls.Add(this.TaskType);
            this.Controls.Add(this.TasksGroup);
            this.Controls.Add(this.pictureBox2);
            this.Name = "UC_Home";
            this.Size = new System.Drawing.Size(1060, 581);
            this.TasksGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox TasksGroup;
        private System.Windows.Forms.TextBox TaskType;
        private System.Windows.Forms.Button AddTaskBtn;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button DoneTask;
        private System.Windows.Forms.CheckedListBox CheckedTask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
