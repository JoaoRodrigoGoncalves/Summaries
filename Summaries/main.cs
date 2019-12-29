using System;
using System.Windows.Forms;

namespace Summaries
{
    public partial class main : Form
    {
        private int userID;
        private string user;
        private string displayName;

        /// <summary>
        /// Main function from the dashboard form.
        /// </summary>
        /// <param name="id">The user id retrived from the database</param>
        /// <param name="username">The username retrived from the database (login name)</param>
        /// <param name="display">The name to be displayed that was retrived from the database</param>
        public main(int id, string username, string display)
        {
            InitializeComponent();
            userID = id;
            user = username;
            displayName = display;
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void main_Shown(object sender, EventArgs e)
        {
            sessionLabel.Text += " " + displayName;
        }

        private void main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void menuFileChange_Password_Click(object sender, EventArgs e)
        {
            changePassword password = new changePassword(userID, user, displayName);
            password.ShowDialog();
        }
    }
}
