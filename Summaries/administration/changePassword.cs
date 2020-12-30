using Newtonsoft.Json;
using Summaries.codeResources;
using System;
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

        simpleServerResponse response;
        string jsonResponse = "";
        string POSTdata = string.Empty;
        bool shouldAbort = false;
        Local_Storage storage = Local_Storage.Retrieve;

        private void checkConnection()
        {
            var functions = new codeResources.functions();
            if (functions.CheckForInternetConnection(storage.inUseDomain))
            { 
                POSTdata = "oldpasswd=" + functions.Hash(currentPasswordBox.Text) + "&newpasswd=" + functions.Hash(newPasswordBox.Text);
                jsonResponse = functions.APIRequest("PUT", POSTdata, "user/" + storage.userID + "/changepassword");
            }
            else
            {
                shouldAbort = true;
                MessageBox.Show("Lost Connection to the server. Please try again later!", "Connection Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void changePassword_Load(object sender, EventArgs e)
        {
            using (codeResources.loadingForm form = new codeResources.loadingForm(checkConnection))
            {
                form.ShowDialog();
            }
            this.Text += storage.displayName;
            usernameBox.Text = storage.username;
        }

        private void resetFields()
        {
            currentPasswordBox.Clear();
            newPasswordBox.Clear();
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
                        var functions = new codeResources.functions();
                        try
                        {
                            using (codeResources.loadingForm form = new codeResources.loadingForm(checkConnection))
                            {
                                form.ShowDialog();
                            }

                            if (shouldAbort)
                            {
                                this.Close();
                            }
                            else
                            {
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
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "\n" + ex.StackTrace + "\n" + jsonResponse, "Critital Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
