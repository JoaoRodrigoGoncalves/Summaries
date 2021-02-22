using Summaries.codeResources;
using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace Summaries
{
    public partial class loading : Form
    {
        public loading()
        {
            InitializeComponent();
        }

        private void loading_Shown(object sender, EventArgs e)
        {
            Local_Storage storage = Local_Storage.Retrieve;
            var functions = new functions();

            if (!functions.CheckForInternetConnection("http://google.com/generate_204"))
            {
                MessageBox.Show(GlobalStrings.NoInternetLong, GlobalStrings.NoInternet, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            else
            {
                if (!functions.CheckForInternetConnection("https://joaogoncalves.eu"))
                {
                    if (!functions.CheckForInternetConnection("https://joaogoncalves.myftp.org"))
                    {
                        MessageBox.Show(GlobalStrings.CannotConnectServerLong, GlobalStrings.CannotConnectServer, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                    else
                    {
                        storage.inUseDomain = "https://joaogoncalves.myftp.org";
                    }

                }
                else
                {
                    storage.inUseDomain = "https://joaogoncalves.eu";
                }

                Directory.CreateDirectory(@"" + Path.GetTempPath() + "summariesTemp");

                try
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(storage.inUseDomain + "/summaries/resources/licenses.txt", Path.GetTempPath() + "summariesTemp\\licenses.txt");
                    }

                    string downloadURL = "";
                    Version newVersion = null;
                    string xmlURL = storage.inUseDomain + "/summaries/updater.xml";
                    XmlTextReader reader = null;

                    reader = new XmlTextReader(xmlURL);
                    reader.MoveToContent();
                    string elementName = "";

                    try
                    {
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "summariesapp"))
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Element)
                                {
                                    elementName = reader.Name;
                                }
                                else
                                {
                                    if ((reader.NodeType == XmlNodeType.Text) && (reader.HasValue))
                                    {
                                        switch (elementName)
                                        {
                                            case "version":
                                                newVersion = new Version(reader.Value);
                                                break;
                                            case "downloadurl":
                                                downloadURL = reader.Value;
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception exec)
                    {
                        throw new Exception(GlobalStrings.FailedCheckUpdates + ": " + exec.Message);
                    }
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close();
                        }
                    }

                    Version appVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                    if (appVersion.CompareTo(newVersion) < 0)
                    {
                        var res = MessageBox.Show(GlobalStrings.NewVersionLong, GlobalStrings.NewVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(downloadURL);
                            Application.Exit();
                        }
                        else
                        {
                            MessageBox.Show(GlobalStrings.LaunchOnLatestVersion, GlobalStrings.Closing, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.Exit();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, GlobalStrings.CouldNotLoadResources, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                login loginForm = new login();
                this.Close();
                loginForm.Show();
            }
        }
    }
}
