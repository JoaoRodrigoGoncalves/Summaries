
namespace Summaries.codeResources
{
    partial class ReportInfoForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportInfoForm));
            this.label1 = new System.Windows.Forms.Label();
            this.schoolNameTB = new System.Windows.Forms.TextBox();
            this.saveBTN = new System.Windows.Forms.Button();
            this.cityNameTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cancelBTN = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "School Name";
            // 
            // schoolNameTB
            // 
            this.schoolNameTB.Location = new System.Drawing.Point(90, 10);
            this.schoolNameTB.Name = "schoolNameTB";
            this.schoolNameTB.Size = new System.Drawing.Size(452, 20);
            this.schoolNameTB.TabIndex = 1;
            // 
            // saveBTN
            // 
            this.saveBTN.Location = new System.Drawing.Point(467, 62);
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.Size = new System.Drawing.Size(75, 23);
            this.saveBTN.TabIndex = 2;
            this.saveBTN.Text = "Save";
            this.saveBTN.UseVisualStyleBackColor = true;
            this.saveBTN.Click += new System.EventHandler(this.saveBTN_Click);
            // 
            // cityNameTB
            // 
            this.cityNameTB.Location = new System.Drawing.Point(90, 36);
            this.cityNameTB.Name = "cityNameTB";
            this.cityNameTB.Size = new System.Drawing.Size(452, 20);
            this.cityNameTB.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "City";
            // 
            // cancelBTN
            // 
            this.cancelBTN.Location = new System.Drawing.Point(386, 62);
            this.cancelBTN.Name = "cancelBTN";
            this.cancelBTN.Size = new System.Drawing.Size(75, 23);
            this.cancelBTN.TabIndex = 9;
            this.cancelBTN.Text = "Cancel";
            this.cancelBTN.UseVisualStyleBackColor = true;
            this.cancelBTN.Click += new System.EventHandler(this.cancelBTN_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ReportInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 93);
            this.Controls.Add(this.cancelBTN);
            this.Controls.Add(this.cityNameTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.saveBTN);
            this.Controls.Add(this.schoolNameTB);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(570, 132);
            this.MinimumSize = new System.Drawing.Size(570, 132);
            this.Name = "ReportInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Report";
            this.Load += new System.EventHandler(this.ReportInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox schoolNameTB;
        private System.Windows.Forms.Button saveBTN;
        private System.Windows.Forms.TextBox cityNameTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelBTN;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}