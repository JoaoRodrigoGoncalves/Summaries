﻿using Newtonsoft.Json;
using Summaries.codeResources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;
using static Summaries.codeResources.functions;

namespace Summaries
{
    public partial class newSummary : Form
    {
        private bool isEdit = false;
        private string originalText = null;
        private string originalDate = null;
        private int originalSummaryID = 0;
        private int originalWorkspaceID = 0;
        private int dbRow = 0;
        private int summaryID = 0;
        private int newWorkspaceID = 0;
        string jsonWorkspace = "";
        string jsonResponse = "";
        string jsonSaveResponse = "";
        string savePOSTdata = "API=" + Properties.Settings.Default.APIkey;
        bool shouldAbortLoad = false;
        bool readOnlyMode = false;
        List<String> filesToAdd = new List<string>();
        List<String> filesToRemove = new List<string>();

        //*********************//

        public class Attachments
        {
            public string filename { get; set; }
            public string path { get; set; }
        }

        public class Content
        {
            public int id { get; set; }
            public int userid { get; set; }
            public string date { get; set; }
            public int summaryNumber { get; set; }
            public int workspace { get; set; }
            public string contents { get; set; }
            public List<Attachments> attachments { get; set; }
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

        public class uploadInfo
        {
            public bool status { get; set; }
            public string errors { get; set; }
            public string rowID { get; set; }
        }
        
        serverResponse response;
        workspacesServerResponse workspaces;
        uploadInfo uploadResults;

        public newSummary(int summaryid = 0)
        {
            // this does not require any workspace parameter because the Properties.Settings.Default.currentWorkspaceID were either loaded on the summaries
            // list window, or will be addressed later on this code
            InitializeComponent();
            summaryID = summaryid;
        }

        private void APICalls()
        {
            var functions = new codeResources.functions();
            if (functions.CheckForInternetConnection(Properties.Settings.Default.inUseDomain))
            {
                jsonWorkspace = functions.APIRequest("API=" + Properties.Settings.Default.APIkey, "workspaceListRequest.php");
                workspaces = JsonConvert.DeserializeObject<workspacesServerResponse>(jsonWorkspace);
                string POSTdata = "API=" + Properties.Settings.Default.APIkey + "&userid=" + Properties.Settings.Default.userID + "&workspace=0";
                jsonResponse = functions.APIRequest(POSTdata, "summaryListRequest.php");
            }
            else
            {
                shouldAbortLoad = true;
                MessageBox.Show("Lost connection to ther server. Please try again.", "Connection Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void APISave()
        {
            var functions = new codeResources.functions();
            jsonSaveResponse = functions.APIRequest(savePOSTdata, "summaryUpdateRequest.php");

        }

        private void newSummary_Load(object sender, EventArgs e)
        {
            contentsBox.Focus();
            workspaceComboBox.Items.Clear();
            var functions = new codeResources.functions();
            using(codeResources.loadingForm form = new codeResources.loadingForm(APICalls))
            {
                form.ShowDialog();
            }

            if (shouldAbortLoad)
            {
                this.Close();
            }
            else
            {
                try
                {
                    response = JsonConvert.DeserializeObject<serverResponse>(jsonResponse);

                    if (workspaces.contents == null)
                    {
                        Properties.Settings.Default.currentWorkspaceID = 0;
                        MessageBox.Show("Cannot create summaries because there are no available workspaces!", "No available workspaces", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                    else
                    {
                        foreach (workspacesContent content in workspaces.contents)
                        {
                            if (content.read)
                            {
                                workspaceComboBox.Items.Add(content.name);
                            }
                        }

                        try
                        {

                            if (response.status)
                            {
                                //******* just to reinforce
                                dateBox.CustomFormat = "yyyy-MM-dd";
                                dateBox.Format = DateTimePickerFormat.Custom;
                                //******* just to reinforce
                                if (summaryID != 0)
                                {
                                    isEdit = true;
                                }

                                if (Properties.Settings.Default.currentWorkspaceID == 0)
                                {
                                    // Workspace not defined yet
                                    workspaceComboBox.SelectedIndex = 0;
                                    Properties.Settings.Default.currentWorkspaceID = workspaces.contents[workspaces.contents.FindIndex(z => z.name == workspaceComboBox.Text)].id;
                                }
                                else
                                {
                                    workspaceComboBox.SelectedItem = workspaces.contents[workspaces.contents.FindIndex(c => c.id == Properties.Settings.Default.currentWorkspaceID)].name;
                                }

                                if (isEdit)
                                {
                                    this.Text = "Edit Summary";
                                    summaryNumberBox.Value = summaryID;
                                    dateBox.Value = DateTime.ParseExact(response.contents[response.contents.FindIndex(x => x.summaryNumber == summaryID)].date, "yyyy-MM-dd", new CultureInfo("pt"));
                                    contentsBox.Text = response.contents[response.contents.FindIndex(x => x.summaryNumber == summaryID)].contents;
                                    originalText = functions.Hash(response.contents[response.contents.FindIndex(x => x.summaryNumber == summaryID)].contents);
                                    originalDate = response.contents[response.contents.FindIndex(x => x.summaryNumber == summaryID)].date;
                                    originalWorkspaceID = response.contents[response.contents.FindIndex(x => x.summaryNumber == summaryID)].workspace;
                                    originalSummaryID = summaryID;
                                    dbRow = response.contents[response.contents.FindIndex(x => x.summaryNumber == summaryID)].id;
                                    if (response.contents[response.contents.FindIndex(x => x.summaryNumber == summaryID)].attachments != null)
                                    {
                                        foreach (var attach in response.contents[response.contents.FindIndex(x => x.summaryNumber == summaryID)].attachments)
                                        {
                                            attachmentsGridView.Rows.Add(attach.filename, "Remove");
                                        }
                                    }

                                }
                                else
                                {
                                    if (response.contents != null)
                                    {
                                        List<Content> workspaceRelated = new List<Content>();
                                        foreach (Content row in response.contents)
                                        {
                                            if (row.workspace == Properties.Settings.Default.currentWorkspaceID)
                                            {
                                                workspaceRelated.Add(row);
                                            }
                                        }

                                        if (workspaceRelated.Count > 0)
                                        {
                                            summaryNumberBox.Value = workspaceRelated[workspaceRelated.Count - 1].summaryNumber + 1;
                                        }
                                        else
                                        {
                                            summaryNumberBox.Value = 1;
                                        }
                                    }
                                    else
                                    {
                                        summaryNumberBox.Value = 1;
                                    }

                                    dateBox.Value = DateTime.ParseExact(DateTime.Today.ToString("yyyy-MM-dd"), "yyyy-MM-dd", new CultureInfo("pt"));
                                }

                                if (!workspaces.contents[workspaces.contents.FindIndex(x => x.id == Properties.Settings.Default.currentWorkspaceID)].write)
                                {
                                    readOnlyMode = true;
                                    workspaceComboBox.Enabled = false;
                                    summaryNumberBox.Enabled = false;
                                    dateBox.Enabled = false;
                                    contentsBox.ReadOnly = true;
                                    addAttachmentBTN.Enabled = false;
                                    saveBTN.Enabled = false;
                                }

                            }
                            else
                            {
                                MessageBox.Show("Error: " + response.errors, "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Critical error. " + ex.Message + "\n" + ex.StackTrace + "\n" + jsonResponse, "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                }
                catch (Exception ex)
                {
                    if (!functions.CheckForInternetConnection(Properties.Settings.Default.inUseDomain))
                    {
                        MessageBox.Show("Connection to the server lost. Please try again later.", "Connection Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Critical error: " + ex.Message + "\n" + jsonWorkspace + "\n" + ex.StackTrace + "\n" + ex.InnerException, "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            if(contentsBox.Text == "" || contentsBox.TextLength < 1 || contentsBox.Text == string.Empty || filesToAdd.Count < 1 || filesToRemove.Count < 1)
            {
                this.Close();
            }

            bool shouldAbort = false;
            if (!isEdit)
            {
                bool isInList = false;
                bool isDateUsed = false;
                try
                {
                    //checks if summary number is in use on this workspace
                    foreach(Content content in response.contents)
                    {
                        if (content.workspace == workspaces.contents[workspaces.contents.FindIndex(x => x.name == workspaceComboBox.SelectedItem.ToString())].id)
                        {
                            if (content.summaryNumber == Convert.ToInt32(summaryNumberBox.Value))
                            {
                                isInList = true;
                            }

                            if (content.date == dateBox.Value.ToString("yyyy-MM-dd"))
                            {
                                isDateUsed = true;
                            }
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    isInList = false;
                }
                

                if (isInList)
                {
                    var result = MessageBox.Show("The Summary Number given is already registered. Do you wish to overwrite it?", "Summary Number already registered", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(result == DialogResult.Yes)
                    {
                        isEdit = true;
                        dbRow = response.contents[Convert.ToInt32(summaryNumberBox.Value) - 1].id;
                    }
                    else
                    {
                        shouldAbort = true;
                    }
                }

                if (isDateUsed && !shouldAbort)
                {
                    var res = MessageBox.Show("The Selected date has already a summary registered. Do you wish to overwrite it?", "Selected date already registered", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(res == DialogResult.Yes)
                    {
                        isEdit = true;
                        dbRow = response.contents[response.contents.FindIndex(w => w.date == dateBox.Value.ToString("yyyy-MM-dd"))].id;
                    }
                    else
                    {
                        shouldAbort = true;
                    }
                }

            }

            var functions = new codeResources.functions();

            if (!shouldAbort)
            {
                if (isEdit)
                {
                    if ((originalText != functions.Hash(contentsBox.Text)) || (originalDate != dateBox.Value.ToString("yyyy-MM-dd")) || (originalSummaryID != summaryNumberBox.Value) || filesToAdd.Count > 0 || filesToRemove.Count > 0)
                    {
                        if(filesToAdd.Count > 0 || filesToRemove.Count > 0) // Checks if there are files to add or remove
                        {
                            if(filesToAdd.Count > 0)
                            {
                                List<string> filesToAdopt = new List<string>();
                                filesToAdopt = UploadFiles(filesToAdd);
                                if (filesToAdopt != null && filesToAdopt.Count > 0)
                                {
                                    // Here it saves the basic info about the current summary and uploads the files to the server
                                    if (UpdateDB(Convert.ToInt32(summaryNumberBox.Value), dateBox.Value.ToString("yyyy-MM-dd"), contentsBox.Text, workspaces.contents[workspaces.contents.FindIndex(x => x.name == workspaceComboBox.SelectedItem.ToString())].id, dbRow, filesToAdopt, filesToRemove))
                                    {
                                        MessageBox.Show("Summary saved successfully!", "Summaries", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("An error occurred while trying to save the summary.", "Error while saving the summary", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("An error occurred while trying to upload the files.", "Error while uploading files", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                // Here it saves the basic info about the current summary and uploads the files to the server
                                if (UpdateDB(Convert.ToInt32(summaryNumberBox.Value), dateBox.Value.ToString("yyyy-MM-dd"), contentsBox.Text, workspaces.contents[workspaces.contents.FindIndex(x => x.name == workspaceComboBox.SelectedItem.ToString())].id, dbRow, null, filesToRemove))
                                {
                                    MessageBox.Show("Summary saved successfully!", "Summaries", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("An error occurred while trying to save the summary.", "Error while saving the summary", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else // There isn't any kind of file operation to be performed
                        {
                            if (UpdateDB(Convert.ToInt32(summaryNumberBox.Value), dateBox.Value.ToString("yyyy-MM-dd"), contentsBox.Text, workspaces.contents[workspaces.contents.FindIndex(x => x.name == workspaceComboBox.SelectedItem.ToString())].id, dbRow))
                            {
                                MessageBox.Show("Changes saved successfully!", "Summaries", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("An error occurred while trying to save the summary.", "Error while saving the summary", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {

                    // This is a new summary

                    if(filesToAdd.Count > 0) // Cheks if there are files to add
                    {
                        List<string> filesToAdopt = new List<string>();
                        filesToAdopt = UploadFiles(filesToAdd);
                        if (filesToAdopt != null && filesToAdopt.Count > 0)
                        {
                            // Here it saves the basic info about the current summary and uploads the files to the server
                            if (UpdateDB(Convert.ToInt32(summaryNumberBox.Value), dateBox.Value.ToString("yyyy-MM-dd"), contentsBox.Text, workspaces.contents[workspaces.contents.FindIndex(x => x.name == workspaceComboBox.SelectedItem.ToString())].id, 0, filesToAdopt))
                            {
                                MessageBox.Show("Summary saved successfully!", "Summaries", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("An error occurred while trying to save the summary.", "Error while saving the summary", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while trying to upload the files.", "Error while uploading files", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // Here it saves the basic info about the current summary and uploads the files to the server
                        if (UpdateDB(Convert.ToInt32(summaryNumberBox.Value), dateBox.Value.ToString("yyyy-MM-dd"), contentsBox.Text, workspaces.contents[workspaces.contents.FindIndex(x => x.name == workspaceComboBox.SelectedItem.ToString())].id))
                        {
                            MessageBox.Show("Summary saved successfully!", "Summaries", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while trying to save the summary.", "Error while saving the summary", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    
                    
                }
            }
        }

        /// <summary>
        /// Updates the database with the new information
        /// </summary>
        /// <param name="summaryID">The ID of the summary</param>
        /// <param name="date">The date of the summary</param>
        /// <param name="text">The text of the summary</param>
        /// <param name="workspaceID">The ID of the workspace</param>
        /// <param name="dbRowID">(Optional) The row in the database to be updated</param>
        /// <param name="filesToAdopt">(Optional) The list of files to be adopted</param>
        /// <param name="filesToRemove">(Optional) The list of files to be removed</param>
        /// <returns></returns>
        private bool UpdateDB(int summaryID, string date, string text, int workspaceID, int dbRowID = 0, List<string> filesToAdopt = null, List<string> filesToRemove = null)
        {
            var functions = new codeResources.functions();
            string filesLoad = "";

            if(filesToAdopt != null)
            {
                filesLoad = "&filesToAdopt=" + functions.Hash(JsonConvert.SerializeObject(filesToAdopt));
            }

            if(filesToRemove != null)
            {
                filesLoad += "&filesToRemove=" + functions.Hash(JsonConvert.SerializeObject(filesToRemove));
            }

            if(dbRowID > 0)
            {
                savePOSTdata += "&operation=edit" + "&userID=" + Properties.Settings.Default.userID + "&workspace=" + workspaceID + "&dbrowID=" + dbRowID + "&summaryID=" + summaryID + "&date=" + functions.Hash(date) + "&contents=" + functions.Hash(text) + filesLoad ;
            }
            else
            {
                savePOSTdata += "&operation=new" + "&userID=" + Properties.Settings.Default.userID + "&workspace=" + workspaceID + "&summaryID=" + summaryID + "&date=" + functions.Hash(date) + "&contents=" + functions.Hash(text) + filesLoad;
            }

            using (codeResources.loadingForm loadForm = new codeResources.loadingForm(APISave)) {
                loadForm.ShowDialog();
            }

            simpleServerResponse serverResponse;
            try
            {
                serverResponse = JsonConvert.DeserializeObject<simpleServerResponse>(jsonSaveResponse);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "\n " + jsonSaveResponse, "Critital Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            if(!serverResponse.status && (serverResponse.errors != null || serverResponse.errors.Length > 0))
            {
                MessageBox.Show("Error: " + serverResponse.errors, "Critital backend error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return serverResponse.status;
        }

        /// <summary>
        /// Upload the specified files and adopts them
        /// </summary>
        /// <see cref="https://stackoverflow.com/questions/10237983/upload-to-php-server-from-c-sharp-client-application"/>
        /// <param name="files">List of files to upload</param>
        /// <param name="summaryID">Current Summary ID</param>
        /// <returns>List of files to be adopted</returns>
        private List<string> UploadFiles(List<String> filesToUpload)
        {
            List<string> filesToAdopt = new List<string>();
            foreach(string currentFile in filesToUpload)
            {
                WebClient Client = new WebClient();
                Client.Headers.Add("User-Agent", "app");
                Client.Headers.Add("Content-Type", "binary/octet-stream");
                Client.Headers.Add("API", Properties.Settings.Default.APIkey);
                byte[] result = Client.UploadFile(Properties.Settings.Default.inUseDomain + "/summaries/api/summaryUploadFile.php", "POST", currentFile);

                string response = System.Text.Encoding.UTF8.GetString(result, 0, result.Length);
                uploadResults = JsonConvert.DeserializeObject<uploadInfo>(response);

                if (uploadResults.status)
                {
                    filesToAdopt.Add(uploadResults.rowID);
                }
                else
                {
                    MessageBox.Show("Error: " + uploadResults.errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            return filesToAdopt;
        }

        private void workspaceComboBox_DropDownClosed(object sender, EventArgs e)
        {
            newWorkspaceID = workspaces.contents[workspaces.contents.FindIndex(x => x.name == workspaceComboBox.SelectedItem.ToString())].id;
            if (newWorkspaceID != Properties.Settings.Default.currentWorkspaceID)
            {
                Properties.Settings.Default.currentWorkspaceID = newWorkspaceID;
                newSummary_Load(sender, e);
            }
        }

        private void newSummary_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void newSummary_DragDrop(object sender, DragEventArgs e)
        {
            addToFileTable((string[])e.Data.GetData(DataFormats.FileDrop));
        }

        /// <summary>
        /// Adds files to the table
        /// </summary>
        /// <param name="files">Files to be added</param>
        private void addToFileTable(string[] files)
        {
            if (!readOnlyMode)
            {
                foreach (var file in files)
                {
                    if (!string.IsNullOrEmpty(file))
                    {
                        string fileName = file.Split('\\')[file.Split('\\').Length - 1];
                        if (filesToAdd.Exists(x => x.Split('\\')[x.Split('\\').Length -1] == fileName))
                        {
                            MessageBox.Show("This file name already exists. Please rename the file and try again.", "File Already Loaded", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            try
                            {
                                if(response.contents[response.contents.FindIndex(x => x.summaryNumber == summaryID)].attachments.Exists(x => x.filename == fileName))
                                {
                                    MessageBox.Show("This file name already exists. Please rename the file and try again.", "File Already Loaded", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    filesToAdd.Add(file);
                                    attachmentsGridView.Rows.Add(fileName, "Remove");
                                }
                            }
                            catch
                            {
                                filesToAdd.Add(file);
                                attachmentsGridView.Rows.Add(fileName, "Remove");
                            }
                        }
                    }
                }
            }
        }

        private void attachmentsGridView_DragEnter(object sender, DragEventArgs e)
        {
            newSummary_DragEnter(sender, e);
        }

        private void attachmentsGridView_DragDrop(object sender, DragEventArgs e)
        {
            newSummary_DragDrop(sender, e);
        }

        private void attachmentsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // https://stackoverflow.com/questions/3577297/how-to-handle-click-event-in-button-column-in-datagridview

                var senderGrid = (DataGridView)sender;
                bool done = false;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    string fileName = attachmentsGridView.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                    DialogResult response = MessageBox.Show("Are you sure you want to remove " + fileName + "?", "Remove File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if(response == DialogResult.Yes)
                    {
                        // Checks if he file is in the filesToAdd list. If the file is in there, it means that it was added just now and it is not on the server
                        // If the file is not there, it means that the file is already on the server and has to be removed from there
                        foreach(var file in filesToAdd)
                        {
                            if (file.Split('\\')[file.Split('\\').Length - 1] == fileName)
                            {
                                filesToAdd.Remove(file);
                                done = true;
                                break;
                            }
                        }
                        if (!done)
                        {
                            filesToRemove.Add(fileName);
                        }
                        attachmentsGridView.Rows.RemoveAt(e.RowIndex);
                    }
                }
                else
                {
                    if(e.ColumnIndex == 0 && e.RowIndex >= 0)
                    {
                        // https://stackoverflow.com/questions/525364/how-to-download-a-file-from-a-website-in-c-sharp

                        try
                        {
                            string cell = senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                            bool inServer = true;
                            
                            foreach(var file in filesToAdd)
                            {
                                if(file.Split('\\')[file.Split('\\').Length -1] == cell)
                                {
                                    inServer = false;
                                    break;
                                }
                            }

                            if (inServer)
                            {
                                string fileExtension = cell.Substring(cell.Length - cell.Split('.')[cell.Split('.').Length - 1].Length);
                                string finalPath = Path.GetTempPath() + "~summariestemp" + Path.GetRandomFileName().Replace('.', 'a') + "." + fileExtension;

                                string inServerPath = response.contents[response.contents.FindIndex(x => x.summaryNumber == summaryID)].attachments.Find(x => x.filename == cell).path;
                                string inServerName = inServerPath.Split('\\')[inServerPath.Split('\\').Length - 1];

                                WebClient client = new WebClient();
                                client.Headers.Add("API", Properties.Settings.Default.APIkey);
                                client.Headers.Add("FILE", inServerName);
                                client.DownloadFile(Properties.Settings.Default.inUseDomain + "/summaries/api/getFile.php", @"" + finalPath);

                                Process.Start(@"" + finalPath);
                            }
                            else
                            {
                                int index = filesToAdd.FindIndex(x => x.Contains(cell)); // finds the full path of the specifeid file. Returns an index to be used below
                                Process.Start(@"" + filesToAdd[index]);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Could not open file: " + ex.Message + "\n" + ex.InnerException, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch { }
        }

        private void addAttachmentBTN_Click(object sender, EventArgs e)
        {
            DialogResult result;
            fileUpload.FileName = "";
            result = fileUpload.ShowDialog();
            addToFileTable(fileUpload.FileNames);
        }
    }
}
