using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static Summaries.codeResources.functions;

namespace Summaries.administration
{
    public partial class AdministrationMenu : Form
    {
        codeResources.functions functions = new codeResources.functions();
        
        public AdministrationMenu()
        {
            InitializeComponent();
        }

        public class usersServerResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
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

        public class workspacesServerResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
            public List<workspacesContent> contents { get; set; }
        }

        public class workspacesContent
        {
            public int id { get; set; }
            public string workspaceName { get; set; }
            public bool read { get; set; }
            public bool write { get; set; }
            public int totalSummaries { get; set; }
        }

        ContextMenuStrip usersMenu = new ContextMenuStrip();
        ContextMenuStrip classesMenu = new ContextMenuStrip();
        ContextMenuStrip workspacesMenu = new ContextMenuStrip();
        List<String[]> usersArray = new List<string[]>();
        List<String[]> classesArray = new List<string[]>();
        List<String[]> workspacesArray = new List<string[]>();
        TreeNode currentSelectedNode;
        string objectType = null; // Dynamically changes to "User", "Class" or "Workspace" when the user clicks on a node
        codeResources.Local_Storage storage = codeResources.Local_Storage.Retrieve;

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (treeView1.SelectedNode.Tag)
            {
                case "usersNode":
                    currentSelectedNode = treeView1.SelectedNode;
                    objectType = "User";
                    GetUsers();
                    treeView1.SelectedNode.Expand();
                    break;

                case "classesNode":
                    currentSelectedNode = treeView1.SelectedNode;
                    objectType = "Class";
                    GetClasses();
                    treeView1.SelectedNode.Expand();
                    break;

                case "workspacesNode":
                    currentSelectedNode = treeView1.SelectedNode;
                    objectType = "Workspace";
                    GetWorkspaces();
                    treeView1.SelectedNode.Expand();
                    break;

                default:
                    if (treeView1.SelectedNode.Name.Contains("class-"))
                    {
                        // The "class-" name is part of the groups presented under the Users node
                        currentSelectedNode = treeView1.SelectedNode.Parent;
                        objectType = "User";
                        GetUsers(false, int.Parse(treeView1.SelectedNode.Tag.ToString()));
                    }
                    break;
            }
        }

        private void GetUsers(bool refresh = false, int classID = -1)
        {
            if(usersArray.Count == 0 || refresh)
            {
                usersArray.Clear();
                var usersConvert = JsonConvert.DeserializeObject<usersServerResponse>(functions.APIRequest("GET", null, "user"));
                if (usersConvert.status)
                {
                    treeView1.Nodes[0].Nodes[0].Nodes.Clear();
                    GetClasses(true);
                    foreach (usersContent content in usersConvert.contents)
                    {
                        string[] row1 = new string[] { content.userid.ToString(), content.user.ToString(), content.displayName.ToString(), classesArray[classesArray.FindIndex(x => x[0] == content.classID.ToString())][1].ToString(), content.isAdmin.ToString(), content.isDeletionProtected.ToString() };
                        usersArray.Add(row1);
                    }
                    foreach(var Class in classesArray)
                    {
                        treeView1.Nodes[0].Nodes[0].Nodes.Add("class-" + Class[1], "(" + Class[2] + ") " + Class[1], "group.png", "group.png").Tag = Class[0];
                    }
                }
                else
                {
                    MessageBox.Show("Something went wrong: " + usersConvert.errors, "Error");
                    return;
                }
            }
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Refresh();
            dataGridView.ColumnCount = 4; // Setting this to 4 instead of 6 fixes the issue where 2 extra blank columns would appear at the end
            dataGridView.Columns[0].Name = "userID";
            dataGridView.Columns[0].HeaderText = "#";
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns[1].Name = "username";
            dataGridView.Columns[1].HeaderText = "Login Name";
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns[2].Name = "displayName";
            dataGridView.Columns[2].HeaderText = "Display Name";
            dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns[3].Name = "class";
            dataGridView.Columns[3].HeaderText = "Class";
            dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            // ** Admin column **
            DataGridViewCheckBoxColumn column4 = new DataGridViewCheckBoxColumn();
            column4.Name = "isAdmin";
            column4.HeaderText = "Admin?";
            column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            column4.FlatStyle = FlatStyle.Standard;
            column4.ThreeState = false;
            column4.CellTemplate = new DataGridViewCheckBoxCell();
            dataGridView.Columns.Insert(4, column4);
            // ** Protection Column **
            DataGridViewCheckBoxColumn column5 = new DataGridViewCheckBoxColumn();
            column5.Name = "isProtected";
            column5.HeaderText = "Deletion Protected?";
            column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            column5.FlatStyle = FlatStyle.Standard;
            column5.ThreeState = false;
            column5.CellTemplate = new DataGridViewCheckBoxCell();
            dataGridView.Columns.Insert(5, column5);
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToResizeColumns = true;
            dataGridView.MultiSelect = false;

            foreach (string[] rowArray in usersArray)
            {
                if(classID > -1)
                {
                    // Check if class name on rowArray is the same as the class pointed by classID
                    if(rowArray[3] == classesArray[classesArray.FindIndex(x => x[0] == classID.ToString())][1])
                    {
                        dataGridView.Rows.Add(rowArray);
                    }
                }
                else
                {
                    dataGridView.Rows.Add(rowArray);
                }
            }
        }

        private void GetClasses(bool refresh = false)
        {
            if(classesArray.Count == 0 || refresh)
            {
                classesArray.Clear();
                var classesConvert = JsonConvert.DeserializeObject<classesServerResponse>(functions.APIRequest("GET", null, "class"));
                if (classesConvert.status)
                {
                    treeView1.Nodes[0].Nodes[1].Nodes.Clear();
                    foreach (classesContent content in classesConvert.contents)
                    {
                        string[] row1 = new string[] { content.classID.ToString(), content.className.ToString(), content.totalUsers.ToString() };
                        classesArray.Add(row1);
                    }
                }
                else
                {
                    MessageBox.Show("Something went wrong: " + classesConvert.errors, "Error");
                    return;
                }
            }
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            dataGridView.ColumnCount = 3;
            dataGridView.Columns[0].Name = "classID";
            dataGridView.Columns[0].HeaderText = "#";
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns[1].Name = "className";
            dataGridView.Columns[1].HeaderText = "Class Name";
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns[2].Name = "registeredUsers";
            dataGridView.Columns[2].HeaderText = "Total of Registered Users";
            dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToResizeColumns = true;
            dataGridView.MultiSelect = false;

            foreach (string[] rowArray in classesArray)
            {
                dataGridView.Rows.Add(rowArray);
            }
        }

        private void GetWorkspaces(bool refresh = false)
        {
            if(workspacesArray.Count == 0 || refresh)
            {
                workspacesArray.Clear();
                var workspacesConvert = JsonConvert.DeserializeObject<workspacesServerResponse>(functions.APIRequest("GET", null, "workspace"));
                if (workspacesConvert.status)
                {
                    treeView1.Nodes[0].Nodes[2].Nodes.Clear();
                    foreach (workspacesContent content in workspacesConvert.contents)
                    {
                        string[] row1 = new string[] { content.id.ToString(), content.workspaceName.ToString(), content.read.ToString(), content.write.ToString(), content.totalSummaries.ToString() };
                        workspacesArray.Add(row1);
                    }
                }
                else
                {
                    MessageBox.Show("Something went wrong: " + workspacesConvert.errors, "Error");
                    return;
                }
            }
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            dataGridView.ColumnCount = 3; // Setting this to 3 instead of 5 fixes the issue where 2 extra blank columns would appear at the end
            dataGridView.Columns[0].Name = "workspaceID";
            dataGridView.Columns[0].HeaderText = "#";
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns[1].Name = "workspaceName";
            dataGridView.Columns[1].HeaderText = "Name";
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            // ** Read Column **
            DataGridViewCheckBoxColumn column2 = new DataGridViewCheckBoxColumn();
            column2.Name = "readMode";
            column2.HeaderText = "Read?";
            column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            column2.FlatStyle = FlatStyle.Standard;
            column2.ThreeState = false;
            column2.CellTemplate = new DataGridViewCheckBoxCell();
            dataGridView.Columns.Insert(2, column2);
            // ** Write Column **
            DataGridViewCheckBoxColumn column3 = new DataGridViewCheckBoxColumn();
            column3.Name = "readMode";
            column3.HeaderText = "Read?";
            column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            column3.FlatStyle = FlatStyle.Standard;
            column3.ThreeState = false;
            column3.CellTemplate = new DataGridViewCheckBoxCell();
            dataGridView.Columns.Insert(3, column3);
            dataGridView.Columns[4].Name = "savedSummaries";
            dataGridView.Columns[4].HeaderText = "Registered Summaries";
            dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToResizeColumns = true;
            dataGridView.MultiSelect = false;

            foreach (string[] rowArray in workspacesArray)
            {
                dataGridView.Rows.Add(rowArray);
            }
        }

        private void AdministrationMenu_Load(object sender, EventArgs e)
        {
            treeView1.Nodes[0].Expand();
            treeView1.Nodes[0].Nodes[0].ContextMenuStrip = usersMenu;
            treeView1.Nodes[0].Nodes[1].ContextMenuStrip = classesMenu;
            treeView1.Nodes[0].Nodes[2].ContextMenuStrip = workspacesMenu;
            usersMenu.Items.Add("Refresh", null, refreshUsers_ContextEvent);
            classesMenu.Items.Add("Refresh", null, refreshClasses_ContextEvent);
            workspacesMenu.Items.Add("Refresh", null, refreshWorkspaces_ContextEvent);
        }

        private void refreshUsers_ContextEvent(object sender, EventArgs e)
        {
            treeView1.SelectedNode = treeView1.Nodes[0].Nodes[0];
            GetUsers(true);
        }

        private void refreshClasses_ContextEvent(object sender, EventArgs e)
        {
            treeView1.SelectedNode = treeView1.Nodes[0].Nodes[1];
            GetClasses(true);
        }

        private void refreshWorkspaces_ContextEvent(object sender, EventArgs e)
        {
            treeView1.SelectedNode = treeView1.Nodes[0].Nodes[2];
            GetWorkspaces(true);
        }

        private void DeleteEntry_ContextEvent(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView.Rows[selectedRowIndex];
            switch (currentSelectedNode.Tag)
            {
                #region usersNode
                case "usersNode":
                    int userID = int.Parse(selectedRow.Cells["userID"].Value.ToString());
                    if(usersArray[usersArray.FindIndex(x => x[0] == userID.ToString())][5] == "True")
                    {
                        MessageBox.Show("Can't delete user \"" + selectedRow.Cells["displayName"].Value.ToString() + "\" because it is protected against accidental deletion");
                    }
                    else
                    {
                        if(MessageBox.Show("Are you sure you want to delete \"" + selectedRow.Cells["displayName"].Value.ToString() + "\"?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            simpleServerResponse userDeleteRequest = null;
                            string response = null;
                            try
                            {
                                response = functions.APIRequest("DELETE", null, "user/" + userID);
                                userDeleteRequest = JsonConvert.DeserializeObject<simpleServerResponse>(response);
                                if (userDeleteRequest.status)
                                {
                                    dataGridView.ClearSelection();
                                    dataGridView.Rows.Remove(selectedRow);
                                    MessageBox.Show("Success!", "Operation Completed Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    GetUsers(true);
                                }
                                else
                                {
                                    MessageBox.Show("Error: " + userDeleteRequest.errors + "\n" + userDeleteRequest.ErrorCode, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show("Request: " + userDeleteRequest + "\n" +
                                    "Response: " + response + "\n" + 
                                    "Exception: " + ex.Message + "\n" +
                                    "Stack: " + ex.StackTrace, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    break;
                #endregion

                #region classesNode
                case "classesNode":
                    if (MessageBox.Show("Are you sure you want to delete \"" + selectedRow.Cells["className"].Value.ToString() + "\" class?", "Delete Class", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int classID = int.Parse(selectedRow.Cells["classID"].Value.ToString());
                        simpleServerResponse classDeleteRequest = null;
                        string response = null;
                        try
                        {
                            response = functions.APIRequest("DELETE", null, "class/" + classID);
                            classDeleteRequest = JsonConvert.DeserializeObject<simpleServerResponse>(response);

                            if (classDeleteRequest.status)
                            {
                                dataGridView.ClearSelection();
                                dataGridView.Rows.Remove(selectedRow);
                                MessageBox.Show("Success!", "Operation Completed Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                GetUsers(true);
                            }
                            else
                            {
                                MessageBox.Show("Error: " + classDeleteRequest.errors + "\nError Code: " + classDeleteRequest.ErrorCode, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Response: " + response + "\n" +
                                "Error: " + ex.Message + "\n" +
                                "Stack: " + ex.StackTrace, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
                #endregion

                #region workspacesNode
                case "workspacesNode":
                    if (MessageBox.Show("Are you sure you want to delete the workspace \"" + selectedRow.Cells["workspaceName"].Value.ToString() + "\"?", "Delete Workspace", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int workspaceID = int.Parse(selectedRow.Cells["workspaceID"].Value.ToString());
                        simpleServerResponse workspaceDeleteRequest = null;
                        string response = null;
                        try
                        {
                            response = functions.APIRequest("DELETE", null, "workspace/" + workspaceID);
                            workspaceDeleteRequest = JsonConvert.DeserializeObject<simpleServerResponse>(response);

                            if (workspaceDeleteRequest.status)
                            {
                                dataGridView.ClearSelection();
                                dataGridView.Rows.Remove(selectedRow);
                                MessageBox.Show("Success!", "Operation Completed Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                GetWorkspaces(true);
                            }
                            else
                            {
                                MessageBox.Show("Error: " + workspaceDeleteRequest.errors + "\nError Code: " + workspaceDeleteRequest.ErrorCode, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Response: " + response + "\n" +
                                "Error: " + ex.Message + "\n" +
                                "Stack: " + ex.StackTrace, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
                #endregion

                default:
                    break;
            }
        }

        private void EditEntry_ContextEvent(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView.Rows[selectedRowIndex];
            switch (currentSelectedNode.Tag)
            {
                case "usersNode":
                    int userID = int.Parse(selectedRow.Cells["userID"].Value.ToString());
                    UserConfigForm userForm = new UserConfigForm(userID);
                    userForm.ShowDialog();
                    GetUsers(true);
                    break;

                case "classesNode":
                    int classID = int.Parse(selectedRow.Cells["classID"].Value.ToString());
                    ClassConfigForm classForm = new ClassConfigForm(classID);
                    classForm.ShowDialog();
                    GetClasses(true);
                    break;

                case "workspacesNode":
                    int workspaceID = int.Parse(selectedRow.Cells["workspaceID"].Value.ToString());
                    WorkspaceConfigForm workspaceForm = new WorkspaceConfigForm(workspaceID);
                    workspaceForm.ShowDialog();
                    GetWorkspaces(true);
                    break;

                default:
                    break;
            }
        }

        private void AddNew_ContextEvent(object sender, EventArgs e)
        {
            switch (currentSelectedNode.Tag)
            {
                case "usersNode":
                    UserConfigForm userForm = new UserConfigForm();
                    userForm.ShowDialog();
                    GetUsers(true);
                    break;
                case "classesNode":
                    ClassConfigForm classForm = new ClassConfigForm();
                    classForm.ShowDialog();
                    GetClasses(true);
                    break;

                case "workspacesNode":
                    WorkspaceConfigForm workspaceForm = new WorkspaceConfigForm();
                    workspaceForm.ShowDialog();
                    GetWorkspaces(true);
                    break;

                default:
                    break;
            }
        }

        private void FlushWorkspace_ContextEvent(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView.Rows[selectedRowIndex];
            int workspaceID = int.Parse(selectedRow.Cells["workspaceID"].Value.ToString());

            codeResources.confirmByTyping flushConfirmForm = new codeResources.confirmByTyping(workspacesArray[workspacesArray.FindIndex(x => x[0] == workspaceID.ToString())][1]);
            flushConfirmForm.ShowDialog();

            if (storage.typeTestSuccessfull)
            {
                storage.typeTestSuccessfull = false;
                string flushRequest = null;
                simpleServerResponse flushResponse = null;

                try
                {
                    flushRequest = functions.APIRequest("DELETE", null, "workspace/" + workspaceID + "/flush");
                    flushResponse = JsonConvert.DeserializeObject<simpleServerResponse>(flushRequest);

                    if (flushResponse.status)
                    {
                        GetWorkspaces(true);
                    }
                    else
                    {
                        MessageBox.Show("Error: " + flushResponse.errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Request: " + flushRequest + "\n" +
                        "Response: " + flushResponse + "\n" +
                        "Error: " + ex.Message + "\n" +
                        "Stack: " + ex.StackTrace, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MoveUserToClass_ContextEvent(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            int clickedClassID = int.Parse(clickedItem.Tag.ToString());

            int selectedRowIndex = dataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView.Rows[selectedRowIndex];
            int userID = int.Parse(selectedRow.Cells["userID"].Value.ToString());

            int arrayIndex = usersArray.FindIndex(x => x[0] == userID.ToString());

            simpleServerResponse moveUserRequest = null;
            string response = null;
            string craftData = "username=" + usersArray[arrayIndex][1] + 
                "&displayName=" + usersArray[arrayIndex][2] +
                "&classID=" + clickedClassID +
                "&isAdmin=" + usersArray[arrayIndex][4] +
                "&isDeletionProtected=" + usersArray[arrayIndex][5];
            try
            {
                response = functions.APIRequest("PUT", craftData, "user/" + userID);
                moveUserRequest = JsonConvert.DeserializeObject<simpleServerResponse>(response);

                if (moveUserRequest.status)
                {
                    GetUsers(true);
                }
                else
                {
                    MessageBox.Show("Error: " + moveUserRequest.errors + "\nError Code: " + moveUserRequest.ErrorCode, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Request: " + moveUserRequest + "\n" +
                                "Response: " + response + "\n" +
                                "Exception: " + ex.Message + "\n" +
                                "Stack: " + ex.StackTrace, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* Adapted from: https://stackoverflow.com/questions/3035144/right-click-to-select-a-row-in-a-datagridview-and-show-a-menu-to-delete-it
         * It works way better if we use the MouseClick instead of the MouseDown event
         */
        private void dataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                var hit = dataGridView.HitTest(e.X, e.Y);
                dataGridView.ClearSelection();
                dataGridView.Rows[hit.RowIndex].Selected = true;
                if (e.Button == MouseButtons.Right)
                {
                    int selectedRowIndex = dataGridView.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView.Rows[selectedRowIndex];

                    ContextMenuStrip strip = new ContextMenuStrip();
                    strip.Items.Add("Add New " + objectType, Properties.Resources.addSummary, AddNew_ContextEvent);
                    if (objectType == "Class" && int.Parse(selectedRow.Cells[0].Value.ToString()) == 0)
                    {
                        strip.Show(dataGridView, new Point(e.X, e.Y));
                    }
                    else
                    {
                        strip.Items.Add("-");
                        if(objectType == "User")
                        {
                        
                            int thisUserClassID = int.Parse(classesArray[classesArray.FindIndex(x => x[1] == selectedRow.Cells["class"].Value.ToString())][0]);

                            strip.Items.Add("Move User to...");
                            ContextMenuStrip moveToClass = new ContextMenuStrip();
                            foreach(var x in classesArray)
                            {
                                if(int.Parse(x[0]) != thisUserClassID)
                                {
                                    ToolStripItem current = (strip.Items[2] as ToolStripMenuItem).DropDownItems.Add(x[1], Properties.Resources.group, MoveUserToClass_ContextEvent);
                                    current.Tag = x[0]; // sets the tag as the classID
                                }
                                else
                                {
                                    ToolStripItem current = (strip.Items[2] as ToolStripMenuItem).DropDownItems.Add(x[1], Properties.Resources.group);
                                    current.Enabled = false;
                                }
                            }
                        }
                        strip.Items.Add("Edit " + objectType, Properties.Resources.newSummary, EditEntry_ContextEvent);
                        if(objectType == "Workspace")
                        {
                            strip.Items.Add("Flush Workspace", Properties.Resources.flushWorkspace, FlushWorkspace_ContextEvent);
                        }
                        strip.Items.Add("Delete " + objectType, Properties.Resources.deleteSummary, DeleteEntry_ContextEvent);
                        strip.Show(dataGridView, new Point(e.X, e.Y));
                    }
                }
            }
            catch { }
        }
    }
}
