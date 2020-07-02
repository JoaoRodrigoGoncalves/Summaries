using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using static Summaries.codeResources.functions;

namespace Summaries
{
    public partial class AdministrationPanel : Form
    {
        private int currentSelectedrow = 0;
        private int currentSelectedWorkspace = 0;
        private int currentSelectedClass = 0;
        private int previousSelectedrow = 0;
        private int previousSelectedWorkspace = 0;
        private int previousSelectedClass = 0;
        private int selectedTab = 0;
        private bool addingUser = false;
        private bool addingClass = false;
        private bool addingWorkspace = false;

        public AdministrationPanel()
        {
            InitializeComponent();
        }

        public class workspacesContent
        {
            public int id { get; set; }
            public string name { get; set; }
            public bool read { get; set; }
            public bool write { get; set; }
            public int totalSummaries { get; set; }
        }

        public class workspacesResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
            public List<workspacesContent> contents { get; set; }
        }

        public class Content
        {
            public int userid { get; set; }
            public string user { get; set; }
            public string displayName { get; set; }
            public string className { get; set; }
            public bool isAdmin { get; set; } = false;
            public bool isDeletionProtected { get; set; } = false;
        }

        public class serverResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
            public List<Content> contents { get; set; }
        }

        public class classContent
        {
            public int classID { get; set; }
            public string className { get; set; }
            public int totalUsers { get; set; }
        }

        public class classServerResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
            public List<classContent> contents { get; set; }
        }

        classServerResponse classServer;
        serverResponse response;
        workspacesResponse workspacesServerResponse;
        bool shouldAbort = false;
        string jsonResponse = "";
        string classJsonResponse = "";
        string workspaceJsonResponse = "";
        string GlobalPOSTdata = "";
        string GlobalAPIResponse = "";

        private void APICalls()
        {
            var functions = new codeResources.functions();
            if (functions.CheckForInternetConnection(Properties.Settings.Default.inUseDomain))
            {
                jsonResponse = functions.APIRequest("API=" + Properties.Settings.Default.AccessToken, "user/list");
                classJsonResponse = functions.APIRequest("API=" + Properties.Settings.Default.AccessToken, "class/list");
                workspaceJsonResponse = functions.APIRequest("API=" + Properties.Settings.Default.AccessToken, "workspace/list");
            }
            else
            {
                shouldAbort = true;
                MessageBox.Show("Lost connection to the server. Please try again.", "Connection Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveUser()
        {
            var functions = new codeResources.functions();
            GlobalAPIResponse = functions.APIRequest(GlobalPOSTdata, "user/edit");
        }

        private void DeleteUser()
        {
            var functions = new codeResources.functions();
            GlobalAPIResponse = functions.APIRequest(GlobalPOSTdata, "usser/delete");
        }

        private void ResetUser()
        {
            var functions = new codeResources.functions();
            GlobalAPIResponse = functions.APIRequest(GlobalPOSTdata, "user/changePassword");
        }

        private void SaveClass()
        {
            var functions = new codeResources.functions();
            GlobalAPIResponse = functions.APIRequest(GlobalPOSTdata, "class/edit");
        }

        private void DeleteClass()
        {
            var functions = new codeResources.functions();
            GlobalAPIResponse = functions.APIRequest(GlobalPOSTdata, "class/delete");
        }

        private void SaveWorkspace() {
            var functions = new codeResources.functions();
            GlobalAPIResponse = functions.APIRequest(GlobalPOSTdata, "workspace/edit");
        }

        private void DeleteWorkspace()
        {
            var functions = new codeResources.functions();
            GlobalAPIResponse = functions.APIRequest(GlobalPOSTdata, "workspace/delete");
        }

        private void FlushWorkspace()
        {
            var functions = new codeResources.functions();
            GlobalAPIResponse = functions.APIRequest(GlobalPOSTdata, "workspace/flush");
        }

        private void AdministrationPanel_Load(object sender, EventArgs e)
        {
            try
            {
                var functions = new codeResources.functions();
                using(codeResources.loadingForm form = new codeResources.loadingForm(APICalls))
                {
                    form.ShowDialog();
                }

                if (shouldAbort)
                {
                    this.Close();
                }
                else
                {
                    response = JsonConvert.DeserializeObject<serverResponse>(jsonResponse);
                    classServer = JsonConvert.DeserializeObject<classServerResponse>(classJsonResponse);


                    if (response.status && classServer.status)
                    {
                        classBox.Items.Clear();
                        userDataGrid.Rows.Clear();
                        userDataGrid.Refresh();
                        userDataGrid.ColumnCount = 6;
                        userDataGrid.Columns[0].Name = "userID";
                        userDataGrid.Columns[0].HeaderText = "#";
                        userDataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        userDataGrid.Columns[1].Name = "username";
                        userDataGrid.Columns[1].HeaderText = "Login Name";
                        userDataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        userDataGrid.Columns[2].Name = "displayName";
                        userDataGrid.Columns[2].HeaderText = "Display Name";
                        userDataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        userDataGrid.Columns[3].Name = "class";
                        userDataGrid.Columns[3].HeaderText = "Class";
                        userDataGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        userDataGrid.Columns[4].Name = "isAdmin";
                        userDataGrid.Columns[4].HeaderText = "Admin?";
                        userDataGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        userDataGrid.Columns[5].Name = "isProtected";
                        userDataGrid.Columns[5].HeaderText = "Deletion Protected?";
                        userDataGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        userDataGrid.AllowUserToDeleteRows = false;
                        userDataGrid.AllowUserToAddRows = false;
                        userDataGrid.AllowUserToResizeColumns = true;
                        userDataGrid.MultiSelect = false; //just to reinforce


                        var rows = new List<string[]>();
                        foreach (Content content in response.contents)
                        {
                            string[] row1 = new string[] { content.userid.ToString(), content.user.ToString(), content.displayName.ToString(), classServer.contents.Find(x => x.classID == Convert.ToInt32(content.className)).className, content.isAdmin.ToString(), content.isDeletionProtected.ToString() };
                            rows.Add(row1);
                        }

                        foreach (string[] rowArray in rows)
                        {
                            userDataGrid.Rows.Add(rowArray);
                        }

                        foreach (classContent classContent in classServer.contents)
                        {
                            classBox.Items.Add(classContent.className);
                        }

                        DataGridViewRow selectedRow = userDataGrid.Rows[0];
                        usernameBox.Text = selectedRow.Cells["username"].Value.ToString();
                        displayNameBox.Text = selectedRow.Cells["displayName"].Value.ToString();
                        classBox.SelectedItem = selectedRow.Cells["class"].Value.ToString();
                        if (selectedRow.Cells["isAdmin"].Value.ToString() == "True")
                        {
                            adminPrivBox.Checked = true;
                        }
                        else
                        {
                            adminPrivBox.Checked = false;
                        }

                        if (selectedRow.Cells["isProtected"].Value.ToString() == "True")
                        {
                            accidentalDeletionBox.Checked = true;
                        }
                        else
                        {
                            accidentalDeletionBox.Checked = false;
                        }

                        resetPWBTN.Enabled = true;
                        deleteUserBTN.Enabled = true;

                    }
                    else
                    {
                        MessageBox.Show("A critical error occurred. " + response.errors, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }

                workspacesServerResponse = JsonConvert.DeserializeObject<workspacesResponse>(workspaceJsonResponse);

                if (workspacesServerResponse.status)
                {
                    workspacesDataGrid.Rows.Clear();
                    workspaceBOX.Clear();
                    writeCheckBox.Checked = true;
                    readCheckBox.Checked = true;
                    workspacesDataGrid.Enabled = true;
                    workspacesDataGrid.ColumnCount = 5;
                    workspacesDataGrid.Columns[0].Name = "id";
                    workspacesDataGrid.Columns[0].HeaderText = "#";
                    workspacesDataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    workspacesDataGrid.Columns[1].Name = "name";
                    workspacesDataGrid.Columns[1].HeaderText = "Name";
                    workspacesDataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    workspacesDataGrid.Columns[2].Name = "readMode";
                    workspacesDataGrid.Columns[2].HeaderText = "Read?";
                    workspacesDataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    workspacesDataGrid.Columns[3].Name = "writeMode";
                    workspacesDataGrid.Columns[3].HeaderText = "Write?";
                    workspacesDataGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    workspacesDataGrid.Columns[4].Name = "registeredSummaries";
                    workspacesDataGrid.Columns[4].HeaderText = "Registered Summaries";
                    workspacesDataGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    workspacesDataGrid.AllowUserToDeleteRows = false;
                    workspacesDataGrid.AllowUserToAddRows = false;
                    workspacesDataGrid.AllowUserToResizeColumns = true;
                    workspacesDataGrid.MultiSelect = false; //just to reinforce

                    var workspaceRows = new List<string[]>();
                    if(workspacesServerResponse.contents != null)
                    {
                        workspaceBOX.Enabled = true;
                        writeCheckBox.Enabled = true;
                        readCheckBox.Enabled = true;
                        saveWorkspaceBTN.Enabled = true;
                        flushSummariesBTN.Enabled = true;
                        deleteWorkspaceBTN.Enabled = true;

                        foreach (workspacesContent workspaceContent in workspacesServerResponse.contents)
                        {
                            string[] nextRow = new string[] { workspaceContent.id.ToString(), workspaceContent.name.ToString(), workspaceContent.read.ToString(), workspaceContent.write.ToString(), workspaceContent.totalSummaries.ToString() };
                            workspaceRows.Add(nextRow);
                        }

                        foreach (string[] wrowArray in workspaceRows)
                        {
                            workspacesDataGrid.Rows.Add(wrowArray);
                        }

                        DataGridViewRow selectedWorkspaceRow = workspacesDataGrid.Rows[0];
                        workspaceBOX.Text = selectedWorkspaceRow.Cells["name"].Value.ToString();
                        if (selectedWorkspaceRow.Cells["readMode"].Value.ToString() == "True")
                        {
                            readCheckBox.Checked = true;
                        }
                        else
                        {
                            readCheckBox.Checked = false;
                        }

                        if (selectedWorkspaceRow.Cells["writeMode"].Value.ToString() == "True")
                        {
                            writeCheckBox.Checked = true;
                        }
                        else
                        {
                            writeCheckBox.Checked = false;
                        }

                        flushSummariesBTN.Enabled = true;
                        deleteUserBTN.Enabled = true;
                    }
                    else
                    {
                        workspaceBOX.Enabled = false;
                        writeCheckBox.Enabled = false;
                        readCheckBox.Enabled = false;
                        saveWorkspaceBTN.Enabled = false;
                        flushSummariesBTN.Enabled = false;
                        deleteWorkspaceBTN.Enabled = false;
                    }
                    
                }
                else
                {
                    MessageBox.Show("A critical error occurred. " + workspacesServerResponse.errors, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

                if (classServer.status)
                {
                    classesDataGrid.Rows.Clear();
                    classNameBOX.Clear();
                    classesDataGrid.ColumnCount = 3;
                    classesDataGrid.Columns[0].Name = "classID";
                    classesDataGrid.Columns[0].HeaderText = "#";
                    classesDataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    classesDataGrid.Columns[1].Name = "className";
                    classesDataGrid.Columns[1].HeaderText = "Class Name";
                    classesDataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    classesDataGrid.Columns[2].Name = "registeredUsers";
                    classesDataGrid.Columns[2].HeaderText = "Total of Registered Users";
                    classesDataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    classesDataGrid.AllowUserToDeleteRows = false;
                    classesDataGrid.AllowUserToAddRows = false;
                    classesDataGrid.AllowUserToResizeColumns = true;
                    classesDataGrid.MultiSelect = false; //just to reinforce

                    var classRows = new List<string[]>();
                    foreach (classContent classContent in classServer.contents)
                    {
                        string[] nextClassRow = new string[] { classContent.classID.ToString(), classContent.className.ToString(), classContent.totalUsers.ToString() };
                        classRows.Add(nextClassRow);
                    }

                    foreach (string[] wrowArray in classRows)
                    {
                        classesDataGrid.Rows.Add(wrowArray);
                    }

                    DataGridViewRow selectedClasssRow = classesDataGrid.Rows[0];
                    classNameBOX.Text = selectedClasssRow.Cells["className"].Value.ToString();

                    deleteClassBTN.Enabled = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("A critical error occurred. " + ex.Message + "\n" + ex.StackTrace, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            administrationTabMenu.SelectedIndex = selectedTab;
        }

        private void userDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (userDataGrid.SelectedRows.Count > 0 || userDataGrid.SelectedCells.Count > 0)
            {
                int selectedrowindex = userDataGrid.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = userDataGrid.Rows[selectedrowindex];
                currentSelectedrow = selectedrowindex;
                usernameBox.Text = selectedRow.Cells["username"].Value.ToString();
                displayNameBox.Text = selectedRow.Cells["displayName"].Value.ToString();
                classBox.SelectedItem = selectedRow.Cells["class"].Value.ToString();
                if (selectedRow.Cells["isAdmin"].Value.ToString() == "True")
                {
                    adminPrivBox.Checked = true;
                }
                else
                {
                    adminPrivBox.Checked = false;
                }

                if (selectedRow.Cells["isProtected"].Value.ToString() == "True")
                {
                    accidentalDeletionBox.Checked = true;
                }
                else
                {
                    accidentalDeletionBox.Checked = false;
                }

                resetPWBTN.Enabled = true;
                deleteUserBTN.Enabled = true;

            }
        }

        private void newUserBTN_Click(object sender, EventArgs e)
        {
            if (addingUser)
            {
                addingUser = false;
                newUserBTN.Text = "Add User";
                currentSelectedrow = previousSelectedrow;
                infoGBox.Text = "Editing User " + userDataGrid.Rows[currentSelectedrow].Cells["displayName"].Value.ToString();
                resetPWBTN.Enabled = true;
                deleteUserBTN.Enabled = true;
                userDataGrid.Enabled = true;
                usernameBox.Text = userDataGrid.Rows[currentSelectedrow].Cells["username"].Value.ToString();
                displayNameBox.Text = userDataGrid.Rows[currentSelectedrow].Cells["displayName"].Value.ToString();
                classBox.SelectedItem = userDataGrid.Rows[currentSelectedrow].Cells["class"].Value.ToString();
                if (userDataGrid.Rows[currentSelectedrow].Cells["isAdmin"].Value.ToString() == "True")
                {
                    adminPrivBox.Checked = true;
                }
                else
                {
                    adminPrivBox.Checked = false;
                }
                if (userDataGrid.Rows[currentSelectedrow].Cells["isProtected"].Value.ToString() == "True")
                {
                    accidentalDeletionBox.Checked = true;
                }
                else
                {
                    accidentalDeletionBox.Checked = false;
                }
            }
            else
            {
                addingUser = true;
                previousSelectedrow = currentSelectedrow;
                currentSelectedrow = 0;
                usernameBox.Clear();
                displayNameBox.Clear();
                classBox.SelectedIndex = 0;
                adminPrivBox.Checked = false;
                accidentalDeletionBox.Checked = false;
                resetPWBTN.Enabled = false;
                deleteUserBTN.Enabled = false;
                userDataGrid.Enabled = false;
                newUserBTN.Text = "Cancel";
                infoGBox.Text = "Adding User";
            }
        }

        private void resetPWBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (!addingUser)
                {
                    if (userDataGrid.SelectedRows.Count > 0 || userDataGrid.SelectedCells.Count > 0)
                    {
                        int selectedrowindex = userDataGrid.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedRow = userDataGrid.Rows[selectedrowindex];
                        int userToReset = Convert.ToInt32(selectedRow.Cells["userID"].Value.ToString());
                        if (userDataGrid.Rows[currentSelectedrow].Cells["isProtected"].Value.ToString() == "True")
                        {
                            MessageBox.Show("Cannot reset this user's password because the account is protected against accidental deletion!", "Protection Against Accidental Deletion Alert!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            var functions = new codeResources.functions();
                            GlobalPOSTdata = "API=" + Properties.Settings.Default.AccessToken + "&userID=" + userToReset + "&reset=true";

                            simpleServerResponse serverResponse;

                            using (codeResources.loadingForm form = new codeResources.loadingForm(ResetUser)) {
                                form.ShowDialog();
                            }

                            serverResponse = JsonConvert.DeserializeObject<simpleServerResponse>(GlobalAPIResponse);

                            if (serverResponse.status)
                            {
                                MessageBox.Show("Password Reseted Successfully to \"defaultPW\"!", "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("A critical error occurred. " + serverResponse.errors, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A critical error occurred. " + ex.Message, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            try
            {

                if (usernameBox.TextLength < 1 || displayNameBox.TextLength < 1 || classBox.Text.Length < 1)
                {
                    MessageBox.Show("Please fill all the fields before continue.", "Blank fileds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var functions = new codeResources.functions();
                    string username = functions.Hash(usernameBox.Text);
                    string displayName = functions.Hash(displayNameBox.Text);
                    string classGiven = classBox.Text;
                    string classNum = functions.Hash(classServer.contents[classServer.contents.FindIndex(x => x.className == classBox.Text)].classID.ToString());
                    string isAdmin = adminPrivBox.Checked.ToString();
                    string isDeletionProtected = accidentalDeletionBox.Checked.ToString();
                    if (addingUser)
                    {
                        GlobalPOSTdata = "API=" + Properties.Settings.Default.AccessToken;
                        GlobalPOSTdata += "&username=" + username + "&displayName=" + displayName + "&classID=" + classNum + "&admin=" + isAdmin + "&deletionProtection=" + isDeletionProtected;

                        simpleServerResponse serverResponse;

                        using (codeResources.loadingForm form = new codeResources.loadingForm(SaveUser)) {
                            form.ShowDialog();
                        }

                        serverResponse = JsonConvert.DeserializeObject<simpleServerResponse>(GlobalAPIResponse);

                        if (serverResponse.status)
                        {
                            MessageBox.Show("New user " + displayNameBox.Text + " created successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            newUserBTN_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("A critical error occurred. " + serverResponse.errors, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                    else
                    {
                        int selectedrowindex = userDataGrid.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedRow = userDataGrid.Rows[selectedrowindex];
                        int userToUpdate = Convert.ToInt32(selectedRow.Cells["userID"].Value.ToString());
                        GlobalPOSTdata = "API=" + Properties.Settings.Default.AccessToken + "&userID=" + userToUpdate + "&username=" + username + "&displayName=" + displayName + "&classID=" + classNum + "&admin=" + isAdmin + "&deletionProtection=" + isDeletionProtected;

                        simpleServerResponse serverResponse;

                        using (codeResources.loadingForm form = new codeResources.loadingForm(SaveUser)) {
                            form.ShowDialog();
                        }

                        serverResponse = JsonConvert.DeserializeObject<simpleServerResponse>(GlobalAPIResponse);

                        if (serverResponse.status)
                        {
                            MessageBox.Show("Edited user " + displayNameBox.Text + " successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("A critical error occurred. " + serverResponse.errors, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }

                    }
                }
                AdministrationPanel_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("A critical error occurred. " + ex.Message + "\n" + ex.StackTrace, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void refreshBTN_Click(object sender, EventArgs e)
        {
            AdministrationPanel_Load(sender, e);
        }

        private void deleteUserBTN_Click(object sender, EventArgs e)
        {
            int selectedrowindex = userDataGrid.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = userDataGrid.Rows[selectedrowindex];

            if (Properties.Settings.Default.userID == Convert.ToInt32(selectedRow.Cells["userID"].Value))
            {
                MessageBox.Show("Cannot delete the current user being used", "Unable to delete the user", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var res = MessageBox.Show("Are you sure you want to permanently delete " + selectedRow.Cells["displayName"].Value.ToString(), "Delete user", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    if (selectedRow.Cells["isProtected"].Value.ToString() == "False")
                    {
                        try
                        {
                            var functions = new codeResources.functions();
                            int userToDelete = Convert.ToInt32(selectedRow.Cells["userID"].Value.ToString());
                            GlobalPOSTdata = "API=" + Properties.Settings.Default.AccessToken + "&userID=" + userToDelete;

                            simpleServerResponse serverResponse;

                            using (codeResources.loadingForm form = new codeResources.loadingForm(DeleteUser)) {
                                form.ShowDialog();
                            }

                            serverResponse = JsonConvert.DeserializeObject<simpleServerResponse>(GlobalAPIResponse);

                            if (serverResponse.status)
                            {
                                MessageBox.Show("User Deleted Successfully!", "User Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                AdministrationPanel_Load(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("A critical error occurred. " + serverResponse.errors, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("A critical error occurred. " + ex.Message, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("The user is protected against deletion and cannot be deleted.", "Protected against deletion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void saveWorkspaceBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (workspaceBOX.TextLength < 1)
                {
                    MessageBox.Show("Please fill all the fields before continue.", "Blank fileds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var functions = new codeResources.functions();
                    string workspaceName = functions.Hash(workspaceBOX.Text);
                    string readMode = readCheckBox.Checked.ToString();
                    string writeMode = writeCheckBox.Checked.ToString();
                    if (addingWorkspace)
                    {
                        GlobalPOSTdata = "API=" + Properties.Settings.Default.AccessToken + "&name=" + workspaceName + "&readMode=" + readMode + "&writeMode=" + writeMode;

                        simpleServerResponse serverResponse;

                        using (codeResources.loadingForm form = new codeResources.loadingForm(SaveWorkspace)) {
                            form.ShowDialog();
                        }

                        serverResponse = JsonConvert.DeserializeObject<simpleServerResponse>(GlobalAPIResponse);

                        if (serverResponse.status)
                        {
                            MessageBox.Show("New workspace " + workspaceBOX.Text + " created successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            addWorkspaceBTN_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("A critical error occurred. " + serverResponse.errors, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                    else
                    {
                        int selectedWorkwspaceIndex = workspacesDataGrid.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedWorkspaceRow = workspacesDataGrid.Rows[selectedWorkwspaceIndex];
                        int workspaceToUpdate = Convert.ToInt32(selectedWorkspaceRow.Cells["id"].Value.ToString());
                        GlobalPOSTdata = "API=" + Properties.Settings.Default.AccessToken + "&workspaceID=" + workspaceToUpdate + "&name=" + functions.Hash(workspaceBOX.Text) + "&readMode=" + readMode + "&writeMode=" + writeMode;

                        simpleServerResponse serverResponse;

                        using (codeResources.loadingForm form = new codeResources.loadingForm(SaveWorkspace)) {
                            form.ShowDialog();
                        }

                        serverResponse = JsonConvert.DeserializeObject<simpleServerResponse>(GlobalAPIResponse);

                        if (serverResponse.status)
                        {
                            MessageBox.Show("Edited workspace " + workspaceBOX.Text + " successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            addWorkspaceBTN_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("A critical error occurred. " + serverResponse.errors, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }

                    }
                }
                AdministrationPanel_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("A critical error occurred. " + ex.Message + "\n" + ex.StackTrace, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void administrationTabMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTab = administrationTabMenu.SelectedIndex;
        }

        private void addWorkspaceBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (addingWorkspace)
                {
                    addingWorkspace = false;
                    addWorkspaceBTN.Text = "Add Workspace";
                    currentSelectedWorkspace = previousSelectedWorkspace;
                    workspaceGRPBOX.Text = "Editing Workspace";
                    if(workspacesDataGrid.Rows.Count > 0)
                    {
                        workspaceBOX.Text = workspacesDataGrid.Rows[currentSelectedWorkspace].Cells["name"].Value.ToString();
                        flushSummariesBTN.Enabled = true;
                        deleteWorkspaceBTN.Enabled = true;
                        workspacesDataGrid.Enabled = true;
                        if (workspacesDataGrid.Rows[currentSelectedWorkspace].Cells["readMode"].Value.ToString() == "True")
                        {
                            readCheckBox.Checked = true;
                        }
                        else
                        {
                            readCheckBox.Checked = false;
                        }
                        if (workspacesDataGrid.Rows[currentSelectedWorkspace].Cells["writeMode"].Value.ToString() == "True")
                        {
                            writeCheckBox.Checked = true;
                        }
                        else
                        {
                            writeCheckBox.Checked = false;
                        }
                    }
                    else
                    {
                        workspaceBOX.Clear();
                        workspaceBOX.Enabled = false;
                        flushSummariesBTN.Enabled = false;
                        deleteWorkspaceBTN.Enabled = false;
                        readCheckBox.Enabled = false;
                        writeCheckBox.Enabled = false;
                    }
                    
                }
                else
                {
                    addingWorkspace = true;
                    previousSelectedWorkspace = currentSelectedWorkspace;
                    currentSelectedWorkspace = 0;
                    workspaceBOX.Clear();
                    workspaceBOX.Enabled = true;
                    readCheckBox.Enabled = true;
                    readCheckBox.Checked = true;
                    writeCheckBox.Checked = true;
                    writeCheckBox.Enabled = true;
                    saveWorkspaceBTN.Enabled = true;
                    workspacesDataGrid.Enabled = false;
                    flushSummariesBTN.Enabled = false;
                    deleteWorkspaceBTN.Enabled = false;
                    addWorkspaceBTN.Text = "Cancel";
                    workspaceGRPBOX.Text = "Adding Workspace";
                }
            }catch(Exception ex)
            {
                MessageBox.Show("A critical error occurred. " + ex.Message + "\n" + ex.StackTrace, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            
        }

        private void workspacesDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (workspacesDataGrid.SelectedRows.Count > 0 || workspacesDataGrid.SelectedCells.Count > 0)
            {
                int selectedWorkwspaceRowIndex = workspacesDataGrid.SelectedCells[0].RowIndex;
                DataGridViewRow selectedWorkspaceRow = workspacesDataGrid.Rows[selectedWorkwspaceRowIndex];
                currentSelectedWorkspace = selectedWorkwspaceRowIndex;
                workspaceGRPBOX.Text = "Editing Workspace";
                workspaceBOX.Text = selectedWorkspaceRow.Cells["name"].Value.ToString();
                if (selectedWorkspaceRow.Cells["readMode"].Value.ToString() == "True")
                {
                    readCheckBox.Checked = true;
                }
                else
                {
                    readCheckBox.Checked = false;
                }

                if (selectedWorkspaceRow.Cells["writeMode"].Value.ToString() == "True")
                {
                    writeCheckBox.Checked = true;
                }
                else
                {
                    writeCheckBox.Checked = false;
                }

                flushSummariesBTN.Enabled = true;
                deleteWorkspaceBTN.Enabled = true;

            }
        }

        private void writeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(writeCheckBox.Checked && !readCheckBox.Checked)
            {
                readCheckBox.Checked = true;
            }
        }

        private void deleteWorkspaceBTN_Click(object sender, EventArgs e)
        {
            int selectedWorkspaceIndex = workspacesDataGrid.SelectedCells[0].RowIndex;
            DataGridViewRow selectedWorkspaceRow = workspacesDataGrid.Rows[selectedWorkspaceIndex];

            codeResources.confirmByTyping writtenConfirmation = new codeResources.confirmByTyping(selectedWorkspaceRow.Cells["name"].Value.ToString());
            Properties.Settings.Default.typeTestSuccessfull = false; // just to be sure
            writtenConfirmation.ShowDialog();

            if (Properties.Settings.Default.typeTestSuccessfull)
            {
                Properties.Settings.Default.typeTestSuccessfull = false;
                try
                {
                    var functions = new codeResources.functions();
                    GlobalPOSTdata = "API=" + Properties.Settings.Default.AccessToken + "&workspaceID=" + Convert.ToInt32(selectedWorkspaceRow.Cells["id"].Value.ToString());

                    simpleServerResponse serverResponse;

                    using (codeResources.loadingForm form = new codeResources.loadingForm(DeleteWorkspace)) {
                        form.ShowDialog();
                    }

                    serverResponse = JsonConvert.DeserializeObject<simpleServerResponse>(GlobalAPIResponse);

                    if (serverResponse.status)
                    {
                        MessageBox.Show("Workspace Deleted Successfully!", "Workspace Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AdministrationPanel_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("A critical error occurred. " + serverResponse.errors, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A critical error occurred. " + ex.Message + "\n" + ex.StackTrace, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        private void workspaceRefreshBTN_Click(object sender, EventArgs e)
        {
            AdministrationPanel_Load(sender, e);
        }

        private void flushSummariesBTN_Click(object sender, EventArgs e)
        {
            int selectedWorkspaceIndex = workspacesDataGrid.SelectedCells[0].RowIndex;
            DataGridViewRow selectedWorkspaceRow = workspacesDataGrid.Rows[selectedWorkspaceIndex];

            codeResources.confirmByTyping writtenConfirmation = new codeResources.confirmByTyping(selectedWorkspaceRow.Cells["name"].Value.ToString());
            Properties.Settings.Default.typeTestSuccessfull = false; // just to be sure
            writtenConfirmation.ShowDialog();

            if (Properties.Settings.Default.typeTestSuccessfull)
            {
                Properties.Settings.Default.typeTestSuccessfull = false;
                try
                {
                    var functions = new codeResources.functions();
                    GlobalPOSTdata = "API=" + Properties.Settings.Default.AccessToken + "&workspaceID=" + Convert.ToInt32(selectedWorkspaceRow.Cells["id"].Value.ToString());

                    simpleServerResponse serverResponse;

                    using (codeResources.loadingForm form = new codeResources.loadingForm(FlushWorkspace)) {
                        form.ShowDialog();
                    }

                    serverResponse = JsonConvert.DeserializeObject<simpleServerResponse>(GlobalAPIResponse);

                    if (serverResponse.status)
                    {
                        MessageBox.Show("Workspace Flushed Successfully!", "Workspace Flushed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AdministrationPanel_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("A critical error occurred. " + serverResponse.errors + "\n" + GlobalAPIResponse, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A critical error occurred. " + ex.Message + "\n" + ex.StackTrace, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        private void classesRefreshBTN_Click(object sender, EventArgs e)
        {
            AdministrationPanel_Load(sender, e);
        }

        private void classSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (classNameBOX.TextLength < 1)
                {
                    MessageBox.Show("Please fill all the fields before continue.", "Blank fileds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var functions = new codeResources.functions();
                    if (addingClass)
                    {
                        GlobalPOSTdata = "API=" + Properties.Settings.Default.AccessToken + "&name=" + functions.Hash(classNameBOX.Text);
                        simpleServerResponse serverResponse;

                        using (codeResources.loadingForm form = new codeResources.loadingForm(SaveClass)) {
                            form.ShowDialog();
                        }

                        serverResponse = JsonConvert.DeserializeObject<simpleServerResponse>(GlobalAPIResponse);

                        if (serverResponse.status)
                        {
                            MessageBox.Show("New class " + classNameBOX.Text + " created successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            addClassBTN_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("A critical error occurred. " + serverResponse.errors, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                    else
                    {
                        int selectedClassIndex = classesDataGrid.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedClassRow = classesDataGrid.Rows[selectedClassIndex];
                        int classToUpdate = Convert.ToInt32(selectedClassRow.Cells["classID"].Value.ToString());
                        string POSTdata = "API=" + Properties.Settings.Default.AccessToken + "&classID=" + classToUpdate + "&name=" + functions.Hash(classNameBOX.Text);

                        simpleServerResponse serverResponse;

                        using (codeResources.loadingForm form = new codeResources.loadingForm(SaveClass)) {
                            form.ShowDialog();
                        }

                        serverResponse = JsonConvert.DeserializeObject<simpleServerResponse>(GlobalAPIResponse);

                        if (serverResponse.status)
                        {
                            MessageBox.Show("Edited class " + classNameBOX.Text + " successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("A critical error occurred. " + serverResponse.errors, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }

                    }
                }
                AdministrationPanel_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("A critical error occurred. " + ex.Message, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void deleteClassBTN_Click(object sender, EventArgs e)
        {
            int selectedClassIndex = classesDataGrid.SelectedCells[0].RowIndex;
            DataGridViewRow selectedClassRow = classesDataGrid.Rows[selectedClassIndex];

            if (Convert.ToInt32(selectedClassRow.Cells["classID"].Value) == 0)
            {
                MessageBox.Show("That class cannot be deleted!", "Code level protection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                codeResources.confirmByTyping writtenConfirmation = new codeResources.confirmByTyping(selectedClassRow.Cells["className"].Value.ToString());
                Properties.Settings.Default.typeTestSuccessfull = false; // just to be sure
                writtenConfirmation.ShowDialog();

                if (Properties.Settings.Default.typeTestSuccessfull)
                {
                    Properties.Settings.Default.typeTestSuccessfull = false;
                    try
                    {
                        var functions = new codeResources.functions();
                        GlobalPOSTdata = "API=" + Properties.Settings.Default.AccessToken + "&classID=" + Convert.ToInt32(selectedClassRow.Cells["classID"].Value.ToString());

                        simpleServerResponse serverResponse;

                        using (codeResources.loadingForm form = new codeResources.loadingForm(DeleteClass)) {
                            form.ShowDialog();
                        }

                        serverResponse = JsonConvert.DeserializeObject<simpleServerResponse>(GlobalAPIResponse);

                        if (serverResponse.status)
                        {
                            MessageBox.Show("Class Deleted Successfully!", "Class Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            AdministrationPanel_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("A critical error occurred. " + serverResponse.errors, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("A critical error occurred. " + ex.Message + "\n" + ex.StackTrace, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
        }

        private void addClassBTN_Click(object sender, EventArgs e)
        {
            if (addingClass)
            {
                addingClass = false;
                addClassBTN.Text = "Add Class";
                currentSelectedClass = previousSelectedClass;
                infoGBox.Text = "Editing Class " + classesDataGrid.Rows[currentSelectedClass].Cells["className"].Value.ToString();
                deleteClassBTN.Enabled = true;
                classesDataGrid.Enabled = true;
                classNameBOX.Text = classesDataGrid.Rows[currentSelectedClass].Cells["className"].Value.ToString();
            }
            else
            {
                addingClass = true;
                previousSelectedClass = currentSelectedClass;
                currentSelectedClass = 0;
                classNameBOX.Clear();
                deleteClassBTN.Enabled = false;
                classesDataGrid.Enabled = false;
                addClassBTN.Text = "Cancel";
                classGRP.Text = "Adding Class";
            }
        }

        private void classesDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (classesDataGrid.SelectedRows.Count > 0 || classesDataGrid.SelectedCells.Count > 0)
            {
                int selectedClassRowIndex = classesDataGrid.SelectedCells[0].RowIndex;
                DataGridViewRow selectedClassRow = classesDataGrid.Rows[selectedClassRowIndex];
                currentSelectedrow = selectedClassRowIndex;
                classNameBOX.Text = selectedClassRow.Cells["className"].Value.ToString();

                deleteClassBTN.Enabled = true;
            }
        }
    }
}
