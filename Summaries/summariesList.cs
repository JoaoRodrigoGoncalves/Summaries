using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Summaries
{
    public partial class summariesList : Form
    {

        private int userID;

        public summariesList(int id)
        {
            InitializeComponent();
            userID = id;
        }

        /// <summary>
        /// Sends a request to the server for the list of summaries, given an userID
        /// </summary>
        /// <param name="userid">The id of the user to get the summaries from</param>
        /// <returns></returns>
        public static string summaryListRequest(int userid)
        {
            string POSTdata = "userid=" + userid;
            var data = Encoding.UTF8.GetBytes(POSTdata);
            var request = WebRequest.CreateHttp("https://joaogoncalves.myftp.org/restricted/api/summaryListRequest.php");
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

        private void summariesList_Load(object sender, EventArgs e)
        {
            string jsonResponse = summaryListRequest(userID);
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

        private class simpleServerResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
        }

        private void deleteSummary_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count > 0 || dataGrid.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGrid.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGrid.Rows[selectedrowindex];
                int selectedSummary = Convert.ToInt32(selectedRow.Cells["summaryNumber"].Value);

                string POSTdata = "userid=" + userID + "&summaryID=" + selectedSummary;
                var data = Encoding.UTF8.GetBytes(POSTdata);
                var request = WebRequest.CreateHttp("https://joaogoncalves.myftp.org/restricted/api/summaryDeleteRequest.php");
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
                    if(serverResponse.errors == null || serverResponse.errors.Length < 1)
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

        private void editSummary_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count > 0 || dataGrid.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGrid.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGrid.Rows[selectedrowindex];
                int selectedSummary = Convert.ToInt32(selectedRow.Cells["summaryNumber"].Value);

                newSummary editSummary = new newSummary(userID, selectedSummary);
                editSummary.ShowDialog();
                summariesList_Load(sender, e);
            }
        }

        private void addSummary_Click(object sender, EventArgs e)
        {
            newSummary newSummary = new newSummary(userID);
            newSummary.ShowDialog();
            summariesList_Load(sender, e);
        }

        private void refreshList_Click(object sender, EventArgs e)
        {

            summariesList_Load(sender, e);
        }
    }
}
