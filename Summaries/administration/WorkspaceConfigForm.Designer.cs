
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.addClassBTN = new System.Windows.Forms.Button();
            this.classesCB = new System.Windows.Forms.ComboBox();
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
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hoursDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workspacePic)).BeginInit();
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
            this.GeneralTabPage.Controls.Add(this.groupBox2);
            this.GeneralTabPage.Controls.Add(this.groupBox1);
            this.GeneralTabPage.Controls.Add(this.workspaceNameTB);
            this.GeneralTabPage.Controls.Add(this.workspaceNameLB);
            this.GeneralTabPage.Controls.Add(this.WorkspaceNameTOPBox);
            this.GeneralTabPage.Controls.Add(this.workspacePic);
            this.GeneralTabPage.Controls.Add(this.splitterLine);
            resources.ApplyResources(this.GeneralTabPage, "GeneralTabPage");
            this.GeneralTabPage.Name = "GeneralTabPage";
            this.GeneralTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.addClassBTN);
            this.groupBox2.Controls.Add(this.classesCB);
            this.groupBox2.Controls.Add(this.hoursDataGridView);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // addClassBTN
            // 
            resources.ApplyResources(this.addClassBTN, "addClassBTN");
            this.addClassBTN.Name = "addClassBTN";
            this.addClassBTN.UseVisualStyleBackColor = true;
            this.addClassBTN.Click += new System.EventHandler(this.addClassBTN_Click);
            // 
            // classesCB
            // 
            this.classesCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classesCB.FormattingEnabled = true;
            resources.ApplyResources(this.classesCB, "classesCB");
            this.classesCB.Name = "classesCB";
            this.classesCB.Sorted = true;
            // 
            // hoursDataGridView
            // 
            this.hoursDataGridView.AllowUserToAddRows = false;
            this.hoursDataGridView.AllowUserToDeleteRows = false;
            this.hoursDataGridView.AllowUserToResizeRows = false;
            this.hoursDataGridView.CausesValidation = false;
            this.hoursDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.hoursDataGridView, "hoursDataGridView");
            this.hoursDataGridView.MultiSelect = false;
            this.hoursDataGridView.Name = "hoursDataGridView";
            this.hoursDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.hoursDataGridView_CellClick);
            this.hoursDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.hoursDataGridView_CellValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.writeCheck);
            this.groupBox1.Controls.Add(this.readCheck);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // writeCheck
            // 
            resources.ApplyResources(this.writeCheck, "writeCheck");
            this.writeCheck.Name = "writeCheck";
            this.writeCheck.UseVisualStyleBackColor = true;
            // 
            // readCheck
            // 
            resources.ApplyResources(this.readCheck, "readCheck");
            this.readCheck.Name = "readCheck";
            this.readCheck.UseVisualStyleBackColor = true;
            // 
            // workspaceNameTB
            // 
            resources.ApplyResources(this.workspaceNameTB, "workspaceNameTB");
            this.workspaceNameTB.Name = "workspaceNameTB";
            // 
            // workspaceNameLB
            // 
            resources.ApplyResources(this.workspaceNameLB, "workspaceNameLB");
            this.workspaceNameLB.Name = "workspaceNameLB";
            // 
            // WorkspaceNameTOPBox
            // 
            resources.ApplyResources(this.WorkspaceNameTOPBox, "WorkspaceNameTOPBox");
            this.WorkspaceNameTOPBox.Name = "WorkspaceNameTOPBox";
            this.WorkspaceNameTOPBox.ReadOnly = true;
            // 
            // workspacePic
            // 
            this.workspacePic.BackColor = System.Drawing.Color.Gainsboro;
            this.workspacePic.BackgroundImage = global::Summaries.Properties.Resources.summariesList;
            resources.ApplyResources(this.workspacePic, "workspacePic");
            this.workspacePic.Name = "workspacePic";
            this.workspacePic.TabStop = false;
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
            // WorkspaceConfigForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainLayoutPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WorkspaceConfigForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WorkspaceConfigForm_FormClosed);
            this.Load += new System.EventHandler(this.WorkspaceConfigForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WorkspaceConfigForm_KeyDown);
            this.mainLayoutPanel.ResumeLayout(false);
            this.footerLayoutPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.GeneralTabPage.ResumeLayout(false);
            this.GeneralTabPage.PerformLayout();
            this.groupBox2.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button addClassBTN;
        private System.Windows.Forms.ComboBox classesCB;
    }
}