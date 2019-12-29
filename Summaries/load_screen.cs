using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Summaries
{
    public partial class loading : Form
    {
        public loading()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Checks if it is possible to reach the specified link
        /// </summary>
        /// <param name="link">The link to the website or page</param>
        /// <returns></returns>
        public static bool CheckForInternetConnection(string link)
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead(link))
                    return true;
            }
            catch
            {
                return false;
            }
        }

        private void loading_Shown(object sender, EventArgs e)
        {
            if (!CheckForInternetConnection("http://google.com/generate_204"))
            {
                MessageBox.Show("Couldn't establish a connection to the internet. Please try again later.", "Failed to connect to the internet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            else
            {
                if (!CheckForInternetConnection("https://joaogoncalves.myftp.org"))
                {
                    MessageBox.Show("Couldn't establish a connection to the Summaries server. Please try again later.", "Failed to connect to the server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                else
                {
                    login loginForm = new login();
                    this.Close();
                    loginForm.Show();
                }
            }
        }
    }
}
