using Newtonsoft.Json;
using Summaries.codeResources;
using System;
using System.Threading;
using System.Windows.Forms;
using static Summaries.codeResources.functions;

namespace Summaries
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void resetBTN_Click(object sender, EventArgs e)
        {
            usernameBox.Clear();
            passwordBox.Clear();
        }

        private void login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private class userInfo
        {
            public string AccessToken { get; set; }
            public int userID { get; set; }
            public string username { get; set; }
            public int classID { get; set; }
            public string displayName { get; set; }
            public bool adminControl { get; set; }
        }

        string jsonResponse = "";
        string POSTdata = "";
        bool shouldAbort = false;
        Local_Storage storage = Local_Storage.Retrieve;

        private void getInformation()
        {
            var functions = new functions();
            if (functions.CheckForInternetConnection(storage.inUseDomain))
            {
                jsonResponse = functions.APIRequest("POST", POSTdata, "login");
            }
            else
            {
                shouldAbort = true;
                MessageBox.Show(GlobalStrings.ConnectionToServerLost, GlobalStrings.ConnectionLost, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void loginBTN_Click(object sender, EventArgs e)
        {
            simpleServerResponse response;
            userInfo userInfo;
            var functions = new functions();

            try
            {
                if (string.IsNullOrEmpty(usernameBox.Text) || string.IsNullOrEmpty(passwordBox.Text))
                {
                    credentialsWarningLB.Visible = true;
                }
                else
                {
                    string username = functions.Hash(usernameBox.Text);
                    string password = functions.Hash(passwordBox.Text);
                    POSTdata = "usrnm=" + username + "&psswd=" + password;

                    using (loadingForm loading = new loadingForm(getInformation))
                    {
                        loading.ShowDialog();
                    }

                    if (shouldAbort)
                    {
                        passwordBox.Clear();
                        password = "";
                    }
                    else
                    {
                        response = JsonConvert.DeserializeObject<simpleServerResponse>(jsonResponse);

                        if (response.status)
                        {
                            userInfo = JsonConvert.DeserializeObject<userInfo>(jsonResponse);
                            storage.AccessToken = userInfo.AccessToken;
                            storage.userID = userInfo.userID;
                            storage.username = userInfo.username;
                            storage.classID = userInfo.classID;
                            storage.displayName = userInfo.displayName;
                            storage.isAdmin = userInfo.adminControl;

                            main form = new main();
                            this.Hide();
                            form.Show();
                        }
                        else
                        {
                            if (response.errors == "Authentication Failed")
                            {
                                credentialsWarningLB.Visible = true;
                            }
                            else
                            {
                                MessageBox.Show(GlobalStrings.Error + ": " + response.errors, GlobalStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
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

        private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                loginBTN_Click(sender, e);
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            var functions = new functions();
            versionLBL.Text = functions.GetSoftwareVersion();
            switch (Properties.Settings.Default.Language)
            {
                case "pt-PT":
                    languageDropDown.SelectedIndex = languageDropDown.FindStringExact("Português");
                    break;

                default:
                    languageDropDown.SelectedIndex = languageDropDown.FindStringExact("English");
                    break;
            }
        }

        private void languageDropDown_DropDownClosed(object sender, EventArgs e)
        {
            switch (languageDropDown.SelectedItem)
            {
                case "Português":
                    if (Thread.CurrentThread.CurrentUICulture != System.Globalization.CultureInfo.GetCultureInfo("pt-PT"))
                    {
                        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-PT");
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pt-PT");
                        Properties.Settings.Default.Language = "pt-PT";
                        Properties.Settings.Default.Save();
                        this.Controls.Clear();
                        InitializeComponent();
                        languageDropDown.SelectedIndex = languageDropDown.FindStringExact("Português");
                    }
                    break;

                default:
                    if (Thread.CurrentThread.CurrentUICulture != System.Globalization.CultureInfo.GetCultureInfo("en-US"))
                    {
                        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                        Properties.Settings.Default.Language = "en-US";
                        Properties.Settings.Default.Save();
                        this.Controls.Clear();
                        InitializeComponent();
                        languageDropDown.SelectedIndex = languageDropDown.FindStringExact("English");
                    }
                    break;
            }
        }
    }
}
