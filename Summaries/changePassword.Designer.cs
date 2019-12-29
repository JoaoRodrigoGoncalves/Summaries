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
            this.resetBTN = new System.Windows.Forms.Button();
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
            this.changeBTN.CausesValidation = false;
            this.changeBTN.Location = new System.Drawing.Point(265, 133);
            this.changeBTN.Name = "changeBTN";
            this.changeBTN.Size = new System.Drawing.Size(110, 23);
            this.changeBTN.TabIndex = 0;
            this.changeBTN.Text = "Change Password";
            this.changeBTN.UseVisualStyleBackColor = true;
            this.changeBTN.Click += new System.EventHandler(this.changeBTN_Click);
            // 
            // resetBTN
            // 
            this.resetBTN.CausesValidation = false;
            this.resetBTN.Location = new System.Drawing.Point(184, 133);
            this.resetBTN.Name = "resetBTN";
            this.resetBTN.Size = new System.Drawing.Size(75, 23);
            this.resetBTN.TabIndex = 1;
            this.resetBTN.Text = "Reset Fields";
            this.resetBTN.UseVisualStyleBackColor = true;
            this.resetBTN.Click += new System.EventHandler(this.resetBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // usernameBox
            // 
            this.usernameBox.Enabled = false;
            this.usernameBox.Location = new System.Drawing.Point(134, 29);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(241, 20);
            this.usernameBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Current Password";
            // 
            // currentPasswordBox
            // 
            this.currentPasswordBox.Location = new System.Drawing.Point(134, 55);
            this.currentPasswordBox.Name = "currentPasswordBox";
            this.currentPasswordBox.Size = new System.Drawing.Size(241, 20);
            this.currentPasswordBox.TabIndex = 5;
            this.currentPasswordBox.UseSystemPasswordChar = true;
            this.currentPasswordBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.currentPasswordBox_KeyPress);
            // 
            // newPasswordBox
            // 
            this.newPasswordBox.Location = new System.Drawing.Point(134, 81);
            this.newPasswordBox.Name = "newPasswordBox";
            this.newPasswordBox.Size = new System.Drawing.Size(241, 20);
            this.newPasswordBox.TabIndex = 7;
            this.newPasswordBox.UseSystemPasswordChar = true;
            this.newPasswordBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.newPasswordBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "New Password";
            // 
            // confirmPasswordBox
            // 
            this.confirmPasswordBox.Location = new System.Drawing.Point(134, 107);
            this.confirmPasswordBox.Name = "confirmPasswordBox";
            this.confirmPasswordBox.Size = new System.Drawing.Size(241, 20);
            this.confirmPasswordBox.TabIndex = 9;
            this.confirmPasswordBox.UseSystemPasswordChar = true;
            this.confirmPasswordBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.confirmPasswordBox_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Confirm New Password";
            // 
            // changePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(397, 172);
            this.Controls.Add(this.confirmPasswordBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.newPasswordBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.currentPasswordBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resetBTN);
            this.Controls.Add(this.changeBTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "changePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password - ";
            this.Shown += new System.EventHandler(this.changePassword_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button changeBTN;
        private System.Windows.Forms.Button resetBTN;
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