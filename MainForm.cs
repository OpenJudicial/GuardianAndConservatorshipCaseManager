// mainform.cs
using GnC.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace GnC
{
    public partial class MainForm : Form
    {
        private int searchResultStart = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void resetButtons(string current)
        {
            if (current != "btnHome") btnHome.Image = Resources.home;
            if (current != "btnSearch") btnSearch.Image = Resources.search;
            if (current != "btnCalendar") btnCalendar.Image = Resources.calendar;
            if (current != "btnReport") btnReport.Image = Resources.report;
            if (current != "btnCaseDetail") btnCaseDetail.Image = Resources.casedetail;
        }

        private void navButton_Click(object sender, EventArgs e = null)
        {
            Button clickedButton = sender as Button;
            panelDashboard.Controls.Clear();
            lblSelectBar.Top = clickedButton.Top;
            resetButtons(clickedButton.Name);
            panelDashboard.Visible = (clickedButton.Name == "btnHome");
            panelSearch.Visible = (clickedButton.Name == "btnSearch");
            panelCaseDetail.Visible = (clickedButton.Name == "btnCaseDetail");
            MainForm_Resize();
            switch (clickedButton.Name)
            {
                case "btnHome":
                    clickedButton.Image = Resources.home2;
                    panelDashboard.Visible = true;
                    break;
                case "btnSearch":
                    clickedButton.Image = Resources.search2;
                    panelDashboard.Visible = true;
                    cboSearchDistrict.SelectedIndex = 0;
                    textSearch.Focus();
                    break;
                case "btnCalendar":
                    clickedButton.Image = Resources.calendar2;
                    panelDashboard.Controls.Add(new Label { Text = "Calendar View", ForeColor = System.Drawing.Color.White, AutoSize = true });
                    break;
                case "btnCaseDetail":
                    clickedButton.Image = Resources.casedetail2;
                    panelDashboard.Controls.Add(new Label { Text = "Case Detail View", ForeColor = System.Drawing.Color.White, AutoSize = true });
                    tabControlCaseDetails_SelectedIndexChanged();
                    break;
                case "btnReport":
                    clickedButton.Image = Resources.report2;
                    panelDashboard.Controls.Add(new Label { Text = "Report View", ForeColor = System.Drawing.Color.White, AutoSize = true });
                    break;
            }
        }

        private void timerSplash_Tick(object sender, EventArgs e)
        {
            picSplash.Visible = false;
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = textSearch.Text.Trim();
            //Data.readTable("Counties");
            if (string.IsNullOrEmpty(searchText)) resultsPanel.Controls.Clear();            
            else {
                searchResultStart = 0;
                resultsPanel.Controls.Clear();
                DisplayResults(Data.Search(searchText, searchResultStart, int.Parse("0" + picSearchStar.Tag), cboSearchDistrict.SelectedIndex));
            }

        }


        private void DisplayResults(List<SearchResult> results)
        {
            // Clear existing controls
            if (results == null || results.Count == 0)
            {
                btnCaseDetail.Visible = false;
                Label noResultsLabel = new Label();
                noResultsLabel.Text = "No results found.";
                noResultsLabel.Location = new Point(10, 10);
                noResultsLabel.Size = new Size(200, 20);
                noResultsLabel.Font = new Font("Segoe UI", 14F);
                noResultsLabel.ForeColor = Color.Gray;
                resultsPanel.Controls.Add(noResultsLabel);
                return;
            } else btnCaseDetail.Visible = true;

            int yPosition = searchResultStart * (UIElements.SEARCHRESULTLABELHEIGHT + 10) + searchResultStart == 0 ? 10 : 10;
            int labelWidth = resultsPanel.Width - 30; // Account for scrollbar

            Label resultLabel;
            foreach (var result in results)
            {
                resultLabel = UIElements.CreateResultLabel(result, yPosition, labelWidth);
                resultLabel.Click += (s, e) => { ShowCase(result); };
                resultsPanel.Controls.Add(resultLabel);
                yPosition += resultLabel.Height + 10; // Add spacing between labels
            }
            resultLabel = UIElements.CreateResultLabel(null, yPosition, labelWidth);
            resultLabel.Click += (s, e) => {    // Add click event for "Get More Records"
                searchResultStart += 20;
                resultsPanel.Controls.Remove(UIElements.FindControlByName(resultsPanel, "seymour"));
                DisplayResults(Data.Search(textSearch.Text.Trim(), searchResultStart));
            };
            resultsPanel.Controls.Add(resultLabel);

            yPosition += 30;
        }

        private string getCaseValue(string attrName, SearchResult selectedCase)
        {
            if (attrName == "CaseStyle") return selectedCase.CaseStyle;
            if (attrName == "DateFiled") return selectedCase.DateFiled;
            if (attrName == "District")  return ""+selectedCase.District;
            return string.Empty;
        }

        private void tabControlCaseDetails_SelectedIndexChanged(object sender = null, EventArgs e = null)
        {
            // TAB CASE DETAILS --------------
            if (tabControlCaseDetails.SelectedTab == tabPageCaseDetails)
            {
                int yPosition = 0;
                Dictionary<int, Attributes> attributes = Data.attrList();
                Dictionary<int, string> answers = Data.getAnswers(CaseID());
                // CaseNo,,,DateFiled,CaseCategory,CaseType,SecurityGroups
                SearchResult selectedCase = (SearchResult)lblCaseNumber.Tag;
                tabPageCaseDetails.Controls.Clear();
                foreach (var ID in attributes.Keys)
                {
                    Label attrLabel = UIElements.CreateAttributeLabel(ID, attributes[ID].AttrName, yPosition, 0);
                    tabPageCaseDetails.Controls.Add(attrLabel);
                    Control attrValue = null;
                    switch (attributes[ID].AttrType) {
                        case 0: attrValue = UIElements.CreateAttributeValueLabel(ID, getCaseValue(attributes[ID].AttrName, selectedCase), yPosition, 0, tabPageCaseDetails); break;
                        case 1: attrValue = UIElements.CreateAttributeValueTextBox(ID, attributes[ID].AttrName, yPosition, tabPageCaseDetails);
                            attrValue.KeyPress += (s, ev) => { timerSave.Tag = "Answers;" + ID;
                                //timerSave.Enabled = true;
                                //MessageBox.Show($"Selected #{label.Tag}:", "Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }; break;
                        case 2: attrValue = UIElements.CreateAttributeValueComboBox(ID, attributes[ID].AttrName, yPosition, tabPageCaseDetails, attributes[ID].PossibleValues); break;
                    }
                    
                    tabPageCaseDetails.Controls.Add(attrValue);
                    yPosition += attrLabel.Height; // Add spacing between labels                    
                }
            }

            // TAB CASE NOTES ------------------
            if (tabControlCaseDetails.SelectedTab == tabPageCaseNotes)
            {
                textCaseNotes.Tag = null;
                timerSave.Tag = "CaseNotes";
                //Load from database
                Dictionary<string, string> notes = Data.readCaseNotes(CaseID());
                cboModified_Notes.Tag = notes;
                cboModified_Notes.Items.Clear();
                foreach (var modifieddate in notes.Keys)
                {
                    var item = cboModified_Notes.Items.Add(modifieddate);
                    if (modifieddate.StartsWith("*"))
                    {
                        cboModified_Notes.SelectedIndex = item;
                    }
                }
            }

            // TAB CASE HISTORY ---------------
            if (tabControlCaseDetails.SelectedTab == tabPageCaseHistory)
            {
                dataGridHistory.DataSource = Data.readCaseHistory(CaseID());
                dataGridHistory.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }

            // TAB CASE HEARINGS ---------------
            if (tabControlCaseDetails.SelectedTab == tabPageCaseEvents)
            {
                tabPageCaseEvents.Controls.Clear();
                int yPosition = 10;

                List<string> hearings = Data.Hearings(lblCaseNumber.Text);
                foreach (var hearing in hearings)
                {
                    string[] col = hearing.Split('\t');
                    Label resultLabel = UIElements.CreateLabel(yPosition, tabPageCaseEvents.Width - 36);
                    resultLabel.Text = col[4] + "  " + col[5] + "  " + col[6] + "\n" + col[7] + "\n" + col[2];
                    tabPageCaseEvents.Controls.Add(resultLabel);
                    yPosition += resultLabel.Height + 10; // Add spacing between labels
                }                
            }

            // TAB CASE FILES ---------------
            if (tabControlCaseDetails.SelectedTab == tabPageCaseFiles)
            {
                LoadSharePointFolder();
            }
        }

        private int CaseID() { return ((SearchResult)lblCaseNumber.Tag).ID; }
        private string CaseNo() { return ((SearchResult)lblCaseNumber.Tag).CaseNo; }

        private void textCaseNotes_TextChanged(object sender, EventArgs e)
        {
            if (textCaseNotes.Tag == null) {
                timerSave.Enabled = false;
                timerSave.Enabled = true;
            }
        }

        private void timerSave_Tick(object sender, EventArgs e)
        {
            timerSave.Enabled = false;
            if (("" + timerSave.Tag.ToString()).StartsWith("CaseNotes"))
            {
                Data.writeCaseNotes(CaseID(), textCaseNotes.Text);
            }
        }

        private void cboModified_Notes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModified_Notes.Tag != null)
            {
                Dictionary<string, string> notes = (Dictionary<string, string>)cboModified_Notes.Tag;
                textCaseNotes.Tag = "LOADING";
                textCaseNotes.Text = notes[cboModified_Notes.SelectedItem.ToString()];
                textCaseNotes.Tag = null;
                textCaseNotes.ReadOnly = !cboModified_Notes.SelectedItem.ToString().StartsWith("*");
            }
        }

        private void textCaseNotes_KeyDown(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < cboModified_Notes.Items.Count; i++)
                if (cboModified_Notes.Items[i].ToString().StartsWith("*")) cboModified_Notes.SelectedIndex = i;
        }

        private void MainForm_Resize(object sender = null, EventArgs e = null)
        {
            tabControlCaseDetails.Width = this.Width - 150;
            tabControlCaseDetails.Height = this.Height - 150;
            lblHorizBar1.Width = tabPageCaseNotes.Width - 10;
            textCaseNotes.Width = tabPageCaseNotes.Width - 10;
            textCaseNotes.Height = tabPageCaseNotes.Height - 45;
            foreach (Control ctrl in tabPageCaseDetails.Controls)
            {
                if (ctrl.Name.StartsWith("AttributeValue_")) ctrl.Width = UIElements.AttrValueWidth(tabPageCaseDetails);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MainForm_Resize();

            Program.StarredCases = new Dictionary<string, bool>();
            List<string> stars = Utils.readLocal("StarredCases.txt");
            foreach(string s in stars) { Program.StarredCases.Add(s, false); }
        }

        private void picSearchStar_Click(object sender, EventArgs e)
        {
            if (int.Parse("0" + picSearchStar.Tag) == 0) {
                picSearchStar.BackgroundImage = Resources.star2;
                picSearchStar.Tag = 1;
            } else {
                picSearchStar.BackgroundImage = Resources.star;
                picSearchStar.Tag = 0;
            }
        }

        private void picCaseStar_Click(object sender, EventArgs e)
        {
            if (int.Parse("0" + picSearchStar.Tag) == 0) {
                picCaseStar.BackgroundImage = Resources.star2;
                picCaseStar.Tag = 1;
                if (!Program.StarredCases.ContainsKey("" + CaseID())) Program.StarredCases.Add("" + CaseID(), true);
            } else {
                picCaseStar.BackgroundImage = Resources.star;
                picCaseStar.Tag = 0;
                if (Program.StarredCases.ContainsKey("" + CaseID())) Program.StarredCases.Remove("" + CaseID());
            }
            Utils.writeLocal("StarredCases.txt", Program.StarredCases.Keys.ToList<string>());
        }

        private void ShowCase(SearchResult selectedCase) {
            lblCaseNumber.Tag = selectedCase;
            lblCaseNumber.Text = selectedCase.CaseNo;
            picCaseStar.BackgroundImage = Program.StarredCases.ContainsKey(""+selectedCase.ID) ? Resources.star2 : Resources.star;
            tabControlCaseDetails_SelectedIndexChanged();
            navButton_Click(btnCaseDetail);
        }

        private void LoadSharePointFolder()
        {
            string sharePointUrl = "https://site.sharepoint.com/GnC/folder/" + CaseNo();
            //Check if folder exists, if not, create it
            sharePointUrl = Uri.EscapeUriString(sharePointUrl);
            webSharePoint.Navigate(sharePointUrl);
            // Alt: Install Microsoft.Web.WebView2 (NuGet package)
            //await webView21.EnsureCoreWebView2Async();
            //webView21.CoreWebView2.Navigate(sharePointUrl);
        }

        private void tabControlCaseDetails_DrawItem(object sender, DrawItemEventArgs e)
        {
            var tabPage = tabControl1.TabPages[e.Index];
            var tabRect = tabControl1.GetTabRect(e.Index);

            // Custom drawing
            if (e.State == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            }

            TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font,
                tabRect, tabPage.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}
