using System;
using System.Drawing;
using System.Windows.Forms;

namespace Summaries.userSettings
{
    public partial class userSettings : Form
    {
        public userSettings()
        {
            InitializeComponent();
        }

        private void userSettings_Load(object sender, EventArgs e)
        {
            codeResources.Local_Storage storage = codeResources.Local_Storage.Retrieve;
            Text = storage.displayName + " Settings";
            nameBoxlb.Text = storage.displayName;
            if (storage.userImageLocation != null)
            {
                userImagePB.Image = Image.FromFile(@storage.userImageLocation);
            }
        }

        private void removePhotoBTN_Click(object sender, EventArgs e)
        {
            userImagePB.Image = Summaries.Properties.Resources.userIcon;
        }

        private void changePasswordBTN_Click(object sender, EventArgs e)
        {
            changePassword changePassword = new changePassword();
            changePassword.ShowDialog();
        }
    }
}
