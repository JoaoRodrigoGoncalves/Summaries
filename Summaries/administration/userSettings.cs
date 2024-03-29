﻿using Newtonsoft.Json;
using Summaries.codeResources;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Summaries.userSettings
{
    public partial class userSettings : Form
    {
        Local_Storage storage = Local_Storage.Retrieve;
        functions functions = new functions();
        string classRequest = null;
        ClassInfo classResponse = null;

        public userSettings()
        {
            InitializeComponent();
        }

        public class ClassInfo
        {
            public bool status { get; set; }
            public string error { get; set; }
            public List<ClassList> contents { get; set; }
        }

        public class ClassList
        {
            public int classID { get; set; }
            public string className { get; set; }
            public int totalUsers { get; set; }
        }

        public void getClass()
        {
            classRequest = functions.APIRequest("GET", null, "class");
        }

        private void userSettings_Load(object sender, EventArgs e)
        {
            Text = String.Format(GlobalStrings.UserSettings, storage.displayName);
            nameBox.Text = storage.displayName;

            using (loadingForm form = new loadingForm(getClass))
            {
                form.ShowDialog();
            }

            try
            {
                classResponse = JsonConvert.DeserializeObject<ClassInfo>(classRequest);
                if (classResponse.status)
                {
                    foreach (ClassList list in classResponse.contents)
                    {
                        if (list.classID == storage.classID)
                        {
                            classNameBox.Text = list.className;
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show(GlobalStrings.CantGetClassInfo, GlobalStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {

            }

            if (storage.isAdmin)
            {
                userTypeBox.Text = GlobalStrings.Administrator;
            }
            else
            {
                userTypeBox.Text = GlobalStrings.Student;
            }
            bigBarCheckBox.Checked = Properties.Settings.Default.bigBar;
            hoursPerDaySetting.Value = Properties.Settings.Default.hoursPerDay;
        }

        private void changePasswordBTN_Click(object sender, EventArgs e)
        {
            changePassword changePassword = new changePassword();
            changePassword.ShowDialog();
        }

        private void bigBarCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (bigBarCheckBox.Checked != Properties.Settings.Default.bigBar)
            {
                Properties.Settings.Default.bigBar = bigBarCheckBox.Checked;
                Properties.Settings.Default.Save();
            }
        }
        private void hoursPerDaySetting_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.hoursPerDay = (int) hoursPerDaySetting.Value;
            Properties.Settings.Default.Save();
        }
    }
}
