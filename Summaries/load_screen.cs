using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Summaries
{
    public partial class loading : Form
    {
        private string inUseDomain;

        public loading()
        {
            InitializeComponent();
        }

        private void loading_Shown(object sender, EventArgs e)
        {
            var functions = new codeResources.functions();

            if (!functions.CheckForInternetConnection("http://google.com/generate_204"))
            {
                MessageBox.Show("Couldn't establish a connection to the internet. Please try again later.", "Failed to connect to the internet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            else
            {
                if (!functions.CheckForInternetConnection("https://joaogoncalves.eu"))
                {
                    if (!functions.CheckForInternetConnection("https://joaogoncalves.myftp.org"))
                    {
                        MessageBox.Show("Couldn't establish a connection to the Summaries server. Please try again later.", "Failed to connect to the server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                    else
                    {
                        inUseDomain = "https://joaogoncalves.myftp.org";
                    }

                }
                else
                {
                    inUseDomain = "https://joaogoncalves.eu";
                }

                try
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(userStorage.inUseDomain + "/restricted/licenses.txt", Path.GetTempPath() + "\\licenses.txt");
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Cannot load all needed resources", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                login loginForm = new login(inUseDomain);
                this.Close();
                loginForm.Show();
            }
        }
    }
}
