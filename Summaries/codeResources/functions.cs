using Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Summaries.codeResources
{
    public class functions
    {
        public class simpleServerResponse
        {
            public bool status { get; set; }
            public int ErrorCode { get; set; }
            public string errors { get; set; }
        }

        private class Content
        {
            public int id { get; set; }
            public int userid { get; set; }
            public string date { get; set; }
            public int summaryNumber { get; set; }
            public int workspace { get; set; }
            public string bodytext { get; set; }
        }

        private class serverResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
            public List<Content> contents { get; set; }
        }


        /// <summary>
        /// Uses BASE64 to hash the given string
        /// </summary>
        /// <param name="text">String to hash</param>
        /// <returns>The string in BASE64</returns>
        public string Hash(string text)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Checks if it is possible to reach the specified link
        /// </summary>
        /// <param name="link">The link to the website or page</param>
        /// <returns>True if there is an internet connection</returns>
        public bool CheckForInternetConnection(string link)
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead(link))
                    return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// Returns a 3-digit version-like string
        /// </summary>
        /// https://stackoverflow.com/questions/31863551/truncating-a-version-number-c-sharp
        /// <returns>3-digit version</returns>
        public string GetSoftwareVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersion = FileVersionInfo.GetVersionInfo(assembly.Location);
            String[] versionArray = fileVersion.ProductVersion.ToString().Split('.');
            return string.Join(".", versionArray.Take(3));
        }

        /// <summary>
        /// Calls the given function on the API with the provided POST data
        /// </summary>
        /// <param name="method">Method to be used</param>
        /// <param name="POSTdata">The Information required to send to the web server</param>
        /// <param name="endpoint">Endpoint link after api/[version]/</param>
        /// <returns>Returns a JSON string with que server response</returns>
        public string APIRequest(string method, string POSTdata, string endpoint)
        {
            Local_Storage storage = Local_Storage.Retrieve;
            POSTdata = POSTdata == null ? "" : POSTdata;
            string finalData = "";
            try
            {
                var data = Encoding.UTF8.GetBytes(POSTdata);
                HttpWebRequest request = WebRequest.CreateHttp(storage.inUseDomain + "/summaries/api/v" + GetSoftwareVersion()[0] + "/" + endpoint);
                request.Method = method.ToUpper();
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.UserAgent = "App-V" + GetSoftwareVersion();
                request.Headers.Add("HTTP-X-API-KEY", storage.AccessToken);
                //writes the post data to the stream
                if (method.ToUpper() == "POST" || method.ToUpper() == "PUT")
                {
                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                        stream.Close();
                    }
                }
                //ler a resposta
                using (var response = request.GetResponse())
                {
                    var dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    finalData = reader.ReadToEnd();
                    dataStream.Close();
                    response.Close();
                }
            }
            catch (WebException ex)
            {
                if (CheckForInternetConnection(storage.inUseDomain))
                {
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        finalData = reader.ReadToEnd();
                    }
                }
                else
                {
                    finalData = "{\"status\":\"false\", \"errors\":\"Lost Connection to the Server\"}";
                }
            }
            return finalData;
        }

        /// <summary>
        /// Creates a word file, based on the current selected workspace, with all registered summaries.
        /// <see cref="https://docs.microsoft.com/en-us/previous-versions/office/troubleshoot/office-developer/automate-word-create-file-using-visual-c"/>
        /// </summary>
        public void ExportToWordFile()
        {
            try
            {
                Local_Storage storage = Local_Storage.Retrieve;

                object oMissing = Missing.Value;
                object oEndOfDoc = "\\endofdoc";

                Word.Application oWord;
                Word.Document oDoc;
                oWord = new Word.Application();
                oWord.Visible = true;
                oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                // Documment configuration

                oWord.ActiveDocument.Styles.Add("default");
                Style Default = oWord.ActiveDocument.Styles["default"];
                Default.Font.Name = "Arial";
                Default.Font.Size = 11;
                Default.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
                Default.ParagraphFormat.FirstLineIndent = 1;

                // actual word document content

                Word.Paragraph oPara1;
                oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara1.set_Style(Default);
                oPara1.Range.Font.Size = 12;
                oPara1.Range.Font.Bold = 1;
                oPara1.Range.Font.AllCaps = 1;
                oPara1.Range.Text = "Summaries Workspace Export";
                oPara1.Range.InsertParagraphAfter();

                Word.Paragraph oPara2;
                oPara2 = oDoc.Paragraphs.Add(ref oMissing);
                oPara2.set_Style(Default);

                if (CheckForInternetConnection(storage.inUseDomain))
                {
                    string jsonResponse = APIRequest("GET", null, "user/" + storage.userID + "/workspace/" + storage.currentWorkspaceID + "/summary");
                    serverResponse response;
                    response = JsonConvert.DeserializeObject<serverResponse>(jsonResponse);
                    if (response.status)
                    {
                        if (response.contents != null)
                        {
                            int rowsAmount = response.contents.Count + 1;
                            Word.Table oTable;
                            Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                            oTable = oDoc.Tables.Add(wrdRng, rowsAmount, 2, ref oMissing, ref oMissing);
                            oTable.Range.ParagraphFormat.SpaceAfter = 6;
                            oTable.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                            oTable.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                            int r;

                            oTable.Cell(1, 1).Range.Text = "Date";
                            oTable.Cell(1, 2).Range.Text = "Summary";

                            oTable.AllowAutoFit = true;
                            oTable.Columns[1].AutoFit();
                            Single firstColWidth = oTable.Columns[1].Width;
                            oTable.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitWindow);
                            oTable.Columns[1].SetWidth(firstColWidth, Word.WdRulerStyle.wdAdjustFirstColumn);

                            for (r = 2; r <= rowsAmount; r++)
                            {
                                oTable.Cell(r, 1).Range.Text = response.contents[r - 2].date;
                                oTable.Cell(r, 2).Range.Text = response.contents[r - 2].bodytext;
                            }
                        }
                        else
                        {
                            oPara2.Range.Text = "There are no summaries to be shown.";
                        }
                        oWord.Activate();
                    }
                    else
                    {
                        MessageBox.Show("Error: " + response.errors, "Critical Backend Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lost connection to the server. Please try again later.", "Connection Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nExport Halted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // https://stackoverflow.com/a/55788490/10935376
    public class NumericUpDownColumn : DataGridViewColumn
    {
        public NumericUpDownColumn()
            : base(new NumericUpDownCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set
            {
                if (value != null && !value.GetType().IsAssignableFrom(typeof(NumericUpDownCell)))
                {
                    throw new InvalidCastException("Must be a NumericUpDownCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    public class NumericUpDownCell : DataGridViewTextBoxCell
    {
        private decimal min = 0;
        private decimal max = 8760;

        public NumericUpDownCell()
            : base()
        {
            Style.Format = "F0";
        }
        public NumericUpDownCell(decimal min = 0, decimal max = 8760)
            : base()
        {
            this.min = min;
            this.max = max;
            Style.Format = "F0";
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            NumericUpDownEditingControl ctl = DataGridView.EditingControl as NumericUpDownEditingControl;
            ctl.Minimum = this.min;
            ctl.Maximum = this.max;
            ctl.Value = Convert.ToDecimal(this.Value);
        }

        public override Type EditType
        {
            get { return typeof(NumericUpDownEditingControl); }
        }

        public override Type ValueType
        {
            get { return typeof(Decimal); }
        }

        public override object DefaultNewRowValue
        {
            get { return null; } //未編集の新規行に余計な初期値が出ないようにする
        }
    }

    public class NumericUpDownEditingControl : NumericUpDown, IDataGridViewEditingControl
    {
        private DataGridView dataGridViewControl;
        private bool valueIsChanged = false;
        private int rowIndexNum;

        public NumericUpDownEditingControl()
            : base()
        {
            this.DecimalPlaces = 0;
        }

        public DataGridView EditingControlDataGridView
        {
            get { return dataGridViewControl; }
            set { dataGridViewControl = value; }
        }

        public object EditingControlFormattedValue
        {
            get { return this.Value.ToString("F0"); }
            set { this.Value = Decimal.Parse(value.ToString()); }
        }
        public int EditingControlRowIndex
        {
            get { return rowIndexNum; }
            set { rowIndexNum = value; }
        }
        public bool EditingControlValueChanged
        {
            get { return valueIsChanged; }
            set { valueIsChanged = value; }
        }

        public Cursor EditingPanelCursor
        {
            get { return base.Cursor; }
        }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            return (keyData == Keys.Left || keyData == Keys.Right ||
                keyData == Keys.Up || keyData == Keys.Down ||
                keyData == Keys.Home || keyData == Keys.End ||
                keyData == Keys.PageDown || keyData == Keys.PageUp);
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return this.Value.ToString();
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
        }

        protected override void OnValueChanged(EventArgs e)
        {
            valueIsChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(e);
        }
    }
}
