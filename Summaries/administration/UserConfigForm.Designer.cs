
namespace Summaries.administration
{
    partial class UserConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserConfigForm));
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.footerLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.okBTN = new System.Windows.Forms.Button();
            this.cancelBTN = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.GeneralTabPage = new System.Windows.Forms.TabPage();
            this.isDeletionProtectedCheck = new System.Windows.Forms.CheckBox();
            this.isAdminCheck = new System.Windows.Forms.CheckBox();
            this.classCB = new System.Windows.Forms.ComboBox();
            this.classLB = new System.Windows.Forms.Label();
            this.displayNameTB = new System.Windows.Forms.TextBox();
            this.displayNameLB = new System.Windows.Forms.Label();
            this.loginNameTB = new System.Windows.Forms.TextBox();
            this.usernameLB = new System.Windows.Forms.Label();
            this.UsernameTOPBox = new System.Windows.Forms.TextBox();
            this.userProfilePic = new System.Windows.Forms.PictureBox();
            this.splitterLine = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.mainLayoutPanel.SuspendLayout();
            this.footerLayoutPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.GeneralTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userProfilePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.ColumnCount = 1;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.Controls.Add(this.footerLayoutPanel, 0, 1);
            this.mainLayoutPanel.Controls.Add(this.tabControl1, 0, 0);
            this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.RowCount = 2;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.mainLayoutPanel.Size = new System.Drawing.Size(401, 506);
            this.mainLayoutPanel.TabIndex = 0;
            // 
            // footerLayoutPanel
            // 
            this.footerLayoutPanel.ColumnCount = 3;
            this.footerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.footerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.footerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.footerLayoutPanel.Controls.Add(this.okBTN, 2, 0);
            this.footerLayoutPanel.Controls.Add(this.cancelBTN, 1, 0);
            this.footerLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.footerLayoutPanel.Location = new System.Drawing.Point(3, 473);
            this.footerLayoutPanel.Name = "footerLayoutPanel";
            this.footerLayoutPanel.RowCount = 1;
            this.footerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.footerLayoutPanel.Size = new System.Drawing.Size(395, 30);
            this.footerLayoutPanel.TabIndex = 0;
            // 
            // okBTN
            // 
            this.okBTN.Location = new System.Drawing.Point(319, 3);
            this.okBTN.Name = "okBTN";
            this.okBTN.Size = new System.Drawing.Size(73, 23);
            this.okBTN.TabIndex = 0;
            this.okBTN.Text = "OK";
            this.okBTN.UseVisualStyleBackColor = true;
            this.okBTN.Click += new System.EventHandler(this.okBTN_Click);
            // 
            // cancelBTN
            // 
            this.cancelBTN.Location = new System.Drawing.Point(240, 3);
            this.cancelBTN.Name = "cancelBTN";
            this.cancelBTN.Size = new System.Drawing.Size(73, 23);
            this.cancelBTN.TabIndex = 1;
            this.cancelBTN.Text = "Cancel";
            this.cancelBTN.UseVisualStyleBackColor = true;
            this.cancelBTN.Click += new System.EventHandler(this.cancelBTN_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.GeneralTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(395, 464);
            this.tabControl1.TabIndex = 1;
            // 
            // GeneralTabPage
            // 
            this.GeneralTabPage.Controls.Add(this.isDeletionProtectedCheck);
            this.GeneralTabPage.Controls.Add(this.isAdminCheck);
            this.GeneralTabPage.Controls.Add(this.classCB);
            this.GeneralTabPage.Controls.Add(this.classLB);
            this.GeneralTabPage.Controls.Add(this.displayNameTB);
            this.GeneralTabPage.Controls.Add(this.displayNameLB);
            this.GeneralTabPage.Controls.Add(this.loginNameTB);
            this.GeneralTabPage.Controls.Add(this.usernameLB);
            this.GeneralTabPage.Controls.Add(this.UsernameTOPBox);
            this.GeneralTabPage.Controls.Add(this.userProfilePic);
            this.GeneralTabPage.Controls.Add(this.splitterLine);
            this.GeneralTabPage.Location = new System.Drawing.Point(4, 22);
            this.GeneralTabPage.Name = "GeneralTabPage";
            this.GeneralTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralTabPage.Size = new System.Drawing.Size(387, 438);
            this.GeneralTabPage.TabIndex = 0;
            this.GeneralTabPage.Text = "General";
            this.GeneralTabPage.UseVisualStyleBackColor = true;
            // 
            // isDeletionProtectedCheck
            // 
            this.isDeletionProtectedCheck.AutoSize = true;
            this.isDeletionProtectedCheck.Location = new System.Drawing.Point(10, 265);
            this.isDeletionProtectedCheck.Name = "isDeletionProtectedCheck";
            this.isDeletionProtectedCheck.Size = new System.Drawing.Size(205, 17);
            this.isDeletionProtectedCheck.TabIndex = 11;
            this.isDeletionProtectedCheck.Text = "Protected Against Accidental Deletion";
            this.isDeletionProtectedCheck.UseVisualStyleBackColor = true;
            // 
            // isAdminCheck
            // 
            this.isAdminCheck.AutoSize = true;
            this.isAdminCheck.Location = new System.Drawing.Point(10, 241);
            this.isAdminCheck.Name = "isAdminCheck";
            this.isAdminCheck.Size = new System.Drawing.Size(139, 17);
            this.isAdminCheck.TabIndex = 10;
            this.isAdminCheck.Text = "Administrative Privileges";
            this.isAdminCheck.UseVisualStyleBackColor = true;
            // 
            // classCB
            // 
            this.classCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classCB.FormattingEnabled = true;
            this.classCB.Location = new System.Drawing.Point(10, 194);
            this.classCB.Name = "classCB";
            this.classCB.Size = new System.Drawing.Size(370, 21);
            this.classCB.TabIndex = 9;
            // 
            // classLB
            // 
            this.classLB.AutoSize = true;
            this.classLB.Location = new System.Drawing.Point(7, 178);
            this.classLB.Name = "classLB";
            this.classLB.Size = new System.Drawing.Size(32, 13);
            this.classLB.TabIndex = 7;
            this.classLB.Text = "Class";
            // 
            // displayNameTB
            // 
            this.displayNameTB.Location = new System.Drawing.Point(10, 149);
            this.displayNameTB.Name = "displayNameTB";
            this.displayNameTB.Size = new System.Drawing.Size(370, 20);
            this.displayNameTB.TabIndex = 6;
            // 
            // displayNameLB
            // 
            this.displayNameLB.AutoSize = true;
            this.displayNameLB.Location = new System.Drawing.Point(7, 133);
            this.displayNameLB.Name = "displayNameLB";
            this.displayNameLB.Size = new System.Drawing.Size(72, 13);
            this.displayNameLB.TabIndex = 5;
            this.displayNameLB.Text = "Display Name";
            // 
            // loginNameTB
            // 
            this.loginNameTB.Location = new System.Drawing.Point(10, 105);
            this.loginNameTB.Name = "loginNameTB";
            this.loginNameTB.Size = new System.Drawing.Size(370, 20);
            this.loginNameTB.TabIndex = 4;
            // 
            // usernameLB
            // 
            this.usernameLB.AutoSize = true;
            this.usernameLB.Location = new System.Drawing.Point(7, 89);
            this.usernameLB.Name = "usernameLB";
            this.usernameLB.Size = new System.Drawing.Size(64, 13);
            this.usernameLB.TabIndex = 3;
            this.usernameLB.Text = "Login Name";
            // 
            // UsernameTOPBox
            // 
            this.UsernameTOPBox.Location = new System.Drawing.Point(76, 28);
            this.UsernameTOPBox.Name = "UsernameTOPBox";
            this.UsernameTOPBox.ReadOnly = true;
            this.UsernameTOPBox.Size = new System.Drawing.Size(306, 20);
            this.UsernameTOPBox.TabIndex = 2;
            // 
            // userProfilePic
            // 
            this.userProfilePic.BackColor = System.Drawing.Color.Gainsboro;
            this.userProfilePic.BackgroundImage = global::Summaries.Properties.Resources.userIcon;
            this.userProfilePic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.userProfilePic.Location = new System.Drawing.Point(6, 6);
            this.userProfilePic.Name = "userProfilePic";
            this.userProfilePic.Size = new System.Drawing.Size(64, 64);
            this.userProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userProfilePic.TabIndex = 0;
            this.userProfilePic.TabStop = false;
            // 
            // splitterLine
            // 
            this.splitterLine.AutoSize = true;
            this.splitterLine.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.splitterLine.Location = new System.Drawing.Point(7, 65);
            this.splitterLine.Name = "splitterLine";
            this.splitterLine.Size = new System.Drawing.Size(373, 13);
            this.splitterLine.TabIndex = 1;
            this.splitterLine.Text = "_____________________________________________________________";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // UserConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 506);
            this.Controls.Add(this.mainLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(417, 545);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(417, 545);
            this.Name = "UserConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Properties";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserConfigForm_FormClosed);
            this.Load += new System.EventHandler(this.UserConfigForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserConfigForm_KeyDown);
            this.mainLayoutPanel.ResumeLayout(false);
            this.footerLayoutPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.GeneralTabPage.ResumeLayout(false);
            this.GeneralTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userProfilePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel footerLayoutPanel;
        private System.Windows.Forms.Button okBTN;
        private System.Windows.Forms.Button cancelBTN;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage GeneralTabPage;
        private System.Windows.Forms.PictureBox userProfilePic;
        private System.Windows.Forms.Label splitterLine;
        private System.Windows.Forms.TextBox UsernameTOPBox;
        private System.Windows.Forms.TextBox displayNameTB;
        private System.Windows.Forms.Label displayNameLB;
        private System.Windows.Forms.TextBox loginNameTB;
        private System.Windows.Forms.Label usernameLB;
        private System.Windows.Forms.ComboBox classCB;
        private System.Windows.Forms.Label classLB;
        private System.Windows.Forms.CheckBox isDeletionProtectedCheck;
        private System.Windows.Forms.CheckBox isAdminCheck;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}