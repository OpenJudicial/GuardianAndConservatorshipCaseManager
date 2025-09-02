using System.Windows.Forms;

namespace GnC
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelNav;
        private System.Windows.Forms.Panel panelDashboard;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCalendar;
        private System.Windows.Forms.Button btnReport;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelNav = new System.Windows.Forms.Panel();
            this.lblSelectBar = new System.Windows.Forms.Label();
            this.btnCaseDetail = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnCalendar = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.panelDashboard = new System.Windows.Forms.Panel();
            this.picSplash = new System.Windows.Forms.PictureBox();
            this.timerSplash = new System.Windows.Forms.Timer(this.components);
            this.panelSearch = new System.Windows.Forms.Panel();
            this.cboSearchDistrict = new System.Windows.Forms.ComboBox();
            this.picSearchStar = new System.Windows.Forms.PictureBox();
            this.resultsPanel = new System.Windows.Forms.Panel();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.labelSearchBkgd = new System.Windows.Forms.Label();
            this.picSearchGo = new System.Windows.Forms.PictureBox();
            this.panelCaseDetail = new System.Windows.Forms.Panel();
            this.picCaseStar = new System.Windows.Forms.PictureBox();
            this.tabControlCaseDetails = new System.Windows.Forms.TabControl();
            this.tabPageCaseDetails = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPageCaseEvents = new System.Windows.Forms.TabPage();
            this.tabPageCaseNotes = new System.Windows.Forms.TabPage();
            this.textCaseNotes = new System.Windows.Forms.TextBox();
            this.cboModified_Notes = new System.Windows.Forms.ComboBox();
            this.lblHorizBar1 = new System.Windows.Forms.Label();
            this.tabPageCaseFiles = new System.Windows.Forms.TabPage();
            this.webSharePoint = new System.Windows.Forms.WebBrowser();
            this.tabPageCaseHistory = new System.Windows.Forms.TabPage();
            this.dataGridHistory = new System.Windows.Forms.DataGridView();
            this.lblCaseNumber = new System.Windows.Forms.Label();
            this.picCaseDetailIcon = new System.Windows.Forms.PictureBox();
            this.labelCaseDetailBkgd = new System.Windows.Forms.Label();
            this.timerSave = new System.Windows.Forms.Timer(this.components);
            this.panelNav.SuspendLayout();
            this.panelDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSplash)).BeginInit();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchStar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchGo)).BeginInit();
            this.panelCaseDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCaseStar)).BeginInit();
            this.tabControlCaseDetails.SuspendLayout();
            this.tabPageCaseDetails.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageCaseNotes.SuspendLayout();
            this.tabPageCaseFiles.SuspendLayout();
            this.tabPageCaseHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCaseDetailIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelNav
            // 
            this.panelNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panelNav.Controls.Add(this.lblSelectBar);
            this.panelNav.Controls.Add(this.btnCaseDetail);
            this.panelNav.Controls.Add(this.btnReport);
            this.panelNav.Controls.Add(this.btnCalendar);
            this.panelNav.Controls.Add(this.btnSearch);
            this.panelNav.Controls.Add(this.btnHome);
            this.panelNav.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(69, 606);
            this.panelNav.TabIndex = 1;
            // 
            // lblSelectBar
            // 
            this.lblSelectBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(184)))), ((int)(((byte)(254)))));
            this.lblSelectBar.Location = new System.Drawing.Point(0, 3);
            this.lblSelectBar.Name = "lblSelectBar";
            this.lblSelectBar.Size = new System.Drawing.Size(4, 64);
            this.lblSelectBar.TabIndex = 5;
            // 
            // btnCaseDetail
            // 
            this.btnCaseDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaseDetail.Image = global::GnC.Properties.Resources.casedetail;
            this.btnCaseDetail.Location = new System.Drawing.Point(5, 263);
            this.btnCaseDetail.Name = "btnCaseDetail";
            this.btnCaseDetail.Size = new System.Drawing.Size(64, 64);
            this.btnCaseDetail.TabIndex = 4;
            this.btnCaseDetail.Visible = false;
            this.btnCaseDetail.Click += new System.EventHandler(this.navButton_Click);
            // 
            // btnReport
            // 
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Image = global::GnC.Properties.Resources.report;
            this.btnReport.Location = new System.Drawing.Point(5, 198);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(64, 64);
            this.btnReport.TabIndex = 0;
            this.btnReport.Click += new System.EventHandler(this.navButton_Click);
            // 
            // btnCalendar
            // 
            this.btnCalendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalendar.Image = global::GnC.Properties.Resources.calendar;
            this.btnCalendar.Location = new System.Drawing.Point(5, 133);
            this.btnCalendar.Name = "btnCalendar";
            this.btnCalendar.Size = new System.Drawing.Size(64, 64);
            this.btnCalendar.TabIndex = 1;
            this.btnCalendar.Click += new System.EventHandler(this.navButton_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::GnC.Properties.Resources.search;
            this.btnSearch.Location = new System.Drawing.Point(5, 68);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(64, 64);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Click += new System.EventHandler(this.navButton_Click);
            // 
            // btnHome
            // 
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Image = global::GnC.Properties.Resources.home2;
            this.btnHome.Location = new System.Drawing.Point(5, 3);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(64, 64);
            this.btnHome.TabIndex = 3;
            this.btnHome.Click += new System.EventHandler(this.navButton_Click);
            // 
            // panelDashboard
            // 
            this.panelDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelDashboard.Controls.Add(this.picSplash);
            this.panelDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDashboard.Location = new System.Drawing.Point(69, 0);
            this.panelDashboard.Name = "panelDashboard";
            this.panelDashboard.Size = new System.Drawing.Size(943, 606);
            this.panelDashboard.TabIndex = 0;
            // 
            // picSplash
            // 
            this.picSplash.BackgroundImage = global::GnC.Properties.Resources.splash;
            this.picSplash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picSplash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picSplash.Location = new System.Drawing.Point(0, 0);
            this.picSplash.Name = "picSplash";
            this.picSplash.Size = new System.Drawing.Size(943, 606);
            this.picSplash.TabIndex = 2;
            this.picSplash.TabStop = false;
            // 
            // timerSplash
            // 
            this.timerSplash.Enabled = true;
            this.timerSplash.Interval = 1000;
            this.timerSplash.Tick += new System.EventHandler(this.timerSplash_Tick);
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelSearch.Controls.Add(this.cboSearchDistrict);
            this.panelSearch.Controls.Add(this.picSearchStar);
            this.panelSearch.Controls.Add(this.resultsPanel);
            this.panelSearch.Controls.Add(this.textSearch);
            this.panelSearch.Controls.Add(this.labelSearchBkgd);
            this.panelSearch.Controls.Add(this.picSearchGo);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSearch.Location = new System.Drawing.Point(69, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(943, 606);
            this.panelSearch.TabIndex = 2;
            this.panelSearch.Visible = false;
            // 
            // cboSearchDistrict
            // 
            this.cboSearchDistrict.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cboSearchDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchDistrict.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F);
            this.cboSearchDistrict.ForeColor = System.Drawing.Color.White;
            this.cboSearchDistrict.FormattingEnabled = true;
            this.cboSearchDistrict.Items.AddRange(new object[] {
            "All Districts",
            "District 1",
            "District 2",
            "District 3",
            "District 4",
            "District 5",
            "District 6",
            "District 7"});
            this.cboSearchDistrict.Location = new System.Drawing.Point(579, 36);
            this.cboSearchDistrict.Name = "cboSearchDistrict";
            this.cboSearchDistrict.Size = new System.Drawing.Size(194, 33);
            this.cboSearchDistrict.TabIndex = 8;
            // 
            // picSearchStar
            // 
            this.picSearchStar.BackgroundImage = global::GnC.Properties.Resources.star;
            this.picSearchStar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSearchStar.Location = new System.Drawing.Point(526, 36);
            this.picSearchStar.Name = "picSearchStar";
            this.picSearchStar.Size = new System.Drawing.Size(32, 32);
            this.picSearchStar.TabIndex = 7;
            this.picSearchStar.TabStop = false;
            this.picSearchStar.Tag = "0";
            this.picSearchStar.Click += new System.EventHandler(this.picSearchStar_Click);
            // 
            // resultsPanel
            // 
            this.resultsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsPanel.AutoScroll = true;
            this.resultsPanel.Location = new System.Drawing.Point(35, 92);
            this.resultsPanel.Name = "resultsPanel";
            this.resultsPanel.Size = new System.Drawing.Size(1109, 616);
            this.resultsPanel.TabIndex = 6;
            // 
            // textSearch
            // 
            this.textSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.textSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textSearch.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSearch.ForeColor = System.Drawing.Color.White;
            this.textSearch.Location = new System.Drawing.Point(58, 35);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(380, 32);
            this.textSearch.TabIndex = 3;
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            // 
            // labelSearchBkgd
            // 
            this.labelSearchBkgd.BackColor = System.Drawing.Color.White;
            this.labelSearchBkgd.Location = new System.Drawing.Point(56, 33);
            this.labelSearchBkgd.Name = "labelSearchBkgd";
            this.labelSearchBkgd.Size = new System.Drawing.Size(384, 36);
            this.labelSearchBkgd.TabIndex = 5;
            // 
            // picSearchGo
            // 
            this.picSearchGo.BackgroundImage = global::GnC.Properties.Resources.search;
            this.picSearchGo.Location = new System.Drawing.Point(451, 37);
            this.picSearchGo.Name = "picSearchGo";
            this.picSearchGo.Size = new System.Drawing.Size(34, 30);
            this.picSearchGo.TabIndex = 4;
            this.picSearchGo.TabStop = false;
            // 
            // panelCaseDetail
            // 
            this.panelCaseDetail.Controls.Add(this.picCaseStar);
            this.panelCaseDetail.Controls.Add(this.tabControlCaseDetails);
            this.panelCaseDetail.Controls.Add(this.lblCaseNumber);
            this.panelCaseDetail.Controls.Add(this.picCaseDetailIcon);
            this.panelCaseDetail.Controls.Add(this.labelCaseDetailBkgd);
            this.panelCaseDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCaseDetail.Location = new System.Drawing.Point(69, 0);
            this.panelCaseDetail.Name = "panelCaseDetail";
            this.panelCaseDetail.Size = new System.Drawing.Size(943, 606);
            this.panelCaseDetail.TabIndex = 8;
            this.panelCaseDetail.Visible = false;
            // 
            // picCaseStar
            // 
            this.picCaseStar.BackgroundImage = global::GnC.Properties.Resources.star;
            this.picCaseStar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCaseStar.Location = new System.Drawing.Point(456, 32);
            this.picCaseStar.Name = "picCaseStar";
            this.picCaseStar.Size = new System.Drawing.Size(31, 33);
            this.picCaseStar.TabIndex = 10;
            this.picCaseStar.TabStop = false;
            this.picCaseStar.Click += new System.EventHandler(this.picCaseStar_Click);
            // 
            // tabControlCaseDetails
            // 
            this.tabControlCaseDetails.Controls.Add(this.tabPageCaseDetails);
            this.tabControlCaseDetails.Controls.Add(this.tabPageCaseEvents);
            this.tabControlCaseDetails.Controls.Add(this.tabPageCaseNotes);
            this.tabControlCaseDetails.Controls.Add(this.tabPageCaseFiles);
            this.tabControlCaseDetails.Controls.Add(this.tabPageCaseHistory);
            this.tabControlCaseDetails.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F);
            this.tabControlCaseDetails.Location = new System.Drawing.Point(29, 85);
            this.tabControlCaseDetails.Name = "tabControlCaseDetails";
            this.tabControlCaseDetails.SelectedIndex = 0;
            this.tabControlCaseDetails.Size = new System.Drawing.Size(878, 498);
            this.tabControlCaseDetails.TabIndex = 9;
            this.tabControlCaseDetails.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControlCaseDetails_DrawItem);
            this.tabControlCaseDetails.SelectedIndexChanged += new System.EventHandler(this.tabControlCaseDetails_SelectedIndexChanged);
            // 
            // tabPageCaseDetails
            // 
            this.tabPageCaseDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabPageCaseDetails.Controls.Add(this.tabControl1);
            this.tabPageCaseDetails.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.tabPageCaseDetails.Location = new System.Drawing.Point(4, 29);
            this.tabPageCaseDetails.Name = "tabPageCaseDetails";
            this.tabPageCaseDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCaseDetails.Size = new System.Drawing.Size(870, 465);
            this.tabPageCaseDetails.TabIndex = 0;
            this.tabPageCaseDetails.Text = " Case Details ";
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F);
            this.tabControl1.Location = new System.Drawing.Point(15, 17);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(841, 432);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabPage1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(833, 396);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = " Case ";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabPage2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(833, 396);
            this.tabPage2.TabIndex = 6;
            this.tabPage2.Text = " Parties ";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabPage3.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.tabPage3.Location = new System.Drawing.Point(4, 32);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(833, 396);
            this.tabPage3.TabIndex = 7;
            this.tabPage3.Text = " Attorneys ";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabPage4.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.tabPage4.Location = new System.Drawing.Point(4, 32);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(833, 396);
            this.tabPage4.TabIndex = 8;
            this.tabPage4.Text = " Status ";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabPage5.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.tabPage5.Location = new System.Drawing.Point(4, 32);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(833, 396);
            this.tabPage5.TabIndex = 9;
            this.tabPage5.Text = " Pleadings ";
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabPage6.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.tabPage6.Location = new System.Drawing.Point(4, 32);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(833, 396);
            this.tabPage6.TabIndex = 10;
            this.tabPage6.Text = " Motions ";
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabPage7.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.tabPage7.Location = new System.Drawing.Point(4, 32);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(833, 396);
            this.tabPage7.TabIndex = 11;
            this.tabPage7.Text = " Orders ";
            // 
            // tabPage8
            // 
            this.tabPage8.AutoScroll = true;
            this.tabPage8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabPage8.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.tabPage8.Location = new System.Drawing.Point(4, 32);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(833, 396);
            this.tabPage8.TabIndex = 4;
            this.tabPage8.Text = " Hearings ";
            // 
            // tabPageCaseEvents
            // 
            this.tabPageCaseEvents.AutoScroll = true;
            this.tabPageCaseEvents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabPageCaseEvents.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.tabPageCaseEvents.Location = new System.Drawing.Point(4, 29);
            this.tabPageCaseEvents.Name = "tabPageCaseEvents";
            this.tabPageCaseEvents.Size = new System.Drawing.Size(870, 465);
            this.tabPageCaseEvents.TabIndex = 4;
            this.tabPageCaseEvents.Text = " Events ";
            // 
            // tabPageCaseNotes
            // 
            this.tabPageCaseNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabPageCaseNotes.Controls.Add(this.textCaseNotes);
            this.tabPageCaseNotes.Controls.Add(this.cboModified_Notes);
            this.tabPageCaseNotes.Controls.Add(this.lblHorizBar1);
            this.tabPageCaseNotes.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.tabPageCaseNotes.Location = new System.Drawing.Point(4, 29);
            this.tabPageCaseNotes.Name = "tabPageCaseNotes";
            this.tabPageCaseNotes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCaseNotes.Size = new System.Drawing.Size(870, 465);
            this.tabPageCaseNotes.TabIndex = 1;
            this.tabPageCaseNotes.Text = " Notes ";
            // 
            // textCaseNotes
            // 
            this.textCaseNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.textCaseNotes.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F);
            this.textCaseNotes.ForeColor = System.Drawing.Color.White;
            this.textCaseNotes.Location = new System.Drawing.Point(5, 40);
            this.textCaseNotes.Multiline = true;
            this.textCaseNotes.Name = "textCaseNotes";
            this.textCaseNotes.Size = new System.Drawing.Size(727, 331);
            this.textCaseNotes.TabIndex = 4;
            this.textCaseNotes.Tag = "CaseNotes";
            this.textCaseNotes.TextChanged += new System.EventHandler(this.textCaseNotes_TextChanged);
            this.textCaseNotes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textCaseNotes_KeyDown);
            // 
            // cboModified_Notes
            // 
            this.cboModified_Notes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cboModified_Notes.Dock = System.Windows.Forms.DockStyle.Right;
            this.cboModified_Notes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModified_Notes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboModified_Notes.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F);
            this.cboModified_Notes.ForeColor = System.Drawing.Color.White;
            this.cboModified_Notes.FormattingEnabled = true;
            this.cboModified_Notes.Items.AddRange(new object[] {
            "Current"});
            this.cboModified_Notes.Location = new System.Drawing.Point(692, 3);
            this.cboModified_Notes.Name = "cboModified_Notes";
            this.cboModified_Notes.Size = new System.Drawing.Size(175, 28);
            this.cboModified_Notes.TabIndex = 3;
            this.cboModified_Notes.SelectedIndexChanged += new System.EventHandler(this.cboModified_Notes_SelectedIndexChanged);
            // 
            // lblHorizBar1
            // 
            this.lblHorizBar1.BackColor = System.Drawing.Color.White;
            this.lblHorizBar1.Location = new System.Drawing.Point(5, 34);
            this.lblHorizBar1.Name = "lblHorizBar1";
            this.lblHorizBar1.Size = new System.Drawing.Size(728, 2);
            this.lblHorizBar1.TabIndex = 2;
            // 
            // tabPageCaseFiles
            // 
            this.tabPageCaseFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabPageCaseFiles.Controls.Add(this.webSharePoint);
            this.tabPageCaseFiles.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.tabPageCaseFiles.Location = new System.Drawing.Point(4, 29);
            this.tabPageCaseFiles.Name = "tabPageCaseFiles";
            this.tabPageCaseFiles.Size = new System.Drawing.Size(870, 465);
            this.tabPageCaseFiles.TabIndex = 3;
            this.tabPageCaseFiles.Text = " Files ";
            // 
            // webSharePoint
            // 
            this.webSharePoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webSharePoint.Location = new System.Drawing.Point(0, 0);
            this.webSharePoint.MinimumSize = new System.Drawing.Size(20, 20);
            this.webSharePoint.Name = "webSharePoint";
            this.webSharePoint.Size = new System.Drawing.Size(870, 465);
            this.webSharePoint.TabIndex = 0;
            this.webSharePoint.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // tabPageCaseHistory
            // 
            this.tabPageCaseHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabPageCaseHistory.Controls.Add(this.dataGridHistory);
            this.tabPageCaseHistory.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.tabPageCaseHistory.Location = new System.Drawing.Point(4, 29);
            this.tabPageCaseHistory.Name = "tabPageCaseHistory";
            this.tabPageCaseHistory.Size = new System.Drawing.Size(870, 465);
            this.tabPageCaseHistory.TabIndex = 5;
            this.tabPageCaseHistory.Text = " History ";
            // 
            // dataGridHistory
            // 
            this.dataGridHistory.AllowUserToAddRows = false;
            this.dataGridHistory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.dataGridHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridHistory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dataGridHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridHistory.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridHistory.Location = new System.Drawing.Point(0, 0);
            this.dataGridHistory.Name = "dataGridHistory";
            this.dataGridHistory.ReadOnly = true;
            this.dataGridHistory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridHistory.RowHeadersVisible = false;
            this.dataGridHistory.RowHeadersWidth = 51;
            this.dataGridHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridHistory.Size = new System.Drawing.Size(870, 465);
            this.dataGridHistory.TabIndex = 1;
            // 
            // lblCaseNumber
            // 
            this.lblCaseNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblCaseNumber.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaseNumber.ForeColor = System.Drawing.Color.White;
            this.lblCaseNumber.Location = new System.Drawing.Point(60, 36);
            this.lblCaseNumber.Name = "lblCaseNumber";
            this.lblCaseNumber.Size = new System.Drawing.Size(380, 27);
            this.lblCaseNumber.TabIndex = 8;
            this.lblCaseNumber.Tag = "";
            this.lblCaseNumber.Text = "CR-31013-130";
            // 
            // picCaseDetailIcon
            // 
            this.picCaseDetailIcon.BackgroundImage = global::GnC.Properties.Resources.casedetail;
            this.picCaseDetailIcon.Location = new System.Drawing.Point(26, 33);
            this.picCaseDetailIcon.Name = "picCaseDetailIcon";
            this.picCaseDetailIcon.Size = new System.Drawing.Size(28, 33);
            this.picCaseDetailIcon.TabIndex = 7;
            this.picCaseDetailIcon.TabStop = false;
            // 
            // labelCaseDetailBkgd
            // 
            this.labelCaseDetailBkgd.BackColor = System.Drawing.Color.White;
            this.labelCaseDetailBkgd.Location = new System.Drawing.Point(58, 34);
            this.labelCaseDetailBkgd.Name = "labelCaseDetailBkgd";
            this.labelCaseDetailBkgd.Size = new System.Drawing.Size(384, 31);
            this.labelCaseDetailBkgd.TabIndex = 6;
            // 
            // timerSave
            // 
            this.timerSave.Interval = 2000;
            this.timerSave.Tick += new System.EventHandler(this.timerSave_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1012, 606);
            this.Controls.Add(this.panelCaseDetail);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelDashboard);
            this.Controls.Add(this.panelNav);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guardianship & Conservatorship Case Management System";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panelNav.ResumeLayout(false);
            this.panelDashboard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSplash)).EndInit();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchStar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchGo)).EndInit();
            this.panelCaseDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCaseStar)).EndInit();
            this.tabControlCaseDetails.ResumeLayout(false);
            this.tabPageCaseDetails.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageCaseNotes.ResumeLayout(false);
            this.tabPageCaseNotes.PerformLayout();
            this.tabPageCaseFiles.ResumeLayout(false);
            this.tabPageCaseHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCaseDetailIcon)).EndInit();
            this.ResumeLayout(false);

        }

        private void ConfigureNavButton(System.Windows.Forms.Button btn, string name, System.Drawing.Image img, int top)
        {
            btn.Name = name;
            btn.Image = img;
            btn.Size = new System.Drawing.Size(80, 60);
            btn.Location = new System.Drawing.Point(0, top);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            btn.ForeColor = System.Drawing.Color.White;
            btn.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            btn.Click += new System.EventHandler(this.navButton_Click);
            this.panelNav.Controls.Add(btn);
        }

        private Label lblSelectBar;
        private Button btnCaseDetail;
        private PictureBox picSplash;
        private Timer timerSplash;
        private Panel panelSearch;
        private Label labelSearchBkgd;
        private PictureBox picSearchGo;
        private TextBox textSearch;
        private Panel resultsPanel;
        private Panel panelCaseDetail;
        private TabControl tabControlCaseDetails;
        private TabPage tabPageCaseDetails;
        private TabPage tabPageCaseNotes;
        private TabPage tabPageCaseFiles;
        private Label lblCaseNumber;
        private PictureBox picCaseDetailIcon;
        private Label labelCaseDetailBkgd;
        private TabPage tabPageCaseEvents;
        private ComboBox cboModified_Notes;
        private Label lblHorizBar1;
        private TextBox textCaseNotes;
        private Timer timerSave;
        private TabPage tabPageCaseHistory;
        private DataGridView dataGridHistory;
        private PictureBox picSearchStar;
        private ComboBox cboSearchDistrict;
        private PictureBox picCaseStar;
        private WebBrowser webSharePoint;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private TabPage tabPage7;
        private TabPage tabPage8;
    }
}


