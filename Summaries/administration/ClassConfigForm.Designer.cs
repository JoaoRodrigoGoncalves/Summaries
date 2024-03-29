﻿
namespace Summaries.administration
{
    partial class ClassConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClassConfigForm));
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.footerLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.okBTN = new System.Windows.Forms.Button();
            this.cancelBTN = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.GeneralTabPage = new System.Windows.Forms.TabPage();
            this.usersOnThisClassGV = new System.Windows.Forms.DataGridView();
            this.classNameTB = new System.Windows.Forms.TextBox();
            this.classNameLB = new System.Windows.Forms.Label();
            this.ClassNameTOPBox = new System.Windows.Forms.TextBox();
            this.classPic = new System.Windows.Forms.PictureBox();
            this.splitterLine = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.userLoginName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userDisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainLayoutPanel.SuspendLayout();
            this.footerLayoutPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.GeneralTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersOnThisClassGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // mainLayoutPanel
            // 
            resources.ApplyResources(this.mainLayoutPanel, "mainLayoutPanel");
            this.mainLayoutPanel.Controls.Add(this.footerLayoutPanel, 0, 1);
            this.mainLayoutPanel.Controls.Add(this.tabControl1, 0, 0);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            // 
            // footerLayoutPanel
            // 
            resources.ApplyResources(this.footerLayoutPanel, "footerLayoutPanel");
            this.footerLayoutPanel.Controls.Add(this.okBTN, 2, 0);
            this.footerLayoutPanel.Controls.Add(this.cancelBTN, 1, 0);
            this.footerLayoutPanel.Name = "footerLayoutPanel";
            // 
            // okBTN
            // 
            resources.ApplyResources(this.okBTN, "okBTN");
            this.okBTN.Name = "okBTN";
            this.okBTN.UseVisualStyleBackColor = true;
            this.okBTN.Click += new System.EventHandler(this.okBTN_Click);
            // 
            // cancelBTN
            // 
            resources.ApplyResources(this.cancelBTN, "cancelBTN");
            this.cancelBTN.Name = "cancelBTN";
            this.cancelBTN.UseVisualStyleBackColor = true;
            this.cancelBTN.Click += new System.EventHandler(this.cancelBTN_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.GeneralTabPage);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // GeneralTabPage
            // 
            this.GeneralTabPage.Controls.Add(this.usersOnThisClassGV);
            this.GeneralTabPage.Controls.Add(this.classNameTB);
            this.GeneralTabPage.Controls.Add(this.classNameLB);
            this.GeneralTabPage.Controls.Add(this.ClassNameTOPBox);
            this.GeneralTabPage.Controls.Add(this.classPic);
            this.GeneralTabPage.Controls.Add(this.splitterLine);
            resources.ApplyResources(this.GeneralTabPage, "GeneralTabPage");
            this.GeneralTabPage.Name = "GeneralTabPage";
            this.GeneralTabPage.UseVisualStyleBackColor = true;
            // 
            // usersOnThisClassGV
            // 
            this.usersOnThisClassGV.AllowUserToAddRows = false;
            this.usersOnThisClassGV.AllowUserToDeleteRows = false;
            this.usersOnThisClassGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.usersOnThisClassGV.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.usersOnThisClassGV.CausesValidation = false;
            this.usersOnThisClassGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersOnThisClassGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userLoginName,
            this.userDisplayName});
            resources.ApplyResources(this.usersOnThisClassGV, "usersOnThisClassGV");
            this.usersOnThisClassGV.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.usersOnThisClassGV.Name = "usersOnThisClassGV";
            this.usersOnThisClassGV.ReadOnly = true;
            // 
            // classNameTB
            // 
            resources.ApplyResources(this.classNameTB, "classNameTB");
            this.classNameTB.Name = "classNameTB";
            // 
            // classNameLB
            // 
            resources.ApplyResources(this.classNameLB, "classNameLB");
            this.classNameLB.Name = "classNameLB";
            // 
            // ClassNameTOPBox
            // 
            resources.ApplyResources(this.ClassNameTOPBox, "ClassNameTOPBox");
            this.ClassNameTOPBox.Name = "ClassNameTOPBox";
            this.ClassNameTOPBox.ReadOnly = true;
            // 
            // classPic
            // 
            this.classPic.BackColor = System.Drawing.Color.Gainsboro;
            this.classPic.BackgroundImage = global::Summaries.Properties.Resources.group;
            resources.ApplyResources(this.classPic, "classPic");
            this.classPic.Name = "classPic";
            this.classPic.TabStop = false;
            // 
            // splitterLine
            // 
            resources.ApplyResources(this.splitterLine, "splitterLine");
            this.splitterLine.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.splitterLine.Name = "splitterLine";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // userLoginName
            // 
            this.userLoginName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            resources.ApplyResources(this.userLoginName, "userLoginName");
            this.userLoginName.Name = "userLoginName";
            this.userLoginName.ReadOnly = true;
            // 
            // userDisplayName
            // 
            this.userDisplayName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.userDisplayName, "userDisplayName");
            this.userDisplayName.Name = "userDisplayName";
            this.userDisplayName.ReadOnly = true;
            // 
            // ClassConfigForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainLayoutPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClassConfigForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClassConfigForm_FormClosed);
            this.Load += new System.EventHandler(this.ClassConfigForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ClassConfigForm_KeyDown);
            this.mainLayoutPanel.ResumeLayout(false);
            this.footerLayoutPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.GeneralTabPage.ResumeLayout(false);
            this.GeneralTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersOnThisClassGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classPic)).EndInit();
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
        private System.Windows.Forms.PictureBox classPic;
        private System.Windows.Forms.Label splitterLine;
        private System.Windows.Forms.TextBox ClassNameTOPBox;
        private System.Windows.Forms.TextBox classNameTB;
        private System.Windows.Forms.Label classNameLB;
        private System.Windows.Forms.DataGridView usersOnThisClassGV;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn userLoginName;
        private System.Windows.Forms.DataGridViewTextBoxColumn userDisplayName;
    }
}