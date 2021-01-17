namespace Summaries
{
    partial class main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.userSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuOptionsAdministration_Panel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptionsAdministration_PanelStrip = new System.Windows.Forms.ToolStripSeparator();
            this.menuOptionsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSummary = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSummaryNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSummaryList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAboutLicenses = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAboutSummaries = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sessionLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.summaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOptions,
            this.menuSummary,
            this.menuAbout});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menu.Size = new System.Drawing.Size(800, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menuOptions
            // 
            this.menuOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userSettingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.menuOptionsAdministration_Panel,
            this.menuOptionsAdministration_PanelStrip,
            this.menuOptionsExit});
            this.menuOptions.Name = "menuOptions";
            this.menuOptions.Size = new System.Drawing.Size(61, 20);
            this.menuOptions.Text = "&Options";
            // 
            // userSettingsToolStripMenuItem
            // 
            this.userSettingsToolStripMenuItem.Image = global::Summaries.Properties.Resources.administrationPanel;
            this.userSettingsToolStripMenuItem.Name = "userSettingsToolStripMenuItem";
            this.userSettingsToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.userSettingsToolStripMenuItem.Text = "User &Settings";
            this.userSettingsToolStripMenuItem.Click += new System.EventHandler(this.userSettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // menuOptionsAdministration_Panel
            // 
            this.menuOptionsAdministration_Panel.Image = global::Summaries.Properties.Resources.administrationPanel;
            this.menuOptionsAdministration_Panel.Name = "menuOptionsAdministration_Panel";
            this.menuOptionsAdministration_Panel.Size = new System.Drawing.Size(187, 22);
            this.menuOptionsAdministration_Panel.Text = "&Administration Menu";
            this.menuOptionsAdministration_Panel.Visible = false;
            this.menuOptionsAdministration_Panel.Click += new System.EventHandler(this.menuOptionsAdministration_Panel_Click);
            // 
            // menuOptionsAdministration_PanelStrip
            // 
            this.menuOptionsAdministration_PanelStrip.Name = "menuOptionsAdministration_PanelStrip";
            this.menuOptionsAdministration_PanelStrip.Size = new System.Drawing.Size(184, 6);
            this.menuOptionsAdministration_PanelStrip.Visible = false;
            // 
            // menuOptionsExit
            // 
            this.menuOptionsExit.Image = global::Summaries.Properties.Resources.exit;
            this.menuOptionsExit.Name = "menuOptionsExit";
            this.menuOptionsExit.Size = new System.Drawing.Size(187, 22);
            this.menuOptionsExit.Text = "&Exit";
            this.menuOptionsExit.Click += new System.EventHandler(this.menuOptionsExit_Click);
            // 
            // menuSummary
            // 
            this.menuSummary.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSummaryNew,
            this.menuSummaryList});
            this.menuSummary.Name = "menuSummary";
            this.menuSummary.Size = new System.Drawing.Size(70, 20);
            this.menuSummary.Text = "&Summary";
            // 
            // menuSummaryNew
            // 
            this.menuSummaryNew.Image = global::Summaries.Properties.Resources.newSummary;
            this.menuSummaryNew.Name = "menuSummaryNew";
            this.menuSummaryNew.Size = new System.Drawing.Size(154, 22);
            this.menuSummaryNew.Text = "&New Summary";
            this.menuSummaryNew.Click += new System.EventHandler(this.menuSummaryNew_Click);
            // 
            // menuSummaryList
            // 
            this.menuSummaryList.Image = global::Summaries.Properties.Resources.summariesList;
            this.menuSummaryList.Name = "menuSummaryList";
            this.menuSummaryList.Size = new System.Drawing.Size(154, 22);
            this.menuSummaryList.Text = "Summaries &List";
            this.menuSummaryList.Click += new System.EventHandler(this.menuSummaryList_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAboutLicenses,
            this.menuAboutSummaries});
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(52, 20);
            this.menuAbout.Text = "&About";
            // 
            // menuAboutLicenses
            // 
            this.menuAboutLicenses.Image = global::Summaries.Properties.Resources.licenses;
            this.menuAboutLicenses.Name = "menuAboutLicenses";
            this.menuAboutLicenses.Size = new System.Drawing.Size(169, 22);
            this.menuAboutLicenses.Text = "Li&censes";
            this.menuAboutLicenses.Click += new System.EventHandler(this.menuAboutLicenses_Click);
            // 
            // menuAboutSummaries
            // 
            this.menuAboutSummaries.Image = global::Summaries.Properties.Resources.aboutSummaries;
            this.menuAboutSummaries.Name = "menuAboutSummaries";
            this.menuAboutSummaries.Size = new System.Drawing.Size(169, 22);
            this.menuAboutSummaries.Text = "A&bout Summaries";
            this.menuAboutSummaries.Click += new System.EventHandler(this.menuAboutSummaries_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.sessionLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 428);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 22);
            this.panel1.TabIndex = 1;
            // 
            // sessionLabel
            // 
            this.sessionLabel.AutoSize = true;
            this.sessionLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.sessionLabel.Location = new System.Drawing.Point(732, 0);
            this.sessionLabel.Name = "sessionLabel";
            this.sessionLabel.Size = new System.Drawing.Size(68, 13);
            this.sessionLabel.TabIndex = 0;
            this.sessionLabel.Text = "Logged in as";
            this.sessionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 48);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.summaryToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // summaryToolStripMenuItem
            // 
            this.summaryToolStripMenuItem.Image = global::Summaries.Properties.Resources.newSummary;
            this.summaryToolStripMenuItem.Name = "summaryToolStripMenuItem";
            this.summaryToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.summaryToolStripMenuItem.Text = "Summary";
            this.summaryToolStripMenuItem.Click += new System.EventHandler(this.summaryToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::Summaries.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.CausesValidation = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-13, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1247, 108);
            this.label1.TabIndex = 2;
            this.label1.Text = "DEVELOPMENT VERSION";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Summaries";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.main_FormClosed);
            this.Load += new System.EventHandler(this.main_Load);
            this.Shown += new System.EventHandler(this.main_Shown);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuOptions;
        private System.Windows.Forms.ToolStripMenuItem menuOptionsExit;
        private System.Windows.Forms.ToolStripMenuItem menuSummary;
        private System.Windows.Forms.ToolStripMenuItem menuSummaryList;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStripMenuItem menuAboutLicenses;
        private System.Windows.Forms.ToolStripMenuItem menuAboutSummaries;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label sessionLabel;
        private System.Windows.Forms.ToolStripMenuItem menuSummaryNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuOptionsAdministration_Panel;
        private System.Windows.Forms.ToolStripSeparator menuOptionsAdministration_PanelStrip;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem summaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem userSettingsToolStripMenuItem;
    }
}