using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Win32;

namespace Error_file_reader
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
    /// 

   

	public class MainWindow : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox snBox;
        private System.Windows.Forms.Button searchBtn;
		private System.Windows.Forms.TextBox sourceDirBox;
        private System.Windows.Forms.Button sourceDirBtn;
		private System.Windows.Forms.TabPage mainPage;
        private System.Windows.Forms.TabPage errorPage;
        private System.Windows.Forms.ListBox aplBox1;
		private System.Windows.Forms.TabControl tabControl;        
        private Label label2;
        private ListBox aplBox2;
        private Label label3;
        private Label label4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.Container components = null;
        private GroupBox groupBox1;
        private Label endLabel;
        private Label startLabel;
        private Label label5;
        private Button openErrBtn;
        private Button openAplBtn;        
        private ListView groupView;
        private TabPage selectPage;
        private Button showLogBtn;
        private ColumnHeader Failures;
        private ColumnHeader timeOfFailure;
        private ColumnHeader placeOfFailure;
        private System.Windows.Forms.ListBox errBox;        
        private TabPage cookBook;
        private GroupBox groupBox2;
        private Button cbookBtn;
        private TextBox cookView_componentName;
        private Label versionInfoBox;
        private Chart chart1;
        private ListView cookView;
        private ColumnHeader componentName;
        private ColumnHeader notes;
        private TextBox cookView_notes;
        private Label label7;
        private Label label6;
        
        ArrayList foundErrFiles = new ArrayList();
        ArrayList aplFoundStream = new ArrayList();
        ArrayList foundLogFiles = new ArrayList();
        ArrayList cookArray = new ArrayList();
        ArrayList logArray = new ArrayList();
        string extractedWordFromLogrow, selectedLogFile, selectedLogFileName, aplFound, errFile, testStep, cookFileName = String.Empty;
        private ListView selectErrorView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        

		public MainWindow()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.snBox = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.sourceDirBox = new System.Windows.Forms.TextBox();
            this.sourceDirBtn = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.mainPage = new System.Windows.Forms.TabPage();
            this.groupView = new System.Windows.Forms.ListView();
            this.Failures = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.placeOfFailure = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeOfFailure = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.selectPage = new System.Windows.Forms.TabPage();
            this.showLogBtn = new System.Windows.Forms.Button();
            this.errorPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.openErrBtn = new System.Windows.Forms.Button();
            this.openAplBtn = new System.Windows.Forms.Button();
            this.endLabel = new System.Windows.Forms.Label();
            this.startLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.aplBox2 = new System.Windows.Forms.ListBox();
            this.errBox = new System.Windows.Forms.ListBox();
            this.aplBox1 = new System.Windows.Forms.ListBox();
            this.cookBook = new System.Windows.Forms.TabPage();
            this.cookView = new System.Windows.Forms.ListView();
            this.componentName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.notes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.versionInfoBox = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cookView_notes = new System.Windows.Forms.TextBox();
            this.cbookBtn = new System.Windows.Forms.Button();
            this.cookView_componentName = new System.Windows.Forms.TextBox();
            this.selectErrorView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl.SuspendLayout();
            this.mainPage.SuspendLayout();
            this.selectPage.SuspendLayout();
            this.errorPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.cookBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter serial number (SN):";
            // 
            // snBox
            // 
            this.snBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.snBox.Location = new System.Drawing.Point(3, 38);
            this.snBox.MaxLength = 10;
            this.snBox.Name = "snBox";
            this.snBox.Size = new System.Drawing.Size(669, 44);
            this.snBox.TabIndex = 1;
            this.snBox.TextChanged += new System.EventHandler(this.snBox_TextChanged);
            this.snBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.snBox_KeyDown);
            // 
            // searchBtn
            // 
            this.searchBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.searchBtn.Location = new System.Drawing.Point(680, 38);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(282, 44);
            this.searchBtn.TabIndex = 2;
            this.searchBtn.Text = "Search!";
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // sourceDirBox
            // 
            this.sourceDirBox.Location = new System.Drawing.Point(6, 407);
            this.sourceDirBox.Name = "sourceDirBox";
            this.sourceDirBox.Size = new System.Drawing.Size(875, 20);
            this.sourceDirBox.TabIndex = 4;
            // 
            // sourceDirBtn
            // 
            this.sourceDirBtn.Location = new System.Drawing.Point(887, 404);
            this.sourceDirBtn.Name = "sourceDirBtn";
            this.sourceDirBtn.Size = new System.Drawing.Size(75, 23);
            this.sourceDirBtn.TabIndex = 5;
            this.sourceDirBtn.Text = "Open Folder";
            this.sourceDirBtn.Click += new System.EventHandler(this.sourceDirBtn_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.mainPage);
            this.tabControl.Controls.Add(this.selectPage);
            this.tabControl.Controls.Add(this.errorPage);
            this.tabControl.Controls.Add(this.cookBook);
            this.tabControl.Location = new System.Drawing.Point(8, 8);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(987, 456);
            this.tabControl.TabIndex = 7;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);
            // 
            // mainPage
            // 
            this.mainPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mainPage.Controls.Add(this.groupView);
            this.mainPage.Controls.Add(this.label5);
            this.mainPage.Controls.Add(this.searchBtn);
            this.mainPage.Controls.Add(this.snBox);
            this.mainPage.Controls.Add(this.sourceDirBtn);
            this.mainPage.Controls.Add(this.label1);
            this.mainPage.Controls.Add(this.sourceDirBox);
            this.mainPage.Location = new System.Drawing.Point(4, 22);
            this.mainPage.Name = "mainPage";
            this.mainPage.Size = new System.Drawing.Size(979, 430);
            this.mainPage.TabIndex = 0;
            this.mainPage.Text = "Main Page";
            // 
            // groupView
            // 
            this.groupView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Failures,
            this.placeOfFailure,
            this.timeOfFailure});
            this.groupView.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupView.FullRowSelect = true;
            this.groupView.GridLines = true;
            this.groupView.Location = new System.Drawing.Point(6, 113);
            this.groupView.Name = "groupView";
            this.groupView.Size = new System.Drawing.Size(951, 277);
            this.groupView.TabIndex = 10;
            this.groupView.UseCompatibleStateImageBehavior = false;
            this.groupView.View = System.Windows.Forms.View.Details;
            this.groupView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.groupView_MouseDoubleClick);
            // 
            // Failures
            // 
            this.Failures.Text = "Failures";
            this.Failures.Width = 578;
            // 
            // placeOfFailure
            // 
            this.placeOfFailure.Text = "Place";
            this.placeOfFailure.Width = 160;
            // 
            // timeOfFailure
            // 
            this.timeOfFailure.Text = "Time";
            this.timeOfFailure.Width = 210;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Failure(s):";
            // 
            // selectPage
            // 
            this.selectPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.selectPage.Controls.Add(this.selectErrorView);
            this.selectPage.Controls.Add(this.showLogBtn);
            this.selectPage.Location = new System.Drawing.Point(4, 22);
            this.selectPage.Name = "selectPage";
            this.selectPage.Padding = new System.Windows.Forms.Padding(3);
            this.selectPage.Size = new System.Drawing.Size(979, 430);
            this.selectPage.TabIndex = 2;
            this.selectPage.Text = "Select error";
            // 
            // showLogBtn
            // 
            this.showLogBtn.Location = new System.Drawing.Point(6, 401);
            this.showLogBtn.Name = "showLogBtn";
            this.showLogBtn.Size = new System.Drawing.Size(967, 23);
            this.showLogBtn.TabIndex = 12;
            this.showLogBtn.Text = "Show Log";
            this.showLogBtn.UseVisualStyleBackColor = true;
            this.showLogBtn.Click += new System.EventHandler(this.showLogBtn_Click);
            // 
            // errorPage
            // 
            this.errorPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.errorPage.Controls.Add(this.groupBox1);
            this.errorPage.Location = new System.Drawing.Point(4, 22);
            this.errorPage.Name = "errorPage";
            this.errorPage.Size = new System.Drawing.Size(979, 430);
            this.errorPage.TabIndex = 1;
            this.errorPage.Text = "Show Error";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.openErrBtn);
            this.groupBox1.Controls.Add(this.openAplBtn);
            this.groupBox1.Controls.Add(this.endLabel);
            this.groupBox1.Controls.Add(this.startLabel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.aplBox2);
            this.groupBox1.Controls.Add(this.errBox);
            this.groupBox1.Controls.Add(this.aplBox1);
            this.groupBox1.Location = new System.Drawing.Point(10, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(964, 401);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "JTAG";
            // 
            // openErrBtn
            // 
            this.openErrBtn.Location = new System.Drawing.Point(6, 221);
            this.openErrBtn.Name = "openErrBtn";
            this.openErrBtn.Size = new System.Drawing.Size(946, 23);
            this.openErrBtn.TabIndex = 11;
            this.openErrBtn.Text = "Open ERR file";
            this.openErrBtn.UseVisualStyleBackColor = true;
            this.openErrBtn.Click += new System.EventHandler(this.openErrBtn_Click);
            // 
            // openAplBtn
            // 
            this.openAplBtn.Location = new System.Drawing.Point(9, 372);
            this.openAplBtn.Name = "openAplBtn";
            this.openAplBtn.Size = new System.Drawing.Size(946, 23);
            this.openAplBtn.TabIndex = 10;
            this.openAplBtn.Text = "Open APL file";
            this.openAplBtn.UseVisualStyleBackColor = true;
            this.openAplBtn.Click += new System.EventHandler(this.openAplBtn_Click);
            // 
            // endLabel
            // 
            this.endLabel.AutoSize = true;
            this.endLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.endLabel.Location = new System.Drawing.Point(568, 256);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(14, 13);
            this.endLabel.TabIndex = 9;
            this.endLabel.Text = "0";
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startLabel.Location = new System.Drawing.Point(105, 256);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(14, 13);
            this.startLabel.TabIndex = 8;
            this.startLabel.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Vectors:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(475, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Vector End Point:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Vector Start Point:";
            // 
            // aplBox2
            // 
            this.aplBox2.HorizontalScrollbar = true;
            this.aplBox2.Location = new System.Drawing.Point(478, 272);
            this.aplBox2.Name = "aplBox2";
            this.aplBox2.Size = new System.Drawing.Size(477, 95);
            this.aplBox2.TabIndex = 3;
            // 
            // errBox
            // 
            this.errBox.Location = new System.Drawing.Point(6, 31);
            this.errBox.Name = "errBox";
            this.errBox.Size = new System.Drawing.Size(946, 186);
            this.errBox.TabIndex = 2;
            this.errBox.SelectedIndexChanged += new System.EventHandler(this.errBox_SelectedIndexChanged);
            // 
            // aplBox1
            // 
            this.aplBox1.HorizontalScrollbar = true;
            this.aplBox1.Location = new System.Drawing.Point(9, 272);
            this.aplBox1.Name = "aplBox1";
            this.aplBox1.Size = new System.Drawing.Size(463, 95);
            this.aplBox1.TabIndex = 1;
            // 
            // cookBook
            // 
            this.cookBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cookBook.Controls.Add(this.cookView);
            this.cookBook.Controls.Add(this.chart1);
            this.cookBook.Controls.Add(this.versionInfoBox);
            this.cookBook.Controls.Add(this.groupBox2);
            this.cookBook.Location = new System.Drawing.Point(4, 22);
            this.cookBook.Name = "cookBook";
            this.cookBook.Padding = new System.Windows.Forms.Padding(3);
            this.cookBook.Size = new System.Drawing.Size(979, 430);
            this.cookBook.TabIndex = 3;
            this.cookBook.Text = "Cook Book";
            // 
            // cookView
            // 
            this.cookView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.componentName,
            this.notes});
            this.cookView.GridLines = true;
            this.cookView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.cookView.Location = new System.Drawing.Point(12, 117);
            this.cookView.MultiSelect = false;
            this.cookView.Name = "cookView";
            this.cookView.Size = new System.Drawing.Size(344, 303);
            this.cookView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.cookView.TabIndex = 4;
            this.cookView.UseCompatibleStateImageBehavior = false;
            this.cookView.View = System.Windows.Forms.View.Details;
            // 
            // componentName
            // 
            this.componentName.Text = "Component Name";
            this.componentName.Width = 100;
            // 
            // notes
            // 
            this.notes.Text = "Notes";
            this.notes.Width = 240;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(362, 117);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(605, 303);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // versionInfoBox
            // 
            this.versionInfoBox.AutoSize = true;
            this.versionInfoBox.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.versionInfoBox.Location = new System.Drawing.Point(389, 14);
            this.versionInfoBox.Name = "versionInfoBox";
            this.versionInfoBox.Size = new System.Drawing.Size(200, 30);
            this.versionInfoBox.TabIndex = 1;
            this.versionInfoBox.Text = "Version - Failure";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cookView_notes);
            this.groupBox2.Controls.Add(this.cbookBtn);
            this.groupBox2.Controls.Add(this.cookView_componentName);
            this.groupBox2.Location = new System.Drawing.Point(6, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(967, 64);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Send to Cook Book";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(165, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Notes:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Component Name:";
            // 
            // cookView_notes
            // 
            this.cookView_notes.Location = new System.Drawing.Point(168, 29);
            this.cookView_notes.Name = "cookView_notes";
            this.cookView_notes.Size = new System.Drawing.Size(712, 20);
            this.cookView_notes.TabIndex = 2;
            // 
            // cbookBtn
            // 
            this.cbookBtn.Location = new System.Drawing.Point(886, 26);
            this.cbookBtn.Name = "cbookBtn";
            this.cbookBtn.Size = new System.Drawing.Size(75, 23);
            this.cbookBtn.TabIndex = 1;
            this.cbookBtn.Text = "OK";
            this.cbookBtn.UseVisualStyleBackColor = true;
            this.cbookBtn.Click += new System.EventHandler(this.cbookBtn_Click);
            // 
            // cookView_componentName
            // 
            this.cookView_componentName.Location = new System.Drawing.Point(6, 29);
            this.cookView_componentName.Name = "cookView_componentName";
            this.cookView_componentName.Size = new System.Drawing.Size(156, 20);
            this.cookView_componentName.TabIndex = 0;
            // 
            // selectErrorView
            // 
            this.selectErrorView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.selectErrorView.ForeColor = System.Drawing.SystemColors.WindowText;
            this.selectErrorView.FullRowSelect = true;
            this.selectErrorView.GridLines = true;
            this.selectErrorView.Location = new System.Drawing.Point(6, 6);
            this.selectErrorView.Name = "selectErrorView";
            this.selectErrorView.Size = new System.Drawing.Size(967, 380);
            this.selectErrorView.TabIndex = 14;
            this.selectErrorView.UseCompatibleStateImageBehavior = false;
            this.selectErrorView.View = System.Windows.Forms.View.Details;
            this.selectErrorView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.selectErrorView_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Test-Step";
            this.columnHeader1.Width = 578;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Limits";
            this.columnHeader2.Width = 160;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Result";
            this.columnHeader3.Width = 223;
            // 
            // MainWindow
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(998, 476);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Debug Tool by Z. Kazintsi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.tabControl.ResumeLayout(false);
            this.mainPage.ResumeLayout(false);
            this.mainPage.PerformLayout();
            this.selectPage.ResumeLayout(false);
            this.errorPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.cookBook.ResumeLayout(false);
            this.cookBook.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainWindow());
		}

        // 1. Click on 'Search'

        private void searchBtn_Click(object sender, System.EventArgs e)
        {
            if (snBox.Text.Length > 0)
            {
                groupView.Items.Clear();
                foundLogFiles.Clear();
                clearBoxes();
                try
                {
                    recurseSearch(@sourceDirBox.Text + "\\LOG", "*" + snBox.Text + "*.log");
                    //kiesesek betoltese az elso oldalra
                    foreach (string log in foundLogFiles)
                    {
                        string logRow = String.Empty;
                        using (StreamReader sr = new StreamReader(log))
                        {
                            logRow = sr.ReadLine();
                        }

                        groupView.Items.Add(new ListViewItem(new string[] { log, logRow, File.GetCreationTime(log).ToString() }));
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }     

        // 2. Searching files in directories

		private void recurseSearch(string path, string fileName)
		{            
			try
			{
				foreach (string fName in Directory.GetFiles(path, fileName))
				{
                    //File.Copy(fName, Path.GetTempPath()+"",true); lementes a Temp-be hogy ne terhelodjon a szerver
					//foundFiles.Add(fName);
                    if (Path.GetExtension(fName) == ".log")
                    {
                        foundLogFiles.Add(fName);
                    }
                    if (Path.GetExtension(fName) == ".err")
                    {
                        foundErrFiles.Add(fName);
                    }
				}
				foreach (string pName in Directory.GetDirectories(path))
				{
					recurseSearch(pName,fileName );//rekurziv
				}				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        // 3. Double-clicking will search related error files and open next tab

        private void groupView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int groupIndex = 0;
            var index = groupView.SelectedIndices;

            foreach (int i in index)
            {
                groupIndex = i;
            }
            if (groupIndex >= 0)
            {
                selectedLogFile = foundLogFiles[groupIndex].ToString();
                selectedLogFileName = Path.GetFileNameWithoutExtension(foundLogFiles[groupIndex].ToString());

                foundErrFiles.Clear();//in-memory               
                recurseSearch(@sourceDirBox.Text, selectedLogFileName + "*.err");//reload
                uploadLogBox();
                this.tabControl.SelectedIndex = 1;
            }
        }

        // 4. Filling up the 2nd tab (helper for 3.)
        private void uploadLogBox()
        {
            logArray.Clear();
            selectErrorView.Items.Clear();
            string subtest = String.Empty;
            string limits = String.Empty;
            string result = String.Empty;
            try
            {
                using (FileStream fs = new FileStream(selectedLogFile, FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string logRow = String.Empty;
                        while ((logRow = sr.ReadLine()) != null)
                        {
                            if ((logRow != "") && (logRow[0] == '-'))
                            {
                                logArray.Clear();
                                subtest = "";
                                limits = "";
                                result = "";
                            }
                            else if (!Regex.IsMatch(logRow, "For Testing The Board with VIP Manger", RegexOptions.IgnoreCase) && !Regex.IsMatch(logRow, "Sorensen", RegexOptions.IgnoreCase))
                            {
                                if (Regex.IsMatch(logRow, "Subtest:", RegexOptions.IgnoreCase))
                                {
                                    subtest = logRow.Substring(9);
                                }
                                else if (Regex.IsMatch(logRow, "Limits of the test:", RegexOptions.IgnoreCase))
                                {
                                    limits = logRow.Substring(20);
                                }
                                else if (Regex.IsMatch(logRow, "Result for UUT", RegexOptions.IgnoreCase))
                                {
                                    result = logRow.Substring(39).Split(new char[]{'-'}).FirstOrDefault().Trim();
                                }
                                logArray.Add(logRow);
                            }

                            if ((Regex.IsMatch(logRow, "FAILED", RegexOptions.IgnoreCase)) && (!Regex.IsMatch(logRow, "Blank Check Test", RegexOptions.IgnoreCase)))
                            {
                                selectErrorView.Items.Add(new ListViewItem(new string[] { subtest, limits, result }));                                
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
		// 5. Double clicking in 2nd tab will extract the found error files, and open 3rd tab

        private void selectErrorView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            clearBoxes();            

            int errIndex = 0;
            var index = selectErrorView.SelectedIndices;// multi-selected lines

            foreach (int i in index)
            {
                errIndex = i;
            }
            if (errIndex >= 0)
            {
                //extract subtest from selectErrorView
                cookFileName = selectErrorView.Items[errIndex].SubItems[0].Text;//1st column (subtest); used for cookbook
                testStep = selectErrorView.Items[errIndex].SubItems[2].Text; // 3rd column (result); used to search .err and .apl files                
            }

            uploadErrBox();
            openAplBtn.Text = aplFound;
            openErrBtn.Text = errFile;
            this.tabControl.SelectedIndex = 2;
        }

        private void uploadErrBox()
        {
            try
            {
                foreach (string file in foundErrFiles)
                {
                    
                    if (Regex.IsMatch(file, selectedLogFileName, RegexOptions.IgnoreCase) && Regex.IsMatch(file, /*extractedWordFromLogrow*/ testStep, RegexOptions.IgnoreCase))
                    {
                        errFile = file;
                        using (FileStream fs = new FileStream(file, FileMode.Open))
                        {
                            using (StreamReader sr = new StreamReader(fs))
                            {
                                string s = String.Empty;

                                while ((s = sr.ReadLine()) != null)
                                {
                                    if (Regex.IsMatch(s, "VECTOR", RegexOptions.IgnoreCase))
                                    {
                                        errBox.Items.Add(s);
                                    }
                                }
                            }
                        }
                        string[] aplFilesArray;
                        aplFilesArray = Directory.GetFiles(String.Concat(Path.GetDirectoryName(file), @"\APL"));//osszes apl file a konyvtarban
                        string[] fileNameItems = Path.GetFileName(file).Split('-');
                        string aplToFind = Path.GetFileNameWithoutExtension(fileNameItems.Last());//pl. DDR2_1gb3

                        foreach (string aplFile in aplFilesArray)
                        {
                            if (Path.GetFileNameWithoutExtension(aplFile).ToLower() == aplToFind.ToLower())
                                aplFound = aplFile;
                        }
                        
                        if (File.Exists(aplFound))
                        {
                            using (FileStream fs = new FileStream(aplFound, FileMode.Open))
                            {
                                using (StreamReader sr = new StreamReader(fs))
                                {
                                    string s = String.Empty;

                                    while ((s = sr.ReadLine()) != null)
                                    {
                                        aplFoundStream.Add(s);//fajl beolvasasa tombbe
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        // 6. When the user select an extracted error (called "Vector") - fill up APL boxes

        private void errBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                aplBox1.Items.Clear();
                aplBox2.Items.Clear();
                string vectorRow = errBox.SelectedItem.ToString();
                //Console.WriteLine(vectorRow);
                string[] vectorRowItems = vectorRow.Split(' ');
                string vectorStartPoint = String.Empty;
                for (int i = 1; i < vectorRowItems.Length; ++i)//megkeressuk a legelso elemet (a "VECTOR"-t kihagyjuk)
                    if (vectorRowItems[i].Length > 0)
                    {
                        vectorStartPoint = vectorRowItems[i];
                        break;
                    }
                startLabel.Text = vectorStartPoint;
                string vectorEndPoint = vectorRow.Split(' ').Last();
                endLabel.Text = vectorEndPoint;

                foreach (string row in aplFoundStream)
                {
                    string[] rowItems = row.Split(' ');
                    foreach (string rowItem in rowItems)
                    {
                        if (rowItem == vectorStartPoint && Regex.IsMatch(row,"row,column") )
                        {
                            aplBox1.Items.Add(row);
                        }
                        if (rowItem == vectorEndPoint && Regex.IsMatch(row, "row,column"))
                        {
                            aplBox2.Items.Add(row);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }		

        // Helper for the buttons

		private void fileOpener (string file)
		{
			try
			{
				Process.Start(file);				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}			
		}

        // Clear, before next search

        private void clearBoxes()
        {          
            errBox.Items.Clear();
            aplBox1.Items.Clear();
            aplBox2.Items.Clear();            
        }

		private void sourceDirBtn_Click(object sender, System.EventArgs e)//kinyitja a szerveren a konyvtarat
		{
			fileOpener(sourceDirBox.Text);			
		}

		private void snBox_TextChanged(object sender, System.EventArgs e)//magatol megnyomja a gombot, ha SN beszkennelodik
		{
			if (snBox.TextLength == snBox.MaxLength)
			{
				searchBtn.PerformClick();
			}
		}	

        private void snBox_KeyDown(object sender, KeyEventArgs e) //ENTER
        {
            if (e.KeyCode == Keys.Enter)
                searchBtn.PerformClick();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)//biztos bezarja?
        {
            if (MessageBox.Show("Close Window?", "Close", MessageBoxButtons.YesNo) != DialogResult.Yes)
                e.Cancel = true;
        }

        private void showLogBtn_Click(object sender, EventArgs e)
        {
            fileOpener(selectedLogFile);
        }

        private void openErrBtn_Click(object sender, EventArgs e)
        {
            fileOpener(errFile);
        }

        private void openAplBtn_Click(object sender, EventArgs e)
        {
            fileOpener(aplFound);
        }

        string pn = String.Empty;

        private void cbookBtn_Click(object sender, EventArgs e)
        {
            if (cookView_componentName.Text.Length > 0)
            {
                try
                {
                    string cookDir = sourceDirBox.Text + "\\COOKBOOK\\" + pn;
                    Directory.CreateDirectory(cookDir);
                    using (StreamWriter file = new StreamWriter(cookDir + "\\" + /*extractedWordFromLogrow*/ cookFileName + ".cook", true))
                    {
                        file.WriteLine(cookView_componentName.Text.ToUpper() +","+cookView_notes.Text);
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }

                readCook();
            }
            else
            {
                MessageBox.Show("Enter the Component's name!");
            }

        }
        
        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == 3)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(selectedLogFile))
                    {
                        pn = sr.ReadLine();
                        pn = sr.ReadLine();
                    }
                    versionInfoBox.Text = pn + " - " + /*extractedWordFromLogrow*/ cookFileName;                    
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }

                readCook();
            }
        }

        private void readCook()
        {
            cookView.Items.Clear();
            cookArray.Clear();
            try
            {
                using (StreamReader sr = new StreamReader(sourceDirBox.Text + "\\COOKBOOK\\" + pn + "\\" + /*extractedWordFromLogrow*/ cookFileName + ".cook"))
                {
                    string row = String.Empty;
                    while ((row = sr.ReadLine()) != null)
                    {
                        //cookList.Items.Add(row);
                        string extracted_compName = row.Split(new char[]{','}).FirstOrDefault();
                        string extracted_notes = row.Split(new char[] { ',' }).LastOrDefault();
                        // szerkeszteni
                        cookArray.Add(extracted_compName);
                        cookView.Items.Add(new ListViewItem(new string[] { extracted_compName, extracted_notes }));
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            updateChart();
        }
        
        private void updateChart()
        {
            chart1.Series.Clear();
            chart1.ResetAutoValues();

            var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Series1",
                Color = System.Drawing.Color.Blue,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Column
            };

            this.chart1.Series.Add(series1);

            var result = cookArray.ToArray().GroupBy(x => x).Select(x => new { Name = x.Key, Times = x.Count() }).ToArray();

            for (int i = 0; i < result.Count(); ++i)
            {
                series1.Points.Add(result[i].Times);
                series1.Points[i].AxisLabel = result[i].Name.ToString() + " (" + result[i].Times + ")";
            }

            chart1.Invalidate();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            string compName = Convert.ToString(Registry.GetValue(@"HKEY_CURRENT_USER\Volatile Environment", "LOGONSERVER", ""));
            if (compName == "\\\\BLACKEDITION")
            {
                sourceDirBox.Text = @"E:\ERR_FILES";
            }
            else
            {
                sourceDirBox.Text = "\\\\192.168.150.2\\c$\\ERR_FILES";
            }
        }

               
	}
}