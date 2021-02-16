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
            this.workspaceComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.missedDayCheckBox = new System.Windows.Forms.CheckBox();
            this.dayHoursNumberBox = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.fileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteFileBTN = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.summaryNumberBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attachmentsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayHoursNumberBox)).BeginInit();
            this.SuspendLayout();
            // 
            // saveBTN
            // 
            resources.ApplyResources(this.saveBTN, "saveBTN");
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.UseVisualStyleBackColor = true;
            this.saveBTN.Click += new System.EventHandler(this.saveBTN_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // summaryNumberBox
            // 
            resources.ApplyResources(this.summaryNumberBox, "summaryNumberBox");
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
            this.summaryNumberBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // dateBox
            // 
            resources.ApplyResources(this.dateBox, "dateBox");
            this.dateBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateBox.Name = "dateBox";
            this.dateBox.Value = new System.DateTime(2019, 12, 30, 11, 4, 31, 0);
            // 
            // contentsBox
            // 
            resources.ApplyResources(this.contentsBox, "contentsBox");
            this.contentsBox.DetectUrls = false;
            this.contentsBox.Name = "contentsBox";
            // 
            // cancelBTN
            // 
            resources.ApplyResources(this.cancelBTN, "cancelBTN");
            this.cancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBTN.Name = "cancelBTN";
            this.cancelBTN.UseVisualStyleBackColor = true;
            // 
            // fileUpload
            // 
            resources.ApplyResources(this.fileUpload, "fileUpload");
            this.fileUpload.Multiselect = true;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.addAttachmentBTN);
            this.groupBox1.Controls.Add(this.attachmentsGridView);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // addAttachmentBTN
            // 
            resources.ApplyResources(this.addAttachmentBTN, "addAttachmentBTN");
            this.addAttachmentBTN.Name = "addAttachmentBTN";
            this.addAttachmentBTN.UseVisualStyleBackColor = true;
            this.addAttachmentBTN.Click += new System.EventHandler(this.addAttachmentBTN_Click);
            // 
            // attachmentsGridView
            // 
            resources.ApplyResources(this.attachmentsGridView, "attachmentsGridView");
            this.attachmentsGridView.AllowDrop = true;
            this.attachmentsGridView.AllowUserToAddRows = false;
            this.attachmentsGridView.AllowUserToDeleteRows = false;
            this.attachmentsGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.attachmentsGridView.CausesValidation = false;
            this.attachmentsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.attachmentsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileName,
            this.deleteFileBTN});
            this.attachmentsGridView.Name = "attachmentsGridView";
            this.attachmentsGridView.ReadOnly = true;
            this.attachmentsGridView.RowHeadersVisible = false;
            this.attachmentsGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.attachmentsGridView.ShowEditingIcon = false;
            this.attachmentsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.attachmentsGridView_CellContentClick);
            this.attachmentsGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.attachmentsGridView_DragDrop);
            this.attachmentsGridView.DragEnter += new System.Windows.Forms.DragEventHandler(this.attachmentsGridView_DragEnter);
            // 
            // workspaceComboBox
            // 
            resources.ApplyResources(this.workspaceComboBox, "workspaceComboBox");
            this.workspaceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.workspaceComboBox.FormattingEnabled = true;
            this.workspaceComboBox.Name = "workspaceComboBox";
            this.workspaceComboBox.DropDownClosed += new System.EventHandler(this.workspaceComboBox_DropDownClosed);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // missedDayCheckBox
            // 
            resources.ApplyResources(this.missedDayCheckBox, "missedDayCheckBox");
            this.missedDayCheckBox.Name = "missedDayCheckBox";
            this.missedDayCheckBox.UseVisualStyleBackColor = true;
            this.missedDayCheckBox.CheckedChanged += new System.EventHandler(this.missedDayCheckBox_CheckedChanged);
            // 
            // dayHoursNumberBox
            // 
            resources.ApplyResources(this.dayHoursNumberBox, "dayHoursNumberBox");
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
            this.dayHoursNumberBox.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // fileName
            // 
            this.fileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.fileName.Frozen = true;
            resources.ApplyResources(this.fileName, "fileName");
            this.fileName.Name = "fileName";
            this.fileName.ReadOnly = true;
            // 
            // deleteFileBTN
            // 
            this.deleteFileBTN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.deleteFileBTN.Frozen = true;
            resources.ApplyResources(this.deleteFileBTN, "deleteFileBTN");
            this.deleteFileBTN.Name = "deleteFileBTN";
            this.deleteFileBTN.ReadOnly = true;
            this.deleteFileBTN.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.deleteFileBTN.Text = "Remove";
            // 
            // newSummary
            // 
            resources.ApplyResources(this, "$this");
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBTN;
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "newSummary";
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
        private System.Windows.Forms.CheckBox missedDayCheckBox;
        private System.Windows.Forms.NumericUpDown dayHoursNumberBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileName;
        private System.Windows.Forms.DataGridViewButtonColumn deleteFileBTN;
    }
}