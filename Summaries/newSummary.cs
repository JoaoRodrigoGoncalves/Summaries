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
        private int dbRow = 0;
        private int summaryID = 0;

        //*********************//

        private string[] filesToUpload = null;

        public class Content
        {
            public int id { get; set; }
            public int userid { get; set; }
            public string date { get; set; }
            public int summaryNumber { get; set; }
            public string contents { get; set; }
        }

        public class serverResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
            public List<Content> contents { get; set; }
        }

        serverResponse response;

        public newSummary(int summaryid = 0)
        {
            InitializeComponent();
            summaryID = summaryid;
        }

        private void newSummary_Load(object sender, EventArgs e)
        {
            var functions = new codeResources.functions();
            string jsonResponse = summariesList.summaryListRequest(Properties.Settings.Default.userID);

            response = JsonConvert.DeserializeObject<serverResponse>(jsonResponse);
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
                    originalSummaryID = summaryID;
                    dbRow = response.contents[summaryID - 1].id;
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
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            if(contentsBox.Text == "" || contentsBox.TextLength < 1)
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
                    isInList = response.contents.Exists(x => x.summaryNumber == Convert.ToInt32(summaryNumberBox.Value));
                    isDateUsed = response.contents.Exists(y => y.date == dateBox.Value.ToString("yyyy-MM-dd"));
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
                        if (UpdateDB(Convert.ToInt32(summaryNumberBox.Value), dateBox.Value.ToString("yyyy-MM-dd"), contentsBox.Text, dbRow))
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
                    if (UpdateDB(Convert.ToInt32(summaryNumberBox.Value), dateBox.Value.ToString("yyyy-MM-dd"), contentsBox.Text))
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
        private bool UpdateDB(int summaryID, string date, string text, int dbRowID = 0)
        {
            var functions = new codeResources.functions();
            string POSTdata = "API=" + Properties.Settings.Default.APIkey;
            if(dbRowID > 0)
            {
                POSTdata += "&userID=" + Properties.Settings.Default.userID + "&dbrowID=" + dbRowID + "&summaryID=" + summaryID + "&date=" + functions.HashPW(date) + "&contents=" + functions.HashPW(text);
            }
            else
            {
                POSTdata += "&userID=" + Properties.Settings.Default.userID + "&summaryID=" + summaryID + "&date=" + functions.HashPW(date) + "&contents=" + functions.HashPW(text);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramString"></param>
        /// <param name="paramFileStream"></param>
        /// <param name="paramFileBytes"></param>
        /// <returns></returns>
        private async Task<Stream> Upload(string paramString, Stream paramFileStream, byte[] paramFileBytes)
        {
            HttpContent stringContent = new StringContent(paramString);
            HttpContent fileStreamContent = new StreamContent(paramFileStream);
            HttpContent bytesContent = new ByteArrayContent(paramFileBytes);
            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(stringContent, "param1", "param1");
                formData.Add(fileStreamContent, "file1", "file1");
                formData.Add(bytesContent, "file2", "file2");
                var response = await client.PostAsync(Properties.Settings.Default.inUseDomain + "/summaries/api/summaryUpdateRequest.php", formData);
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
                    filesToUpload.SetValue(fileUpload.FileName, index);
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

        private void selectFile_Click(object sender, EventArgs e)
        {
            fileBox.Text = loadFileFromComputer(0);
            removeFile.Visible = true;
            removeFile.Enabled = true;
        }

        private void selectFile2_Click(object sender, EventArgs e)
        {
            fileBox2.Text = loadFileFromComputer(1);
            removeFile2.Visible = true;
            removeFile2.Enabled = true;
        }

        private void selectFile3_Click(object sender, EventArgs e)
        {
            fileBox3.Text = loadFileFromComputer(2);
            removeFile3.Visible = true;
            removeFile3.Enabled = true;
        }

        private void removeFile_Click(object sender, EventArgs e)
        {
            filesToUpload.SetValue(string.Empty, 0);
            fileBox.Text = string.Empty;
            removeFile.Enabled = false;
            removeFile.Visible = false;
        }

        private void removeFile2_Click(object sender, EventArgs e)
        {
            filesToUpload.SetValue(string.Empty, 1);
            fileBox2.Text = string.Empty;
            removeFile2.Enabled = false;
            removeFile2.Visible = false;
        }

        private void removeFile3_Click(object sender, EventArgs e)
        {
            filesToUpload.SetValue(string.Empty, 2);
            fileBox3.Text = string.Empty;
            removeFile3.Enabled = false;
            removeFile3.Visible = false;
        }

        private void fileBox_MouseClick(object sender, MouseEventArgs e)
        {
            //
        }

        private void fileBox2_MouseClick(object sender, MouseEventArgs e)
        {
            //
        }

        private void fileBox3_MouseClick(object sender, MouseEventArgs e)
        {
            //
        }

        private void fileBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            fileBox_MouseClick(sender, e);
        }

        private void fileBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            fileBox2_MouseClick(sender, e);
        }

        private void fileBox3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            fileBox3_MouseClick(sender, e);
        }
    }
}
