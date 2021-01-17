
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
            this.GeneralTabPage.Controls.Add(this.usersOnThisClassGV);
            this.GeneralTabPage.Controls.Add(this.classNameTB);
            this.GeneralTabPage.Controls.Add(this.classNameLB);
            this.GeneralTabPage.Controls.Add(this.ClassNameTOPBox);
            this.GeneralTabPage.Controls.Add(this.classPic);
            this.GeneralTabPage.Controls.Add(this.splitterLine);
            this.GeneralTabPage.Location = new System.Drawing.Point(4, 22);
            this.GeneralTabPage.Name = "GeneralTabPage";
            this.GeneralTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralTabPage.Size = new System.Drawing.Size(387, 438);
            this.GeneralTabPage.TabIndex = 0;
            this.GeneralTabPage.Text = "General";
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
            this.usersOnThisClassGV.Enabled = false;
            this.usersOnThisClassGV.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.usersOnThisClassGV.Location = new System.Drawing.Point(6, 132);
            this.usersOnThisClassGV.Name = "usersOnThisClassGV";
            this.usersOnThisClassGV.ReadOnly = true;
            this.usersOnThisClassGV.Size = new System.Drawing.Size(374, 300);
            this.usersOnThisClassGV.TabIndex = 5;
            // 
            // classNameTB
            // 
            this.classNameTB.Location = new System.Drawing.Point(10, 105);
            this.classNameTB.Name = "classNameTB";
            this.classNameTB.Size = new System.Drawing.Size(370, 20);
            this.classNameTB.TabIndex = 4;
            // 
            // classNameLB
            // 
            this.classNameLB.AutoSize = true;
            this.classNameLB.Location = new System.Drawing.Point(7, 89);
            this.classNameLB.Name = "classNameLB";
            this.classNameLB.Size = new System.Drawing.Size(63, 13);
            this.classNameLB.TabIndex = 3;
            this.classNameLB.Text = "Class Name";
            // 
            // ClassNameTOPBox
            // 
            this.ClassNameTOPBox.Location = new System.Drawing.Point(76, 28);
            this.ClassNameTOPBox.Name = "ClassNameTOPBox";
            this.ClassNameTOPBox.ReadOnly = true;
            this.ClassNameTOPBox.Size = new System.Drawing.Size(306, 20);
            this.ClassNameTOPBox.TabIndex = 2;
            // 
            // classPic
            // 
            this.classPic.BackColor = System.Drawing.Color.Gainsboro;
            this.classPic.BackgroundImage = global::Summaries.Properties.Resources.group;
            this.classPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.classPic.Location = new System.Drawing.Point(6, 6);
            this.classPic.Name = "classPic";
            this.classPic.Size = new System.Drawing.Size(64, 64);
            this.classPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.classPic.TabIndex = 0;
            this.classPic.TabStop = false;
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
            // userLoginName
            // 
            this.userLoginName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.userLoginName.Frozen = true;
            this.userLoginName.HeaderText = "Login Name";
            this.userLoginName.Name = "userLoginName";
            this.userLoginName.ReadOnly = true;
            this.userLoginName.Width = 89;
            // 
            // userDisplayName
            // 
            this.userDisplayName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.userDisplayName.Frozen = true;
            this.userDisplayName.HeaderText = "Display Name";
            this.userDisplayName.Name = "userDisplayName";
            this.userDisplayName.ReadOnly = true;
            this.userDisplayName.Width = 97;
            // 
            // ClassConfigForm
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
            this.Name = "ClassConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Properties";
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