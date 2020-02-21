using System.Windows.Forms;

namespace Summaries.codeResources
{
    public partial class confirmByTyping : Form
    {
        public confirmByTyping(string textToWrite)
        {
            InitializeComponent();
            textToBeWritten.Text = textToWrite;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if(textBox.Text != textToBeWritten.Text)
            {
                errorLB.Visible = true;
            }
            else
            {
                Properties.Settings.Default.typeTestSuccessfull = true;
                this.Close();
            }
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                button1_Click(sender, e);
            }
        }
    }
}
