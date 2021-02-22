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
            this.bigBar = new System.Windows.Forms.ToolStrip();
            this.userSettingsBTN = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.licensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutSummariesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitBTN = new System.Windows.Forms.ToolStripButton();
            this.administrationMenuBTN = new System.Windows.Forms.ToolStripButton();
            this.newSummaryBTN = new System.Windows.Forms.ToolStripButton();
            this.summariesListBTN = new System.Windows.Forms.ToolStripButton();
            this.menu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.bigBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            resources.ApplyResources(this.menu, "menu");
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOptions,
            this.menuSummary,
            this.menuAbout});
            this.menu.Name = "menu";
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // menuOptions
            // 
            resources.ApplyResources(this.menuOptions, "menuOptions");
            this.menuOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userSettingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.menuOptionsAdministration_Panel,
            this.menuOptionsAdministration_PanelStrip,
            this.menuOptionsExit});
            this.menuOptions.Name = "menuOptions";
            // 
            // userSettingsToolStripMenuItem
            // 
            resources.ApplyResources(this.userSettingsToolStripMenuItem, "userSettingsToolStripMenuItem");
            this.userSettingsToolStripMenuItem.Image = global::Summaries.Properties.Resources.administrationPanel;
            this.userSettingsToolStripMenuItem.Name = "userSettingsToolStripMenuItem";
            this.userSettingsToolStripMenuItem.Click += new System.EventHandler(this.userSettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // menuOptionsAdministration_Panel
            // 
            resources.ApplyResources(this.menuOptionsAdministration_Panel, "menuOptionsAdministration_Panel");
            this.menuOptionsAdministration_Panel.Image = global::Summaries.Properties.Resources.administrationPanel;
            this.menuOptionsAdministration_Panel.Name = "menuOptionsAdministration_Panel";
            this.menuOptionsAdministration_Panel.Click += new System.EventHandler(this.menuOptionsAdministration_Panel_Click);
            // 
            // menuOptionsAdministration_PanelStrip
            // 
            resources.ApplyResources(this.menuOptionsAdministration_PanelStrip, "menuOptionsAdministration_PanelStrip");
            this.menuOptionsAdministration_PanelStrip.Name = "menuOptionsAdministration_PanelStrip";
            // 
            // menuOptionsExit
            // 
            resources.ApplyResources(this.menuOptionsExit, "menuOptionsExit");
            this.menuOptionsExit.Image = global::Summaries.Properties.Resources.exit;
            this.menuOptionsExit.Name = "menuOptionsExit";
            this.menuOptionsExit.Click += new System.EventHandler(this.menuOptionsExit_Click);
            // 
            // menuSummary
            // 
            resources.ApplyResources(this.menuSummary, "menuSummary");
            this.menuSummary.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSummaryNew,
            this.menuSummaryList});
            this.menuSummary.Name = "menuSummary";
            // 
            // menuSummaryNew
            // 
            resources.ApplyResources(this.menuSummaryNew, "menuSummaryNew");
            this.menuSummaryNew.Image = global::Summaries.Properties.Resources.newSummary;
            this.menuSummaryNew.Name = "menuSummaryNew";
            this.menuSummaryNew.Click += new System.EventHandler(this.menuSummaryNew_Click);
            // 
            // menuSummaryList
            // 
            resources.ApplyResources(this.menuSummaryList, "menuSummaryList");
            this.menuSummaryList.Image = global::Summaries.Properties.Resources.summariesList;
            this.menuSummaryList.Name = "menuSummaryList";
            this.menuSummaryList.Click += new System.EventHandler(this.menuSummaryList_Click);
            // 
            // menuAbout
            // 
            resources.ApplyResources(this.menuAbout, "menuAbout");
            this.menuAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAboutLicenses,
            this.menuAboutSummaries});
            this.menuAbout.Name = "menuAbout";
            // 
            // menuAboutLicenses
            // 
            resources.ApplyResources(this.menuAboutLicenses, "menuAboutLicenses");
            this.menuAboutLicenses.Image = global::Summaries.Properties.Resources.licenses;
            this.menuAboutLicenses.Name = "menuAboutLicenses";
            this.menuAboutLicenses.Click += new System.EventHandler(this.menuAboutLicenses_Click);
            // 
            // menuAboutSummaries
            // 
            resources.ApplyResources(this.menuAboutSummaries, "menuAboutSummaries");
            this.menuAboutSummaries.Image = global::Summaries.Properties.Resources.aboutSummaries;
            this.menuAboutSummaries.Name = "menuAboutSummaries";
            this.menuAboutSummaries.Click += new System.EventHandler(this.menuAboutSummaries_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.sessionLabel);
            this.panel1.Name = "panel1";
            // 
            // sessionLabel
            // 
            resources.ApplyResources(this.sessionLabel, "sessionLabel");
            this.sessionLabel.Name = "sessionLabel";
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            // 
            // newToolStripMenuItem
            // 
            resources.ApplyResources(this.newToolStripMenuItem, "newToolStripMenuItem");
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.summaryToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            // 
            // summaryToolStripMenuItem
            // 
            resources.ApplyResources(this.summaryToolStripMenuItem, "summaryToolStripMenuItem");
            this.summaryToolStripMenuItem.Image = global::Summaries.Properties.Resources.newSummary;
            this.summaryToolStripMenuItem.Name = "summaryToolStripMenuItem";
            this.summaryToolStripMenuItem.Click += new System.EventHandler(this.summaryToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Image = global::Summaries.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // bigBar
            // 
            resources.ApplyResources(this.bigBar, "bigBar");
            this.bigBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bigBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userSettingsBTN,
            this.toolStripButton1,
            this.exitBTN,
            this.administrationMenuBTN,
            this.newSummaryBTN,
            this.summariesListBTN});
            this.bigBar.Name = "bigBar";
            // 
            // userSettingsBTN
            // 
            resources.ApplyResources(this.userSettingsBTN, "userSettingsBTN");
            this.userSettingsBTN.Image = global::Summaries.Properties.Resources.administrationPanel;
            this.userSettingsBTN.Name = "userSettingsBTN";
            this.userSettingsBTN.Click += new System.EventHandler(this.userSettingsToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.licensesToolStripMenuItem,
            this.aboutSummariesToolStripMenuItem});
            this.toolStripButton1.Image = global::Summaries.Properties.Resources.aboutSummaries;
            this.toolStripButton1.Name = "toolStripButton1";
            // 
            // licensesToolStripMenuItem
            // 
            resources.ApplyResources(this.licensesToolStripMenuItem, "licensesToolStripMenuItem");
            this.licensesToolStripMenuItem.Image = global::Summaries.Properties.Resources.licenses;
            this.licensesToolStripMenuItem.Name = "licensesToolStripMenuItem";
            this.licensesToolStripMenuItem.Click += new System.EventHandler(this.menuAboutLicenses_Click);
            // 
            // aboutSummariesToolStripMenuItem
            // 
            resources.ApplyResources(this.aboutSummariesToolStripMenuItem, "aboutSummariesToolStripMenuItem");
            this.aboutSummariesToolStripMenuItem.Image = global::Summaries.Properties.Resources.aboutSummaries;
            this.aboutSummariesToolStripMenuItem.Name = "aboutSummariesToolStripMenuItem";
            this.aboutSummariesToolStripMenuItem.Click += new System.EventHandler(this.menuAboutSummaries_Click);
            // 
            // exitBTN
            // 
            resources.ApplyResources(this.exitBTN, "exitBTN");
            this.exitBTN.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exitBTN.Image = global::Summaries.Properties.Resources.exit;
            this.exitBTN.Name = "exitBTN";
            this.exitBTN.Click += new System.EventHandler(this.menuOptionsExit_Click);
            // 
            // administrationMenuBTN
            // 
            resources.ApplyResources(this.administrationMenuBTN, "administrationMenuBTN");
            this.administrationMenuBTN.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.administrationMenuBTN.Image = global::Summaries.Properties.Resources.administrationPanel;
            this.administrationMenuBTN.Name = "administrationMenuBTN";
            this.administrationMenuBTN.Click += new System.EventHandler(this.menuOptionsAdministration_Panel_Click);
            // 
            // newSummaryBTN
            // 
            resources.ApplyResources(this.newSummaryBTN, "newSummaryBTN");
            this.newSummaryBTN.Image = global::Summaries.Properties.Resources.newSummary;
            this.newSummaryBTN.Name = "newSummaryBTN";
            this.newSummaryBTN.Click += new System.EventHandler(this.menuSummaryNew_Click);
            // 
            // summariesListBTN
            // 
            resources.ApplyResources(this.summariesListBTN, "summariesListBTN");
            this.summariesListBTN.Image = global::Summaries.Properties.Resources.summariesList;
            this.summariesListBTN.Name = "summariesListBTN";
            this.summariesListBTN.Click += new System.EventHandler(this.menuSummaryList_Click);
            // 
            // main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.CausesValidation = false;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.bigBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.main_FormClosed);
            this.Load += new System.EventHandler(this.main_Load);
            this.Shown += new System.EventHandler(this.main_Shown);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.bigBar.ResumeLayout(false);
            this.bigBar.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem userSettingsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip bigBar;
        private System.Windows.Forms.ToolStripButton userSettingsBTN;
        private System.Windows.Forms.ToolStripButton administrationMenuBTN;
        private System.Windows.Forms.ToolStripButton newSummaryBTN;
        private System.Windows.Forms.ToolStripButton summariesListBTN;
        private System.Windows.Forms.ToolStripButton exitBTN;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem licensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutSummariesToolStripMenuItem;
    }
}