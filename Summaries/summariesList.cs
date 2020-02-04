﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using static Summaries.codeResources.functions;

namespace Summaries
{
    public partial class summariesList : Form
    {
        string workspaceName = null;

        public summariesList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sends a request to the server for the list of summaries, given an userID
        /// </summary>
        /// <param name="userid">The id of the user to get the summaries from</param>
        /// <returns></returns>
        public static string summaryListRequest(int userid, int workspace = 0)
        {
            string finalData = "";
            try
            {
                string POSTdata = "API=" + Properties.Settings.Default.APIkey + "&userid=" + userid + "&workspace=" + workspace;
                var data = Encoding.UTF8.GetBytes(POSTdata);
                var request = WebRequest.CreateHttp(Properties.Settings.Default.inUseDomain + "/summaries/api/summaryListRequest.php");
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
            catch(Exception ex)
            {
                codeResources.functions functions = new codeResources.functions();
                if (!functions.CheckForInternetConnection(Properties.Settings.Default.inUseDomain))
                {
                    MessageBox.Show("Connection to the server lost. Please try again later.", "Connection Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Critical error: " + ex.Message + "\nResponse: " + finalData, "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return string.Empty;
            }
            
        }

        public class Content
        {
            public int id { get; set; }
            public int userid { get; set; }
            public string date { get; set; }
            public int summaryNumber { get; set; }
            public int workspace { get; set; }
            public string contents { get; set; }
        }

        public class serverResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
            public List<Content> contents { get; set; }
        }

        public class workspacesContent
        {
            public int id { get; set; }
            public string name { get; set; }
            public bool read { get; set; }
            public bool write { get; set; }
        }

        public class workspacesServerResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
            public List<workspacesContent> contents { get; set; }
        }


        codeResources.functions functions = new codeResources.functions();

        private void summariesList_Load(object sender, EventArgs e)
        {
            workspacesServerResponse workspaceResponse;
            string jsonResponse = "";
            int workspaceSelectedID = 0;

            try
            {
                jsonResponse = functions.RequestAllWorkspaces();
                workspaceResponse = JsonConvert.DeserializeObject<workspacesServerResponse>(jsonResponse);
                if (workspaceResponse.status)
                {
                    workspaceComboBox.Items.Clear();
                    foreach (workspacesContent row in workspaceResponse.contents)
                    {
                        if (row.read)
                        {
                            workspaceComboBox.Items.Add(row.name);
                        }
                    }

                    if (workspaceName == null || workspaceName == string.Empty || workspaceName == "")
                    {
                        workspaceSelectedID = workspaceResponse.contents[0].id;
                        workspaceName = workspaceResponse.contents[0].name;
                        workspaceComboBox.SelectedItem = workspaceName;
                    }
                    else
                    {
                        workspaceSelectedID = workspaceResponse.contents[workspaceResponse.contents.FindIndex(x => x.name == workspaceName)].id;
                        workspaceComboBox.SelectedItem = workspaceName;
                    }

                    Properties.Settings.Default.currentWorkspaceID = workspaceSelectedID;

                    try
                    {
                        jsonResponse = summaryListRequest(Properties.Settings.Default.userID, workspaceSelectedID);
                        serverResponse response;
                        response = JsonConvert.DeserializeObject<serverResponse>(jsonResponse);

                        if (response.status)
                        {
                            dataGrid.Rows.Clear();
                            dataGrid.Refresh();
                            if (response.contents != null)
                            {
                                dataGrid.ColumnCount = 3;
                                dataGrid.Columns[0].Name = "date";
                                dataGrid.Columns[0].HeaderText = "Date";
                                dataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                dataGrid.Columns[1].Name = "summaryNumber";
                                dataGrid.Columns[1].HeaderText = "#";
                                dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                dataGrid.Columns[2].Name = "contents";
                                dataGrid.Columns[2].HeaderText = "Summary";
                                dataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                                dataGrid.AllowUserToDeleteRows = false;
                                dataGrid.AllowUserToAddRows = false;
                                dataGrid.MultiSelect = false; //just to reinforce

                                var rows = new List<string[]>();
                                foreach (Content content in response.contents)
                                {
                                    string[] row1 = new string[] { content.date.ToString(), content.summaryNumber.ToString(), content.contents.ToString() };
                                    rows.Add(row1);
                                }

                                foreach (string[] rowArray in rows)
                                {
                                    dataGrid.Rows.Add(rowArray);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error: " + response.errors, "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        codeResources.functions functions = new codeResources.functions();
                        if (!functions.CheckForInternetConnection(Properties.Settings.Default.inUseDomain))
                        {
                            MessageBox.Show("Connection to the server lost. Please try again later.", "Connection Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Critical error: " + ex.Message + "\n" + jsonResponse + "\n" + ex.StackTrace, "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("A critical error occurred. " + workspaceResponse.errors, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                codeResources.functions functions = new codeResources.functions();
                if (!functions.CheckForInternetConnection(Properties.Settings.Default.inUseDomain))
                {
                    MessageBox.Show("Connection to the server lost. Please try again later.", "Connection Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Critical error: " + ex.Message + "\n" + jsonResponse + "\n" + ex.StackTrace, "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void deleteSummary_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGrid.SelectedRows.Count > 0 || dataGrid.SelectedCells.Count > 0)
                {
                    DialogResult boxResponse = MessageBox.Show("Are you sure you want to delete the summary?", "Delete a summary", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (boxResponse == DialogResult.Yes)
                    {
                        int selectedrowindex = dataGrid.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedRow = dataGrid.Rows[selectedrowindex];
                        int selectedSummary = Convert.ToInt32(selectedRow.Cells["summaryNumber"].Value);

                        string POSTdata = "API=" + Properties.Settings.Default.APIkey + "&userid=" + Properties.Settings.Default.userID + "&workspace=" + Properties.Settings.Default.currentWorkspaceID + "&summaryID=" + selectedSummary;
                        var data = Encoding.UTF8.GetBytes(POSTdata);
                        var request = WebRequest.CreateHttp(Properties.Settings.Default.inUseDomain + "/summaries/api/summaryDeleteRequest.php");
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

                        string jsonResponse = finalData;

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
                                MessageBox.Show("The row you are trying to remove does not exist in the database! ", "Row does not exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                summariesList_Load(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("Error: " + serverResponse.errors, "Critital Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }catch(Exception ex)
            {
                codeResources.functions functions = new codeResources.functions();
                if (!functions.CheckForInternetConnection(Properties.Settings.Default.inUseDomain))
                {
                    MessageBox.Show("Connection to the server lost. Please try again later.", "Connection Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Critical error: " + ex.Message, "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            catch(Exception ex)
            {
                codeResources.functions functions = new codeResources.functions();
                if (!functions.CheckForInternetConnection(Properties.Settings.Default.inUseDomain))
                {
                    MessageBox.Show("Connection to the server lost. Please try again later.", "Connection Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Critical error: " + ex.Message, "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void addSummary_Click(object sender, EventArgs e)
        {
            codeResources.functions functions = new codeResources.functions();
            if (!functions.CheckForInternetConnection(Properties.Settings.Default.inUseDomain))
            {
                MessageBox.Show("Connection to the server lost. Please try again later.", "Connection Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                newSummary newSummary = new newSummary();
                newSummary.ShowDialog();
                summariesList_Load(sender, e);
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
    }
}
