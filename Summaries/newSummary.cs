using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Summaries
{
    public partial class newSummary : Form
    {

        private int userID;
        private bool isEdit = false;
        private string originalText = null;
        private string originalDate = null;
        private int originalSummaryID = 0;
        private int dbRow = 0;
        private int summaryID = 0;

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

        /// <summary>
        /// Main function for the newSummary form.
        /// </summary>
        /// <param name="id">UserID</param>
        /// <param name="summaryid">(Optional) ID of the summary to be edited.</param>
        public newSummary(int id, int summaryid = 0)
        {
            InitializeComponent();
            userID = id;
            summaryID = summaryid;
        }

        private void newSummary_Load(object sender, EventArgs e)
        {
            string jsonResponse = summariesList.summaryListRequest(userID);
            
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
                    originalText = Convert.ToBase64String(Encoding.UTF8.GetBytes(response.contents[summaryID - 1].contents));
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
                try
                {
                    isInList = response.contents.Exists(x => x.summaryNumber == Convert.ToInt32(summaryNumberBox.Value));
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
            }

            if (isEdit && !shouldAbort)
            {
                if ((originalText != Convert.ToBase64String(Encoding.UTF8.GetBytes(contentsBox.Text))) || (originalDate != dateBox.Value.ToString("yyyy-MM-dd")) || (originalSummaryID != summaryNumberBox.Value))
                {
                    if(UpdateDB(Convert.ToInt32(summaryNumberBox.Value), dateBox.Value.ToString("yyyy-MM-dd"), contentsBox.Text, dbRow))
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

        private class simpleServerResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
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
            string POSTdata = null;
            if(dbRowID > 0)
            {
                POSTdata = "userID=" + userID + "&dbrowID=" + dbRowID + "&summaryID=" + summaryID + "&date=" + Convert.ToBase64String(Encoding.UTF8.GetBytes(date)) + "&contents=" + Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
            }
            else
            {
                POSTdata = "userID=" + userID + "&summaryID=" + summaryID + "&date=" + Convert.ToBase64String(Encoding.UTF8.GetBytes(date)) + "&contents=" + Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
            }
            var data = Encoding.UTF8.GetBytes(POSTdata);
            var request = WebRequest.CreateHttp("https://joaogoncalves.myftp.org/restricted/api/summaryUpdateRequest.php");
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
    }
}
