using Newtonsoft.Json;
using Summaries.codeResources;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static Summaries.codeResources.functions;

namespace Summaries.administration
{
    public partial class UserConfigForm : Form
    {

        codeResources.functions functions = new codeResources.functions();
        int sentUserID = 0;
        string request = null;
        string classRequest = null;
        string craftData = null;
        string saveRequest = null;
        bool changesHandled = false;

        usersServerResponse response;
        classesServerResponse classResponse;
        simpleServerResponse saveResponse;

        public class usersServerResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
            public string ErrorCode { get; set; }
            public List<usersContent> contents { get; set; }
        }

        public class usersContent
        {
            public int userid { get; set; }
            public string user { get; set; }
            public string displayName { get; set; }
            public string avatarURL { get; set; }
            public int classID { get; set; }
            public bool isAdmin { get; set; } = false;
            public bool isDeletionProtected { get; set; } = false;
        }

        public class classesServerResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
            public List<classesContent> contents { get; set; }
        }

        public class classesContent
        {
            public int classID { get; set; }
            public string className { get; set; }
            public int totalUsers { get; set; }
        }


        public UserConfigForm(int userID = 0)
        {
            InitializeComponent();
            sentUserID = userID;
        }

        private void RequestUserData()
        {
            request = functions.APIRequest("GET", null, "user/" + sentUserID);
            classRequest = functions.APIRequest("GET", null, "class"); // its loaded here so the loading screen does not have to appear twice
        }

        private void RequestClassesList()
        {
            classRequest = functions.APIRequest("GET", null, "class"); // this will only be executed if a new user is being created
        }

        private void CreateNewUser()
        {
            saveRequest = functions.APIRequest("POST", craftData, "user");
        }

        private void UpdateUserData()
        {
            saveRequest = functions.APIRequest("PUT", craftData, "user/" + sentUserID);
        }

        private void UserConfigForm_Load(object sender, EventArgs e)
        {
            if (sentUserID != 0)
            {

                using (loadingForm loading = new loadingForm(RequestUserData))
                {
                    loading.ShowDialog();
                }

                try
                {
                    response = JsonConvert.DeserializeObject<usersServerResponse>(request);

                    if (response.status)
                    {
                        if (response.contents.Count != 1)
                        {
                            MessageBox.Show("More than one entry received", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Close();
                        }
                        else
                        {
                            classResponse = JsonConvert.DeserializeObject<classesServerResponse>(classRequest);

                            if (classResponse.status)
                            {
                                usersContent user = response.contents[0];

                                foreach (var x in classResponse.contents)
                                {
                                    classCB.Items.Add(x.className);
                                }

                                this.Text = "\"" + user.displayName + "\" Properties";

                                if (!string.IsNullOrEmpty(user.avatarURL))
                                {
                                    userProfilePic.Load(user.avatarURL);
                                }

                                UsernameTOPBox.Text = user.displayName;
                                displayNameTB.Text = user.displayName;
                                loginNameTB.Text = user.user;

                                classCB.SelectedItem = classResponse.contents[classResponse.contents.FindIndex(x => x.classID == user.classID)].className;

                                isAdminCheck.Checked = user.isAdmin;
                                isDeletionProtectedCheck.Checked = user.isDeletionProtected;
                            }
                            else
                            {
                                MessageBox.Show("Error: " + classResponse.errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: " + response.errors + "\n" +
                            "ErrorCode: " + response.ErrorCode, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Response: " + response + "\n" +
                        "Request:" + request + "\n" +
                        "Error: " + ex.Message + "\n" +
                        "Stack: " + ex.StackTrace, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            else
            {
                this.Text = "New User Properties";
                UsernameTOPBox.Text = "New User";

                using (loadingForm loading = new loadingForm(RequestClassesList))
                {
                    loading.ShowDialog();
                }

                classResponse = JsonConvert.DeserializeObject<classesServerResponse>(classRequest);

                if (classResponse.status)
                {
                    foreach (var x in classResponse.contents)
                    {
                        classCB.Items.Add(x.className);
                    }
                    classCB.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Error: " + classResponse.errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Close();
        }

        private void UserConfigForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                cancelBTN_Click(sender, e);
            }
        }

        private bool wasAnyFieldModified()
        {
            if (loginNameTB.Text != response.contents[0].user)
                return true;

            if (displayNameTB.Text != response.contents[0].displayName)
                return true;

            if (classCB.SelectedItem.ToString() != classResponse.contents[classResponse.contents.FindIndex(x => x.classID == response.contents[0].classID)].className)
                return true;

            if (isAdminCheck.Checked != response.contents[0].isAdmin)
                return true;

            if (isDeletionProtectedCheck.Checked != response.contents[0].isDeletionProtected)
                return true;

            return false;
        }

        private bool isAnyFieldEmpty()
        {
            errorProvider.SetError(loginNameTB, "");
            errorProvider.SetError(displayNameTB, ""); // Clears errors

            if (string.IsNullOrEmpty(loginNameTB.Text) || string.IsNullOrWhiteSpace(loginNameTB.Text))
            {
                errorProvider.SetIconPadding(loginNameTB, -20);
                errorProvider.SetError(loginNameTB, "This field is mandatory");
                return true;
            }

            if (string.IsNullOrEmpty(displayNameTB.Text) || string.IsNullOrWhiteSpace(displayNameTB.Text))
            {
                errorProvider.SetIconPadding(displayNameTB, -20);
                errorProvider.SetError(displayNameTB, "This field is mandatory");
                return true;
            }

            return false;
        }

        private void okBTN_Click(object sender, EventArgs e)
        {
            if (!isAnyFieldEmpty())
            {
                craftData = "username=" + loginNameTB.Text +
                "&displayName=" + displayNameTB.Text +
                "&classID=" + classResponse.contents[classResponse.contents.FindIndex(x => x.className == classCB.SelectedItem.ToString())].classID +
                "&isAdmin=" + isAdminCheck.Checked.ToString() +
                "&isDeletionProtected=" + isDeletionProtectedCheck.Checked.ToString();
                if (sentUserID != 0) // 0 -> new user. != 0 -> user being edited
                {
                    if (wasAnyFieldModified())
                    {
                        using (loadingForm loading = new loadingForm(UpdateUserData))
                        {
                            loading.ShowDialog();
                        }
                        try
                        {
                            saveResponse = JsonConvert.DeserializeObject<simpleServerResponse>(saveRequest);

                            if (saveResponse.status)
                            {
                                changesHandled = true;
                                cancelBTN_Click(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("Error: " + saveResponse.errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Response: " + saveResponse + "\n" +
                                "Request:" + saveRequest + "\n" +
                                "Error: " + ex.Message + "\n" +
                                "Stack: " + ex.StackTrace, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        changesHandled = true;
                        cancelBTN_Click(sender, e);
                    }
                }
                else
                {
                    using (loadingForm loading = new loadingForm(CreateNewUser))
                    {
                        loading.ShowDialog();
                    }
                    try
                    {

                        saveResponse = JsonConvert.DeserializeObject<simpleServerResponse>(saveRequest);

                        if (saveResponse.status)
                        {
                            changesHandled = true;
                            cancelBTN_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Error: " + saveResponse.errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Response: " + saveResponse + "\n" +
                            "Request:" + saveRequest + "\n" +
                            "Error: " + ex.Message + "\n" +
                            "Stack: " + ex.StackTrace, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void UserConfigForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!changesHandled)
            {
                if (sentUserID != 0)
                {
                    if (wasAnyFieldModified())
                    {
                        if (MessageBox.Show("There are unsaved changes made to this user. Would you like to save them first?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            okBTN_Click(sender, e);
                        }
                    }
                }
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
