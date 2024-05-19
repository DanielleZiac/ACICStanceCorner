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
            this.label3 = new System.Windows.Forms.Label();
            this.UserLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ApprovedLabel = new System.Windows.Forms.Label();
            this.PendingLabel = new System.Windows.Forms.Label();
            this.StatusPie = new LiveCharts.WinForms.PieChart();
            this.ServicePie = new LiveCharts.WinForms.PieChart();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelServicePie = new System.Windows.Forms.Panel();
            this.panelStatusPie = new System.Windows.Forms.Panel();
            this.TasksGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelServicePie.SuspendLayout();
            this.panelStatusPie.SuspendLayout();
            this.SuspendLayout();
            // 
            // TasksGroup
            // 
            this.TasksGroup.Controls.Add(this.DoneTask);
            this.TasksGroup.Controls.Add(this.CheckedTask);
            this.TasksGroup.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TasksGroup.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.TasksGroup.Location = new System.Drawing.Point(855, 83);
            this.TasksGroup.Name = "TasksGroup";
            this.TasksGroup.Size = new System.Drawing.Size(191, 418);
            this.TasksGroup.TabIndex = 2;
            this.TasksGroup.TabStop = false;
            this.TasksGroup.Text = "Tasks";
            // 
            // DoneTask
            // 
            this.DoneTask.Font = new System.Drawing.Font("Century Gothic", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoneTask.Location = new System.Drawing.Point(99, 374);
            this.DoneTask.Name = "DoneTask";
            this.DoneTask.Size = new System.Drawing.Size(86, 38);
            this.DoneTask.TabIndex = 3;
            this.DoneTask.Text = "Done";
            this.DoneTask.UseVisualStyleBackColor = true;
            this.DoneTask.Click += new System.EventHandler(this.DoneTask_Click);
            // 
            // CheckedTask
            // 
            this.CheckedTask.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CheckedTask.Font = new System.Drawing.Font("Century Gothic", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckedTask.ForeColor = System.Drawing.SystemColors.InfoText;
            this.CheckedTask.FormattingEnabled = true;
            this.CheckedTask.Location = new System.Drawing.Point(15, 27);
            this.CheckedTask.Name = "CheckedTask";
            this.CheckedTask.Size = new System.Drawing.Size(170, 276);
            this.CheckedTask.TabIndex = 2;
            // 
            // TaskType
            // 
            this.TaskType.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskType.Location = new System.Drawing.Point(861, 533);
            this.TaskType.Name = "TaskType";
            this.TaskType.Size = new System.Drawing.Size(185, 26);
            this.TaskType.TabIndex = 3;
            // 
            // AddTaskBtn
            // 
            this.AddTaskBtn.BackColor = System.Drawing.Color.LightSkyBlue;
            this.AddTaskBtn.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddTaskBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddTaskBtn.Location = new System.Drawing.Point(861, 565);
            this.AddTaskBtn.Name = "AddTaskBtn";
            this.AddTaskBtn.Size = new System.Drawing.Size(179, 41);
            this.AddTaskBtn.TabIndex = 4;
            this.AddTaskBtn.Text = "Add Task";
            this.AddTaskBtn.UseVisualStyleBackColor = false;
            this.AddTaskBtn.Click += new System.EventHandler(this.AddTaskBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(160)))), ((int)(((byte)(216)))));
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(97, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "Pending";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(519, 565);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 27);
            this.label2.TabIndex = 7;
            this.label2.Text = "Status Pie Chart";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(107)))), ((int)(((byte)(175)))));
            this.label3.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(607, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 27);
            this.label3.TabIndex = 8;
            this.label3.Text = "Users";
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(107)))), ((int)(((byte)(175)))));
            this.UserLabel.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UserLabel.Location = new System.Drawing.Point(601, 100);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(40, 44);
            this.UserLabel.TabIndex = 9;
            this.UserLabel.Text = "0";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1167, 717);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // ApprovedLabel
            // 
            this.ApprovedLabel.AutoSize = true;
            this.ApprovedLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(198)))), ((int)(((byte)(230)))));
            this.ApprovedLabel.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApprovedLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ApprovedLabel.Location = new System.Drawing.Point(346, 100);
            this.ApprovedLabel.Name = "ApprovedLabel";
            this.ApprovedLabel.Size = new System.Drawing.Size(40, 44);
            this.ApprovedLabel.TabIndex = 13;
            this.ApprovedLabel.Text = "0";
            // 
            // PendingLabel
            // 
            this.PendingLabel.AutoSize = true;
            this.PendingLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(160)))), ((int)(((byte)(216)))));
            this.PendingLabel.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PendingLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PendingLabel.Location = new System.Drawing.Point(94, 100);
            this.PendingLabel.Name = "PendingLabel";
            this.PendingLabel.Size = new System.Drawing.Size(40, 44);
            this.PendingLabel.TabIndex = 14;
            this.PendingLabel.Text = "0";
            // 
            // StatusPie
            // 
            this.StatusPie.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.StatusPie.Location = new System.Drawing.Point(0, 3);
            this.StatusPie.Name = "StatusPie";
            this.StatusPie.Size = new System.Drawing.Size(282, 296);
            this.StatusPie.TabIndex = 15;
            this.StatusPie.Text = "Status";
            // 
            // ServicePie
            // 
            this.ServicePie.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.ServicePie.Location = new System.Drawing.Point(3, 3);
            this.ServicePie.Name = "ServicePie";
            this.ServicePie.Size = new System.Drawing.Size(282, 296);
            this.ServicePie.TabIndex = 16;
            this.ServicePie.Text = "Service";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(162, 565);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 27);
            this.label4.TabIndex = 17;
            this.label4.Text = "Service Distribution";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(198)))), ((int)(((byte)(230)))));
            this.label5.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(345, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 27);
            this.label5.TabIndex = 18;
            this.label5.Text = "Approved";
            // 
            // panelServicePie
            // 
            this.panelServicePie.Controls.Add(this.ServicePie);
            this.panelServicePie.Location = new System.Drawing.Point(152, 232);
            this.panelServicePie.Name = "panelServicePie";
            this.panelServicePie.Size = new System.Drawing.Size(288, 309);
            this.panelServicePie.TabIndex = 19;
            // 
            // panelStatusPie
            // 
            this.panelStatusPie.Controls.Add(this.StatusPie);
            this.panelStatusPie.Location = new System.Drawing.Point(470, 232);
            this.panelStatusPie.Name = "panelStatusPie";
            this.panelStatusPie.Size = new System.Drawing.Size(288, 309);
            this.panelStatusPie.TabIndex = 20;
            // 
            // UC_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panelStatusPie);
            this.Controls.Add(this.panelServicePie);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PendingLabel);
            this.Controls.Add(this.ApprovedLabel);
            this.Controls.Add(this.UserLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddTaskBtn);
            this.Controls.Add(this.TaskType);
            this.Controls.Add(this.TasksGroup);
            this.Controls.Add(this.pictureBox2);
            this.Name = "UC_Home";
            this.Size = new System.Drawing.Size(1167, 717);
            this.TasksGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelServicePie.ResumeLayout(false);
            this.panelStatusPie.ResumeLayout(false);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.Label ApprovedLabel;
        private System.Windows.Forms.Label PendingLabel;
        private LiveCharts.WinForms.PieChart StatusPie;
        private LiveCharts.WinForms.PieChart ServicePie;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelServicePie;
        private System.Windows.Forms.Panel panelStatusPie;
    }
}
