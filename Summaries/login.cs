using Newtonsoft.Json;
using Summaries.codeResources;
using System;
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
                jsonResponse = functions.APIRequest("POST", POSTdata, "login/");
            }
            else
            {
                shouldAbort = true;
                MessageBox.Show("Lost Connection to the server. Please try again later!", "Connection Lost!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void loginBTN_Click(object sender, EventArgs e)
        {
            simpleServerResponse response;
            userInfo userInfo;

            try
            {
                string username = usernameBox.Text;
                string password = passwordBox.Text;
                POSTdata = "usrnm=" + username + "&psswd=" + password;
                var functions = new functions();

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
                        storage.displayName = userInfo.displayName;
                        storage.isAdmin = userInfo.adminControl;

                        main form = new main();
                        this.Hide();
                        form.Show();
                    }
                    else
                    {
                        if ((response.errors == null) || (response.errors.Length < 1))
                        {
                            credentialsWarningLB.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("Error: " + response.errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                
            }catch(Exception ex)
            {
                var functions = new functions();
                if (functions.CheckForInternetConnection(storage.inUseDomain))
                {
                    MessageBox.Show("Critial Error: " + ex.Message + "\n" + ex.StackTrace, "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lost Connection to the server. Please try again!", "Connection Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }
    }
}
