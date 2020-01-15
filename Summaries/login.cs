using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using static Summaries.codeResources.functions;

namespace Summaries
{
    public partial class login : Form
    {

        private string inUseDomain;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="InUseDomain">The domain used to make API calls</param>
        public login(string InUseDomain)
        {
            InitializeComponent();
            inUseDomain = InUseDomain;
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
            string jsonResponse = LoginValidation(username, password, inUseDomain);
            response = JsonConvert.DeserializeObject<simpleServerResponse>(jsonResponse);

            if (response.status)
            {
                userInfo = JsonConvert.DeserializeObject<userInfo>(jsonResponse);
                main form = new main(userInfo.userID, userInfo.username, userInfo.displayName, inUseDomain, userInfo.adminControl);
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

        /// <summary>
        /// Sends a login request to the server through HTTPS
        /// </summary>
        /// <param name="username">The username given by the user to login</param>
        /// <param name="password">The password given by the user to login</param>
        /// <returns></returns>
        public static string LoginValidation(string username, string password, string inUseDomain)
        {
            string POSTdata = "API=1f984e2ed1545f287fe473c890266fea901efcd63d07967ae6d2f09f4566ddde930923ee9212ea815186b0c11a620a5cc85e";
            POSTdata += "&usrnm=" + username + "&psswd=" + password;
            var data = Encoding.UTF8.GetBytes(POSTdata);
            var request = WebRequest.CreateHttp(inUseDomain + "/restricted/loginvalidator.php");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            request.UserAgent = "app";
            //writes the post data to the stream
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
                stream.Close();
            }
            //ler a resposta
            string finalData = "";
            using (var response = request.GetResponse())
            {
                var dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                finalData = reader.ReadToEnd();
                dataStream.Close();
                response.Close();
            }
            return finalData;
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
