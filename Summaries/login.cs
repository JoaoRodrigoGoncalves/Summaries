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

        private void loginBTN_Click(object sender, EventArgs e)
        {
            simpleServerResponse response;
            userInfo userInfo;
            
            string username = usernameBox.Text;
            string password = passwordBox.Text;
            string POSTdata = "API=" + Properties.Settings.Default.APIkey + "&usrnm=" + username + "&psswd=" + password;
            var functions = new codeResources.functions();
            string jsonResponse = functions.APIRequest(POSTdata, "loginvalidator.php");
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
                if((response.errors == null) || (response.errors.Length < 1))
                {
                    MessageBox.Show("Username or Password are incorrect.", "Wrong credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error: " + response.errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
