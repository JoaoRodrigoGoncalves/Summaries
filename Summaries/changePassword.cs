using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using static Summaries.codeResources.functions;

namespace Summaries
{
    public partial class changePassword : Form
    {
        public changePassword()
        {
            InitializeComponent();
        }

        private void changePassword_Shown(object sender, EventArgs e)
        {
            this.Text += Properties.Settings.Default.displayName;
            usernameBox.Text = Properties.Settings.Default.username;
        }

        private void resetFields()
        {
            currentPasswordBox.Clear();
            newPasswordBox.Clear();
            confirmPasswordBox.Clear();
        }

        private void changeBTN_Click(object sender, EventArgs e)
        {
            if(currentPasswordBox.Text.Length <1 || newPasswordBox.Text.Length <1 || confirmPasswordBox.Text.Length < 1)
            {
                MessageBox.Show("One or more fields are empty. Please fill them before continue.", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (newPasswordBox.Text == confirmPasswordBox.Text)
                {
                    if (newPasswordBox.Text != currentPasswordBox.Text)
                    {
                        string jsonResponse = "";
                        try
                        {
                            var functions = new codeResources.functions();
                            jsonResponse = ChangePassword(Properties.Settings.Default.userID, functions.HashPW(currentPasswordBox.Text), functions.HashPW(newPasswordBox.Text));
                            simpleServerResponse response;
                            response = JsonConvert.DeserializeObject<simpleServerResponse>(jsonResponse);

                            if (!response.status)
                            {
                                if ((response.errors == null) || (response.errors.Length < 1))
                                {
                                    currentPasswordBox.Clear();
                                    MessageBox.Show("The given 'Current Password' is incorrect. Please try again.", "Password Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("Error: " + response.errors, "Critital Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Password Changed Successfully!", "Password Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Critital Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBox.Show(jsonResponse, "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        resetFields();
                        MessageBox.Show("The current password and the new password given are the same.", "Cannot change to the same password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    resetFields();
                    MessageBox.Show("The new passwords don't match. Please try again.", "The passwords don't match", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sends a request to the server to change the password of the user
        /// </summary>
        /// <param name="userID">The id of the user wich password should be changed</param>
        /// <param name="oldPassword">The old user's password (in BASE64)</param>
        /// <param name="newPassword">The new password to change to (in BASE64)</param>
        /// <returns></returns>
        public static string ChangePassword(int userID, string oldPassword, string newPassword)
        {
            string POSTdata = "API=" + Properties.Settings.Default.APIkey + "&userID=" + userID + "&oldpsswd=" + oldPassword + "&newpsswd=" + newPassword;
            var data = Encoding.UTF8.GetBytes(POSTdata);
            var request = WebRequest.CreateHttp(Properties.Settings.Default.inUseDomain + "/summaries/api/changePassword.php");
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

        private void currentPasswordBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Escape))
            {
                this.Close();
            }

            if (e.KeyChar == (char)(Keys.Enter))
            {
                changeBTN_Click(sender, e);
            }
        }

        private void newPasswordBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Escape))
            {
                this.Close();
            }

            if (e.KeyChar == (char)(Keys.Enter))
            {
                changeBTN_Click(sender, e);
            }
        }

        private void confirmPasswordBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Escape))
            {
                this.Close();
            }

            if (e.KeyChar == (char)(Keys.Enter))
            {
                changeBTN_Click(sender, e);
            }
        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
