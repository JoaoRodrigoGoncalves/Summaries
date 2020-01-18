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
            this.button1 = new System.Windows.Forms.Button();
            this.fileUpload = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectedAttachments = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.summaryNumberBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedAttachments)).BeginInit();
            this.SuspendLayout();
            // 
            // saveBTN
            // 
            this.saveBTN.Location = new System.Drawing.Point(380, 310);
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
            this.cancelBTN.Location = new System.Drawing.Point(299, 310);
            this.cancelBTN.Name = "cancelBTN";
            this.cancelBTN.Size = new System.Drawing.Size(75, 23);
            this.cancelBTN.TabIndex = 5;
            this.cancelBTN.Text = "Cancel";
            this.cancelBTN.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Summaries.Properties.Resources.addSummary;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(186, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // fileUpload
            // 
            this.fileUpload.Filter = "All files (*.*)|*.*";
            this.fileUpload.Multiselect = true;
            this.fileUpload.Title = "Select a file to be uploaded...";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.selectedAttachments);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(461, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 321);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attachments";
            // 
            // selectedAttachments
            // 
            this.selectedAttachments.AllowUserToAddRows = false;
            this.selectedAttachments.AllowUserToDeleteRows = false;
            this.selectedAttachments.AllowUserToResizeRows = false;
            this.selectedAttachments.CausesValidation = false;
            this.selectedAttachments.Location = new System.Drawing.Point(6, 19);
            this.selectedAttachments.Name = "selectedAttachments";
            this.selectedAttachments.Size = new System.Drawing.Size(200, 269);
            this.selectedAttachments.TabIndex = 1;
            // 
            // newSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBTN;
            this.ClientSize = new System.Drawing.Size(685, 345);
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
            ((System.ComponentModel.ISupportInitialize)(this.selectedAttachments)).EndInit();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView selectedAttachments;
    }
}