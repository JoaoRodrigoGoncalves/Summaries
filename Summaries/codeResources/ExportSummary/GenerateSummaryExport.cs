/**
 * File based on MigraDoc's documentation
 * http://www.pdfsharp.net/wiki/Invoice-sample.ashx
 */

using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Summaries.codeResources.ExportSummary
{
    public class GenerateSummaryExport
    {
        functions func = new functions();
        Local_Storage storage = Local_Storage.Retrieve;

        Document _document;
        Table _table;

        class summariesServerResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
            public List<summariesContent> contents { get; set; }
        }

        class summariesContent
        {
            public int ID { get; set; }
            public int userID { get; set; }
            public string date { get; set; }
            public int summaryNumber { get; set; }
            public int workspaceID { get; set; }
            public string bodyText { get; set; }
            public int dayHours { get; set; }
        }

        summariesServerResponse summariesResponse;

        public class classServerResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
            public List<classContents> contents { get; set; }
        }

        public class classContents
        {
            public int classID { get; set; }
            public string className { get; set; }
            public int totalUsers { get; set; }
        }

        classServerResponse classResponse;

        public class workspaceServerResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
            public List<workspaceContents> contents { get; set; }
        }

        public class workspaceContents
        {
            public int id { get; set; }
            public string workspaceName { get; set; }
            public bool read { get; set; }
            public bool write { get; set; }
            public int totalSummaries { get; set; }
            public List<hours> hours { get; set; }
        }

        public class hours
        {
            public int id { get; set; }
            public int workspaceID { get; set; }
            public int classID { get; set; }
            public int TotalHours { get; set; }
        }

        workspaceServerResponse workspaceResponse;

        public class userServerResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
            public List<userContents> contents { get; set; }
        }

        public class userContents
        {
            public int userid { get; set; }
            public string user { get; set; }
            public string displayName { get; set; }
            public int classID { get; set; }
            public bool isAdmin { get; set; }
            public bool isDeletionProtected { get; set; }
        }

        userServerResponse userResponse;

        string studentName_g;
        int? classID_g;        

        public Document CreateDocument(int? userID = null, int? classID = null, int? workspaceID = null)
        {
            if(userID == null || classID == null || workspaceID == null)
            {
                userID = storage.userID;
                classID = storage.classID;
                classID_g = storage.classID;
                workspaceID = storage.currentWorkspaceID;
                studentName_g = storage.displayName;
            }
            else
            {
                if (userID < 1 || classID < 0 || workspaceID < 0)
                {
                    throw new Exception("The userID, classID and workspaceID parameters have to be greater than 0. No document was generated.");
                }
                else
                {
                    userResponse = JsonConvert.DeserializeObject<userServerResponse>(func.APIRequest("GET", null, "user/" + userID));
                    if (userResponse.status)
                    {
                        classID_g = userResponse.contents[0].classID;
                        studentName_g = userResponse.contents[0].displayName;
                    }
                    else
                    {
                        throw new Exception(GlobalStrings.Error + ": " + userResponse.errors);
                    }
                }
            }

            try
            {
                summariesResponse = JsonConvert.DeserializeObject<summariesServerResponse>(func.APIRequest("GET", null, "user/" + userID + "/workspace/" + workspaceID + "/summary"));
                if (summariesResponse.status)
                {
                    classResponse = JsonConvert.DeserializeObject<classServerResponse>(func.APIRequest("GET", null, "class/" + classID));
                    if (classResponse.status)
                    {
                        workspaceResponse = JsonConvert.DeserializeObject<workspaceServerResponse>(func.APIRequest("GET", null, "workspace/" + workspaceID));
                        if (workspaceResponse.status)
                        {
                            // Create a new MigraDoc document.
                            _document = new Document();
                            _document.Info.Title = GenerateSummaryExportStrings.DocumentType + " - " + studentName_g;
                            _document.Info.Author = storage.displayName + " (Summaries)";

                            DefineStyles();
                            CreatePage();
                            FillContent();

                            return _document;
                        }
                        else
                        {
                            throw new Exception(GlobalStrings.Error + ": " + workspaceResponse.errors);
                        }
                    }
                    else
                    {
                        throw new Exception(GlobalStrings.Error + ": " + classResponse.errors);
                    }
                }
                else
                {
                    throw new Exception(GlobalStrings.Error + ": " + summariesResponse.errors);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Defines the styles used to format the MigraDoc document.
        /// </summary>
        void DefineStyles()
        {
            // Get the predefined style Normal.
            var style = _document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Arial";

            style = _document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = _document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called Table based on style Normal.
            style = _document.Styles.AddStyle("Table", "Normal");
            style.Font.Size = 11;

            // Create a new style called Title based on style Normal.
            style = _document.Styles.AddStyle("Title", "Normal");
            style.Font.Name = "Arial";
            style.Font.Size = 11;

            // Create a new style called Reference based on style Normal.
            style = _document.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);
        }

        /// <summary>
        /// Creates the static parts of the report.
        /// </summary>
        void CreatePage()
        {
            try
            {
                // Each MigraDoc document needs at least one section.
                var section = _document.AddSection();

                // Define the page setup. We use an image in the header, therefore the
                // default top margin is too small for our invoice.
                section.PageSetup = _document.DefaultPageSetup.Clone();
                // We increase the TopMargin to prevent the document body from overlapping the page header.
                // We have an image of 3.5 cm height in the header.
                // The default position for the header is 1.25 cm.
                // We add 0.5 cm spacing between header image and body and get 5.25 cm.
                // Default value is 2.5 cm.
                section.PageSetup.TopMargin = "5.25cm";

                // Put the logo in the header.
                var tempPath = Path.GetTempPath() + "summariesTemp\\appLogo.png";
                Properties.Resources.icon1.Save(tempPath);
                var image = section.Headers.Primary.AddImage(tempPath);
                image.Height = "3.5cm";
                image.LockAspectRatio = true;
                image.RelativeVertical = RelativeVertical.Line;
                image.RelativeHorizontal = RelativeHorizontal.Margin;
                image.Top = ShapePosition.Top;
                image.Left = ShapePosition.Left;
                image.WrapFormat.Style = WrapStyle.Through;
                image.Section.AddParagraph(GlobalStrings.AppName);


                var school = section.Headers.Primary.AddParagraph(Properties.Settings.Default.SchoolName);
                school.Format.Font.Size = 11;
                school.Format.SpaceBefore = "1.5cm";
                school.Format.SpaceAfter = 3;
                school.Format.Alignment = ParagraphAlignment.Right;

                var documentType = section.Headers.Primary.AddParagraph(GenerateSummaryExportStrings.DocumentType);
                documentType.Format.Font.Size = 11;
                documentType.Format.Alignment = ParagraphAlignment.Right;

                var info = section.AddParagraph(String.Format("{0}: {1}.\n{2}: {3}.\n{4}: {5}.",
                                                                GenerateSummaryExportStrings.StudentName,
                                                                studentName_g,
                                                                GenerateSummaryExportStrings.Class,
                                                                classResponse.contents[0].className,
                                                                GenerateSummaryExportStrings.Workload,
                                                                workspaceResponse.contents[0].hours[workspaceResponse.contents[0].hours.FindIndex(x => x.classID == classID_g)].TotalHours
                                                ));
                info.Format.Font.Size = 11;
                info.Format.SpaceAfter = "0.5cm";
                info.Format.SpaceBefore = "0.5cm";

                // Create the item table.
                _table = section.AddTable();
                _table.Style = "Table";
                _table.Borders.Color = new Color(0, 0, 0);
                _table.Borders.Width = 0.25;

                // Before you can add a row, you must define the columns.
                var column = _table.AddColumn("3cm");
                column.Format.Alignment = ParagraphAlignment.Left;
                column = _table.AddColumn("2cm");
                column.Format.Alignment = ParagraphAlignment.Left;
                column = _table.AddColumn("1cm");
                column.Format.Alignment = ParagraphAlignment.Left;
                column = _table.AddColumn("10cm");
                column.Format.Alignment = ParagraphAlignment.Left;
                var leftIndentToCenterTable = (section.PageSetup.PageWidth.Centimeter - section.PageSetup.LeftMargin.Centimeter - section.PageSetup.RightMargin.Centimeter - 16) / 2;
                _table.Rows.LeftIndent = Unit.FromCentimeter(leftIndentToCenterTable);

                // Create the header of the table.
                var row = _table.AddRow();
                row.HeadingFormat = true;
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Format.Font.Size = 9;
                row.Shading.Color = Color.Empty;
                row.Cells[0].AddParagraph(GenerateSummaryExportStrings.Date);
                row.Cells[0].Format.Font.Bold = false;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[1].AddParagraph(GenerateSummaryExportStrings.HoursWorked);
                row.Cells[1].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[2].AddParagraph(GenerateSummaryExportStrings.SummaryNumber);
                row.Cells[2].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[2].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[3].AddParagraph(GenerateSummaryExportStrings.SummaryBody);
                row.Cells[3].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[3].VerticalAlignment = VerticalAlignment.Center;
                _table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty);

                var key = section.AddParagraph(GenerateSummaryExportStrings.DayMissedChar + " - " + GenerateSummaryExportStrings.DayMissedLong);
                key.Format.Alignment = ParagraphAlignment.Left;
                key.Format.Font.Size = 11;
                key.Format.SpaceBefore = "0.5cm";

                String[] signers = { studentName_g, GenerateSummaryExportStrings.CompanyResponsable, GenerateSummaryExportStrings.Teacher };
                foreach (string name in signers)
                {
                    var _signLine = section.AddParagraph("______________________________");
                    _signLine.Format.Alignment = ParagraphAlignment.Right;
                    _signLine.Format.SpaceBefore = "1cm";

                    var _signerName = section.AddParagraph(name);
                    _signerName.Format.Alignment = ParagraphAlignment.Right;
                    _signerName.Format.SpaceBefore = "0.2cm";

                }

                // Create the footer.
                string date = DateTime.Today.ToString("dd/MM/yyyy");
                string time = DateTime.Now.ToString("HH:mm:ss");
                var paragraph = section.Footers.Primary.AddParagraph();
                paragraph.AddText(String.Format(GlobalStrings.GenerationTime, date, time));
                paragraph.Format.Font.Size = 6;
            }
            catch (Exception ex)
            {
                File.WriteAllText(Path.GetTempPath() + "summariesTemp\\generateReportErrorLog.txt", ex.Message + " -> " + ex.StackTrace);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Creates the dynamic parts of the report.
        /// </summary>
        void FillContent()
        {
            int totalHours = 0;
            if (summariesResponse.contents != null)
            {
                summariesResponse.contents.Sort((x, y) => x.summaryNumber.CompareTo(y.summaryNumber)); // Sort by summary number
                foreach (summariesContent item in summariesResponse.contents)
                {
                    totalHours += item.dayHours;
                    var row = this._table.AddRow();
                    row.Cells[0].AddParagraph(item.date);
                    row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
                    row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
                    if (item.dayHours != 0)
                    {
                        row.Cells[1].AddParagraph(item.dayHours.ToString());
                    }
                    else
                    {
                        row.Cells[1].AddParagraph(GenerateSummaryExportStrings.DayMissedChar);
                    }
                    row.Cells[1].Format.Alignment = ParagraphAlignment.Center;
                    row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
                    row.Cells[2].AddParagraph(item.summaryNumber.ToString()); ;
                    row.Cells[2].Format.Alignment = ParagraphAlignment.Center;
                    row.Cells[2].VerticalAlignment = VerticalAlignment.Center;
                    row.Cells[3].AddParagraph(item.bodyText);
                    row.Cells[3].Format.Alignment = ParagraphAlignment.Center;
                    row.Cells[3].VerticalAlignment = VerticalAlignment.Center;

                }
                _table.SetEdge(0, 0, 4, _table.Rows.Count, Edge.Box, BorderStyle.Single, 0.75, Color.Empty);

                var lastRow = this._table.AddRow();
                lastRow.Cells[0].AddParagraph(GenerateSummaryExportStrings.Total);
                lastRow.Cells[0].VerticalAlignment = VerticalAlignment.Center;
                lastRow.Cells[0].Format.Alignment = ParagraphAlignment.Right;
                lastRow.Cells[0].Borders.Visible = false;
                lastRow.Cells[1].AddParagraph(totalHours.ToString());
                lastRow.Cells[1].Format.Alignment = ParagraphAlignment.Center;
                lastRow.Cells[1].VerticalAlignment = VerticalAlignment.Center;
                lastRow.Cells[2].Borders.Visible = false;
                lastRow.Cells[3].Borders.Visible = false;
            }
        }
    }
}