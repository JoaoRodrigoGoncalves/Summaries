
namespace Summaries.administration
{
    partial class WorkspaceConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkspaceConfigForm));
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.footerLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.okBTN = new System.Windows.Forms.Button();
            this.cancelBTN = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.GeneralTabPage = new System.Windows.Forms.TabPage();
            this.hoursDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.writeCheck = new System.Windows.Forms.CheckBox();
            this.readCheck = new System.Windows.Forms.CheckBox();
            this.workspaceNameTB = new System.Windows.Forms.TextBox();
            this.workspaceNameLB = new System.Windows.Forms.Label();
            this.WorkspaceNameTOPBox = new System.Windows.Forms.TextBox();
            this.workspacePic = new System.Windows.Forms.PictureBox();
            this.splitterLine = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.mainLayoutPanel.SuspendLayout();
            this.footerLayoutPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.GeneralTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hoursDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workspacePic)).BeginInit();
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
            this.GeneralTabPage.Controls.Add(this.hoursDataGridView);
            this.GeneralTabPage.Controls.Add(this.groupBox1);
            this.GeneralTabPage.Controls.Add(this.workspaceNameTB);
            this.GeneralTabPage.Controls.Add(this.workspaceNameLB);
            this.GeneralTabPage.Controls.Add(this.WorkspaceNameTOPBox);
            this.GeneralTabPage.Controls.Add(this.workspacePic);
            this.GeneralTabPage.Controls.Add(this.splitterLine);
            this.GeneralTabPage.Location = new System.Drawing.Point(4, 22);
            this.GeneralTabPage.Name = "GeneralTabPage";
            this.GeneralTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralTabPage.Size = new System.Drawing.Size(387, 438);
            this.GeneralTabPage.TabIndex = 0;
            this.GeneralTabPage.Text = "General";
            this.GeneralTabPage.UseVisualStyleBackColor = true;
            // 
            // hoursDataGridView
            // 
            this.hoursDataGridView.AllowUserToAddRows = false;
            this.hoursDataGridView.AllowUserToDeleteRows = false;
            this.hoursDataGridView.AllowUserToResizeRows = false;
            this.hoursDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hoursDataGridView.Location = new System.Drawing.Point(10, 206);
            this.hoursDataGridView.Name = "hoursDataGridView";
            this.hoursDataGridView.Size = new System.Drawing.Size(370, 226);
            this.hoursDataGridView.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.writeCheck);
            this.groupBox1.Controls.Add(this.readCheck);
            this.groupBox1.Location = new System.Drawing.Point(10, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 68);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Workspace Permissions";
            // 
            // writeCheck
            // 
            this.writeCheck.AutoSize = true;
            this.writeCheck.Location = new System.Drawing.Point(6, 42);
            this.writeCheck.Name = "writeCheck";
            this.writeCheck.Size = new System.Drawing.Size(81, 17);
            this.writeCheck.TabIndex = 6;
            this.writeCheck.Text = "Write Mode";
            this.writeCheck.UseVisualStyleBackColor = true;
            // 
            // readCheck
            // 
            this.readCheck.AutoSize = true;
            this.readCheck.Location = new System.Drawing.Point(6, 19);
            this.readCheck.Name = "readCheck";
            this.readCheck.Size = new System.Drawing.Size(82, 17);
            this.readCheck.TabIndex = 5;
            this.readCheck.Text = "Read Mode";
            this.readCheck.UseVisualStyleBackColor = true;
            // 
            // workspaceNameTB
            // 
            this.workspaceNameTB.Location = new System.Drawing.Point(10, 105);
            this.workspaceNameTB.Name = "workspaceNameTB";
            this.workspaceNameTB.Size = new System.Drawing.Size(370, 20);
            this.workspaceNameTB.TabIndex = 4;
            // 
            // workspaceNameLB
            // 
            this.workspaceNameLB.AutoSize = true;
            this.workspaceNameLB.Location = new System.Drawing.Point(7, 89);
            this.workspaceNameLB.Name = "workspaceNameLB";
            this.workspaceNameLB.Size = new System.Drawing.Size(93, 13);
            this.workspaceNameLB.TabIndex = 3;
            this.workspaceNameLB.Text = "Workspace Name";
            // 
            // WorkspaceNameTOPBox
            // 
            this.WorkspaceNameTOPBox.Location = new System.Drawing.Point(76, 28);
            this.WorkspaceNameTOPBox.Name = "WorkspaceNameTOPBox";
            this.WorkspaceNameTOPBox.ReadOnly = true;
            this.WorkspaceNameTOPBox.Size = new System.Drawing.Size(306, 20);
            this.WorkspaceNameTOPBox.TabIndex = 2;
            // 
            // workspacePic
            // 
            this.workspacePic.BackColor = System.Drawing.Color.Gainsboro;
            this.workspacePic.BackgroundImage = global::Summaries.Properties.Resources.summariesList;
            this.workspacePic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.workspacePic.Location = new System.Drawing.Point(6, 6);
            this.workspacePic.Name = "workspacePic";
            this.workspacePic.Size = new System.Drawing.Size(64, 64);
            this.workspacePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.workspacePic.TabIndex = 0;
            this.workspacePic.TabStop = false;
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
            // WorkspaceConfigForm
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
            this.Name = "WorkspaceConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Properties";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WorkspaceConfigForm_FormClosed);
            this.Load += new System.EventHandler(this.WorkspaceConfigForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WorkspaceConfigForm_KeyDown);
            this.mainLayoutPanel.ResumeLayout(false);
            this.footerLayoutPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.GeneralTabPage.ResumeLayout(false);
            this.GeneralTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hoursDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workspacePic)).EndInit();
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
        private System.Windows.Forms.PictureBox workspacePic;
        private System.Windows.Forms.Label splitterLine;
        private System.Windows.Forms.TextBox WorkspaceNameTOPBox;
        private System.Windows.Forms.TextBox workspaceNameTB;
        private System.Windows.Forms.Label workspaceNameLB;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.CheckBox writeCheck;
        private System.Windows.Forms.CheckBox readCheck;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView hoursDataGridView;
    }
}