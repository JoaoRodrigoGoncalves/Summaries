using Newtonsoft.Json;
using Summaries.codeResources;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static Summaries.codeResources.functions;

namespace Summaries
{
    public partial class summariesList : Form
    {
        string workspaceName = null;
        Local_Storage storage = Local_Storage.Retrieve;

        public summariesList()
        {
            InitializeComponent();
        }

        public class Content
        {
            public int ID { get; set; }
            public int userID { get; set; }
            public string date { get; set; }
            public int summaryNumber { get; set; }
            public int workspaceID { get; set; }
            public string bodyText { get; set; }
            public int dayHours { get; set; }
        }

        public class serverResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
            public List<Content> contents { get; set; }
        }

        serverResponse response = null;
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
            public List<hoursContent> hours { get; set; }
        }

        public class hoursContent
        {
            public int id { get; set; }
            public int workspaceID { get; set; }
            public int classID { get; set; }
            public int totalHours { get; set; }
        }

        functions functions = new functions();
        workspacesServerResponse workspaceResponse;
        bool shouldAbort = false;
        int workspaceSelectedID = 0;

        string jsonResponse = "";

        private void requestWorkpaceList()
        {
            var functions = new functions();
            if (functions.CheckForInternetConnection(storage.inUseDomain))
            {
                jsonResponse = functions.APIRequest("GET", null, "workspace");
            }
            else
            {
                shouldAbort = true;
                MessageBox.Show(GlobalStrings.ConnectionToServerLost, GlobalStrings.ConnectionLost, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void requestSummaryList()
        {
            var functions = new functions();
            if (functions.CheckForInternetConnection(storage.inUseDomain))
            {
                jsonResponse = functions.APIRequest("GET", null, "user/" + storage.userID + "/workspace/" + storage.currentWorkspaceID + "/summary");
            }
            else
            {
                shouldAbort = true;
                MessageBox.Show(GlobalStrings.ConnectionToServerLost, GlobalStrings.ConnectionLost, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void summariesList_Load(object sender, EventArgs e)
        {
            summarizedHoursHolder.Text = "0"; // must set it to 0 here otherwise, if the workspace is clear, the number of summarized hours will be the last loaded one
            // Requests the Workspace list, showing the loading screen to the user
            using (loadingForm form = new loadingForm(requestWorkpaceList))
            {
                form.ShowDialog();
            }

            if (shouldAbort)
            {
                this.Close();
            }
            else
            {
                try
                {
                    workspaceResponse = JsonConvert.DeserializeObject<workspacesServerResponse>(jsonResponse);
                    if (workspaceResponse.status)
                    {
                        if (workspaceResponse.contents == null)
                        {
                            storage.currentWorkspaceID = 0;
                            MessageBox.Show(summariesListStrings.NoAvailableWorkspacesLong, summariesListStrings.NoAvailableWorkspaces, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                        else
                        {
                            workspaceComboBox.Items.Clear();
                            foreach (workspacesContent row in workspaceResponse.contents)
                            {
                                if (row.hours != null)
                                {
                                    if (row.read && row.hours.Exists(x => x.classID == storage.classID))
                                    {
                                        workspaceComboBox.Items.Add(row.workspaceName);
                                    }
                                }
                            }

                            int totalWorkspaceHours = 0;

                            if (workspaceName == null || workspaceName == string.Empty || workspaceName == "")
                            {
                                int index = workspaceResponse.contents.FindIndex(x => x.read == true && x.hours.Exists(c => c.classID == storage.classID));
                                workspaceSelectedID = workspaceResponse.contents[index].id;
                                workspaceName = workspaceResponse.contents[index].workspaceName;
                                workspaceComboBox.SelectedItem = workspaceName;
                                totalWorkspaceHours = workspaceResponse.contents[index].hours[workspaceResponse.contents[index].hours.FindIndex(x => x.classID == storage.classID)].totalHours;
                                totalHoursHolder.Text = totalWorkspaceHours.ToString();
                            }
                            else
                            {
                                int workspaceIndex = workspaceResponse.contents.FindIndex(x => x.workspaceName == workspaceName);
                                workspaceSelectedID = workspaceResponse.contents[workspaceIndex].id;
                                totalWorkspaceHours = workspaceResponse.contents[workspaceIndex].hours[workspaceResponse.contents[workspaceIndex].hours.FindIndex(x => x.classID == storage.classID)].totalHours;
                                totalHoursHolder.Text = totalWorkspaceHours.ToString();
                                workspaceComboBox.SelectedItem = workspaceName;
                            }

                            storage.currentWorkspaceID = workspaceSelectedID;

                            try
                            {
                                using (loadingForm form = new loadingForm(requestSummaryList))
                                {
                                    form.ShowDialog();
                                }

                                response = JsonConvert.DeserializeObject<serverResponse>(jsonResponse);

                                if (response.status)
                                {
                                    int summarizedHours = 0;
                                    dataGrid.Rows.Clear();
                                    dataGrid.Refresh();
                                    if (response.contents != null)
                                    {
                                        dataGrid.ColumnCount = 3;
                                        dataGrid.Columns[0].Name = "date";
                                        dataGrid.Columns[0].HeaderText = summariesListStrings.Date;
                                        dataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                        dataGrid.Columns[1].Name = "summaryNumber";
                                        dataGrid.Columns[1].HeaderText = "#";
                                        dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                        dataGrid.Columns[2].Name = "contents";
                                        dataGrid.Columns[2].HeaderText = summariesListStrings.Summary;
                                        dataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                                        dataGrid.AllowUserToDeleteRows = false;
                                        dataGrid.AllowUserToAddRows = false;
                                        dataGrid.MultiSelect = false; //just to reinforce

                                        var rows = new List<string[]>();
                                        foreach (Content content in response.contents)
                                        {
                                            string[] row1 = new string[] { content.date.ToString(), content.summaryNumber.ToString(), content.bodyText.ToString() };
                                            summarizedHours += content.dayHours;
                                            rows.Add(row1);
                                        }

                                        foreach (string[] rowArray in rows)
                                        {
                                            dataGrid.Rows.Add(rowArray);
                                        }
                                        dataGrid.Sort(this.dataGrid.Columns[0], Properties.Settings.Default.summaryOrderDate);
                                        decimal daysLeft = 0;
                                        daysLeft = (totalWorkspaceHours - summarizedHours) / 7;
                                        summarizedHoursHolder.Text = summarizedHours.ToString() + " (" + daysLeft + " " + GlobalStrings.Days + ")";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(GlobalStrings.Error + ": " + response.errors, GlobalStrings.CriticalError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                functions functions = new functions();
                                if (!functions.CheckForInternetConnection(storage.inUseDomain))
                                {
                                    MessageBox.Show(GlobalStrings.ConnectionToServerLost, GlobalStrings.ConnectionLost, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show(GlobalStrings.CriticalError + ": " + ex.Message + "\n" + jsonResponse + "\n" + ex.StackTrace, GlobalStrings.CriticalError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(GlobalStrings.Error + ": " + workspaceResponse.errors, GlobalStrings.CriticalError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    functions functions = new functions();
                    if (!functions.CheckForInternetConnection(storage.inUseDomain))
                    {
                        MessageBox.Show(GlobalStrings.ConnectionToServerLost, GlobalStrings.ConnectionLost, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(GlobalStrings.Error + ": " + ex.Message + "\n" + jsonResponse + "\n" + ex.StackTrace, GlobalStrings.CriticalError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void deleteSummary_Click(object sender, EventArgs e)
        {
            if (workspaceResponse.contents[workspaceResponse.contents.FindIndex(x => x.workspaceName == workspaceName)].write)
            {
                try
                {
                    if (dataGrid.SelectedRows.Count > 0 || dataGrid.SelectedCells.Count > 0)
                    {
                        DialogResult boxResponse = MessageBox.Show(summariesListStrings.DeleteSummaryQuestion, summariesListStrings.DeleteSummary, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (boxResponse == DialogResult.Yes)
                        {
                            int selectedrowindex = dataGrid.SelectedCells[0].RowIndex;
                            DataGridViewRow selectedRow = dataGrid.Rows[selectedrowindex];
                            int selectedSummary = Convert.ToInt32(selectedRow.Cells["summaryNumber"].Value);

                            string jsonResponse = functions.APIRequest("DELETE", null, "user/" + storage.userID + "/summary/" + response.contents[response.contents.FindIndex(x => x.summaryNumber == selectedSummary && x.workspaceID == storage.currentWorkspaceID)].ID);

                            simpleServerResponse serverResponse;

                            serverResponse = JsonConvert.DeserializeObject<simpleServerResponse>(jsonResponse);

                            if (serverResponse.status)
                            {
                                summariesList_Load(sender, e);
                            }
                            else
                            {
                                if (serverResponse.errors == null || serverResponse.errors.Length < 1)
                                {
                                    MessageBox.Show(summariesListStrings.RowNotExistLong, summariesListStrings.RowDoesNotExist, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    summariesList_Load(sender, e);
                                }
                                else
                                {
                                    MessageBox.Show(GlobalStrings.Error + ": " + serverResponse.errors + "\n" + jsonResponse, GlobalStrings.CriticalError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    functions functions = new functions();
                    if (!functions.CheckForInternetConnection(storage.inUseDomain))
                    {
                        MessageBox.Show(GlobalStrings.ConnectionToServerLost, GlobalStrings.ConnectionLost, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(GlobalStrings.Error + ": " + ex.Message + "\n" + ex.StackTrace + "\n" + ex.Source, GlobalStrings.CriticalError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(summariesListStrings.ReadOnlyWorkspace, summariesListStrings.ReadOnly, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void editSummary_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGrid.SelectedRows.Count > 0 || dataGrid.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataGrid.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGrid.Rows[selectedrowindex];
                    int selectedSummary = Convert.ToInt32(selectedRow.Cells["summaryNumber"].Value);

                    newSummary editSummary = new newSummary(selectedSummary);
                    editSummary.ShowDialog();
                    summariesList_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                functions functions = new functions();
                if (!functions.CheckForInternetConnection(storage.inUseDomain))
                {
                    MessageBox.Show(GlobalStrings.ConnectionToServerLost, GlobalStrings.ConnectionLost, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(GlobalStrings.Error + ": " + ex.Message, GlobalStrings.CriticalError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void addSummary_Click(object sender, EventArgs e)
        {
            if (workspaceResponse.contents[workspaceResponse.contents.FindIndex(x => x.workspaceName == workspaceName)].write)
            {
                functions functions = new functions();
                if (!functions.CheckForInternetConnection(storage.inUseDomain))
                {
                    MessageBox.Show(GlobalStrings.ConnectionToServerLost, GlobalStrings.ConnectionLost, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    newSummary newSummary = new newSummary();
                    newSummary.ShowDialog();
                    summariesList_Load(sender, e);
                }
            }
            else
            {
                MessageBox.Show(summariesListStrings.ReadOnlyWorkspace, summariesListStrings.ReadOnly, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void refreshList_Click(object sender, EventArgs e)
        {
            summariesList_Load(sender, e);
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editSummary_Click(sender, e);
        }

        private void workspaceComboBox_DropDownClosed(object sender, EventArgs e)
        {
            workspaceName = workspaceComboBox.SelectedItem.ToString();
            summariesList_Load(sender, e);
        }

        private void exportWorkspace_Click(object sender, EventArgs e)
        {
            codeResources.ExportSummary.ExportSummaryForm export = new codeResources.ExportSummary.ExportSummaryForm();
            export.ShowDialog();
        }

        private void dataGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(Properties.Settings.Default.summaryOrderDate == System.ComponentModel.ListSortDirection.Ascending)
            {
                Properties.Settings.Default.summaryOrderDate = System.ComponentModel.ListSortDirection.Descending;
                Properties.Settings.Default.Save();
                dataGrid.Sort(this.dataGrid.Columns[0], System.ComponentModel.ListSortDirection.Descending);
            }
            else
            {
                Properties.Settings.Default.summaryOrderDate = System.ComponentModel.ListSortDirection.Ascending;
                Properties.Settings.Default.Save();
                dataGrid.Sort(this.dataGrid.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
            }
        }
    }
}