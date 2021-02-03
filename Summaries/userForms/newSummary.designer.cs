namespace Summaries
{
    partial class newSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(newSummary));
            this.saveBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.summaryNumberBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.dateBox = new System.Windows.Forms.DateTimePicker();
            this.contentsBox = new System.Windows.Forms.RichTextBox();
            this.cancelBTN = new System.Windows.Forms.Button();
            this.fileUpload = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addAttachmentBTN = new System.Windows.Forms.Button();
            this.attachmentsGridView = new System.Windows.Forms.DataGridView();
            this.fileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteFileBTN = new System.Windows.Forms.DataGridViewButtonColumn();
            this.workspaceComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.missedDayCheckBox = new System.Windows.Forms.CheckBox();
            this.dayHoursNumberBox = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.summaryNumberBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attachmentsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayHoursNumberBox)).BeginInit();
            this.SuspendLayout();
            // 
            // saveBTN
            // 
            this.saveBTN.Location = new System.Drawing.Point(380, 450);
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.Size = new System.Drawing.Size(75, 23);
            this.saveBTN.TabIndex = 6;
            this.saveBTN.Text = "Save";
            this.saveBTN.UseVisualStyleBackColor = true;
            this.saveBTN.Click += new System.EventHandler(this.saveBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Summary Number";
            // 
            // summaryNumberBox
            // 
            this.summaryNumberBox.Location = new System.Drawing.Point(108, 39);
            this.summaryNumberBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.summaryNumberBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.summaryNumberBox.Name = "summaryNumberBox";
            this.summaryNumberBox.Size = new System.Drawing.Size(53, 20);
            this.summaryNumberBox.TabIndex = 2;
            this.summaryNumberBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Date";
            // 
            // dateBox
            // 
            this.dateBox.CustomFormat = "yyyy-MM-dd";
            this.dateBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateBox.Location = new System.Drawing.Point(108, 66);
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(95, 20);
            this.dateBox.TabIndex = 3;
            this.dateBox.Value = new System.DateTime(2019, 12, 30, 11, 4, 31, 0);
            // 
            // contentsBox
            // 
            this.contentsBox.DetectUrls = false;
            this.contentsBox.Location = new System.Drawing.Point(15, 92);
            this.contentsBox.Name = "contentsBox";
            this.contentsBox.Size = new System.Drawing.Size(440, 190);
            this.contentsBox.TabIndex = 4;
            this.contentsBox.Text = "";
            // 
            // cancelBTN
            // 
            this.cancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBTN.Location = new System.Drawing.Point(299, 450);
            this.cancelBTN.Name = "cancelBTN";
            this.cancelBTN.Size = new System.Drawing.Size(75, 23);
            this.cancelBTN.TabIndex = 7;
            this.cancelBTN.Text = "Cancel";
            this.cancelBTN.UseVisualStyleBackColor = true;
            // 
            // fileUpload
            // 
            this.fileUpload.Filter = "All files (*.*)|*.*";
            this.fileUpload.Multiselect = true;
            this.fileUpload.Title = "Select a file to be uploaded...";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addAttachmentBTN);
            this.groupBox1.Controls.Add(this.attachmentsGridView);
            this.groupBox1.Location = new System.Drawing.Point(12, 288);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 156);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attachments";
            // 
            // addAttachmentBTN
            // 
            this.addAttachmentBTN.Location = new System.Drawing.Point(362, 19);
            this.addAttachmentBTN.Name = "addAttachmentBTN";
            this.addAttachmentBTN.Size = new System.Drawing.Size(75, 23);
            this.addAttachmentBTN.TabIndex = 6;
            this.addAttachmentBTN.Text = "Attach File...";
            this.addAttachmentBTN.UseVisualStyleBackColor = true;
            this.addAttachmentBTN.Click += new System.EventHandler(this.addAttachmentBTN_Click);
            // 
            // attachmentsGridView
            // 
            this.attachmentsGridView.AllowDrop = true;
            this.attachmentsGridView.AllowUserToAddRows = false;
            this.attachmentsGridView.AllowUserToDeleteRows = false;
            this.attachmentsGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.attachmentsGridView.CausesValidation = false;
            this.attachmentsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.attachmentsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileName,
            this.deleteFileBTN});
            this.attachmentsGridView.Location = new System.Drawing.Point(6, 49);
            this.attachmentsGridView.Name = "attachmentsGridView";
            this.attachmentsGridView.ReadOnly = true;
            this.attachmentsGridView.RowHeadersVisible = false;
            this.attachmentsGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.attachmentsGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.attachmentsGridView.ShowEditingIcon = false;
            this.attachmentsGridView.Size = new System.Drawing.Size(431, 101);
            this.attachmentsGridView.TabIndex = 5;
            this.attachmentsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.attachmentsGridView_CellContentClick);
            this.attachmentsGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.attachmentsGridView_DragDrop);
            this.attachmentsGridView.DragEnter += new System.Windows.Forms.DragEventHandler(this.attachmentsGridView_DragEnter);
            // 
            // fileName
            // 
            this.fileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.fileName.Frozen = true;
            this.fileName.HeaderText = "Name";
            this.fileName.Name = "fileName";
            this.fileName.ReadOnly = true;
            this.fileName.Width = 330;
            // 
            // deleteFileBTN
            // 
            this.deleteFileBTN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.deleteFileBTN.Frozen = true;
            this.deleteFileBTN.HeaderText = "";
            this.deleteFileBTN.Name = "deleteFileBTN";
            this.deleteFileBTN.ReadOnly = true;
            this.deleteFileBTN.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.deleteFileBTN.Text = "Remove";
            // 
            // workspaceComboBox
            // 
            this.workspaceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.workspaceComboBox.FormattingEnabled = true;
            this.workspaceComboBox.Location = new System.Drawing.Point(108, 12);
            this.workspaceComboBox.Name = "workspaceComboBox";
            this.workspaceComboBox.Size = new System.Drawing.Size(184, 21);
            this.workspaceComboBox.TabIndex = 1;
            this.workspaceComboBox.DropDownClosed += new System.EventHandler(this.workspaceComboBox_DropDownClosed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Workspace";
            // 
            // missedDayCheckBox
            // 
            this.missedDayCheckBox.AutoSize = true;
            this.missedDayCheckBox.Location = new System.Drawing.Point(374, 67);
            this.missedDayCheckBox.Name = "missedDayCheckBox";
            this.missedDayCheckBox.Size = new System.Drawing.Size(82, 17);
            this.missedDayCheckBox.TabIndex = 10;
            this.missedDayCheckBox.Text = "Not Present";
            this.missedDayCheckBox.UseVisualStyleBackColor = true;
            this.missedDayCheckBox.CheckedChanged += new System.EventHandler(this.missedDayCheckBox_CheckedChanged);
            // 
            // dayHoursNumberBox
            // 
            this.dayHoursNumberBox.Location = new System.Drawing.Point(330, 66);
            this.dayHoursNumberBox.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.dayHoursNumberBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dayHoursNumberBox.Name = "dayHoursNumberBox";
            this.dayHoursNumberBox.Size = new System.Drawing.Size(39, 20);
            this.dayHoursNumberBox.TabIndex = 11;
            this.dayHoursNumberBox.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(289, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Hours";
            // 
            // newSummary
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBTN;
            this.ClientSize = new System.Drawing.Size(473, 483);
            this.Controls.Add(this.dayHoursNumberBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.missedDayCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.workspaceComboBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelBTN);
            this.Controls.Add(this.contentsBox);
            this.Controls.Add(this.dateBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.summaryNumberBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveBTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(489, 522);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(489, 522);
            this.Name = "newSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add a new summary";
            this.Load += new System.EventHandler(this.newSummary_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.newSummary_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.newSummary_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.summaryNumberBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.attachmentsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayHoursNumberBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown summaryNumberBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateBox;
        private System.Windows.Forms.RichTextBox contentsBox;
        private System.Windows.Forms.Button cancelBTN;
        private System.Windows.Forms.OpenFileDialog fileUpload;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox workspaceComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView attachmentsGridView;
        private System.Windows.Forms.Button addAttachmentBTN;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileName;
        private System.Windows.Forms.DataGridViewButtonColumn deleteFileBTN;
        private System.Windows.Forms.CheckBox missedDayCheckBox;
        private System.Windows.Forms.NumericUpDown dayHoursNumberBox;
        private System.Windows.Forms.Label label4;
    }
}