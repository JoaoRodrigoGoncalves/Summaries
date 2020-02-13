using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        private int previousSelectedrow = 0;
        private int previousSelectedWorkspace = 0;
        private int selectedTab = 0;
        private bool addingUser = false;
        //private bool addingClass = false;
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
        }

        public class classServerResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
            public List<classContent> contents { get; set; }
        }

        private void AdministrationPanel_Load(object sender, EventArgs e)
        {
            try
            {
                string jsonResponse = RequestUserList();
                serverResponse response;
                response = JsonConvert.DeserializeObject<serverResponse>(jsonResponse);
                classServerResponse classServer;
                codeResources.functions funct = new codeResources.functions();
                string classJsonResponse = funct.RequestClassesList();
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

                workspacesResponse workspacesResponse;
                workspacesResponse = JsonConvert.DeserializeObject<workspacesResponse>(funct.RequestAllWorkspaces());

                if (workspacesResponse.status)
                {
                    workspacesDataGrid.Rows.Clear();
                    workspacesDataGrid.ColumnCount = 4;
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
                    workspacesDataGrid.AllowUserToDeleteRows = false;
                    workspacesDataGrid.AllowUserToAddRows = false;
                    workspacesDataGrid.AllowUserToResizeColumns = true;
                    workspacesDataGrid.MultiSelect = false; //just to reinforce

                    var workspaceRows = new List<string[]>();
                    foreach (workspacesContent workspaceContent in workspacesResponse.contents)
                    {
                        string[] nextRow = new string[] { workspaceContent.id.ToString(), workspaceContent.name.ToString(), workspaceContent.read.ToString(), workspaceContent.write.ToString() };
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
                    MessageBox.Show("A critical error occurred. " + workspacesResponse.errors, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("A critical error occurred. " + ex.Message + "\n" + ex.StackTrace, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            administrationTabMenu.SelectedIndex = selectedTab;
        }

        public static string RequestUserList()
        {
            string POSTdata = "API=" + Properties.Settings.Default.APIkey;
            var data = Encoding.UTF8.GetBytes(POSTdata);
            var request = WebRequest.CreateHttp(Properties.Settings.Default.inUseDomain + "/summaries/api/userListRequest.php");
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
                            string POSTdata = "API=" + Properties.Settings.Default.APIkey + "&userID=" + userToReset + "&reset=true";
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
                            simpleServerResponse serverResponse;
                            serverResponse = JsonConvert.DeserializeObject<simpleServerResponse>(finalData);

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
                    string username = functions.HashPW(usernameBox.Text);
                    string displayName = functions.HashPW(displayNameBox.Text);
                    string classGiven = classBox.Text;
                    var digits = classGiven.SkipWhile(c => !Char.IsDigit(c))
                        .TakeWhile(Char.IsDigit)
                        .ToArray();
                    string classNum = functions.HashPW(new string(digits));
                    string isAdmin = adminPrivBox.Checked.ToString();
                    string isDeletionProtected = accidentalDeletionBox.Checked.ToString();
                    if (addingUser)
                    {
                        string POSTdata = "API=" + Properties.Settings.Default.APIkey;
                        POSTdata += "&username=" + username + "&displayName=" + displayName + "&classID=" + classNum + "&admin=" + isAdmin + "&deletionProtection=" + isDeletionProtected;
                        var data = Encoding.UTF8.GetBytes(POSTdata);
                        var request = WebRequest.CreateHttp(Properties.Settings.Default.inUseDomain + "/summaries/api/changeUser.php");
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

                        simpleServerResponse serverResponse;
                        serverResponse = JsonConvert.DeserializeObject<simpleServerResponse>(finalData);

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
                        string POSTdata = "API=" + Properties.Settings.Default.APIkey + "&userID=" + userToUpdate + "&username=" + username + "&displayName=" + displayName + "&classID=" + classNum + "&admin=" + isAdmin + "&deletionProtection=" + isDeletionProtected;
                        var data = Encoding.UTF8.GetBytes(POSTdata);
                        var request = WebRequest.CreateHttp(Properties.Settings.Default.inUseDomain + "/summaries/api/changeUser.php");
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

                        simpleServerResponse serverResponse;
                        serverResponse = JsonConvert.DeserializeObject<simpleServerResponse>(finalData);

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
                MessageBox.Show("A critical error occurred. " + ex.Message, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            int userToDelete = Convert.ToInt32(selectedRow.Cells["userID"].Value.ToString());
                            string POSTdata = "API=" + Properties.Settings.Default.APIkey + "&userID=" + userToDelete;
                            var data = Encoding.UTF8.GetBytes(POSTdata);
                            var request = WebRequest.CreateHttp(Properties.Settings.Default.inUseDomain + "/summaries/api/requestUserDelete.php");
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

                            simpleServerResponse serverResponse;

                            serverResponse = JsonConvert.DeserializeObject<simpleServerResponse>(finalData);

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
                    string workspaceName = functions.HashPW(workspaceBOX.Text);
                    string readMode = readCheckBox.Checked.ToString();
                    string writeMode = writeCheckBox.Checked.ToString();
                    if (addingWorkspace)
                    {
                        string POSTdata = "API=" + Properties.Settings.Default.APIkey;
                        POSTdata += "&name=" + workspaceName + "&readMode=" + readMode + "&writeMode=" + writeMode;
                        var data = Encoding.UTF8.GetBytes(POSTdata);
                        var request = WebRequest.CreateHttp(Properties.Settings.Default.inUseDomain + "/summaries/api/changeWorkspace.php");
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

                        simpleServerResponse serverResponse;
                        serverResponse = JsonConvert.DeserializeObject<simpleServerResponse>(finalData);

                        if (serverResponse.status)
                        {
                            MessageBox.Show("New workspace " + workspaceBOX.Text + " created successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        int selectedWorkwspaceIndex = workspacesDataGrid.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedWorkspaceRow = userDataGrid.Rows[selectedWorkwspaceIndex];
                        int workspaceToUpdate = Convert.ToInt32(selectedWorkspaceRow.Cells["id"].Value.ToString());
                        string POSTdata = "API=" + Properties.Settings.Default.APIkey + "&workspaceID=" + workspaceToUpdate + "&name=" + workspaceBOX.Text + "&readMode=" + readMode + "&writeMode=" + writeMode;
                        var data = Encoding.UTF8.GetBytes(POSTdata);
                        var request = WebRequest.CreateHttp(Properties.Settings.Default.inUseDomain + "/summaries/api/changeWorkspace.php");
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

                        simpleServerResponse serverResponse;
                        serverResponse = JsonConvert.DeserializeObject<simpleServerResponse>(finalData);

                        if (serverResponse.status)
                        {
                            MessageBox.Show("Edited workspace " + workspaceBOX.Text + " successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void administrationTabMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTab = administrationTabMenu.SelectedIndex;
        }

        private void addWorkspaceBTN_Click(object sender, EventArgs e)
        {
            if (addingWorkspace)
            {
                addingWorkspace = false;
                addWorkspaceBTN.Text = "Add Workspace";
                currentSelectedWorkspace = previousSelectedWorkspace;
                workspaceGRPBOX.Text = "Editing Workspace ";
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
                addingWorkspace = true;
                previousSelectedWorkspace = currentSelectedWorkspace;
                currentSelectedWorkspace = 0;
                workspaceBOX.Clear();
                readCheckBox.Checked = true;
                writeCheckBox.Checked = true;
                workspacesDataGrid.Enabled = false;
                flushSummariesBTN.Enabled = false;
                deleteWorkspaceBTN.Enabled = false;
                addWorkspaceBTN.Text = "Cancel";
                workspaceGRPBOX.Text = "Adding Workspace";
            }
        }

        private void workspacesDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (workspacesDataGrid.SelectedRows.Count > 0 || workspacesDataGrid.SelectedCells.Count > 0)
            {
                int selectedWorkwspaceRowIndex = workspacesDataGrid.SelectedCells[0].RowIndex;
                DataGridViewRow selectedWorkspaceRow = workspacesDataGrid.Rows[selectedWorkwspaceRowIndex];
                currentSelectedWorkspace = selectedWorkwspaceRowIndex;
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
                    string POSTdata = "API=" + Properties.Settings.Default.APIkey + "&workspaceID=" + Convert.ToInt32(selectedWorkspaceRow.Cells["id"].Value.ToString());
                    var data = Encoding.UTF8.GetBytes(POSTdata);
                    var request = WebRequest.CreateHttp(Properties.Settings.Default.inUseDomain + "/summaries/api/requestWorkspaceDelete.php");
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

                    simpleServerResponse serverResponse;

                    serverResponse = JsonConvert.DeserializeObject<simpleServerResponse>(finalData);

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
    }
}
