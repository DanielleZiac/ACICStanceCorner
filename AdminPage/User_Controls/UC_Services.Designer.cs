namespace AdminPage.User_Controls
{
    partial class UC_Services
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ApprovalTable = new System.Windows.Forms.DataGridView();
            this.colSRCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colService = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.submitApproval = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.StatusCBox = new System.Windows.Forms.ComboBox();
            this.detailsLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ApprovalTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ApprovalTable
            // 
            this.ApprovalTable.AllowUserToAddRows = false;
            this.ApprovalTable.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ApprovalTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ApprovalTable.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.ApprovalTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ApprovalTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ApprovalTable.ColumnHeadersHeight = 29;
            this.ApprovalTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ApprovalTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSRCode,
            this.colService,
            this.colItem,
            this.colDetails,
            this.colDate,
            this.colStatus});
            this.ApprovalTable.EnableHeadersVisualStyles = false;
            this.ApprovalTable.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.ApprovalTable.Location = new System.Drawing.Point(38, 235);
            this.ApprovalTable.Name = "ApprovalTable";
            this.ApprovalTable.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ApprovalTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ApprovalTable.RowHeadersWidth = 51;
            this.ApprovalTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApprovalTable.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.ApprovalTable.RowTemplate.Height = 24;
            this.ApprovalTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ApprovalTable.Size = new System.Drawing.Size(806, 307);
            this.ApprovalTable.TabIndex = 7;
            this.ApprovalTable.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ApprovalTable_CellFormatting);
            this.ApprovalTable.SelectionChanged += new System.EventHandler(this.ApprovalTable_SelectionChanged);
            // 
            // colSRCode
            // 
            this.colSRCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSRCode.HeaderText = "SR-Code";
            this.colSRCode.MinimumWidth = 6;
            this.colSRCode.Name = "colSRCode";
            this.colSRCode.ReadOnly = true;
            // 
            // colService
            // 
            this.colService.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colService.HeaderText = "Service";
            this.colService.MinimumWidth = 6;
            this.colService.Name = "colService";
            this.colService.ReadOnly = true;
            this.colService.Width = 99;
            // 
            // colItem
            // 
            this.colItem.HeaderText = "Item";
            this.colItem.MinimumWidth = 6;
            this.colItem.Name = "colItem";
            this.colItem.ReadOnly = true;
            this.colItem.Width = 70;
            // 
            // colDetails
            // 
            this.colDetails.HeaderText = "Quantity";
            this.colDetails.MinimumWidth = 6;
            this.colDetails.Name = "colDetails";
            this.colDetails.ReadOnly = true;
            this.colDetails.Width = 80;
            // 
            // colDate
            // 
            this.colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDate.HeaderText = "Date";
            this.colDate.MinimumWidth = 6;
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.colStatus.DefaultCellStyle = dataGridViewCellStyle3;
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 6;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // submitApproval
            // 
            this.submitApproval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(107)))), ((int)(((byte)(175)))));
            this.submitApproval.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitApproval.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitApproval.ForeColor = System.Drawing.SystemColors.Control;
            this.submitApproval.Location = new System.Drawing.Point(533, 167);
            this.submitApproval.Name = "submitApproval";
            this.submitApproval.Size = new System.Drawing.Size(105, 31);
            this.submitApproval.TabIndex = 7;
            this.submitApproval.Text = "Submit";
            this.submitApproval.UseVisualStyleBackColor = false;
            this.submitApproval.Click += new System.EventHandler(this.submitApproval_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(302, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Status: ";
            // 
            // StatusCBox
            // 
            this.StatusCBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.StatusCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StatusCBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StatusCBox.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusCBox.FormattingEnabled = true;
            this.StatusCBox.Items.AddRange(new object[] {
            "Pending",
            "Approved",
            "Rejected"});
            this.StatusCBox.Location = new System.Drawing.Point(367, 173);
            this.StatusCBox.Name = "StatusCBox";
            this.StatusCBox.Size = new System.Drawing.Size(121, 25);
            this.StatusCBox.TabIndex = 5;
            // 
            // detailsLabel
            // 
            this.detailsLabel.AutoSize = true;
            this.detailsLabel.BackColor = System.Drawing.Color.White;
            this.detailsLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailsLabel.Location = new System.Drawing.Point(302, 75);
            this.detailsLabel.Name = "detailsLabel";
            this.detailsLabel.Size = new System.Drawing.Size(61, 20);
            this.detailsLabel.TabIndex = 1;
            this.detailsLabel.Text = "Details:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AdminPage.Properties.Resources.detailsBG;
            this.pictureBox1.Location = new System.Drawing.Point(275, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(385, 199);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(96, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 37);
            this.label1.TabIndex = 10;
            this.label1.Text = "Approval";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(675, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 37);
            this.label3.TabIndex = 11;
            this.label3.Text = "Sheet";
            // 
            // UC_Services
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(234)))), ((int)(((byte)(239)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.submitApproval);
            this.Controls.Add(this.StatusCBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ApprovalTable);
            this.Controls.Add(this.detailsLabel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UC_Services";
            this.Size = new System.Drawing.Size(1060, 581);
            ((System.ComponentModel.ISupportInitialize)(this.ApprovalTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView ApprovalTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox StatusCBox;
        private System.Windows.Forms.Label detailsLabel;
        private System.Windows.Forms.Button submitApproval;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSRCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colService;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}
