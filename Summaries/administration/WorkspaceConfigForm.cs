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
        string classRequest = null;
        string craftData = null;
        string saveRequest = null;
        bool changesHandled = false;

        simpleServerResponse saveResponse;
        workspacesServerResponse workspaceResponse;
        classServerResponse classResponse;
        HoursEditObject hoursControl = new HoursEditObject()
        {
            classesToAdd = new List<classesToAdd>(),
            classesToEdit = new List<classesToEdit>(),
            classesToRemove = new List<classesToRemove>()
        };
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

        public class classServerResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
            public List<classContent> contents { get; set; }
        }

        public class classContent
        {
            public int classID { get; set; }
            public string className { get; set; }
            public int totalUsers { get; set; }
        }

        public class HoursEditObject
        {
            public List<classesToAdd> classesToAdd { get; set; }
            public List<classesToEdit> classesToEdit { get; set; }
            public List<classesToRemove> classesToRemove { get; set; }
        }

        public class classesToAdd
        {
            public int classID { get; set; }
            public int totalHours { get; set; }
        }

        public class classesToEdit
        {
            public int classID { get; set; }
            public int totalHours { get; set; }
        }

        public class classesToRemove
        {
            public int classID { get; set; }
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

        private void RequestClassData()
        {
            classRequest = functions.APIRequest("GET", null, "class");
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
            DataGridViewTextBoxColumn className = new DataGridViewTextBoxColumn();
            className.Name = "className";
            className.HeaderText = AdministrationMenuStrings.ClassName;
            className.ReadOnly = true;
            hoursDataGridView.Columns.Add(className);

            NumericUpDownColumn column = new NumericUpDownColumn();
            column.Name = "totalHours";
            column.HeaderText = WorkspaceConfigFormStrings.TotalHours;
            column.ReadOnly = false;
            hoursDataGridView.Columns.Add(column);

            DataGridViewButtonColumn removeBTN = new DataGridViewButtonColumn();
            removeBTN.HeaderText = "";
            removeBTN.Name = "removeBTN";
            hoursDataGridView.Columns.Add(removeBTN);

            using (loadingForm loading = new loadingForm(RequestClassData))
            {
                loading.ShowDialog();
            }

            try
            {
                classResponse = JsonConvert.DeserializeObject<classServerResponse>(classRequest);

                if (classResponse.status)
                {
                    if (classResponse.contents.Count < 1)
                    {
                        MessageBox.Show(WorkspaceConfigFormStrings.ClassesNotFound, GlobalStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                    }
                    else
                    {
                        foreach (classContent Class in classResponse.contents)
                        {
                            classesCB.Items.Add(Class.className);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(GlobalStrings.Error + ": " + classResponse.errors, GlobalStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Response: " + classResponse + "\n" +
                        "Request:" + classRequest + "\n" +
                        "Error: " + ex.Message + "\n" +
                        "Stack: " + ex.StackTrace, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

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
                            MessageBox.Show(GlobalStrings.GotMoreThanOneEntry, GlobalStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Close();
                        }
                        else
                        {
                            this.Text = String.Format(WorkspaceConfigFormStrings.FormTitle, workspaceResponse.contents[0].workspaceName);
                            WorkspaceNameTOPBox.Text = workspaceResponse.contents[0].workspaceName;
                            workspaceNameTB.Text = workspaceResponse.contents[0].workspaceName;

                            readCheck.Checked = workspaceResponse.contents[0].read;
                            writeCheck.Checked = workspaceResponse.contents[0].write;


                            if(workspaceResponse.contents[0].hours != null)
                            {
                                foreach (hoursContent item in workspaceResponse.contents[0].hours)
                                {
                                    DataGridViewRow row = new DataGridViewRow();
                                    DataGridViewTextBoxCell TBcell = new DataGridViewTextBoxCell();
                                    TBcell.Value = classResponse.contents[classResponse.contents.FindIndex(x => x.classID == item.classID)].className;
                                    classesCB.Items.Remove(classResponse.contents[classResponse.contents.FindIndex(x => x.classID == item.classID)].className);
                                    NumericUpDownCell NumUpDownCell = new NumericUpDownCell();
                                    NumUpDownCell.Value = item.totalHours;
                                    DataGridViewButtonCell BTNCell = new DataGridViewButtonCell();
                                    BTNCell.Tag = classResponse.contents.FindIndex(x => x.classID == item.classID);
                                    BTNCell.Value = WorkspaceConfigFormStrings.RemoveBTN;

                                    row.Cells.Add(TBcell);
                                    row.Cells.Add(NumUpDownCell);
                                    row.Cells.Add(BTNCell);

                                    hoursDataGridView.Rows.Add(row);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(GlobalStrings.Error + ": " + workspaceResponse.errors, GlobalStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Workspace Response: " + workspaceResponse + "\n" +
                        "Workspace Request:" + workspaceRequest + "\n" +
                        "Error: " + ex.Message + "\n" +
                        "Stack: " + ex.StackTrace, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            else
            {
                this.Text = WorkspaceConfigFormStrings.NewWorkspaceTitle;
                WorkspaceNameTOPBox.Text = WorkspaceConfigFormStrings.NewWorkspace;
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

            if (hoursControl.classesToAdd.Count > 0)
                return true;

            if (hoursControl.classesToEdit.Count > 0)
                return true;

            if (hoursControl.classesToRemove.Count > 0)
                return true;

            return false;
        }

        private bool isAnyFieldEmpty()
        {
            errorProvider.SetError(workspaceNameTB, ""); // Clears errors

            if (string.IsNullOrEmpty(workspaceNameTB.Text) || string.IsNullOrWhiteSpace(workspaceNameTB.Text))
            {
                errorProvider.SetIconPadding(workspaceNameTB, -20);
                errorProvider.SetError(workspaceNameTB, GlobalStrings.MandatoryField);
                return true;
            }

            return false;
        }

        private void okBTN_Click(object sender, EventArgs e)
        {
            if (!isAnyFieldEmpty())
            {
                if(hoursDataGridView.Rows.Count == 0)
                {
                    MessageBox.Show(WorkspaceConfigFormStrings.NoClassHoursAssignedWarning, WorkspaceConfigFormStrings.NoClassHours, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    readCheck.Checked = false;
                    writeCheck.Checked = false;
                }
                craftData = "workspaceName=" + workspaceNameTB.Text +
                            "&readMode=" + readCheck.Checked.ToString() +
                            "&writeMode=" + writeCheck.Checked.ToString() +
                            "&JSONString=" + functions.Hash(JsonConvert.SerializeObject(hoursControl));
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
                                MessageBox.Show(GlobalStrings.Error + ": " + saveResponse.errors, GlobalStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if(!workspaceResponse.contents.Exists(x => x.workspaceName == workspaceNameTB.Text))
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
                                MessageBox.Show(GlobalStrings.Error + ": " + saveResponse.errors, GlobalStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show(WorkspaceConfigFormStrings.WorkspaceNameInUse, WorkspaceConfigFormStrings.WorkspaceNameInUseShort, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if (MessageBox.Show(WorkspaceConfigFormStrings.UnsavedChangesQuestion, WorkspaceConfigFormStrings.UnsavedChanges, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            okBTN_Click(sender, e);
                        }
                    }
                }
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void addClassBTN_Click(object sender, EventArgs e)
        {
            if(classesCB.Items.Count > 0 && classesCB.SelectedItem != null)
            {
                int classIndex = classResponse.contents.FindIndex(x => x.className == classesCB.SelectedItem.ToString());
                classesCB.Items.RemoveAt(classesCB.SelectedIndex);
                if(classesCB.Items.Count > 0)
                {
                    classesCB.SelectedIndex = 0;
                }

                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell TBcell = new DataGridViewTextBoxCell();
                TBcell.Value = classResponse.contents[classIndex].className;
                NumericUpDownCell NumUpDownCell = new NumericUpDownCell();
                NumUpDownCell.Value = 300;
                DataGridViewButtonCell BTNCell = new DataGridViewButtonCell();
                BTNCell.Tag = classIndex;
                BTNCell.Value = WorkspaceConfigFormStrings.RemoveBTN;

                row.Cells.Add(TBcell);
                row.Cells.Add(NumUpDownCell);
                row.Cells.Add(BTNCell);

                if(sentWorkspaceID != 0) // checks if we're editing a workspace
                {
                    if(!hoursControl.classesToAdd.Exists(x => x.classID == classResponse.contents[classIndex].classID)) // checks if this class is not on the "to add" list
                    {
                        if(hoursControl.classesToRemove.Exists(x => x.classID == classResponse.contents[classIndex].classID)) // checks if this class if on the "to remove" list
                        {
                            hoursControl.classesToRemove.Remove(hoursControl.classesToRemove.Find(x => x.classID == classResponse.contents[classIndex].classID)); // removes the class from the "to remove" list
                        }

                        if(hoursControl.classesToEdit.Exists(x => x.classID == classResponse.contents[classIndex].classID)) // checks if this class is on the "to edit" list
                        {
                            hoursControl.classesToEdit[hoursControl.classesToEdit.FindIndex(x => x.classID == classResponse.contents[classIndex].classID)].totalHours = 300;
                        }
                        else
                        {
                            if(workspaceResponse.contents[0].hours.Exists(x => x.classID == classResponse.contents[classIndex].classID)) // checks if this class was already registered on the server
                            {
                                // if the class was alread redistered on the server, this will add to the "to edit" list instead of the "to add". This way, it will not create multiple instances of the same class on the same workspace
                                if(workspaceResponse.contents[0].hours[workspaceResponse.contents[0].hours.FindIndex(x => x.classID == classResponse.contents[classIndex].classID)].totalHours != 300) // checks if the hours total on server is different than the default 300
                                {
                                    classesToEdit toEdit = new classesToEdit();
                                    toEdit.classID = classResponse.contents[classIndex].classID;
                                    toEdit.totalHours = 300;
                                }
                            }
                            else
                            {
                                // add the class to the "to add" list
                                classesToAdd toAdd = new classesToAdd();
                                toAdd.classID = classResponse.contents[classIndex].classID;
                                toAdd.totalHours = 300;
                                hoursControl.classesToAdd.Add(toAdd);
                            }
                        }
                    }
                }
                else
                {
                    // new workspace
                    classesToAdd toAdd = new classesToAdd();
                    toAdd.classID = classResponse.contents[classIndex].classID;
                    toAdd.totalHours = 300;
                    hoursControl.classesToAdd.Add(toAdd);
                }
                hoursDataGridView.Rows.Add(row);
            }
        }

        private void hoursDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)
                {
                    int removedClassIndex = classResponse.contents.FindIndex(x => x.className == hoursDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                    if (sentWorkspaceID != 0)
                    {
                        if (hoursControl.classesToAdd.Exists(x => x.classID == classResponse.contents[removedClassIndex].classID))
                        {
                            hoursControl.classesToAdd.Remove(hoursControl.classesToAdd[hoursControl.classesToAdd.FindIndex(x => x.classID == classResponse.contents[removedClassIndex].classID)]);
                        }
                        if (hoursControl.classesToEdit.Exists(x => x.classID == classResponse.contents[removedClassIndex].classID))
                        {
                            hoursControl.classesToEdit.Remove(hoursControl.classesToEdit.Find(x => x.classID == classResponse.contents[removedClassIndex].classID));
                        }
                        if (!hoursControl.classesToRemove.Exists(x => x.classID == classResponse.contents[removedClassIndex].classID))
                        {
                            classesToRemove toRemove = new classesToRemove();
                            toRemove.classID = classResponse.contents[removedClassIndex].classID;
                            hoursControl.classesToRemove.Add(toRemove);
                        }
                    }
                    else
                    {
                        // new workspace
                        if (hoursControl.classesToAdd.Exists(x => x.classID == classResponse.contents[removedClassIndex].classID))
                        {
                            hoursControl.classesToAdd.Remove(hoursControl.classesToAdd.Find(x => x.classID == classResponse.contents[removedClassIndex].classID));
                        }
                    }

                    hoursDataGridView.Rows.RemoveAt(e.RowIndex);
                    classesCB.Items.Add(classResponse.contents[removedClassIndex].className);
                }
            }
            catch { }
        }

        private void hoursDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int newHoursTotal = int.Parse(hoursDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

            int editedClassIndex = classResponse.contents.FindIndex(x => x.className == hoursDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());

            if(hoursControl.classesToEdit.Exists(x => x.classID == classResponse.contents[editedClassIndex].classID)) // check if this class is on the "to edit" list
            {
                hoursControl.classesToEdit[hoursControl.classesToEdit.FindIndex(x => x.classID == classResponse.contents[editedClassIndex].classID)].totalHours = newHoursTotal;
            }
            else
            {
                // if it is not on the "to edit" list, then check if it is on the "to add" list
                if(hoursControl.classesToAdd.Exists(x => x.classID == classResponse.contents[editedClassIndex].classID))
                {
                    hoursControl.classesToAdd[hoursControl.classesToAdd.FindIndex(x => x.classID == classResponse.contents[editedClassIndex].classID)].totalHours = newHoursTotal;
                }
                else
                {
                    // if it is in neither one of them, create a new entry on the "to edit" list
                    classesToEdit toEdit = new classesToEdit();
                    toEdit.classID = classResponse.contents[editedClassIndex].classID;
                    toEdit.totalHours = newHoursTotal;
                    hoursControl.classesToEdit.Add(toEdit);
                }
            }
        }
    }
}
