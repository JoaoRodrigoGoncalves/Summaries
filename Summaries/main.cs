﻿using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Summaries
{
    public partial class main : Form
    {
        private int userID;
        private string user;
        private string displayName;

        private bool isHidden = false;

        /// <summary>
        /// Main function from the dashboard form.
        /// </summary>
        /// <param name="id">The user id retrived from the database</param>
        /// <param name="username">The username retrived from the database (login name)</param>
        /// <param name="display">The name to be displayed that was retrived from the database</param>
        public main(int id, string username, string display)
        {
            InitializeComponent();
            userID = id;
            user = username;
            displayName = display;
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
            changePassword password = new changePassword(userID, user, displayName);
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
                    client.DownloadFile("https://joaogoncalves.myftp.org/restricted/licenses.txt", Path.GetTempPath() + "\\licenses.txt");
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
            throw new NotImplementedException();
        }
    }
}
