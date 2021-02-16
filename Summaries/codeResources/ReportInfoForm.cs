using MigraDoc.Rendering;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Summaries.codeResources
{
    public partial class ReportInfoForm : Form
    {
        int workspaceID;
        public ReportInfoForm(int workspaceID)
        {
            InitializeComponent();
            this.workspaceID = workspaceID;
        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ReportInfoForm_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.SchoolName))
            {
                schoolNameTB.Text = Properties.Settings.Default.SchoolName;
            }

            if (!String.IsNullOrEmpty(Properties.Settings.Default.City))
            {
                cityNameTB.Text = Properties.Settings.Default.City;
            }
        }

        private bool EmptyFields()
        {
            errorProvider.Clear();
            if (String.IsNullOrEmpty(schoolNameTB.Text) || String.IsNullOrWhiteSpace(schoolNameTB.Text))
            {
                errorProvider.SetIconPadding(schoolNameTB, -20);
                errorProvider.SetError(schoolNameTB, GlobalStrings.MandatoryField);
                return true;
            }

            if (String.IsNullOrEmpty(cityNameTB.Text) || String.IsNullOrWhiteSpace(cityNameTB.Text))
            {
                errorProvider.SetIconPadding(cityNameTB, -20);
                errorProvider.SetError(cityNameTB, GlobalStrings.MandatoryField);
                return true;
            }

            return false;
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            if (!EmptyFields())
            {
                if(Properties.Settings.Default.SchoolName != schoolNameTB.Text)
                {
                    Properties.Settings.Default.SchoolName = schoolNameTB.Text;
                    Properties.Settings.Default.Save();
                }

                if (Properties.Settings.Default.City != cityNameTB.Text)
                {
                    Properties.Settings.Default.City = cityNameTB.Text;
                    Properties.Settings.Default.Save();
                }

                try
                {
                    GenerateReport report = new GenerateReport();
                    var pdf = report.CreateDocument(this.workspaceID);
                    pdf.UseCmykColor = true;

                    // Create a renderer for PDF that uses Unicode font encoding.
                    var pdfRenderer = new PdfDocumentRenderer(true);

                    // Set the MigraDoc document.
                    pdfRenderer.Document = pdf;

                    // Create the PDF document.
                    pdfRenderer.RenderDocument();

                    SaveFileDialog saveFile = new SaveFileDialog();
                    saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    saveFile.Filter = "PDF|*.pdf";
                    saveFile.ShowDialog();

                    pdfRenderer.Save(saveFile.FileName);
                    Process.Start(saveFile.FileName);
                    Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(GlobalStrings.Error + ": " + ex.Message, GlobalStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
