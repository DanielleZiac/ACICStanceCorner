namespace AdminPage.User_Controls
{
    partial class UC_Transaction
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.TransactionTable = new System.Windows.Forms.DataGridView();
            this.detailsLabelTrans = new System.Windows.Forms.Label();
            this.colSRCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colService = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdminApp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(391, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transaction History";
            // 
            // TransactionTable
            // 
            this.TransactionTable.AllowUserToAddRows = false;
            this.TransactionTable.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.TransactionTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.TransactionTable.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.TransactionTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TransactionTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.TransactionTable.ColumnHeadersHeight = 29;
            this.TransactionTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.TransactionTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSRCode,
            this.colService,
            this.colDetails,
            this.colItem,
            this.colAdminApp,
            this.colDate});
            this.TransactionTable.EnableHeadersVisualStyles = false;
            this.TransactionTable.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.TransactionTable.Location = new System.Drawing.Point(43, 77);
            this.TransactionTable.Name = "TransactionTable";
            this.TransactionTable.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TransactionTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.TransactionTable.RowHeadersWidth = 51;
            this.TransactionTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransactionTable.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.TransactionTable.RowTemplate.Height = 24;
            this.TransactionTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TransactionTable.Size = new System.Drawing.Size(975, 252);
            this.TransactionTable.TabIndex = 6;
            this.TransactionTable.SelectionChanged += new System.EventHandler(this.TransactionTable_SelectionChanged);
            // 
            // detailsLabelTrans
            // 
            this.detailsLabelTrans.AutoSize = true;
            this.detailsLabelTrans.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(225)))), ((int)(((byte)(238)))));
            this.detailsLabelTrans.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailsLabelTrans.Location = new System.Drawing.Point(394, 400);
            this.detailsLabelTrans.Name = "detailsLabelTrans";
            this.detailsLabelTrans.Size = new System.Drawing.Size(61, 20);
            this.detailsLabelTrans.TabIndex = 1;
            this.detailsLabelTrans.Text = "Details:";
            // 
            // colSRCode
            // 
            this.colSRCode.HeaderText = "SR-Code";
            this.colSRCode.MinimumWidth = 6;
            this.colSRCode.Name = "colSRCode";
            this.colSRCode.ReadOnly = true;
            this.colSRCode.Width = 125;
            // 
            // colService
            // 
            this.colService.HeaderText = "Service";
            this.colService.MinimumWidth = 6;
            this.colService.Name = "colService";
            this.colService.ReadOnly = true;
            this.colService.Width = 70;
            // 
            // colDetails
            // 
            this.colDetails.HeaderText = "Quantity";
            this.colDetails.MinimumWidth = 6;
            this.colDetails.Name = "colDetails";
            this.colDetails.ReadOnly = true;
            this.colDetails.Width = 80;
            // 
            // colItem
            // 
            this.colItem.HeaderText = "Item";
            this.colItem.MinimumWidth = 6;
            this.colItem.Name = "colItem";
            this.colItem.ReadOnly = true;
            this.colItem.Width = 125;
            // 
            // colAdminApp
            // 
            this.colAdminApp.HeaderText = "Approved By";
            this.colAdminApp.MinimumWidth = 6;
            this.colAdminApp.Name = "colAdminApp";
            this.colAdminApp.ReadOnly = true;
            this.colAdminApp.Width = 125;
            // 
            // colDate
            // 
            this.colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDate.HeaderText = "Date";
            this.colDate.MinimumWidth = 6;
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AdminPage.Properties.Resources.invoiceBG1;
            this.pictureBox1.Location = new System.Drawing.Point(201, 357);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(614, 211);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // UC_Transaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(234)))), ((int)(((byte)(239)))));
            this.Controls.Add(this.detailsLabelTrans);
            this.Controls.Add(this.TransactionTable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UC_Transaction";
            this.Size = new System.Drawing.Size(1060, 581);
            this.Load += new System.EventHandler(this.UC_Transaction_LoadAsync);
            ((System.ComponentModel.ISupportInitialize)(this.TransactionTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView TransactionTable;
        private System.Windows.Forms.Label detailsLabelTrans;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSRCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colService;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdminApp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
