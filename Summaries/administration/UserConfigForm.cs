using Newtonsoft.Json;
using Summaries.codeResources;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static Summaries.codeResources.functions;

namespace Summaries.administration
{
    public partial class UserConfigForm : Form
    {

        codeResources.functions functions = new codeResources.functions();
        int sentUserID = 0;
        int? classID_g;
        string request = null;
        string allUsersRequest = null;
        string classRequest = null;
        string craftData = null;
        string saveRequest = null;
        string workspacesInfo = null;
        bool changesHandled = false;

        usersServerResponse response;
        usersServerResponse allUsersList;
        classesServerResponse classResponse;
        simpleServerResponse saveResponse;
        workspacesDataResponse workspaceDataResponse;

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

        public class workspacesDataResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
            public List<workspacesData> contents { get; set; }
        }

        public class workspacesData
        {
            public int workspace_ID { get; set; }
            public string workspace_Name { get; set; }
            public int hours_Completed { get; set; }
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
            workspacesInfo = functions.APIRequest("GET", null, "user/" + sentUserID + "/signedupWorkspaces");
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

        private void GetAllUsers()
        {
            allUsersRequest = functions.APIRequest("GET", null, "user");
        }

        private void UserConfigForm_Load(object sender, EventArgs e)
        {

            using (loadingForm loading = new loadingForm(GetAllUsers))
            {
                loading.ShowDialog();
            }

            allUsersList = JsonConvert.DeserializeObject<usersServerResponse>(allUsersRequest);

            if (allUsersList.status)
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
                                MessageBox.Show(GlobalStrings.GotMoreThanOneEntry, GlobalStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Close();
                            }
                            else
                            {
                                classResponse = JsonConvert.DeserializeObject<classesServerResponse>(classRequest);

                                if (classResponse.status)
                                {

                                    // General tab

                                    usersContent user = response.contents[0];

                                    foreach (var x in classResponse.contents)
                                    {
                                        classCB.Items.Add(x.className);
                                    }

                                    this.Text = String.Format(UserConfigFormStrings.FormTitle, user.displayName);

                                    UsernameTOPBox.Text = user.displayName;
                                    displayNameTB.Text = user.displayName;
                                    loginNameTB.Text = user.user;

                                    classCB.SelectedItem = classResponse.contents[classResponse.contents.FindIndex(x => x.classID == user.classID)].className;
                                    classID_g = user.classID;

                                    isAdminCheck.Checked = user.isAdmin;
                                    isDeletionProtectedCheck.Checked = user.isDeletionProtected;

                                    // Workspaces tab

                                    workspacesDataGrid.Rows.Clear();
                                    workspacesDataGrid.Columns.Clear();
                                    workspacesDataGrid.AutoGenerateColumns = false;
                                    workspacesDataGrid.Refresh();
                                    workspacesDataGrid.ColumnCount = 3;
                                    workspacesDataGrid.Columns[0].Name = "workspaceID";
                                    workspacesDataGrid.Columns[0].HeaderText = "#";
                                    workspacesDataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                    workspacesDataGrid.Columns[1].Name = "workspaceName";
                                    workspacesDataGrid.Columns[1].HeaderText = UserConfigFormStrings.WorkspaceTab_Name;
                                    workspacesDataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                                    workspacesDataGrid.Columns[2].Name = "hours";
                                    workspacesDataGrid.Columns[2].HeaderText = GenerateReportStrings.HoursWorked;
                                    workspacesDataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                    workspacesDataGrid.MultiSelect = false;

                                    try
                                    {
                                        workspaceDataResponse = JsonConvert.DeserializeObject<workspacesDataResponse>(workspacesInfo);
                                        if (workspaceDataResponse.status)
                                        {
                                            if(workspaceDataResponse.contents == null)
                                            {
                                                workspacesDataGrid.Enabled = false;
                                                workspacesDataGrid.BackgroundColor = SystemColors.InactiveCaption;
                                                noDataLabel.Visible = true;
                                            }
                                            else
                                            {
                                                foreach(workspacesData data in workspaceDataResponse.contents)
                                                {
                                                    string[] row = new string[] { data.workspace_ID.ToString(), data.workspace_Name.ToString(), data.hours_Completed.ToString() };
                                                    workspacesDataGrid.Rows.Add(row);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show(GlobalStrings.Error + ":" + workspaceDataResponse.errors, GlobalStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    catch(Exception wex)
                                    {
                                        MessageBox.Show(wex.Message + "\n" + wex.StackTrace, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(GlobalStrings.Error + ": " + classResponse.errors, GlobalStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        Console.WriteLine(workspacesInfo);
                        MessageBox.Show("Response: " + response + "\n" +
                            "Request:" + request + "\n" +
                            "Error: " + ex.Message + "\n" +
                            "Stack: " + ex.StackTrace, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                    }
                }
                else
                {
                    this.Text = UserConfigFormStrings.NewUserProperties;
                    UsernameTOPBox.Text = UserConfigFormStrings.NewUser;
                    workspacesPage.Enabled = false;
                    workspacesDataGrid.BackgroundColor = SystemColors.InactiveCaption;
                    noDataLabel.Visible = true;

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
                        MessageBox.Show(GlobalStrings.Error + ": " + classResponse.errors, GlobalStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                    }
                }
            }
            else
            {
                MessageBox.Show(GlobalStrings.Error + ": " + allUsersList.errors, GlobalStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
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
                errorProvider.SetError(loginNameTB, GlobalStrings.MandatoryField);
                return true;
            }

            if (string.IsNullOrEmpty(displayNameTB.Text) || string.IsNullOrWhiteSpace(displayNameTB.Text))
            {
                errorProvider.SetIconPadding(displayNameTB, -20);
                errorProvider.SetError(displayNameTB, GlobalStrings.MandatoryField);
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
                if (!allUsersList.contents.Exists(x => x.user == loginNameTB.Text && x.userid != sentUserID))
                {
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
                                    MessageBox.Show(GlobalStrings.Error + ": " + saveResponse.errors, GlobalStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                MessageBox.Show(GlobalStrings.Error + ": " + saveResponse.errors, GlobalStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                else
                {
                    MessageBox.Show(UserConfigFormStrings.LoginNameInUse, UserConfigFormStrings.LoginNameInUseShort, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if (MessageBox.Show(UserConfigFormStrings.UnsavedChangesQuestion, GlobalStrings.UnsavedChanges, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            okBTN_Click(sender, e);
                        }
                    }
                }
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void workspacesDataGrid_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                var hit = workspacesDataGrid.HitTest(e.X, e.Y);
                workspacesDataGrid.ClearSelection();
                workspacesDataGrid.Rows[hit.RowIndex].Selected = true;
                if (e.Button == MouseButtons.Right)
                {
                    int selectedRowIndex = workspacesDataGrid.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = workspacesDataGrid.Rows[selectedRowIndex];

                    ContextMenuStrip strip = new ContextMenuStrip();
                    strip.Items.Add(UserConfigFormStrings.WorkspaceTab_ExportUserReport, Properties.Resources.export, ExportUserReport);
                    strip.Show(workspacesDataGrid, new Point(e.X, e.Y));
                }
            }
            catch { }
        }

        private void ExportUserReport(object sender, EventArgs e)
        {
            int selectedRowIndex = workspacesDataGrid.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = workspacesDataGrid.Rows[selectedRowIndex];
            int workspaceID = int.Parse(selectedRow.Cells["workspaceID"].Value.ToString());
            codeResources.ExportSummary.ExportSummaryForm export = new codeResources.ExportSummary.ExportSummaryForm(sentUserID, classID_g, workspaceID);
            export.ShowDialog();
        }
    }
}
