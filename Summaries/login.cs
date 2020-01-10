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

        private void loginBTN_Click(object sender, EventArgs e)
        {
            simpleServerResponse response;
            userStorage storage;

            string username = usernameBox.Text;
            string password = passwordBox.Text;
            string jsonResponse = LoginValidation(username, password);
            response = JsonConvert.DeserializeObject<simpleServerResponse>(jsonResponse);

            if (response.status)
            {
                storage = JsonConvert.DeserializeObject<userStorage>(jsonResponse);
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
