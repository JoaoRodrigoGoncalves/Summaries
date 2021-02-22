
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
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // schoolNameTB
            // 
            resources.ApplyResources(this.schoolNameTB, "schoolNameTB");
            this.schoolNameTB.Name = "schoolNameTB";
            // 
            // saveBTN
            // 
            resources.ApplyResources(this.saveBTN, "saveBTN");
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.UseVisualStyleBackColor = true;
            this.saveBTN.Click += new System.EventHandler(this.saveBTN_Click);
            // 
            // cityNameTB
            // 
            resources.ApplyResources(this.cityNameTB, "cityNameTB");
            this.cityNameTB.Name = "cityNameTB";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cancelBTN
            // 
            resources.ApplyResources(this.cancelBTN, "cancelBTN");
            this.cancelBTN.Name = "cancelBTN";
            this.cancelBTN.UseVisualStyleBackColor = true;
            this.cancelBTN.Click += new System.EventHandler(this.cancelBTN_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ReportInfoForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancelBTN);
            this.Controls.Add(this.cityNameTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.saveBTN);
            this.Controls.Add(this.schoolNameTB);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "ReportInfoForm";
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