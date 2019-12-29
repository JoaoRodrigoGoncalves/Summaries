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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.newSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSummary = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSummaryList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAboutLicenses = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAboutSummaries = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileChange_Password = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sessionLabel = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuSummary,
            this.menuAbout});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menu.Size = new System.Drawing.Size(800, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSummaryToolStripMenuItem,
            this.menuFileChange_Password,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "File";
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(180, 22);
            this.menuFileExit.Text = "Exit";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // newSummaryToolStripMenuItem
            // 
            this.newSummaryToolStripMenuItem.Name = "newSummaryToolStripMenuItem";
            this.newSummaryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newSummaryToolStripMenuItem.Text = "New Summary";
            // 
            // menuSummary
            // 
            this.menuSummary.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSummaryList});
            this.menuSummary.Name = "menuSummary";
            this.menuSummary.Size = new System.Drawing.Size(70, 20);
            this.menuSummary.Text = "Summary";
            // 
            // menuSummaryList
            // 
            this.menuSummaryList.Name = "menuSummaryList";
            this.menuSummaryList.Size = new System.Drawing.Size(180, 22);
            this.menuSummaryList.Text = "Summaries List";
            // 
            // menuAbout
            // 
            this.menuAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAboutLicenses,
            this.menuAboutSummaries});
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(52, 20);
            this.menuAbout.Text = "About";
            // 
            // menuAboutLicenses
            // 
            this.menuAboutLicenses.Name = "menuAboutLicenses";
            this.menuAboutLicenses.Size = new System.Drawing.Size(180, 22);
            this.menuAboutLicenses.Text = "Licenses";
            // 
            // menuAboutSummaries
            // 
            this.menuAboutSummaries.Name = "menuAboutSummaries";
            this.menuAboutSummaries.Size = new System.Drawing.Size(180, 22);
            this.menuAboutSummaries.Text = "About Summaries";
            // 
            // menuFileChange_Password
            // 
            this.menuFileChange_Password.Name = "menuFileChange_Password";
            this.menuFileChange_Password.Size = new System.Drawing.Size(180, 22);
            this.menuFileChange_Password.Text = "Change Password";
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
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Summaries";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.main_FormClosed);
            this.Shown += new System.EventHandler(this.main_Shown);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem newSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripMenuItem menuSummary;
        private System.Windows.Forms.ToolStripMenuItem menuSummaryList;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStripMenuItem menuAboutLicenses;
        private System.Windows.Forms.ToolStripMenuItem menuAboutSummaries;
        private System.Windows.Forms.ToolStripMenuItem menuFileChange_Password;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label sessionLabel;
    }
}