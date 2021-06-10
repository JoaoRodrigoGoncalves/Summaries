
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
            this.workspacesPage = new System.Windows.Forms.TabPage();
            this.noDataLabel = new System.Windows.Forms.Label();
            this.workspacesDataGrid = new System.Windows.Forms.DataGridView();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.mainLayoutPanel.SuspendLayout();
            this.footerLayoutPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.GeneralTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userProfilePic)).BeginInit();
            this.workspacesPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workspacesDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // mainLayoutPanel
            // 
            resources.ApplyResources(this.mainLayoutPanel, "mainLayoutPanel");
            this.mainLayoutPanel.Controls.Add(this.footerLayoutPanel, 0, 1);
            this.mainLayoutPanel.Controls.Add(this.tabControl1, 0, 0);
            this.errorProvider.SetError(this.mainLayoutPanel, resources.GetString("mainLayoutPanel.Error"));
            this.errorProvider.SetIconAlignment(this.mainLayoutPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("mainLayoutPanel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.mainLayoutPanel, ((int)(resources.GetObject("mainLayoutPanel.IconPadding"))));
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            // 
            // footerLayoutPanel
            // 
            resources.ApplyResources(this.footerLayoutPanel, "footerLayoutPanel");
            this.footerLayoutPanel.Controls.Add(this.okBTN, 2, 0);
            this.footerLayoutPanel.Controls.Add(this.cancelBTN, 1, 0);
            this.errorProvider.SetError(this.footerLayoutPanel, resources.GetString("footerLayoutPanel.Error"));
            this.errorProvider.SetIconAlignment(this.footerLayoutPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("footerLayoutPanel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.footerLayoutPanel, ((int)(resources.GetObject("footerLayoutPanel.IconPadding"))));
            this.footerLayoutPanel.Name = "footerLayoutPanel";
            // 
            // okBTN
            // 
            resources.ApplyResources(this.okBTN, "okBTN");
            this.errorProvider.SetError(this.okBTN, resources.GetString("okBTN.Error"));
            this.errorProvider.SetIconAlignment(this.okBTN, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("okBTN.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.okBTN, ((int)(resources.GetObject("okBTN.IconPadding"))));
            this.okBTN.Name = "okBTN";
            this.okBTN.UseVisualStyleBackColor = true;
            this.okBTN.Click += new System.EventHandler(this.okBTN_Click);
            // 
            // cancelBTN
            // 
            resources.ApplyResources(this.cancelBTN, "cancelBTN");
            this.errorProvider.SetError(this.cancelBTN, resources.GetString("cancelBTN.Error"));
            this.errorProvider.SetIconAlignment(this.cancelBTN, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cancelBTN.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.cancelBTN, ((int)(resources.GetObject("cancelBTN.IconPadding"))));
            this.cancelBTN.Name = "cancelBTN";
            this.cancelBTN.UseVisualStyleBackColor = true;
            this.cancelBTN.Click += new System.EventHandler(this.cancelBTN_Click);
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.GeneralTabPage);
            this.tabControl1.Controls.Add(this.workspacesPage);
            this.errorProvider.SetError(this.tabControl1, resources.GetString("tabControl1.Error"));
            this.errorProvider.SetIconAlignment(this.tabControl1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tabControl1.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.tabControl1, ((int)(resources.GetObject("tabControl1.IconPadding"))));
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // GeneralTabPage
            // 
            resources.ApplyResources(this.GeneralTabPage, "GeneralTabPage");
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
            this.errorProvider.SetError(this.GeneralTabPage, resources.GetString("GeneralTabPage.Error"));
            this.errorProvider.SetIconAlignment(this.GeneralTabPage, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("GeneralTabPage.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.GeneralTabPage, ((int)(resources.GetObject("GeneralTabPage.IconPadding"))));
            this.GeneralTabPage.Name = "GeneralTabPage";
            this.GeneralTabPage.UseVisualStyleBackColor = true;
            // 
            // isDeletionProtectedCheck
            // 
            resources.ApplyResources(this.isDeletionProtectedCheck, "isDeletionProtectedCheck");
            this.errorProvider.SetError(this.isDeletionProtectedCheck, resources.GetString("isDeletionProtectedCheck.Error"));
            this.errorProvider.SetIconAlignment(this.isDeletionProtectedCheck, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("isDeletionProtectedCheck.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.isDeletionProtectedCheck, ((int)(resources.GetObject("isDeletionProtectedCheck.IconPadding"))));
            this.isDeletionProtectedCheck.Name = "isDeletionProtectedCheck";
            this.isDeletionProtectedCheck.UseVisualStyleBackColor = true;
            // 
            // isAdminCheck
            // 
            resources.ApplyResources(this.isAdminCheck, "isAdminCheck");
            this.errorProvider.SetError(this.isAdminCheck, resources.GetString("isAdminCheck.Error"));
            this.errorProvider.SetIconAlignment(this.isAdminCheck, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("isAdminCheck.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.isAdminCheck, ((int)(resources.GetObject("isAdminCheck.IconPadding"))));
            this.isAdminCheck.Name = "isAdminCheck";
            this.isAdminCheck.UseVisualStyleBackColor = true;
            // 
            // classCB
            // 
            resources.ApplyResources(this.classCB, "classCB");
            this.classCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.errorProvider.SetError(this.classCB, resources.GetString("classCB.Error"));
            this.classCB.FormattingEnabled = true;
            this.errorProvider.SetIconAlignment(this.classCB, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("classCB.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.classCB, ((int)(resources.GetObject("classCB.IconPadding"))));
            this.classCB.Name = "classCB";
            // 
            // classLB
            // 
            resources.ApplyResources(this.classLB, "classLB");
            this.errorProvider.SetError(this.classLB, resources.GetString("classLB.Error"));
            this.errorProvider.SetIconAlignment(this.classLB, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("classLB.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.classLB, ((int)(resources.GetObject("classLB.IconPadding"))));
            this.classLB.Name = "classLB";
            // 
            // displayNameTB
            // 
            resources.ApplyResources(this.displayNameTB, "displayNameTB");
            this.errorProvider.SetError(this.displayNameTB, resources.GetString("displayNameTB.Error"));
            this.errorProvider.SetIconAlignment(this.displayNameTB, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("displayNameTB.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.displayNameTB, ((int)(resources.GetObject("displayNameTB.IconPadding"))));
            this.displayNameTB.Name = "displayNameTB";
            // 
            // displayNameLB
            // 
            resources.ApplyResources(this.displayNameLB, "displayNameLB");
            this.errorProvider.SetError(this.displayNameLB, resources.GetString("displayNameLB.Error"));
            this.errorProvider.SetIconAlignment(this.displayNameLB, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("displayNameLB.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.displayNameLB, ((int)(resources.GetObject("displayNameLB.IconPadding"))));
            this.displayNameLB.Name = "displayNameLB";
            // 
            // loginNameTB
            // 
            resources.ApplyResources(this.loginNameTB, "loginNameTB");
            this.errorProvider.SetError(this.loginNameTB, resources.GetString("loginNameTB.Error"));
            this.errorProvider.SetIconAlignment(this.loginNameTB, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("loginNameTB.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.loginNameTB, ((int)(resources.GetObject("loginNameTB.IconPadding"))));
            this.loginNameTB.Name = "loginNameTB";
            // 
            // usernameLB
            // 
            resources.ApplyResources(this.usernameLB, "usernameLB");
            this.errorProvider.SetError(this.usernameLB, resources.GetString("usernameLB.Error"));
            this.errorProvider.SetIconAlignment(this.usernameLB, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("usernameLB.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.usernameLB, ((int)(resources.GetObject("usernameLB.IconPadding"))));
            this.usernameLB.Name = "usernameLB";
            // 
            // UsernameTOPBox
            // 
            resources.ApplyResources(this.UsernameTOPBox, "UsernameTOPBox");
            this.errorProvider.SetError(this.UsernameTOPBox, resources.GetString("UsernameTOPBox.Error"));
            this.errorProvider.SetIconAlignment(this.UsernameTOPBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("UsernameTOPBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.UsernameTOPBox, ((int)(resources.GetObject("UsernameTOPBox.IconPadding"))));
            this.UsernameTOPBox.Name = "UsernameTOPBox";
            this.UsernameTOPBox.ReadOnly = true;
            // 
            // userProfilePic
            // 
            resources.ApplyResources(this.userProfilePic, "userProfilePic");
            this.userProfilePic.BackColor = System.Drawing.Color.Gainsboro;
            this.userProfilePic.BackgroundImage = global::Summaries.Properties.Resources.userIcon;
            this.errorProvider.SetError(this.userProfilePic, resources.GetString("userProfilePic.Error"));
            this.errorProvider.SetIconAlignment(this.userProfilePic, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("userProfilePic.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.userProfilePic, ((int)(resources.GetObject("userProfilePic.IconPadding"))));
            this.userProfilePic.Name = "userProfilePic";
            this.userProfilePic.TabStop = false;
            // 
            // splitterLine
            // 
            resources.ApplyResources(this.splitterLine, "splitterLine");
            this.errorProvider.SetError(this.splitterLine, resources.GetString("splitterLine.Error"));
            this.splitterLine.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.errorProvider.SetIconAlignment(this.splitterLine, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitterLine.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.splitterLine, ((int)(resources.GetObject("splitterLine.IconPadding"))));
            this.splitterLine.Name = "splitterLine";
            // 
            // workspacesPage
            // 
            resources.ApplyResources(this.workspacesPage, "workspacesPage");
            this.workspacesPage.Controls.Add(this.noDataLabel);
            this.workspacesPage.Controls.Add(this.workspacesDataGrid);
            this.errorProvider.SetError(this.workspacesPage, resources.GetString("workspacesPage.Error"));
            this.errorProvider.SetIconAlignment(this.workspacesPage, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("workspacesPage.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.workspacesPage, ((int)(resources.GetObject("workspacesPage.IconPadding"))));
            this.workspacesPage.Name = "workspacesPage";
            this.workspacesPage.UseVisualStyleBackColor = true;
            // 
            // noDataLabel
            // 
            resources.ApplyResources(this.noDataLabel, "noDataLabel");
            this.noDataLabel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.errorProvider.SetError(this.noDataLabel, resources.GetString("noDataLabel.Error"));
            this.errorProvider.SetIconAlignment(this.noDataLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("noDataLabel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.noDataLabel, ((int)(resources.GetObject("noDataLabel.IconPadding"))));
            this.noDataLabel.Name = "noDataLabel";
            // 
            // workspacesDataGrid
            // 
            resources.ApplyResources(this.workspacesDataGrid, "workspacesDataGrid");
            this.workspacesDataGrid.AllowUserToAddRows = false;
            this.workspacesDataGrid.AllowUserToDeleteRows = false;
            this.workspacesDataGrid.AllowUserToResizeRows = false;
            this.workspacesDataGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.workspacesDataGrid.CausesValidation = false;
            this.workspacesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.workspacesDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.errorProvider.SetError(this.workspacesDataGrid, resources.GetString("workspacesDataGrid.Error"));
            this.errorProvider.SetIconAlignment(this.workspacesDataGrid, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("workspacesDataGrid.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.workspacesDataGrid, ((int)(resources.GetObject("workspacesDataGrid.IconPadding"))));
            this.workspacesDataGrid.Name = "workspacesDataGrid";
            this.workspacesDataGrid.ReadOnly = true;
            this.workspacesDataGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.workspacesDataGrid_MouseClick);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            resources.ApplyResources(this.errorProvider, "errorProvider");
            // 
            // UserConfigForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainLayoutPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserConfigForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserConfigForm_FormClosed);
            this.Load += new System.EventHandler(this.UserConfigForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserConfigForm_KeyDown);
            this.mainLayoutPanel.ResumeLayout(false);
            this.footerLayoutPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.GeneralTabPage.ResumeLayout(false);
            this.GeneralTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userProfilePic)).EndInit();
            this.workspacesPage.ResumeLayout(false);
            this.workspacesPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workspacesDataGrid)).EndInit();
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
        private System.Windows.Forms.TabPage workspacesPage;
        private System.Windows.Forms.DataGridView workspacesDataGrid;
        private System.Windows.Forms.Label noDataLabel;
    }
}