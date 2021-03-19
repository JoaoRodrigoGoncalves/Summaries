using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Summaries
{
    public partial class ServerInput : Form
    {
        public ServerInput()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private bool softwareClose = false;

        private void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text.StartsWith("http://") ? textBox1.Text.Substring(6) : textBox1.Text;
            url = url.StartsWith("https://") ? url : "https://" + url;
            url = url.EndsWith("/") ? url.Remove(url.Length - 1) : url;
            Regex reg = new Regex(@"https\:\/\/\w+\.\w+");
            Match m = reg.Match(url);

            if (m.Success)
            {
                Properties.Settings.Default.serverURL = url;
                Properties.Settings.Default.Save();
                softwareClose = true;
                Close();
            }
            else
            {
                ErrorProvider error = new ErrorProvider();
                error.SetError(textBox1, "Invalid Url");
                error.SetIconPadding(textBox1, -20);
            }
        }

        private void ServerInput_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!softwareClose)
            {
                Environment.Exit(0);
            }
        }
    }
}
