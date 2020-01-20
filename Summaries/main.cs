using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Summaries
{
    public partial class main : Form
    {
        private bool isHidden = false;

        public main()
        {
            InitializeComponent();
        }

        private void menuOptionsExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void trayIcon_Click(object sender, EventArgs e)
        {
            if (isHidden)
            {
                this.Show();
                isHidden = false;
            }
            else
            {
                this.Hide();
                isHidden = true;
            }
        }

        private void menuAboutLicenses_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Path.GetTempPath() + "\\licenses.txt");
            }
            catch (System.ComponentModel.Win32Exception)
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(Properties.Settings.Default.inUseDomain + "/summaries/resources/licenses.txt", Path.GetTempPath() + "\\licenses.txt");
                }
                menuAboutLicenses_Click(sender, e);
            }
        }

        private void menuAboutSummaries_Click(object sender, EventArgs e)
        {
            aboutSummaries about = new aboutSummaries();
            about.ShowDialog();
        }

        private void menuSummaryNew_Click(object sender, EventArgs e)
        {
            newSummary newSummary = new newSummary();
            newSummary.ShowDialog();
        }

        private void menuSummaryList_Click(object sender, EventArgs e)
        {
            summariesList summaries = new summariesList();
            summaries.ShowDialog();
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
            AdministrationPanel panel = new AdministrationPanel();
            panel.ShowDialog();
        }
    }
}
