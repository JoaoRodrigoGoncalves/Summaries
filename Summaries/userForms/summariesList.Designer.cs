namespace Summaries
{
    partial class summariesList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(summariesList));
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.addSummary = new System.Windows.Forms.ToolStripButton();
            this.editSummary = new System.Windows.Forms.ToolStripButton();
            this.deleteSummary = new System.Windows.Forms.ToolStripButton();
            this.refreshList = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.totalHoursLB = new System.Windows.Forms.ToolStripLabel();
            this.totalHoursHolder = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.summarizedHoursLB = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.exportWorkspace = new System.Windows.Forms.ToolStripButton();
            this.workspaceComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.summarizedHoursHolder = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGrid, "dataGrid");
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellDoubleClick);
            this.dataGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGrid_ColumnHeaderMouseClick);
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSummary,
            this.editSummary,
            this.deleteSummary,
            this.refreshList,
            this.toolStripLabel2});
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Name = "toolStrip";
            // 
            // addSummary
            // 
            this.addSummary.Image = global::Summaries.Properties.Resources.addSummary;
            resources.ApplyResources(this.addSummary, "addSummary");
            this.addSummary.Name = "addSummary";
            this.addSummary.Click += new System.EventHandler(this.addSummary_Click);
            // 
            // editSummary
            // 
            this.editSummary.Image = global::Summaries.Properties.Resources.newSummary;
            resources.ApplyResources(this.editSummary, "editSummary");
            this.editSummary.Name = "editSummary";
            this.editSummary.Click += new System.EventHandler(this.editSummary_Click);
            // 
            // deleteSummary
            // 
            this.deleteSummary.Image = global::Summaries.Properties.Resources.deleteSummary;
            resources.ApplyResources(this.deleteSummary, "deleteSummary");
            this.deleteSummary.Name = "deleteSummary";
            this.deleteSummary.Click += new System.EventHandler(this.deleteSummary_Click);
            // 
            // refreshList
            // 
            this.refreshList.Image = global::Summaries.Properties.Resources.refresh;
            resources.ApplyResources(this.refreshList, "refreshList");
            this.refreshList.Name = "refreshList";
            this.refreshList.Click += new System.EventHandler(this.refreshList_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.Name = "toolStripLabel2";
            resources.ApplyResources(this.toolStripLabel2, "toolStripLabel2");
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.totalHoursLB,
            this.totalHoursHolder,
            this.toolStripSeparator2,
            this.summarizedHoursLB,
            this.toolStripLabel3,
            this.exportWorkspace,
            this.workspaceComboBox,
            this.toolStripLabel4,
            this.summarizedHoursHolder});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // totalHoursLB
            // 
            this.totalHoursLB.Name = "totalHoursLB";
            resources.ApplyResources(this.totalHoursLB, "totalHoursLB");
            // 
            // totalHoursHolder
            // 
            this.totalHoursHolder.Name = "totalHoursHolder";
            resources.ApplyResources(this.totalHoursHolder, "totalHoursHolder");
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // summarizedHoursLB
            // 
            this.summarizedHoursLB.Name = "summarizedHoursLB";
            resources.ApplyResources(this.summarizedHoursLB, "summarizedHoursLB");
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel3.Name = "toolStripLabel3";
            resources.ApplyResources(this.toolStripLabel3, "toolStripLabel3");
            // 
            // exportWorkspace
            // 
            this.exportWorkspace.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exportWorkspace.Image = global::Summaries.Properties.Resources.export;
            resources.ApplyResources(this.exportWorkspace, "exportWorkspace");
            this.exportWorkspace.Name = "exportWorkspace";
            this.exportWorkspace.Click += new System.EventHandler(this.exportWorkspace_Click);
            // 
            // workspaceComboBox
            // 
            this.workspaceComboBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.workspaceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.workspaceComboBox.Name = "workspaceComboBox";
            resources.ApplyResources(this.workspaceComboBox, "workspaceComboBox");
            this.workspaceComboBox.DropDownClosed += new System.EventHandler(this.workspaceComboBox_DropDownClosed);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel4.Name = "toolStripLabel4";
            resources.ApplyResources(this.toolStripLabel4, "toolStripLabel4");
            // 
            // summarizedHoursHolder
            // 
            this.summarizedHoursHolder.Name = "summarizedHoursHolder";
            resources.ApplyResources(this.summarizedHoursHolder, "summarizedHoursHolder");
            // 
            // summariesList
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dataGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "summariesList";
            this.Load += new System.EventHandler(this.summariesList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton addSummary;
        private System.Windows.Forms.ToolStripButton editSummary;
        private System.Windows.Forms.ToolStripButton deleteSummary;
        private System.Windows.Forms.ToolStripButton refreshList;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel totalHoursLB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel summarizedHoursLB;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox workspaceComboBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripButton exportWorkspace;
        private System.Windows.Forms.ToolStripLabel totalHoursHolder;
        private System.Windows.Forms.ToolStripLabel summarizedHoursHolder;
    }
}