namespace Summaries
{
    partial class changePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(changePassword));
            this.changeBTN = new System.Windows.Forms.Button();
            this.cancelBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.currentPasswordBox = new System.Windows.Forms.TextBox();
            this.newPasswordBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.confirmPasswordBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // changeBTN
            // 
            resources.ApplyResources(this.changeBTN, "changeBTN");
            this.changeBTN.CausesValidation = false;
            this.changeBTN.Name = "changeBTN";
            this.changeBTN.UseVisualStyleBackColor = true;
            this.changeBTN.Click += new System.EventHandler(this.changeBTN_Click);
            // 
            // cancelBTN
            // 
            resources.ApplyResources(this.cancelBTN, "cancelBTN");
            this.cancelBTN.CausesValidation = false;
            this.cancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBTN.Name = "cancelBTN";
            this.cancelBTN.UseVisualStyleBackColor = true;
            this.cancelBTN.Click += new System.EventHandler(this.cancelBTN_Click);
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
            // currentPasswordBox
            // 
            resources.ApplyResources(this.currentPasswordBox, "currentPasswordBox");
            this.currentPasswordBox.Name = "currentPasswordBox";
            this.currentPasswordBox.UseSystemPasswordChar = true;
            this.currentPasswordBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.currentPasswordBox_KeyPress);
            // 
            // newPasswordBox
            // 
            resources.ApplyResources(this.newPasswordBox, "newPasswordBox");
            this.newPasswordBox.Name = "newPasswordBox";
            this.newPasswordBox.UseSystemPasswordChar = true;
            this.newPasswordBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.newPasswordBox_KeyPress);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // confirmPasswordBox
            // 
            resources.ApplyResources(this.confirmPasswordBox, "confirmPasswordBox");
            this.confirmPasswordBox.Name = "confirmPasswordBox";
            this.confirmPasswordBox.UseSystemPasswordChar = true;
            this.confirmPasswordBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.confirmPasswordBox_KeyPress);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // changePassword
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBTN;
            this.CausesValidation = false;
            this.Controls.Add(this.confirmPasswordBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.newPasswordBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.currentPasswordBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelBTN);
            this.Controls.Add(this.changeBTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "changePassword";
            this.Load += new System.EventHandler(this.changePassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button changeBTN;
        private System.Windows.Forms.Button cancelBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox currentPasswordBox;
        private System.Windows.Forms.TextBox newPasswordBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox confirmPasswordBox;
        private System.Windows.Forms.Label label4;
    }
}