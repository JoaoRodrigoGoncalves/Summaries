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
        }
    }
}
