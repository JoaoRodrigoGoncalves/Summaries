using Newtonsoft.Json;
using Summaries.codeResources;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static Summaries.codeResources.functions;

namespace Summaries.administration
{
    public partial class WorkspaceConfigForm : Form
    {

        codeResources.functions functions = new codeResources.functions();
        int sentWorkspaceID = 0;
        string workspaceRequest = null;
        string craftData = null;
        string saveRequest = null;
        bool changesHandled = false;

        simpleServerResponse saveResponse;
        workspacesServerResponse workspaceResponse;
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

        public WorkspaceConfigForm(int workspaceID = 0)
        {
            InitializeComponent();
            sentWorkspaceID = workspaceID;
        }

        private void RequestWorkspaceData()
        {
            workspaceRequest = functions.APIRequest("GET", null, "workspace/" + sentWorkspaceID);
        }

        private void CreateNewWorkspace()
        {
            saveRequest = functions.APIRequest("POST", craftData, "workspace");
        }

        private void UpdateWorkspaceData()
        {
            saveRequest = functions.APIRequest("PUT", craftData, "workspace/" + sentWorkspaceID);
        }

        private void WorkspaceConfigForm_Load(object sender, EventArgs e)
        {
            if (sentWorkspaceID != 0)
            {

                using (loadingForm loading = new loadingForm(RequestWorkspaceData))
                {
                    loading.ShowDialog();
                }

                try
                {
                    workspaceResponse = JsonConvert.DeserializeObject<workspacesServerResponse>(workspaceRequest);

                    if (workspaceResponse.status)
                    {
                        if (workspaceResponse.contents.Count != 1)
                        {
                            MessageBox.Show("More than one entry received", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Close();
                        }
                        else
                        {
                            this.Text = "\"" + workspaceResponse.contents[0].workspaceName + "\" Properties";
                            WorkspaceNameTOPBox.Text = workspaceResponse.contents[0].workspaceName;
                            workspaceNameTB.Text = workspaceResponse.contents[0].workspaceName;

                            readCheck.Checked = workspaceResponse.contents[0].read;
                            writeCheck.Checked = workspaceResponse.contents[0].write;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: " + workspaceResponse.errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Response: " + workspaceResponse + "\n" +
                        "Request:" + workspaceRequest + "\n" +
                        "Error: " + ex.Message + "\n" +
                        "Stack: " + ex.StackTrace, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            else
            {
                this.Text = "New Workspace Properties";
                WorkspaceNameTOPBox.Text = "New Workspace";
            }
        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Close();
        }

        private void WorkspaceConfigForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                cancelBTN_Click(sender, e);
            }
        }

        private bool wasAnyFieldModified()
        {
            if (workspaceNameTB.Text != workspaceResponse.contents[0].workspaceName)
                return true;

            if (readCheck.Checked != workspaceResponse.contents[0].read)
                return true;

            if (writeCheck.Checked != workspaceResponse.contents[0].write)
                return true;

            return false;
        }

        private bool isAnyFieldEmpty()
        {
            errorProvider.SetError(workspaceNameTB, ""); // Clears errors

            if (string.IsNullOrEmpty(workspaceNameTB.Text) || string.IsNullOrWhiteSpace(workspaceNameTB.Text))
            {
                errorProvider.SetIconPadding(workspaceNameTB, -20);
                errorProvider.SetError(workspaceNameTB, "This field is mandatory");
                return true;
            }

            return false;
        }

        private void okBTN_Click(object sender, EventArgs e)
        {
            if (!isAnyFieldEmpty())
            {
                craftData = "workspaceName=" + workspaceNameTB.Text +
                            "&readMode=" + readCheck.Checked.ToString() +
                            "&writeMode=" + writeCheck.Checked.ToString();
                if (sentWorkspaceID != 0) // 0 -> new class. != 0 -> class being edited
                {
                    if (wasAnyFieldModified())
                    {
                        using (loadingForm loading = new loadingForm(UpdateWorkspaceData))
                        {
                            loading.ShowDialog();
                        }
                        try
                        {
                            saveResponse = JsonConvert.DeserializeObject<simpleServerResponse>(saveRequest);

                            if (saveResponse.status)
                            {
                                changesHandled = true;
                                cancelBTN_Click(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("Error: " + saveResponse.errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Response: " + saveResponse + "\n" +
                                "Request:" + saveRequest + "\n" +
                                "Error: " + ex.Message + "\n" +
                                "Stack: " + ex.StackTrace, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        changesHandled = true;
                        cancelBTN_Click(sender, e);
                    }
                }
                else
                {
                    using (loadingForm loading = new loadingForm(CreateNewWorkspace))
                    {
                        loading.ShowDialog();
                    }
                    try
                    {

                        saveResponse = JsonConvert.DeserializeObject<simpleServerResponse>(saveRequest);

                        if (saveResponse.status)
                        {
                            changesHandled = true;
                            cancelBTN_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Error: " + saveResponse.errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Response: " + saveResponse + "\n" +
                            "Request:" + saveRequest + "\n" +
                            "Error: " + ex.Message + "\n" +
                            "Stack: " + ex.StackTrace, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void WorkspaceConfigForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!changesHandled)
            {
                if (sentWorkspaceID != 0)
                {
                    if (wasAnyFieldModified())
                    {
                        if (MessageBox.Show("There are unsaved changes made to this workspace. Would you like to save them first?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            okBTN_Click(sender, e);
                        }
                    }
                }
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
