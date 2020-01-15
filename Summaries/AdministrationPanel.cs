using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using static Summaries.codeResources.functions;

namespace Summaries
{
    public partial class AdministrationPanel : Form
    {

        private int userID;
        private string inUseDomain;

        //***************************//

        private int currentSelectedrow = 0;
        private int previousSelectedrow = 0;
        private bool addingUser = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid">The current userid</param>
        /// <param name="InUseDomain">The domain used to make API calls</param>
        public AdministrationPanel(int userid, string InUseDomain)
        {
            InitializeComponent();
            userID = userid;
            inUseDomain = InUseDomain;
        }

        public class Content
        {
            public int userid { get; set; }
            public string user { get; set; }
            public string displayName { get; set; }
            public string className { get; set; }
            public bool isAdmin { get; set; } = false;
            public bool isDeletionProtected { get; set; } = false;
        }

        public class serverResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
            public List<Content> contents { get; set; }
        }

        public class classContent
        {
            public int classID { get; set; }
            public string className { get; set; }
        }

        public class classServerResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
            public List<classContent> contents { get; set; }
        }

        private void AdministrationPanel_Load(object sender, EventArgs e)
        {
            try
            {
                string jsonResponse = RequestUserList(inUseDomain);
                serverResponse response;
                response = JsonConvert.DeserializeObject<serverResponse>(jsonResponse);
                classServerResponse classServer;
                codeResources.functions funct = new codeResources.functions();
                string classJsonResponse = funct.RequestClassesList(inUseDomain);
                classServer = JsonConvert.DeserializeObject<classServerResponse>(classJsonResponse);



                if (response.status && classServer.status)
                {
                    userDataGrid.Rows.Clear();
                    userDataGrid.Refresh();
                    userDataGrid.ColumnCount = 6;
                    userDataGrid.Columns[0].Name = "userID";
                    userDataGrid.Columns[0].HeaderText = "#";
                    userDataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    userDataGrid.Columns[1].Name = "username";
                    userDataGrid.Columns[1].HeaderText = "Login Name";
                    userDataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    userDataGrid.Columns[2].Name = "displayName";
                    userDataGrid.Columns[2].HeaderText = "Display Name";
                    userDataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    userDataGrid.Columns[3].Name = "class";
                    userDataGrid.Columns[3].HeaderText = "Class";
                    userDataGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    userDataGrid.Columns[4].Name = "isAdmin";
                    userDataGrid.Columns[4].HeaderText = "Admin?";
                    userDataGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    userDataGrid.Columns[5].Name = "isProtected";
                    userDataGrid.Columns[5].HeaderText = "Deletion Protected?";
                    userDataGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    userDataGrid.AllowUserToDeleteRows = false;
                    userDataGrid.AllowUserToAddRows = false;
                    userDataGrid.AllowUserToResizeColumns = true;
                    userDataGrid.MultiSelect = false; //just to reinforce

                    var rows = new List<string[]>();
                    foreach (Content content in response.contents)
                    {
                        string[] row1 = new string[] { content.userid.ToString(), content.user.ToString(), content.displayName.ToString(), content.className.ToString(), content.isAdmin.ToString(), content.isDeletionProtected.ToString() };
                        rows.Add(row1);
                    }

                    foreach (string[] rowArray in rows)
                    {
                        userDataGrid.Rows.Add(rowArray);
                    }

                    DataGridViewRow selectedRow = userDataGrid.Rows[0];
                    usernameBox.Text = selectedRow.Cells["username"].Value.ToString();
                    displayNameBox.Text = selectedRow.Cells["displayName"].Value.ToString();
                    if (selectedRow.Cells["isAdmin"].Value.ToString() == "True")
                    {
                        adminPrivBox.Checked = true;
                    }
                    else
                    {
                        adminPrivBox.Checked = false;
                    }

                    if (selectedRow.Cells["isProtected"].Value.ToString() == "True")
                    {
                        accidentalDeletionBox.Checked = true;
                    }
                    else
                    {
                        accidentalDeletionBox.Checked = false;
                    }

                    resetPWBTN.Enabled = true;
                    deleteUserBTN.Enabled = true;

                    foreach(classContent classContent in classServer.contents)
                    {
                        classBox.Items.Add(classContent.className);
                    }

                }
                else
                {
                    MessageBox.Show("A critical error occurred. " + response.errors, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A critical error occurred. " + ex.Message, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }


        }

        public static string RequestUserList(string inUseDomain)
        {
            string POSTdata = "API=1f984e2ed1545f287fe473c890266fea901efcd63d07967ae6d2f09f4566ddde930923ee9212ea815186b0c11a620a5cc85e";
            var data = Encoding.UTF8.GetBytes(POSTdata);
            var request = WebRequest.CreateHttp(inUseDomain + "/summaries/api/userListRequest.php");
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

        private void userDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (userDataGrid.SelectedRows.Count > 0 || userDataGrid.SelectedCells.Count > 0)
            {
                int selectedrowindex = userDataGrid.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = userDataGrid.Rows[selectedrowindex];
                currentSelectedrow = selectedrowindex;
                usernameBox.Text = selectedRow.Cells["username"].Value.ToString();
                displayNameBox.Text = selectedRow.Cells["displayName"].Value.ToString();
                if (selectedRow.Cells["isAdmin"].Value.ToString() == "True")
                {
                    adminPrivBox.Checked = true;
                }
                else
                {
                    adminPrivBox.Checked = false;
                }

                if (selectedRow.Cells["isProtected"].Value.ToString() == "True")
                {
                    accidentalDeletionBox.Checked = true;
                }
                else
                {
                    accidentalDeletionBox.Checked = false;
                }

                resetPWBTN.Enabled = true;
                deleteUserBTN.Enabled = true;

            }
        }

        private void newUserBTN_Click(object sender, EventArgs e)
        {
            if (addingUser)
            {
                addingUser = false;
                newUserBTN.Text = "Add User";
                currentSelectedrow = previousSelectedrow;
                infoGBox.Text = "Editing User " + userDataGrid.Rows[currentSelectedrow].Cells["displayName"].Value.ToString();
                resetPWBTN.Enabled = true;
                deleteUserBTN.Enabled = true;
                userDataGrid.Enabled = true;
                usernameBox.Text = userDataGrid.Rows[currentSelectedrow].Cells["username"].Value.ToString();
                displayNameBox.Text = userDataGrid.Rows[currentSelectedrow].Cells["displayName"].Value.ToString();
                classBox.SelectedItem = userDataGrid.Rows[currentSelectedrow].Cells["class"].Value.ToString();
                if (userDataGrid.Rows[currentSelectedrow].Cells["isAdmin"].Value.ToString() == "True")
                {
                    adminPrivBox.Checked = true;
                }
                else
                {
                    adminPrivBox.Checked = false;
                }
                if (userDataGrid.Rows[currentSelectedrow].Cells["isProtected"].Value.ToString() == "True")
                {
                    accidentalDeletionBox.Checked = true;
                }
                else
                {
                    accidentalDeletionBox.Checked = false;
                }
            }
            else
            {
                addingUser = true;
                previousSelectedrow = currentSelectedrow;
                currentSelectedrow = 0;
                usernameBox.Clear();
                displayNameBox.Clear();
                classBox.SelectedIndex = 0;
                adminPrivBox.Checked = false;
                accidentalDeletionBox.Checked = false;
                resetPWBTN.Enabled = false;
                deleteUserBTN.Enabled = false;
                userDataGrid.Enabled = false;
                newUserBTN.Text = "Cancel";
                infoGBox.Text = "Adding User";
            }
        }

        private void resetPWBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (!addingUser)
                {
                    if (userDataGrid.SelectedRows.Count > 0 || userDataGrid.SelectedCells.Count > 0)
                    {
                        int selectedrowindex = userDataGrid.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedRow = userDataGrid.Rows[selectedrowindex];
                        int userToReset = Convert.ToInt32(selectedRow.Cells["userID"].Value.ToString());
                        if (userDataGrid.Rows[currentSelectedrow].Cells["isProtected"].Value.ToString() == "True")
                        {
                            MessageBox.Show("Cannot reset this user's password because the account is protected against accidental deletion!", "Protection Against Accidental Deletion Alert!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            string POSTdata = "API=1f984e2ed1545f287fe473c890266fea901efcd63d07967ae6d2f09f4566ddde930923ee9212ea815186b0c11a620a5cc85e";
                            POSTdata += "&userID=" + userToReset + "&reset=true";
                            var data = Encoding.UTF8.GetBytes(POSTdata);
                            var request = WebRequest.CreateHttp(inUseDomain + "/summaries/api/changePassword.php");
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
                            simpleServerResponse serverResponse;
                            serverResponse = JsonConvert.DeserializeObject<simpleServerResponse>(finalData);

                            if (serverResponse.status)
                            {
                                MessageBox.Show("Password Reseted Successfully to \"defaultPW\"!", "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("A critical error occurred. " + serverResponse.errors, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A critical error occurred. " + ex.Message, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (usernameBox.TextLength < 1 || displayNameBox.TextLength < 1)
                {
                    MessageBox.Show("Please fill all the fields before continue.", "Blank fileds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var functions = new codeResources.functions();
                    string username = functions.HashPW(usernameBox.Text);
                    string displayName = functions.HashPW(displayNameBox.Text);
                    string className = functions.HashPW(classBox.SelectedItem.ToString());
                    string isAdmin = adminPrivBox.Checked.ToString();
                    string isDeletionProtected = accidentalDeletionBox.Checked.ToString();
                    if (addingUser)
                    {
                        string POSTdata = "API=1f984e2ed1545f287fe473c890266fea901efcd63d07967ae6d2f09f4566ddde930923ee9212ea815186b0c11a620a5cc85e";
                        POSTdata += "&username=" + username + "&displayName=" + displayName + "&className=" + className + "&admin=" + isAdmin + "&deletionProtection=" + isDeletionProtected;
                        var data = Encoding.UTF8.GetBytes(POSTdata);
                        var request = WebRequest.CreateHttp(inUseDomain + "/summaries/api/changeUser.php");
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

                        simpleServerResponse serverResponse;

                        serverResponse = JsonConvert.DeserializeObject<simpleServerResponse>(finalData);

                        if (serverResponse.status)
                        {
                            MessageBox.Show("New user " + displayNameBox.Text + " created successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            newUserBTN_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("A critical error occurred. " + serverResponse.errors, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                    else
                    {
                        int selectedrowindex = userDataGrid.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedRow = userDataGrid.Rows[selectedrowindex];
                        int userToUpdate = Convert.ToInt32(selectedRow.Cells["userID"].Value.ToString());
                        string POSTdata = "API=1f984e2ed1545f287fe473c890266fea901efcd63d07967ae6d2f09f4566ddde930923ee9212ea815186b0c11a620a5cc85e";
                        POSTdata += "&userID=" + userToUpdate + "&username=" + username + "&displayName=" + displayName + "&className=" + className + "&admin=" + isAdmin + "&deletionProtection=" + isDeletionProtected;
                        var data = Encoding.UTF8.GetBytes(POSTdata);
                        var request = WebRequest.CreateHttp(inUseDomain + "/summaries/api/changeUser.php");
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

                        simpleServerResponse serverResponse;

                        serverResponse = JsonConvert.DeserializeObject<simpleServerResponse>(finalData);

                        if (serverResponse.status)
                        {
                            MessageBox.Show("Edited user " + displayNameBox.Text + " successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("A critical error occurred. " + serverResponse.errors, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }

                    }
                }
                AdministrationPanel_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("A critical error occurred. " + ex.Message, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        private void refreshBTN_Click(object sender, EventArgs e)
        {
            AdministrationPanel_Load(sender, e);
        }

        private void deleteUserBTN_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedrowindex = userDataGrid.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = userDataGrid.Rows[selectedrowindex];
                int userToDelete = Convert.ToInt32(selectedRow.Cells["userID"].Value.ToString());
                string POSTdata = "API=1f984e2ed1545f287fe473c890266fea901efcd63d07967ae6d2f09f4566ddde930923ee9212ea815186b0c11a620a5cc85e";
                POSTdata += "&userID=" + userToDelete;
                var data = Encoding.UTF8.GetBytes(POSTdata);
                var request = WebRequest.CreateHttp(inUseDomain + "/summaries/api/requestUserDelete.php");
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

                simpleServerResponse serverResponse;

                serverResponse = JsonConvert.DeserializeObject<simpleServerResponse>(finalData);

                if (serverResponse.status)
                {
                    MessageBox.Show("User Deleted Successfully!", "User Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AdministrationPanel_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("A critical error occurred. " + serverResponse.errors, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A critical error occurred. " + ex.Message, "Critial Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
