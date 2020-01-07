using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Summaries
{
    public partial class changePassword : Form
    {

        private int userID;
        private string user;
        private string displayName;

        /// <summary>
        /// Main function from the changePassword form.
        /// </summary>
        /// <param name="id">The user id retrived from the database</param>
        /// <param name="username">The username retrived from the database (login name)</param>
        /// <param name="display">The name to be displayed that was retrived from the database</param>
        public changePassword(int id, string username, string display)
        {
            InitializeComponent();
            userID = id;
            user = username;
            displayName = display;
        }

        private void changePassword_Shown(object sender, EventArgs e)
        {
            this.Text += displayName;
            usernameBox.Text = user;
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
                            jsonResponse = ChangePassword(userID, HashPW(currentPasswordBox.Text), HashPW(newPasswordBox.Text));
                            serverResponse response;
                            response = JsonConvert.DeserializeObject<serverResponse>(jsonResponse);

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

        private class serverResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
        }


        /// <summary>
        /// Uses BASE64 to hash the given string
        /// </summary>
        /// <param name="text">String to hash</param>
        /// <returns></returns>
        private string HashPW(string text)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(plainTextBytes);
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
            string POSTdata = "userID=" + userID + "&oldpsswd=" + oldPassword + "&newpsswd=" + newPassword;
            var data = Encoding.UTF8.GetBytes(POSTdata);
            var request = WebRequest.CreateHttp("https://joaogoncalves.myftp.org/restricted/api/changePassword.php");
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
