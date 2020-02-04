using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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

        //*********************//

        private List<string> filesToUpload = new List<string>();

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

        serverResponse response;
        workspacesServerResponse workspaces;

        public newSummary(int summaryid = 0)
        {
            // this does not require any workspace parameter because the Properties.Settings.Default.currentWorkspaceID were either loaded on the summaries
            // list window, or will be addressed later on this code
            InitializeComponent();
            summaryID = summaryid;
        }

        private void newSummary_Load(object sender, EventArgs e)
        {
            workspaceComboBox.Items.Clear();
            var functions = new codeResources.functions();
            string jsonWorkspace = "";
            string jsonResponse = "";
            try
            {
                jsonWorkspace = functions.RequestAllWorkspaces();
                workspaces = JsonConvert.DeserializeObject<workspacesServerResponse>(jsonWorkspace);
                jsonResponse = summariesList.summaryListRequest(Properties.Settings.Default.userID);
                response = JsonConvert.DeserializeObject<serverResponse>(jsonResponse);
                

                foreach (workspacesContent content in workspaces.contents)
                {
                    workspaceComboBox.Items.Add(content.name);
                }

                workspaceComboBox.SelectedIndex = 0;

                if (Properties.Settings.Default.currentWorkspaceID == 0)
                {
                    // Workspace not defined yet
                    workspaceComboBox.SelectedIndex = 0;
                }
                else
                {
                    workspaceComboBox.SelectedItem = workspaces.contents[workspaces.contents.FindIndex(c => c.id == Properties.Settings.Default.currentWorkspaceID)].name;
                    List<Content> workspaceRelated = new List<Content>();
                    foreach (Content row in response.contents)
                    {
                        if (row.workspace == Properties.Settings.Default.currentWorkspaceID)
                        {
                            workspaceRelated.Add(row);
                        }
                    }

                    if(workspaceRelated.Count > 0)
                    {
                        summaryNumberBox.Value = workspaceRelated[workspaceRelated.Count - 1].summaryNumber + 1;
                    }
                    else
                    {
                        summaryNumberBox.Value = 1;
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

                    if (isEdit)
                    {
                        this.Text = "Edit Summary";
                        summaryNumberBox.Value = summaryID;
                        dateBox.Value = DateTime.ParseExact(response.contents[summaryID - 1].date, "yyyy-MM-dd", new CultureInfo("pt"));
                        contentsBox.Text = response.contents[summaryID - 1].contents;
                        originalText = functions.HashPW(response.contents[summaryID - 1].contents);
                        originalDate = response.contents[summaryID - 1].date;
                        originalWorkspaceID = response.contents[summaryID - 1].workspace;
                        originalSummaryID = summaryID;
                        dbRow = response.contents[summaryID - 1].id;
                        foreach (var attach in response.contents[summaryID - 1].attachments)
                        {
                            filesToUpload.Add(attach.path);
                        }
                    }
                    else
                    {
                        try
                        {
                            var lastSummary = response.contents[response.contents.Count - 1];
                            summaryNumberBox.Value = lastSummary.summaryNumber + 1;
                        }
                        catch
                        {
                            summaryNumberBox.Value = 1;
                        }

                        dateBox.Value = DateTime.ParseExact(DateTime.Today.ToString("yyyy-MM-dd"), "yyyy-MM-dd", new CultureInfo("pt"));
                    }
                }
                else
                {
                    MessageBox.Show("Error: " + response.errors, "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Critical error. " + ex.Message + "\n" + jsonResponse, "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            if(contentsBox.Text == "" || contentsBox.TextLength < 1 || contentsBox.Text == string.Empty)
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

                    //isInList = response.contents.Exists(x => x.summaryNumber == Convert.ToInt32(summaryNumberBox.Value));
                    //isDateUsed = response.contents.Exists(y => y.date == dateBox.Value.ToString("yyyy-MM-dd"));
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
                    if ((originalText != functions.HashPW(contentsBox.Text)) || (originalDate != dateBox.Value.ToString("yyyy-MM-dd")) || (originalSummaryID != summaryNumberBox.Value))
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
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
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

        /// <summary>
        /// Updates the database with the new information
        /// </summary>
        /// <param name="summaryID">The ID of the summary</param>
        /// <param name="date">The date of the summary</param>
        /// <param name="text">The text of the summary</param>
        /// <param name="dbRowID">(Optional) The row in the database to be updated</param>
        /// <returns></returns>
        private bool UpdateDB(int summaryID, string date, string text, int workspaceID, int dbRowID = 0)
        {
            var functions = new codeResources.functions();
            string POSTdata = "API=" + Properties.Settings.Default.APIkey;
            if(dbRowID > 0)
            {
                POSTdata += "&userID=" + Properties.Settings.Default.userID + "&workspace=" + workspaceID + "&dbrowID=" + dbRowID + "&summaryID=" + summaryID + "&date=" + functions.HashPW(date) + "&contents=" + functions.HashPW(text);
            }
            else
            {
                POSTdata += "&userID=" + Properties.Settings.Default.userID + "&workspace=" + workspaceID + "&summaryID=" + summaryID + "&date=" + functions.HashPW(date) + "&contents=" + functions.HashPW(text);
            }
            var data = Encoding.UTF8.GetBytes(POSTdata);
            var request = WebRequest.CreateHttp(Properties.Settings.Default.inUseDomain + "/summaries/api/summaryUpdateRequest.php");
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
            try
            {
                serverResponse = JsonConvert.DeserializeObject<simpleServerResponse>(jsonResponse);
            }catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "\n " + jsonResponse, "Critital Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            if(!serverResponse.status && (serverResponse.errors != null || serverResponse.errors.Length > 0))
            {
                MessageBox.Show("Error: " + serverResponse.errors + "\n " + jsonResponse, "Critital backend error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return serverResponse.status;
        }

        // Perform the equivalent of posting a form with a filename and two files, in HTML:
        // <form action="{url}" method="post" enctype="multipart/form-data">
        //     <input type="text" name="filename" />
        //     <input type="file" name="file1" />
        //     <input type="file" name="file2" />
        // </form>
        private async Task<Stream> UploadAsync(string url, string filename, Stream fileStream, byte[] fileBytes)
        {
            // Convert each of the three inputs into HttpContent objects

            HttpContent stringContent = new StringContent(filename);
            // examples of converting both Stream and byte [] to HttpContent objects
            // representing input type file
            HttpContent fileStreamContent = new StreamContent(fileStream);
            HttpContent bytesContent = new ByteArrayContent(fileBytes);

            // Submit the form using HttpClient and 
            // create form data as Multipart (enctype="multipart/form-data")

            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                // Add the HttpContent objects to the form data

                // <input type="text" name="filename" />
                formData.Add(stringContent, "filename", "filename");
                // <input type="file" name="file1" />
                formData.Add(fileStreamContent, "file1", "file1");
                // <input type="file" name="file2" />
                formData.Add(bytesContent, "file2", "file2");

                // Invoke the request to the server

                // equivalent to pressing the submit button on
                // a form with attributes (action="{url}" method="post")
                var response = await client.PostAsync(url, formData);

                // ensure the request was a success
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                return await response.Content.ReadAsStreamAsync();
            }
        }

        /// <summary>
        /// Opens a OpenFileDialog screen and sets the file to be uploaded into the array
        /// </summary>
        /// <param name="index">The index where the file will be stored on the one-demensional array</param>
        /// <returns>The name of the file selected by the user</returns>
        private string loadFileFromComputer(int index)
        {
            try
            {
                fileUpload.Multiselect = false;
                fileUpload.Title = "Select files to upload...";
                fileUpload.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                fileUpload.Filter = "Images (*.BMP;*.JPG;*.JPEG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" + "All files (*.*)|*.*";
                fileUpload.CheckFileExists = true;
                fileUpload.CheckPathExists = true;
                fileUpload.FilterIndex = 2;
                fileUpload.RestoreDirectory = true;
                fileUpload.ReadOnlyChecked = true;
                fileUpload.ShowReadOnly = true;

                if (fileUpload.ShowDialog() == DialogResult.OK)
                {
                    //filesToUpload.SetValue(fileUpload.FileName, index);
                    return fileUpload.FileName;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Critial error: " + ex.Message, "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }

        }

        private void selectfileBTN_Click(object sender, EventArgs e)
        {

        }

        private void workspaceComboBox_DropDownClosed(object sender, EventArgs e)
        {
            Properties.Settings.Default.currentWorkspaceID = workspaces.contents[workspaces.contents.FindIndex(x => x.name == workspaceComboBox.SelectedItem.ToString())].id;
            newSummary_Load(sender, e);        
        }
    }
}
