using Summaries.codeResources;
using System;
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
        Local_Storage storage = Local_Storage.Retrieve;

        private void menuOptionsExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(GlobalStrings.ExitQuestion, GlobalStrings.Exit, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void main_Shown(object sender, EventArgs e)
        {
            sessionLabel.Text += " " + storage.displayName;
        }

        private void main_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Directory.Delete(@"" + Path.GetTempPath() + "summariesTemp", true); // Deletes temp files
            }
            catch { }
            var functions = new functions();
            try
            {
                functions.APIRequest("GET", null, "logout");
            }
            catch { }
            Application.Exit();
        }

        private void menuAboutLicenses_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Path.GetTempPath() + "summariesTemp\\licenses.txt");
            }
            catch (System.ComponentModel.Win32Exception)
            {
                try
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(storage.inUseDomain + "/summaries/resources/licenses.txt", Path.GetTempPath() + "summariesTemp\\licenses.txt");
                    }
                    menuAboutLicenses_Click(sender, e);
                }
                catch (Exception ex)
                {
                    var functions = new codeResources.functions();
                    if (functions.CheckForInternetConnection(storage.inUseDomain))
                    {
                        MessageBox.Show(GlobalStrings.CriticalError + ": " + ex.Message + "\n" + ex.StackTrace, GlobalStrings.CriticalError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(GlobalStrings.ConnectionToServerLost, GlobalStrings.ConnectionLost, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (functions.CheckForInternetConnection(storage.inUseDomain))
            {
                newSummary newSummary = new newSummary();
                newSummary.ShowDialog();
            }
            else
            {
                MessageBox.Show(GlobalStrings.ConnectionToServerLost, GlobalStrings.ConnectionLost, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void menuSummaryList_Click(object sender, EventArgs e)
        {
            var functions = new codeResources.functions();
            if (functions.CheckForInternetConnection(storage.inUseDomain))
            {
                summariesList summaries = new summariesList();
                summaries.ShowDialog();
            }
            else
            {
                MessageBox.Show(GlobalStrings.ConnectionToServerLost, GlobalStrings.ConnectionLost, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void main_Load(object sender, EventArgs e)
        {
            if (storage.isAdmin)
            {
                menuOptionsAdministration_Panel.Visible = true;
                menuOptionsAdministration_PanelStrip.Visible = true;
            }
        }

        private void menuOptionsAdministration_Panel_Click(object sender, EventArgs e)
        {
            var functions = new codeResources.functions();
            if (functions.CheckForInternetConnection(storage.inUseDomain))
            {
                administration.AdministrationMenu panel = new administration.AdministrationMenu();
                panel.ShowDialog();
            }
            else
            {
                MessageBox.Show(GlobalStrings.ConnectionToServerLost, GlobalStrings.ConnectionLost, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuOptionsExit_Click(sender, e);
        }

        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuAboutSummaries_Click(sender, e);
        }

        private void userSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userSettings.userSettings settingsWindow = new userSettings.userSettings();
            settingsWindow.ShowDialog();
        }
    }
}
