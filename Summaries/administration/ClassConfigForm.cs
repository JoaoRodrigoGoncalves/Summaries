﻿using Newtonsoft.Json;
using Summaries.codeResources;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static Summaries.codeResources.functions;

namespace Summaries.administration
{
    public partial class ClassConfigForm : Form
    {

        codeResources.functions functions = new codeResources.functions();
        int sentClassID = 0;
        string userRequest = null;
        string classRequest = null;
        string allClassesRequest = null;
        string craftData = null;
        string saveRequest = null;
        bool changesHandled = false;

        classesServerResponse classResponse;
        classesServerResponse allClassesList;
        usersServerResponse userResponse;
        simpleServerResponse saveResponse;

        public class usersServerResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
            public string ErrorCode { get; set; }
            public List<usersContent> contents { get; set; }
        }

        public class usersContent
        {
            public int userid { get; set; }
            public string user { get; set; }
            public string displayName { get; set; }
            public int classID { get; set; }
            public bool isAdmin { get; set; } = false;
            public bool isDeletionProtected { get; set; } = false;
        }

        public class classesServerResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
            public List<classesContent> contents { get; set; }
        }

        public class classesContent
        {
            public int classID { get; set; }
            public string className { get; set; }
            public int totalUsers { get; set; }
        }


        public ClassConfigForm(int classID = 0)
        {
            InitializeComponent();
            sentClassID = classID;
        }

        private void RequestClassData()
        {
            classRequest = functions.APIRequest("GET", null, "class/" + sentClassID); // its loaded here so the loading screen does not have to appear twice
            userRequest = functions.APIRequest("GET", null, "class/" + sentClassID + "/users");
        }

        private void CreateNewClass()
        {
            saveRequest = functions.APIRequest("POST", craftData, "class");
        }

        private void UpdateClassData()
        {
            saveRequest = functions.APIRequest("PUT", craftData, "class/" + sentClassID);
        }

        private void GetAllClasses()
        {
            allClassesRequest = functions.APIRequest("GET", null, "class");
        }

        private void ClassConfigForm_Load(object sender, EventArgs e)
        {
            using (loadingForm loading = new loadingForm(GetAllClasses))
            {
                loading.ShowDialog();
            }

            allClassesList = JsonConvert.DeserializeObject<classesServerResponse>(allClassesRequest);

            if (allClassesList.status)
            {
                if (sentClassID != 0)
                {

                    using (loadingForm loading = new loadingForm(RequestClassData))
                    {
                        loading.ShowDialog();
                    }

                    try
                    {
                        classResponse = JsonConvert.DeserializeObject<classesServerResponse>(classRequest);

                        if (classResponse.status)
                        {
                            if (classResponse.contents.Count != 1)
                            {
                                MessageBox.Show(GlobalStrings.GotMoreThanOneEntry, GlobalStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Close();
                            }
                            else
                            {
                                userResponse = JsonConvert.DeserializeObject<usersServerResponse>(userRequest);

                                if (userResponse.status)
                                {
                                    classesContent classes = classResponse.contents[0];

                                    this.Text = String.Format(ClassConfigFormStrings.FormName, classes.className);
                                    ClassNameTOPBox.Text = classes.className;
                                    classNameTB.Text = classes.className;

                                    if (userResponse.contents != null)
                                    {
                                        usersOnThisClassGV.Enabled = true;
                                        usersOnThisClassGV.ReadOnly = true;
                                        foreach (var x in userResponse.contents)
                                        {
                                            int thisRowIndex = usersOnThisClassGV.Rows.Add();
                                            usersOnThisClassGV.Rows[thisRowIndex].Cells["userLoginName"].Value = x.user;
                                            usersOnThisClassGV.Rows[thisRowIndex].Cells["userDisplayName"].Value = x.displayName;
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(GlobalStrings.Error + ": " + userResponse.errors, GlobalStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Close();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(GlobalStrings.Error + ": " + classResponse.errors, GlobalStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Response: " + classResponse + "\n" +
                            "Request:" + classRequest + "\n" +
                            "Error: " + ex.Message + "\n" +
                            "Stack: " + ex.StackTrace, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                    }
                }
                else
                {
                    this.Text = ClassConfigFormStrings.NewClassProperties;
                    ClassNameTOPBox.Text = ClassConfigFormStrings.NewClass;

                    usersOnThisClassGV.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show(GlobalStrings.Error + ": " + allClassesList.errors, GlobalStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Close();
        }

        private void ClassConfigForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                cancelBTN_Click(sender, e);
            }
        }

        private void okBTN_Click(object sender, EventArgs e)
        {
            errorProvider.SetError(classNameTB, ""); // Clears errors

            if (!string.IsNullOrEmpty(classNameTB.Text) || !string.IsNullOrWhiteSpace(classNameTB.Text))
            {
                craftData = "className=" + classNameTB.Text;
                if (!allClassesList.contents.Exists(x => x.className == classNameTB.Text && x.classID != sentClassID))
                {
                    if (sentClassID != 0) // 0 -> new class. != 0 -> class being edited
                    {
                        if (classNameTB.Text != classResponse.contents[0].className)
                        {
                            using (loadingForm loading = new loadingForm(UpdateClassData))
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
                        using (loadingForm loading = new loadingForm(CreateNewClass))
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
                }
                else
                {
                    MessageBox.Show(ClassConfigFormStrings.ClassNameInUse, ClassConfigFormStrings.ClassNameInUseShort, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                errorProvider.SetIconPadding(classNameTB, -20);
                errorProvider.SetError(classNameTB, GlobalStrings.MandatoryField);
            }
        }

        private void ClassConfigForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!changesHandled)
            {
                if (sentClassID != 0)
                {
                    if (classNameTB.Text != classResponse.contents[0].className)
                    {
                        if (MessageBox.Show(ClassConfigFormStrings.UnsavedChangesQuestion, GlobalStrings.UnsavedChanges, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
