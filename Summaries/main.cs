using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Summaries
{
    public partial class main : Form
    {

        private int userID;
        private string username;
        private string displayName;
        private string inUseDomain;
        private bool adminControl = false;


        private bool isHidden = false;

        /// <summary>
        /// The function to load the user information and open the form
        /// </summary>
        /// <param name="userid">The ID of the current user</param>
        /// <param name="UserName">The Username of the current user</param>
        /// <param name="DisplayName">The DiplayName of the current user</param>
        /// <param name="InUseDomain">The domain to be used to make API calls</param>
        /// <param name="AdminControl">If the current user has admininstrator privileges</param>
        public main(int userid, string UserName, string DisplayName, string InUseDomain, bool AdminControl = false)
        {
            InitializeComponent();
            userID = userid;
            username = UserName;
            displayName = DisplayName;
            inUseDomain = InUseDomain;
            adminControl = AdminControl;
        }

        private void menuOptionsExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void main_Shown(object sender, EventArgs e)
        {
            sessionLabel.Text += " " + displayName;
        }

        private void main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void menuOptionsChange_Password_Click(object sender, EventArgs e)
        {
            changePassword password = new changePassword(userID, username, displayName, inUseDomain);
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
                    client.DownloadFile(inUseDomain + "/summaries/resources/licenses.txt", Path.GetTempPath() + "\\licenses.txt");
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
            newSummary newSummary = new newSummary(userID, inUseDomain);
            newSummary.ShowDialog();
        }

        private void menuSummaryList_Click(object sender, EventArgs e)
        {
            summariesList summaries = new summariesList(userID, username, displayName, inUseDomain);
            summaries.ShowDialog();
        }

        private void main_Load(object sender, EventArgs e)
        {
            if (adminControl)
            {
                menuOptionsAdministration_Panel.Visible = true;
                menuOptionsAdministration_PanelStrip.Visible = true;
            }
        }

        private void menuOptionsAdministration_Panel_Click(object sender, EventArgs e)
        {
            AdministrationPanel panel = new AdministrationPanel(userID, inUseDomain);
            panel.ShowDialog();
        }
    }
}
