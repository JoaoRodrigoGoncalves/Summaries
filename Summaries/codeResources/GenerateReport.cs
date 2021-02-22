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

namespace Summaries.codeResources
{
    public class GenerateReport
    {
        functions func = new functions();
        Local_Storage storage = Local_Storage.Retrieve;

        Document _document;
        Table _table;

        workspaceServerResponse workspaceResponse;
        userServerResponse userResponse;
        classServerResponse classResponse;
        workspaceHoursServerResponse workspaceHoursResponse;

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

        public class workspaceHoursServerResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
            public List<workspaceHours> contents { get; set; }
        }

        public class workspaceHours
        {
            public int userID { get; set; }
            public int classID { get; set; }
            public int summarizedHours { get; set; }
        }

        public Document CreateDocument(int workspaceID)
        {
            try
            {
                workspaceResponse = JsonConvert.DeserializeObject<workspaceServerResponse>(func.APIRequest("GET", null, "workspace/" + workspaceID));
                if (workspaceResponse.status)
                {
                    if (workspaceResponse.contents[0].hours != null)
                    {
                        userResponse = JsonConvert.DeserializeObject<userServerResponse>(func.APIRequest("GET", null, "user"));
                        if (userResponse.status)
                        {
                            classResponse = JsonConvert.DeserializeObject<classServerResponse>(func.APIRequest("GET", null, "class"));
                            if (classResponse.status)
                            {
                                workspaceHoursResponse = JsonConvert.DeserializeObject<workspaceHoursServerResponse>(func.APIRequest("GET", null, "workspace/" + workspaceID + "/summarizedHours"));
                                if (workspaceHoursResponse.status)
                                {
                                    // Create a new MigraDoc document.
                                    _document = new Document();
                                    _document.Info.Title = GenerateReportStrings.DocumentType + " - " + workspaceResponse.contents[0].workspaceName;
                                    _document.Info.Author = storage.displayName + " (Summaries)";

                                    DefineStyles();

                                    foreach (hours item in workspaceResponse.contents[0].hours)
                                    {
                                        CreatePage(classResponse.contents[classResponse.contents.FindIndex(x => x.classID == item.classID)].className);
                                        FillContent(item.classID);
                                    }

                                    return _document;
                                }
                                else
                                {
                                    throw new Exception(GlobalStrings.Error + ": " + workspaceHoursResponse.errors);
                                }
                            }
                            else
                            {
                                throw new Exception(GlobalStrings.Error + ": " + classResponse.errors);
                            }
                        }
                        else
                        {
                            throw new Exception(GlobalStrings.Error + ": " + userResponse.errors);
                        }
                    }
                    else
                    {
                        throw new Exception(GlobalStrings.Error + ": " + GenerateReportStrings.NoClassesAssociated);
                    }
                }
                else
                {
                    throw new Exception(GlobalStrings.Error + ": " + workspaceResponse.errors);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\n" + ex.StackTrace, ex.InnerException);
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
        void CreatePage(string ClassName)
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

                var documentType = section.Headers.Primary.AddParagraph(GenerateReportStrings.DocumentType);
                documentType.Format.Font.Size = 11;
                documentType.Format.Alignment = ParagraphAlignment.Right;

                var info = section.AddParagraph(String.Format("{0}: {1}.\n{2}: {3}.", GenerateReportStrings.Workspace, workspaceResponse.contents[0].workspaceName, GenerateReportStrings.Class, ClassName));
                info.Format.Font.Size = 11;
                info.Format.SpaceAfter = "0.5cm";
                info.Format.SpaceBefore = "0.5cm";

                // Create the item table.
                _table = section.AddTable();
                _table.Style = "Table";
                _table.Borders.Color = new Color(0, 0, 0);
                _table.Borders.Width = 0.25;

                // Before you can add a row, you must define the columns.
                var column = _table.AddColumn("11cm");
                column.Format.Alignment = ParagraphAlignment.Left;
                column = _table.AddColumn("2cm");
                column.Format.Alignment = ParagraphAlignment.Right;
                column = _table.AddColumn("2cm");
                column.Format.Alignment = ParagraphAlignment.Right;
                var leftIndentToCenterTable = (section.PageSetup.PageWidth.Centimeter - section.PageSetup.LeftMargin.Centimeter - section.PageSetup.RightMargin.Centimeter - 15) / 2;
                _table.Rows.LeftIndent = Unit.FromCentimeter(leftIndentToCenterTable);

                // Create the header of the table.
                var row = _table.AddRow();
                row.HeadingFormat = true;
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Format.Font.Size = 9;
                row.Shading.Color = Color.Empty;
                row.Cells[0].AddParagraph(GenerateReportStrings.StudentName);
                row.Cells[0].Format.Font.Bold = false;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[1].AddParagraph(GenerateReportStrings.HoursWorked);
                row.Cells[1].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[2].AddParagraph(GenerateReportStrings.HoursLeft);
                row.Cells[2].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[2].VerticalAlignment = VerticalAlignment.Center;
                _table.SetEdge(0, 0, 3, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty);

                var dateAndPlace = section.AddParagraph(Properties.Settings.Default.City + ", ");
                dateAndPlace.AddDateField("dd/MM/yyyy");
                dateAndPlace.Format.Font.Size = 11;
                dateAndPlace.Format.Alignment = ParagraphAlignment.Right;
                dateAndPlace.Format.SpaceBefore = "1.5cm";

                var signLine = section.AddParagraph("______________________________");
                signLine.Format.Alignment = ParagraphAlignment.Right;
                signLine.Format.SpaceBefore = "1cm";

                var signerName = section.AddParagraph(storage.displayName);
                signerName.Format.Alignment = ParagraphAlignment.Right;
                signerName.Format.SpaceBefore = "0.2cm";

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
        void FillContent(int classID)
        {
            foreach (userContents student in userResponse.contents)
            {
                if (student.classID == classID)
                {
                    var row = this._table.AddRow();
                    int index = workspaceHoursResponse.contents.FindIndex(x => x.classID == classID && x.userID == student.userid);
                    if(index != -1)
                    {
                        int thisUserHours = workspaceHoursResponse.contents[index].summarizedHours;
                        row.Cells[0].AddParagraph(student.displayName);
                        row.Cells[1].AddParagraph(thisUserHours.ToString());
                        row.Cells[1].Format.Alignment = ParagraphAlignment.Center;
                        row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
                        row.Cells[2].AddParagraph((workspaceResponse.contents[0].hours[workspaceResponse.contents[0].hours.FindIndex(x => x.classID == classID)].TotalHours - thisUserHours).ToString());
                        row.Cells[2].Format.Alignment = ParagraphAlignment.Center;
                        row.Cells[2].VerticalAlignment = VerticalAlignment.Center;
                    }
                }
            }
            _table.SetEdge(0, _table.Rows.Count - 1, 3, 1, Edge.Box, BorderStyle.Single, 0.75);
        }
    }
}