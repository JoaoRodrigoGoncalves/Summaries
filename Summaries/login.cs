using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

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

        private class tempUserStorage
        {
            public int userID { get; set; }
            public string username { get; set; }
            public string displayName { get; set; }
            public bool adminControl { get; set; }
            public string inUseDomain { get; set; }
        }

        private void loginBTN_Click(object sender, EventArgs e)
        {
            simpleServerResponse response;
            
            string username = usernameBox.Text;
            string password = passwordBox.Text;
            string jsonResponse = LoginValidation(username, password);
            response = JsonConvert.DeserializeObject<simpleServerResponse>(jsonResponse);

            if (response.status)
            {
                tempUserStorage temp;
                temp = JsonConvert.DeserializeObject<tempUserStorage>(jsonResponse);
                valueLoader(temp.userID, temp.username, temp.displayName, temp.inUseDomain, temp.adminControl);
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

        private void valueLoader(int user, string username, string displayName, string inUseDomain, bool adminControl = false)
        {
            userStorage.userID = user;
            userStorage.username = username;
            userStorage.displayName = displayName;
            userStorage.adminControl = adminControl;
            userStorage.inUseDomain = inUseDomain;
        }


        /// <summary>
        /// Sends a login request to the server through HTTPS
        /// </summary>
        /// <param name="username">The username given by the user to login</param>
        /// <param name="password">The password given by the user to login</param>
        /// <returns></returns>
        public static string LoginValidation(string username, string password)
        {
            string POSTdata = "usrnm=" + username + "&psswd=" + password;
            var data = Encoding.UTF8.GetBytes(POSTdata);
            var request = WebRequest.CreateHttp(userStorage.inUseDomain + "/restricted/loginvalidator.php");
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
