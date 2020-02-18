using Newtonsoft.Json;
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
            public int userID { get; set; }
            public string username { get; set; }
            public string displayName { get; set; }
            public bool adminControl { get; set; }
        }

        //https://www.youtube.com/watch?v=yZYAaScEsc0

        string jsonResponse = "";
        string POSTdata = "";
        bool shouldAbort = false;

        private void getInformation()
        {
            var functions = new codeResources.functions();
            if (functions.CheckForInternetConnection(Properties.Settings.Default.inUseDomain))
            {
                jsonResponse = functions.APIRequest(POSTdata, "loginvalidator.php");
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
                POSTdata = "API=" + Properties.Settings.Default.APIkey + "&usrnm=" + username + "&psswd=" + password;
                var functions = new codeResources.functions();

                using (codeResources.loadingForm loading = new codeResources.loadingForm(getInformation))
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
                        Properties.Settings.Default.userID = userInfo.userID;
                        Properties.Settings.Default.username = userInfo.username;
                        Properties.Settings.Default.displayName = userInfo.displayName;
                        Properties.Settings.Default.isAdmin = userInfo.adminControl;

                        main form = new main();
                        this.Hide();
                        form.Show();
                    }
                    else
                    {
                        if ((response.errors == null) || (response.errors.Length < 1))
                        {
                            MessageBox.Show("Username or Password are incorrect.", "Wrong credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Error: " + response.errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                
            }catch(Exception ex)
            {
                var functions = new codeResources.functions();
                if (functions.CheckForInternetConnection(Properties.Settings.Default.inUseDomain))
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
    }
}
