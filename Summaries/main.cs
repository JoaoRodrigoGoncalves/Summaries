﻿using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Summaries
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void menuOptionsExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void main_Shown(object sender, EventArgs e)
        {
            sessionLabel.Text += " " + Properties.Settings.Default.displayName;
        }

        private void main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void menuOptionsChange_Password_Click(object sender, EventArgs e)
        {
            changePassword password = new changePassword();
            password.ShowDialog();
        }

        private void menuAboutLicenses_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Path.GetTempPath() + "\\licenses.txt");
            }
            catch (System.ComponentModel.Win32Exception)
            {
                try
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(Properties.Settings.Default.inUseDomain + "/summaries/resources/licenses.txt", Path.GetTempPath() + "\\licenses.txt");
                    }
                    menuAboutLicenses_Click(sender, e);
                }catch(Exception ex)
                {
                    var functions = new codeResources.functions();
                    if (functions.CheckForInternetConnection(Properties.Settings.Default.inUseDomain))
                    {
                        MessageBox.Show("Critical Error: " + ex.Message + "\n" + ex.StackTrace, "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Lost Connection to the server. Please try again later!", "Connection Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
        }

        private void menuAboutSummaries_Click(object sender, EventArgs e)
        {
            aboutSummaries about = new aboutSummaries();
            about.ShowDialog();
        }

        private void menuSummaryNew_Click(object sender, EventArgs e)
        {
            var functions = new codeResources.functions();
            if (functions.CheckForInternetConnection(Properties.Settings.Default.inUseDomain))
            {
                newSummary newSummary = new newSummary();
                newSummary.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lost Connection to the server. Please try again later!", "Connection Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void menuSummaryList_Click(object sender, EventArgs e)
        {
            var functions = new codeResources.functions();
            if (functions.CheckForInternetConnection(Properties.Settings.Default.inUseDomain))
            {
                summariesList summaries = new summariesList();
                summaries.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lost Connection to the server. Please try again later!", "Connection Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void main_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.isAdmin)
            {
                menuOptionsAdministration_Panel.Visible = true;
                menuOptionsAdministration_PanelStrip.Visible = true;
            }
        }

        private void menuOptionsAdministration_Panel_Click(object sender, EventArgs e)
        {
            var functions = new codeResources.functions();
            if (functions.CheckForInternetConnection(Properties.Settings.Default.inUseDomain))
            {
                AdministrationPanel panel = new AdministrationPanel();
                panel.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lost Connection to the server. Please try again later!", "Connection Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
