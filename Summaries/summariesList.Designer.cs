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
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(12, 12);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.Size = new System.Drawing.Size(776, 402);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellDoubleClick);
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSummary,
            this.editSummary,
            this.deleteSummary,
            this.refreshList});
            this.toolStrip.Location = new System.Drawing.Point(0, 425);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(800, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // addSummary
            // 
            this.addSummary.Image = global::Summaries.Properties.Resources.addSummary;
            this.addSummary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addSummary.Name = "addSummary";
            this.addSummary.Size = new System.Drawing.Size(136, 22);
            this.addSummary.Text = "Add a new summary";
            this.addSummary.Click += new System.EventHandler(this.addSummary_Click);
            // 
            // editSummary
            // 
            this.editSummary.Image = global::Summaries.Properties.Resources.newSummary;
            this.editSummary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editSummary.Name = "editSummary";
            this.editSummary.Size = new System.Drawing.Size(101, 22);
            this.editSummary.Text = "Edit Summary";
            this.editSummary.Click += new System.EventHandler(this.editSummary_Click);
            // 
            // deleteSummary
            // 
            this.deleteSummary.Image = global::Summaries.Properties.Resources.deleteSummary;
            this.deleteSummary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteSummary.Name = "deleteSummary";
            this.deleteSummary.Size = new System.Drawing.Size(114, 22);
            this.deleteSummary.Text = "Delete Summary";
            this.deleteSummary.Click += new System.EventHandler(this.deleteSummary_Click);
            // 
            // refreshList
            // 
            this.refreshList.Image = global::Summaries.Properties.Resources.refresh;
            this.refreshList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshList.Name = "refreshList";
            this.refreshList.Size = new System.Drawing.Size(66, 22);
            this.refreshList.Text = "Refresh";
            this.refreshList.Click += new System.EventHandler(this.refreshList_Click);
            // 
            // summariesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dataGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "summariesList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Summaries List";
            this.Load += new System.EventHandler(this.summariesList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
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
    }
}