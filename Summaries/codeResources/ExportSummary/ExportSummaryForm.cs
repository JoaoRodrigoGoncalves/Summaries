﻿using MigraDoc.Rendering;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Summaries.codeResources.ExportSummary
{
    public partial class ExportSummaryForm : Form
    {
        public ExportSummaryForm()
        {
            InitializeComponent();
        }

        private void ExportSummaryForm_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.SchoolName))
            {
                schoolNameTB.Text = Properties.Settings.Default.SchoolName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SchoolName != schoolNameTB.Text)
            {
                Properties.Settings.Default.SchoolName = schoolNameTB.Text;
                Properties.Settings.Default.Save();
            }

            try
            {
                GenerateSummaryExport report = new GenerateSummaryExport();
                var pdf = report.CreateDocument();
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
            catch (Exception ex)
            {
                MessageBox.Show(GlobalStrings.Error + ": " + ex.Message, GlobalStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
