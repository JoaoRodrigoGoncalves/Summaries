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
            this.removeCurrentBTN = new System.Windows.Forms.Button();
            this.fileDisplayer = new System.Windows.Forms.PictureBox();
            this.selectfileBTN = new System.Windows.Forms.Button();
            this.previousBTN = new System.Windows.Forms.Button();
            this.nextBTN = new System.Windows.Forms.Button();
            this.workspaceComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.summaryNumberBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileDisplayer)).BeginInit();
            this.SuspendLayout();
            // 
            // saveBTN
            // 
            this.saveBTN.Location = new System.Drawing.Point(380, 309);
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.Size = new System.Drawing.Size(75, 23);
            this.saveBTN.TabIndex = 9;
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
            this.contentsBox.Location = new System.Drawing.Point(15, 92);
            this.contentsBox.Name = "contentsBox";
            this.contentsBox.Size = new System.Drawing.Size(440, 212);
            this.contentsBox.TabIndex = 4;
            this.contentsBox.Text = "";
            // 
            // cancelBTN
            // 
            this.cancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBTN.Location = new System.Drawing.Point(299, 309);
            this.cancelBTN.Name = "cancelBTN";
            this.cancelBTN.Size = new System.Drawing.Size(75, 23);
            this.cancelBTN.TabIndex = 10;
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
            this.groupBox1.Controls.Add(this.removeCurrentBTN);
            this.groupBox1.Controls.Add(this.fileDisplayer);
            this.groupBox1.Controls.Add(this.selectfileBTN);
            this.groupBox1.Controls.Add(this.previousBTN);
            this.groupBox1.Controls.Add(this.nextBTN);
            this.groupBox1.Location = new System.Drawing.Point(461, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 291);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attachements";
            // 
            // removeCurrentBTN
            // 
            this.removeCurrentBTN.Enabled = false;
            this.removeCurrentBTN.Location = new System.Drawing.Point(236, 26);
            this.removeCurrentBTN.Name = "removeCurrentBTN";
            this.removeCurrentBTN.Size = new System.Drawing.Size(22, 23);
            this.removeCurrentBTN.TabIndex = 5;
            this.removeCurrentBTN.Text = "X";
            this.removeCurrentBTN.UseVisualStyleBackColor = true;
            // 
            // fileDisplayer
            // 
            this.fileDisplayer.Image = global::Summaries.Properties.Resources.noFileSelected1;
            this.fileDisplayer.InitialImage = global::Summaries.Properties.Resources.noFileSelected1;
            this.fileDisplayer.Location = new System.Drawing.Point(108, 27);
            this.fileDisplayer.Name = "fileDisplayer";
            this.fileDisplayer.Size = new System.Drawing.Size(150, 150);
            this.fileDisplayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.fileDisplayer.TabIndex = 4;
            this.fileDisplayer.TabStop = false;
            // 
            // selectfileBTN
            // 
            this.selectfileBTN.Location = new System.Drawing.Point(156, 183);
            this.selectfileBTN.Name = "selectfileBTN";
            this.selectfileBTN.Size = new System.Drawing.Size(54, 37);
            this.selectfileBTN.TabIndex = 7;
            this.selectfileBTN.Text = "Select File";
            this.selectfileBTN.UseVisualStyleBackColor = true;
            this.selectfileBTN.Click += new System.EventHandler(this.selectfileBTN_Click);
            // 
            // previousBTN
            // 
            this.previousBTN.Enabled = false;
            this.previousBTN.Location = new System.Drawing.Point(108, 183);
            this.previousBTN.Name = "previousBTN";
            this.previousBTN.Size = new System.Drawing.Size(42, 37);
            this.previousBTN.TabIndex = 6;
            this.previousBTN.Text = "<";
            this.previousBTN.UseVisualStyleBackColor = true;
            // 
            // nextBTN
            // 
            this.nextBTN.Enabled = false;
            this.nextBTN.Location = new System.Drawing.Point(216, 183);
            this.nextBTN.Name = "nextBTN";
            this.nextBTN.Size = new System.Drawing.Size(42, 37);
            this.nextBTN.TabIndex = 8;
            this.nextBTN.Text = ">";
            this.nextBTN.UseVisualStyleBackColor = true;
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
            // newSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBTN;
            this.ClientSize = new System.Drawing.Size(461, 344);
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
            this.Name = "newSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add a new summary";
            this.Load += new System.EventHandler(this.newSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.summaryNumberBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileDisplayer)).EndInit();
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
        private System.Windows.Forms.Button removeCurrentBTN;
        private System.Windows.Forms.PictureBox fileDisplayer;
        private System.Windows.Forms.Button selectfileBTN;
        private System.Windows.Forms.Button previousBTN;
        private System.Windows.Forms.Button nextBTN;
        private System.Windows.Forms.ComboBox workspaceComboBox;
        private System.Windows.Forms.Label label3;
    }
}