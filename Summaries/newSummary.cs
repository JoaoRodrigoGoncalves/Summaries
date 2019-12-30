using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
            serverResponse response;
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
                    var lastSummary = response.contents[response.contents.Count - 1];
                    summaryNumberBox.Value = lastSummary.summaryNumber + 1;

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
            if (isEdit)
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

            return true;
        }
    }
}
