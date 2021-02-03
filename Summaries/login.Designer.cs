namespace Summaries
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.label1 = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.loginBTN = new System.Windows.Forms.Button();
            this.resetBTN = new System.Windows.Forms.Button();
            this.credentialsWarningLB = new System.Windows.Forms.Label();
            this.versionLBL = new System.Windows.Forms.Label();
            this.layoutTableBase = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.languageDropDown = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.layoutTableBase.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // usernameBox
            // 
            resources.ApplyResources(this.usernameBox, "usernameBox");
            this.usernameBox.Name = "usernameBox";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // passwordBox
            // 
            resources.ApplyResources(this.passwordBox, "passwordBox");
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.UseSystemPasswordChar = true;
            this.passwordBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordBox_KeyDown);
            // 
            // loginBTN
            // 
            resources.ApplyResources(this.loginBTN, "loginBTN");
            this.loginBTN.Name = "loginBTN";
            this.loginBTN.UseVisualStyleBackColor = true;
            this.loginBTN.Click += new System.EventHandler(this.loginBTN_Click);
            // 
            // resetBTN
            // 
            resources.ApplyResources(this.resetBTN, "resetBTN");
            this.resetBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.resetBTN.Name = "resetBTN";
            this.resetBTN.UseVisualStyleBackColor = true;
            this.resetBTN.Click += new System.EventHandler(this.resetBTN_Click);
            // 
            // credentialsWarningLB
            // 
            resources.ApplyResources(this.credentialsWarningLB, "credentialsWarningLB");
            this.credentialsWarningLB.ForeColor = System.Drawing.Color.Red;
            this.credentialsWarningLB.Name = "credentialsWarningLB";
            // 
            // versionLBL
            // 
            resources.ApplyResources(this.versionLBL, "versionLBL");
            this.versionLBL.Name = "versionLBL";
            // 
            // layoutTableBase
            // 
            resources.ApplyResources(this.layoutTableBase, "layoutTableBase");
            this.layoutTableBase.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.layoutTableBase.Name = "layoutTableBase";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Image = global::Summaries.Properties.Resources.userIcon;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // languageDropDown
            // 
            resources.ApplyResources(this.languageDropDown, "languageDropDown");
            this.languageDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageDropDown.FormattingEnabled = true;
            this.languageDropDown.Items.AddRange(new object[] {
            resources.GetString("languageDropDown.Items"),
            resources.GetString("languageDropDown.Items1")});
            this.languageDropDown.Name = "languageDropDown";
            this.languageDropDown.SelectedValueChanged += new System.EventHandler(this.languageDropDown_SelectedValueChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.resetBTN;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.languageDropDown);
            this.Controls.Add(this.versionLBL);
            this.Controls.Add(this.credentialsWarningLB);
            this.Controls.Add(this.resetBTN);
            this.Controls.Add(this.loginBTN);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.layoutTableBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.login_FormClosed);
            this.Load += new System.EventHandler(this.login_Load);
            this.layoutTableBase.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Button loginBTN;
        private System.Windows.Forms.Button resetBTN;
        private System.Windows.Forms.Label credentialsWarningLB;
        private System.Windows.Forms.Label versionLBL;
        private System.Windows.Forms.TableLayoutPanel layoutTableBase;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox languageDropDown;
        private System.Windows.Forms.Label label3;
    }
}