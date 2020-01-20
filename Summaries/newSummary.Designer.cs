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
            this.attachmentsGroup = new System.Windows.Forms.GroupBox();
            this.selectFile3 = new System.Windows.Forms.Button();
            this.removeFile3 = new System.Windows.Forms.Button();
            this.fileBox3 = new System.Windows.Forms.TextBox();
            this.selectFile2 = new System.Windows.Forms.Button();
            this.removeFile2 = new System.Windows.Forms.Button();
            this.fileBox2 = new System.Windows.Forms.TextBox();
            this.selectFile = new System.Windows.Forms.Button();
            this.removeFile = new System.Windows.Forms.Button();
            this.fileBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.summaryNumberBox)).BeginInit();
            this.attachmentsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveBTN
            // 
            this.saveBTN.Location = new System.Drawing.Point(380, 428);
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.Size = new System.Drawing.Size(75, 23);
            this.saveBTN.TabIndex = 4;
            this.saveBTN.Text = "Save";
            this.saveBTN.UseVisualStyleBackColor = true;
            this.saveBTN.Click += new System.EventHandler(this.saveBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Summary Number";
            // 
            // summaryNumberBox
            // 
            this.summaryNumberBox.Location = new System.Drawing.Point(108, 13);
            this.summaryNumberBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.summaryNumberBox.Name = "summaryNumberBox";
            this.summaryNumberBox.Size = new System.Drawing.Size(53, 20);
            this.summaryNumberBox.TabIndex = 1;
            this.summaryNumberBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Date";
            // 
            // dateBox
            // 
            this.dateBox.CustomFormat = "yyyy-MM-dd";
            this.dateBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateBox.Location = new System.Drawing.Point(108, 40);
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(95, 20);
            this.dateBox.TabIndex = 2;
            this.dateBox.Value = new System.DateTime(2019, 12, 30, 11, 4, 31, 0);
            // 
            // contentsBox
            // 
            this.contentsBox.Location = new System.Drawing.Point(15, 80);
            this.contentsBox.Name = "contentsBox";
            this.contentsBox.Size = new System.Drawing.Size(440, 224);
            this.contentsBox.TabIndex = 3;
            this.contentsBox.Text = "";
            // 
            // cancelBTN
            // 
            this.cancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBTN.Location = new System.Drawing.Point(299, 428);
            this.cancelBTN.Name = "cancelBTN";
            this.cancelBTN.Size = new System.Drawing.Size(75, 23);
            this.cancelBTN.TabIndex = 5;
            this.cancelBTN.Text = "Cancel";
            this.cancelBTN.UseVisualStyleBackColor = true;
            // 
            // fileUpload
            // 
            this.fileUpload.Filter = "All files (*.*)|*.*";
            this.fileUpload.Multiselect = true;
            this.fileUpload.Title = "Select a file to be uploaded...";
            // 
            // attachmentsGroup
            // 
            this.attachmentsGroup.Controls.Add(this.selectFile3);
            this.attachmentsGroup.Controls.Add(this.removeFile3);
            this.attachmentsGroup.Controls.Add(this.fileBox3);
            this.attachmentsGroup.Controls.Add(this.selectFile2);
            this.attachmentsGroup.Controls.Add(this.removeFile2);
            this.attachmentsGroup.Controls.Add(this.fileBox2);
            this.attachmentsGroup.Controls.Add(this.selectFile);
            this.attachmentsGroup.Controls.Add(this.removeFile);
            this.attachmentsGroup.Controls.Add(this.fileBox);
            this.attachmentsGroup.Location = new System.Drawing.Point(15, 311);
            this.attachmentsGroup.Name = "attachmentsGroup";
            this.attachmentsGroup.Size = new System.Drawing.Size(439, 111);
            this.attachmentsGroup.TabIndex = 6;
            this.attachmentsGroup.TabStop = false;
            this.attachmentsGroup.Text = "Attachments";
            // 
            // selectFile3
            // 
            this.selectFile3.Location = new System.Drawing.Point(379, 68);
            this.selectFile3.Name = "selectFile3";
            this.selectFile3.Size = new System.Drawing.Size(26, 23);
            this.selectFile3.TabIndex = 8;
            this.selectFile3.Text = "...";
            this.selectFile3.UseVisualStyleBackColor = true;
            this.selectFile3.Click += new System.EventHandler(this.selectFile3_Click);
            // 
            // removeFile3
            // 
            this.removeFile3.Enabled = false;
            this.removeFile3.Location = new System.Drawing.Point(411, 68);
            this.removeFile3.Name = "removeFile3";
            this.removeFile3.Size = new System.Drawing.Size(22, 23);
            this.removeFile3.TabIndex = 7;
            this.removeFile3.Text = "X";
            this.removeFile3.UseVisualStyleBackColor = true;
            this.removeFile3.Visible = false;
            this.removeFile3.Click += new System.EventHandler(this.removeFile3_Click);
            // 
            // fileBox3
            // 
            this.fileBox3.CausesValidation = false;
            this.fileBox3.Location = new System.Drawing.Point(6, 70);
            this.fileBox3.Name = "fileBox3";
            this.fileBox3.ReadOnly = true;
            this.fileBox3.Size = new System.Drawing.Size(367, 20);
            this.fileBox3.TabIndex = 6;
            this.fileBox3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.fileBox3_MouseClick);
            this.fileBox3.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fileBox3_MouseDoubleClick);
            // 
            // selectFile2
            // 
            this.selectFile2.Location = new System.Drawing.Point(379, 42);
            this.selectFile2.Name = "selectFile2";
            this.selectFile2.Size = new System.Drawing.Size(26, 23);
            this.selectFile2.TabIndex = 5;
            this.selectFile2.Text = "...";
            this.selectFile2.UseVisualStyleBackColor = true;
            this.selectFile2.Click += new System.EventHandler(this.selectFile2_Click);
            // 
            // removeFile2
            // 
            this.removeFile2.Enabled = false;
            this.removeFile2.Location = new System.Drawing.Point(411, 42);
            this.removeFile2.Name = "removeFile2";
            this.removeFile2.Size = new System.Drawing.Size(22, 23);
            this.removeFile2.TabIndex = 4;
            this.removeFile2.Text = "X";
            this.removeFile2.UseVisualStyleBackColor = true;
            this.removeFile2.Visible = false;
            this.removeFile2.Click += new System.EventHandler(this.removeFile2_Click);
            // 
            // fileBox2
            // 
            this.fileBox2.CausesValidation = false;
            this.fileBox2.Location = new System.Drawing.Point(6, 44);
            this.fileBox2.Name = "fileBox2";
            this.fileBox2.ReadOnly = true;
            this.fileBox2.Size = new System.Drawing.Size(367, 20);
            this.fileBox2.TabIndex = 3;
            this.fileBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.fileBox2_MouseClick);
            this.fileBox2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fileBox2_MouseDoubleClick);
            // 
            // selectFile
            // 
            this.selectFile.Location = new System.Drawing.Point(379, 16);
            this.selectFile.Name = "selectFile";
            this.selectFile.Size = new System.Drawing.Size(26, 23);
            this.selectFile.TabIndex = 2;
            this.selectFile.Text = "...";
            this.selectFile.UseVisualStyleBackColor = true;
            this.selectFile.Click += new System.EventHandler(this.selectFile_Click);
            // 
            // removeFile
            // 
            this.removeFile.Enabled = false;
            this.removeFile.Location = new System.Drawing.Point(411, 16);
            this.removeFile.Name = "removeFile";
            this.removeFile.Size = new System.Drawing.Size(22, 23);
            this.removeFile.TabIndex = 1;
            this.removeFile.Text = "X";
            this.removeFile.UseVisualStyleBackColor = true;
            this.removeFile.Visible = false;
            this.removeFile.Click += new System.EventHandler(this.removeFile_Click);
            // 
            // fileBox
            // 
            this.fileBox.CausesValidation = false;
            this.fileBox.Location = new System.Drawing.Point(6, 18);
            this.fileBox.Name = "fileBox";
            this.fileBox.ReadOnly = true;
            this.fileBox.Size = new System.Drawing.Size(367, 20);
            this.fileBox.TabIndex = 0;
            this.fileBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.fileBox_MouseClick);
            this.fileBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fileBox_MouseDoubleClick);
            // 
            // newSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBTN;
            this.ClientSize = new System.Drawing.Size(466, 463);
            this.Controls.Add(this.attachmentsGroup);
            this.Controls.Add(this.cancelBTN);
            this.Controls.Add(this.contentsBox);
            this.Controls.Add(this.dateBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.summaryNumberBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveBTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "newSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add a new summary";
            this.Load += new System.EventHandler(this.newSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.summaryNumberBox)).EndInit();
            this.attachmentsGroup.ResumeLayout(false);
            this.attachmentsGroup.PerformLayout();
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
        private System.Windows.Forms.GroupBox attachmentsGroup;
        private System.Windows.Forms.Button selectFile3;
        private System.Windows.Forms.Button removeFile3;
        private System.Windows.Forms.TextBox fileBox3;
        private System.Windows.Forms.Button selectFile2;
        private System.Windows.Forms.Button removeFile2;
        private System.Windows.Forms.TextBox fileBox2;
        private System.Windows.Forms.Button selectFile;
        private System.Windows.Forms.Button removeFile;
        private System.Windows.Forms.TextBox fileBox;
    }
}