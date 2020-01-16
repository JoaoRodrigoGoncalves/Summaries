namespace Summaries
{
    partial class AdministrationPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdministrationPanel));
            this.administrationTabMenu = new System.Windows.Forms.TabControl();
            this.usersTab = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.refreshBTN = new System.Windows.Forms.ToolStripButton();
            this.newUserBTN = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.deleteUserBTN = new System.Windows.Forms.Button();
            this.resetPWBTN = new System.Windows.Forms.Button();
            this.infoGBox = new System.Windows.Forms.GroupBox();
            this.classBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.accidentalDeletionBox = new System.Windows.Forms.CheckBox();
            this.adminPrivBox = new System.Windows.Forms.CheckBox();
            this.displayNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveBTN = new System.Windows.Forms.Button();
            this.userDataGrid = new System.Windows.Forms.DataGridView();
            this.classesTab = new System.Windows.Forms.TabPage();
            this.administrationTabMenu.SuspendLayout();
            this.usersTab.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.infoGBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // administrationTabMenu
            // 
            this.administrationTabMenu.Controls.Add(this.usersTab);
            this.administrationTabMenu.Controls.Add(this.classesTab);
            this.administrationTabMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.administrationTabMenu.Location = new System.Drawing.Point(0, 0);
            this.administrationTabMenu.Name = "administrationTabMenu";
            this.administrationTabMenu.SelectedIndex = 0;
            this.administrationTabMenu.Size = new System.Drawing.Size(911, 450);
            this.administrationTabMenu.TabIndex = 1;
            // 
            // usersTab
            // 
            this.usersTab.Controls.Add(this.toolStrip1);
            this.usersTab.Controls.Add(this.newUserBTN);
            this.usersTab.Controls.Add(this.groupBox1);
            this.usersTab.Controls.Add(this.infoGBox);
            this.usersTab.Controls.Add(this.userDataGrid);
            this.usersTab.Location = new System.Drawing.Point(4, 22);
            this.usersTab.Name = "usersTab";
            this.usersTab.Padding = new System.Windows.Forms.Padding(3);
            this.usersTab.Size = new System.Drawing.Size(903, 424);
            this.usersTab.TabIndex = 0;
            this.usersTab.Text = "Users";
            this.usersTab.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshBTN});
            this.toolStrip1.Location = new System.Drawing.Point(468, 396);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(432, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // refreshBTN
            // 
            this.refreshBTN.Image = global::Summaries.Properties.Resources.refresh;
            this.refreshBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshBTN.Name = "refreshBTN";
            this.refreshBTN.Size = new System.Drawing.Size(66, 22);
            this.refreshBTN.Text = "Refresh";
            this.refreshBTN.Click += new System.EventHandler(this.refreshBTN_Click);
            // 
            // newUserBTN
            // 
            this.newUserBTN.Location = new System.Drawing.Point(474, 6);
            this.newUserBTN.Name = "newUserBTN";
            this.newUserBTN.Size = new System.Drawing.Size(76, 23);
            this.newUserBTN.TabIndex = 9;
            this.newUserBTN.Text = "Add User";
            this.newUserBTN.UseVisualStyleBackColor = true;
            this.newUserBTN.Click += new System.EventHandler(this.newUserBTN_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deleteUserBTN);
            this.groupBox1.Controls.Add(this.resetPWBTN);
            this.groupBox1.Location = new System.Drawing.Point(474, 189);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 204);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Advanced User Options";
            // 
            // deleteUserBTN
            // 
            this.deleteUserBTN.Enabled = false;
            this.deleteUserBTN.Location = new System.Drawing.Point(244, 48);
            this.deleteUserBTN.Name = "deleteUserBTN";
            this.deleteUserBTN.Size = new System.Drawing.Size(171, 23);
            this.deleteUserBTN.TabIndex = 9;
            this.deleteUserBTN.Text = "Delete this User Accout";
            this.deleteUserBTN.UseVisualStyleBackColor = true;
            this.deleteUserBTN.Click += new System.EventHandler(this.deleteUserBTN_Click);
            // 
            // resetPWBTN
            // 
            this.resetPWBTN.Enabled = false;
            this.resetPWBTN.Location = new System.Drawing.Point(244, 19);
            this.resetPWBTN.Name = "resetPWBTN";
            this.resetPWBTN.Size = new System.Drawing.Size(171, 23);
            this.resetPWBTN.TabIndex = 6;
            this.resetPWBTN.Text = "Reset User Password";
            this.resetPWBTN.UseVisualStyleBackColor = true;
            this.resetPWBTN.Click += new System.EventHandler(this.resetPWBTN_Click);
            // 
            // infoGBox
            // 
            this.infoGBox.Controls.Add(this.classBox);
            this.infoGBox.Controls.Add(this.label3);
            this.infoGBox.Controls.Add(this.accidentalDeletionBox);
            this.infoGBox.Controls.Add(this.adminPrivBox);
            this.infoGBox.Controls.Add(this.displayNameBox);
            this.infoGBox.Controls.Add(this.label2);
            this.infoGBox.Controls.Add(this.usernameBox);
            this.infoGBox.Controls.Add(this.label1);
            this.infoGBox.Controls.Add(this.saveBTN);
            this.infoGBox.Location = new System.Drawing.Point(473, 36);
            this.infoGBox.Name = "infoGBox";
            this.infoGBox.Size = new System.Drawing.Size(422, 357);
            this.infoGBox.TabIndex = 1;
            this.infoGBox.TabStop = false;
            this.infoGBox.Text = "Editing User ";
            // 
            // classBox
            // 
            this.classBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classBox.FormattingEnabled = true;
            this.classBox.Location = new System.Drawing.Point(96, 79);
            this.classBox.Name = "classBox";
            this.classBox.Size = new System.Drawing.Size(319, 21);
            this.classBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Class";
            // 
            // accidentalDeletionBox
            // 
            this.accidentalDeletionBox.AutoSize = true;
            this.accidentalDeletionBox.Location = new System.Drawing.Point(96, 130);
            this.accidentalDeletionBox.Name = "accidentalDeletionBox";
            this.accidentalDeletionBox.Size = new System.Drawing.Size(236, 17);
            this.accidentalDeletionBox.TabIndex = 6;
            this.accidentalDeletionBox.Text = "Protect Account Against Accidental Deletion";
            this.accidentalDeletionBox.UseVisualStyleBackColor = true;
            // 
            // adminPrivBox
            // 
            this.adminPrivBox.AutoSize = true;
            this.adminPrivBox.Location = new System.Drawing.Point(96, 106);
            this.adminPrivBox.Name = "adminPrivBox";
            this.adminPrivBox.Size = new System.Drawing.Size(134, 17);
            this.adminPrivBox.TabIndex = 5;
            this.adminPrivBox.Text = "Administrator Privileges";
            this.adminPrivBox.UseVisualStyleBackColor = true;
            // 
            // displayNameBox
            // 
            this.displayNameBox.Location = new System.Drawing.Point(96, 53);
            this.displayNameBox.Name = "displayNameBox";
            this.displayNameBox.Size = new System.Drawing.Size(319, 20);
            this.displayNameBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Display Name";
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(96, 27);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(319, 20);
            this.usernameBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Login Username";
            // 
            // saveBTN
            // 
            this.saveBTN.Location = new System.Drawing.Point(340, 106);
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.Size = new System.Drawing.Size(75, 23);
            this.saveBTN.TabIndex = 0;
            this.saveBTN.Text = "Save";
            this.saveBTN.UseVisualStyleBackColor = true;
            this.saveBTN.Click += new System.EventHandler(this.saveBTN_Click);
            // 
            // userDataGrid
            // 
            this.userDataGrid.AllowUserToAddRows = false;
            this.userDataGrid.AllowUserToDeleteRows = false;
            this.userDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userDataGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.userDataGrid.Location = new System.Drawing.Point(3, 3);
            this.userDataGrid.MultiSelect = false;
            this.userDataGrid.Name = "userDataGrid";
            this.userDataGrid.ReadOnly = true;
            this.userDataGrid.Size = new System.Drawing.Size(465, 418);
            this.userDataGrid.TabIndex = 0;
            this.userDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userDataGrid_CellClick);
            this.userDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userDataGrid_CellClick);
            this.userDataGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userDataGrid_CellClick);
            // 
            // classesTab
            // 
            this.classesTab.Location = new System.Drawing.Point(4, 22);
            this.classesTab.Name = "classesTab";
            this.classesTab.Padding = new System.Windows.Forms.Padding(3);
            this.classesTab.Size = new System.Drawing.Size(792, 424);
            this.classesTab.TabIndex = 1;
            this.classesTab.Text = "Classes";
            this.classesTab.UseVisualStyleBackColor = true;
            // 
            // AdministrationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 450);
            this.Controls.Add(this.administrationTabMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(927, 489);
            this.MinimumSize = new System.Drawing.Size(927, 489);
            this.Name = "AdministrationPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administration Panel";
            this.Load += new System.EventHandler(this.AdministrationPanel_Load);
            this.administrationTabMenu.ResumeLayout(false);
            this.usersTab.ResumeLayout(false);
            this.usersTab.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.infoGBox.ResumeLayout(false);
            this.infoGBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl administrationTabMenu;
        private System.Windows.Forms.TabPage usersTab;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton refreshBTN;
        private System.Windows.Forms.Button newUserBTN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button deleteUserBTN;
        private System.Windows.Forms.Button resetPWBTN;
        private System.Windows.Forms.GroupBox infoGBox;
        private System.Windows.Forms.CheckBox accidentalDeletionBox;
        private System.Windows.Forms.CheckBox adminPrivBox;
        private System.Windows.Forms.TextBox displayNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveBTN;
        private System.Windows.Forms.DataGridView userDataGrid;
        private System.Windows.Forms.ComboBox classBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage classesTab;
    }
}