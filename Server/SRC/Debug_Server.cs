using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.IO;
using System.Text;
using System.Linq;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace FileMonitor
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.Button startBtn;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button stopBtn;
		private System.ComponentModel.IContainer components;
        Settings1 set = Settings1.Default;
		private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.Button copyAPLBtn;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ListBox listBox2;
        private Label label3;
        private Label label4;
		private System.Windows.Forms.ListBox listBox1;
        int monHeight, monWidth;
        Int64 sn;
        private int fileCounter;
        bool logfileCopied = false;


		public Form1()
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

        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.startBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.stopBtn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.copyAPLBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "File Monitor";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(104, 219);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "Start";
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // stopBtn
            // 
            this.stopBtn.Enabled = false;
            this.stopBtn.Location = new System.Drawing.Point(216, 219);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(75, 23);
            this.stopBtn.TabIndex = 1;
            this.stopBtn.Text = "Stop";
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // listBox1
            // 
            this.listBox1.ContextMenu = this.contextMenu1;
            this.listBox1.Location = new System.Drawing.Point(12, 40);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(387, 173);
            this.listBox1.TabIndex = 5;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 249);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(792, 22);
            this.statusBar1.TabIndex = 9;
            this.statusBar1.Text = "Waiting...";
            // 
            // copyAPLBtn
            // 
            this.copyAPLBtn.Location = new System.Drawing.Point(536, 219);
            this.copyAPLBtn.Name = "copyAPLBtn";
            this.copyAPLBtn.Size = new System.Drawing.Size(136, 23);
            this.copyAPLBtn.TabIndex = 17;
            this.copyAPLBtn.Text = "Copy APL files";
            this.copyAPLBtn.Click += new System.EventHandler(this.copyAPLBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(792, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.settingsToolStripMenuItem.Text = "Settings...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // listBox2
            // 
            this.listBox2.ContextMenu = this.contextMenu1;
            this.listBox2.Location = new System.Drawing.Point(405, 40);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(371, 173);
            this.listBox2.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Files to monitor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(402, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Last modified date:";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 271);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.copyAPLBtn);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "DebugTool Server v2.0 by Z.Kazintsi";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>

        private void autoClickAndCopy()
        {
            if (set.autoClickAndCopy)
            {
                AutoItX3Declarations.AU3_MouseClick("left", monWidth-48, monHeight-69, 1, 0); // Show log megnyomasa
                AutoItX3Declarations.AU3_Sleep(1000); // varunk egy kicsit
                AutoItX3Declarations.AU3_Send("!{f}", 0); // Alt+f = file menu
                AutoItX3Declarations.AU3_Send("{ENTER}", 0); // Save menupont
                AutoItX3Declarations.AU3_Send(sn + ".log", 0); // fajl neve
                for (int i = 0; i < 6; ++i) { AutoItX3Declarations.AU3_Send("{TAB}", 0); } // TAB x 6
                AutoItX3Declarations.AU3_Send("{DOWN}", 0);// Le nyil
                AutoItX3Declarations.AU3_Send("{DOWN}", 0);// Le nyil
                AutoItX3Declarations.AU3_Send("{ENTER}", 0); // Dokumentumok
                AutoItX3Declarations.AU3_Send("{TAB}", 0); // fajl nevenek kijelolese
                AutoItX3Declarations.AU3_Send("{TAB}", 0); // fajl nevenek kijelolese
                AutoItX3Declarations.AU3_Send("!{s}", 0); // mentes 
                AutoItX3Declarations.AU3_Send("{ESCAPE}", 0);//ablak bezarasa


                try
                {
                    string from = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), sn + ".log");
                    Console.WriteLine(from);
                    string to = Path.Combine(set.backupFolder + "\\LOG", sn + "_0.log");
                    Console.WriteLine(to);
                    ArrayList output = new ArrayList();
                    Directory.CreateDirectory(set.backupFolder + "\\LOG");
                    if (File.Exists(from))
                    {
                        using (StreamReader sr = new StreamReader(from))
                        {
                            string row = String.Empty;
                            while ((row = sr.ReadLine()) != null)
                            {
                                output.Add(row);
                                if (row.Contains("Start testing iteration"))
                                    output.Clear();
                            }
                        }
                        File.Delete(from);
                        //
                        using (FileStream fs = new FileStream(from, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            using (StreamWriter sw = new StreamWriter(fs))
                            {
                                if (sw != null)
                                {
                                    foreach (string o in output)
                                    {
                                        sw.WriteLine(o);
                                    }
                                }
                            }
                        }
                       
                        //
                        while (File.Exists(to))
                        {
                            ++fileCounter;
                            to = Path.Combine(set.backupFolder + "\\LOG", sn + "_" + fileCounter + ".log");

                        }
                        File.Copy(from, to);
                        File.Delete(from);
                        fileCounter = 0;
                    }

                }
                catch (Exception ex)
                {
                    logger(ex.ToString());
                }
            }
        }

        string fileToCopy = @"C:\Documents and Settings\Administrator\Local Settings\Temp\GiftsResults.tmp";

        private void monitorGiftsTemp()
        {            
            //GiftsResults.tmp beolvassa periodusonkent, ez inditja az AutoCopy-t            
            
            try
            {
                File.Copy(fileToCopy, @"C:\GiftsResults.tmp", true);
            }
            catch (Exception except)
            {
                logger("GiftsResults.tmp not found! Maybe deleted?");
                return;
            }

            string GiftsResults = @"C:\GiftsResults.tmp";

            if (File.Exists(GiftsResults) && logfileCopied==false)
            {

                var modTime = DateTime.Now - File.GetLastWriteTime(GiftsResults);//az utolso modositas ota eltelt ido mp-ben
                using (FileStream fs = new FileStream(GiftsResults, FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string logRow = String.Empty;
                        while ((logRow = sr.ReadLine()) != null)
                        {
                            if (logRow == "Result=0" && modTime.Seconds > 12)// utoljara modositva 12mp-e
                            {
                                //if (MessageBox.Show("Auto Click And Copy?", "AutoClick", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                //{
                                    logger("Log file saving activated!");
                                    autoClickAndCopy();
                                    logfileCopied = true;   //volt masolva, tehat igaz
                                    
                                //}
                                //else
                                //{
                                //    logfileCopied = true;
                                //    //logger(logfileCopied.ToString());
                                //    //return;
                                //}
                            }
                        }
                    }
                }
            }
        }

        private void monitorErrFiles()
        {
            //valtozok lenullazasa minden ciklus elejen
            int tempTimeIndex = 0;
            string modifiedTime = String.Empty;

            foreach (string f in listBox1.Items)
            {
                modifiedTime = File.GetLastWriteTime(f).ToString();//ido lekerese

                if (modifiedTime != listBox2.Items[tempTimeIndex].ToString())// ha nem egyezik a tablazatban levovel, azaz ha megvaltozott
                {
                    listBox2.Items.RemoveAt(tempTimeIndex);
                    listBox2.Items.Insert(tempTimeIndex, modifiedTime);

                    statusBar1.Text = "File changed!";

                    //logger(Path.GetFullPath(f) + " changed!");  
                    string fName = Path.GetFileNameWithoutExtension(f);
                    string ext = Path.GetExtension(f);
                    var strB = new StringBuilder();
                    string sourceDir = Path.GetDirectoryName(f);

                    strB.Append(set.backupFolder);

                    string[] splitDir = sourceDir.Split(new Char[] { ':' });
                    for (int q = 1; q < splitDir.Length; ++q)
                    {
                        strB.Append(splitDir[q]);
                    }

                    strB.Append("\\");
                    Directory.CreateDirectory(strB.ToString());

                    if (sn > 0)// ha van szeria szam 
                    {
                        strB.Append(sn);// hozza adjuk a nevhez
                        strB.Append("_0-");

                    }
                    else //ha nincs szeria szam, atnevezzuk ido szerint
                    {
                        strB.Append("missing-SN-");
                        string[] splitTime = DateTime.Now.ToString().Split(new Char[] { ':', ' ', '.', '\\' });
                        for (int h = 0; h < splitTime.Length; h++)
                        {
                            strB.Append(splitTime[h]);//hozza adjuk a nevhez
                            strB.Append("-");
                        }
                    }

                    strB.Append(fName);
                    strB.Append(ext);
                    string finalBackupFile = strB.ToString();
                    strB.Length = 0;
                    //ERROR szoveg ellenorzese a fajlon belul, ha nincs benne 'ERRORS 1', akkor nem masol
                    string s = String.Empty;
                    using (StreamReader sr = new StreamReader(Path.Combine(sourceDir, fName + ext)))
                    {
                        while ((s = sr.ReadLine()) != null)
                        {
                            if (s.IndexOf("ERRORS") == 0)//szoveg keresese
                            {
                                string[] splitError = s.Split(new Char[] { ' ' });
                                if (int.Parse(splitError[1]) > 0)//ha nagyobb mint egy, azaz ha talalt hibat
                                {
                                    try
                                    {
                                        while (File.Exists(finalBackupFile))//ha van ugyanilyen fajl, atnevezzuk, hogy ne irodjon felul
                                        {
                                            ++fileCounter;
                                            string[] split = finalBackupFile.Split(new char[] { '_' });//felbontas "_" alapjan
                                            
                                            for (int k = 0; k < split.Length - 1; ++k)//osszeillesztes, de az utolsot kihagyjuk (0-serial.err)
                                            {
                                                strB.Append(split[k]);
                                                strB.Append("_");
                                            }
                                            strB.Append(fileCounter);//_1
                                            strB.Append("-");//_1-
                                            strB.Append(fName);//_1-serial
                                            strB.Append(ext);//_1-serial.err 
                                            finalBackupFile = strB.ToString();// full eleresi ut
                                        }
                                        fileCounter = 0;
                                        File.Copy(Path.GetFullPath(f), finalBackupFile, true);
                                    }
                                    catch (Exception ex)
                                    {
                                        statusBar1.Text = "Copy error!";
                                        return;
                                    }
                                    logger(Path.GetFullPath(f) + " copied to " + finalBackupFile + "at " + DateTime.Now.ToString());
                                }
                            }
                        }
                    };
                }
                ++tempTimeIndex;
            }
            statusBar1.Text = "No change found!";
            //logger("Cycle stopped at: " + DateTime.Now.ToString());
        }

		private void Form1_Resize(object sender, System.EventArgs e)
		{
			if(this.WindowState == FormWindowState.Minimized)
			{
			    this.notifyIcon1.Visible = true;
			    this.ShowInTaskbar = false;              
			}
		}

		private void notifyIcon1_Click(object sender, System.EventArgs e)
		{
			this.notifyIcon1.Visible = true;
			this.WindowState = FormWindowState.Normal;
			this.ShowInTaskbar = true;
		}

        internal void startCycle ()
        {
            this.timer1.Interval = int.Parse(set.checkInterval) * 1000;
			this.timer1.Enabled = true;
			this.startBtn.Enabled = false;
			this.stopBtn.Enabled = true;
        }

        internal void stopCycle()
        {
            this.timer1.Enabled = false;
            this.startBtn.Enabled = true;
            this.stopBtn.Enabled = false;
        }
        
        private void startBtn_Click(object sender, System.EventArgs e)
		{
            startCycle();// start gomb            
		}

		private void stopBtn_Click(object sender, System.EventArgs e)
		{
            stopCycle();// stop gomp
		}

		private void timer1_Tick(object sender, System.EventArgs e)//minden 5mp-ben lefut
		{
            Console.WriteLine("Cycle started!");
            statusBar1.Text = "Cycle started!";

            //szeriaszam lekerese a registrybol
            sn = Convert.ToInt64(Registry.GetValue(@"HKEY_CURRENT_USER\Software\Gilat Satellite Networks Ltd.\SEII_JTAG\Serials", "Serial Number 1", 0));

            if (File.Exists(fileToCopy))
            {

                logger(String.Format("Gift's Temp File available, test started! ({0})", sn));

                monitorGiftsTemp();//folyamatosan masolja es ellenorzi a masolatot

                monitorErrFiles(); //err fajlok ellenorzese
            }
            else
            {
                //reset
                logger("Test Stopped! (Gift's Temp File not found)");
                logfileCopied = false;
            }
            //tempSn = sn;
           
                       
            
		}

        public void logger(string text)
        {
            Console.WriteLine(text);
            if(set.useLog)
            using (StreamWriter log = new StreamWriter(@"C:\filemonitor.log", true))
            {
                log.WriteLine(text);
                log.Close();
            }
        }

        private void loadExternalList(string sourceDir)
        {            
            //fajl lista beolvasasa 
            try
            {
                string[] files = Directory.GetFiles(@sourceDir, "*.err", SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    listBox1.Items.Add(file);
                    listBox2.Items.Add(File.GetLastWriteTime(file.ToString())); 
                }                
            }
            catch (Exception e)
            {
                statusBar1.Text = "File not found!";
            }
        }

        private void copyAPLBtn_Click(object sender, System.EventArgs e)
		{
			//APL fajlok masolasa
			foreach (string f in listBox1.Items)
			{
				string sourceDir = Path.GetDirectoryName(f)+"\\";
				string[] aplList = Directory.GetFiles(sourceDir,"*.apl");
				string backupFolderName = "";
				string [] splitDir = sourceDir.Split(new Char [] {':'});
				for (int q = 1;q < splitDir.Length;q++)
				{
					backupFolderName = backupFolderName+splitDir[q];
				}
				string finalBackupDir = set.backupFolder+backupFolderName+"\\APL\\";
				foreach (string apl in aplList)
				{
					string aplfName = Path.GetFileName(apl);
					Directory.CreateDirectory(finalBackupDir);
					File.Copy(Path.Combine(sourceDir,aplfName),Path.Combine(finalBackupDir,aplfName),true);
				}
			}
		}

        private void Form1_Load(object sender, System.EventArgs e)
        {
            //contextMenu();            
            logger("Program started at: " + DateTime.Now.ToString());
            loadExternalList(set.sourceDir1);// listBox1 feltoltese fajlnevekkel az 1. mappabol
            loadExternalList(set.sourceDir2);// listBox1 feltoltese fajlnevekkel a 2. mappabol
            Rectangle monitorSize = Screen.PrimaryScreen.WorkingArea;// kijelzo kepatloja
            monHeight = monitorSize.Height;
            monWidth = monitorSize.Width;
            //tempSn = Convert.ToInt64(Registry.GetValue(@"HKEY_CURRENT_USER\Software\Gilat Satellite Networks Ltd.\SEII_JTAG\Serials", "Serial Number 1", 0));
            //Console.WriteLine(tempSn);
            startCycle();
            
            this.WindowState = FormWindowState.Minimized;          
            
            
        }
		
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //beallitasok ablak
            Settings set = new Settings();
            set.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // about ablak
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger("Program closed at: " + DateTime.Now.ToString());
        }		
	}

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    #region AutoIt Functions
    internal static class AutoItX3Declarations
    {
        //NOTE: This is based on AutoItX v3.3.0.0 which is a Unicode version
        //NOTE: My comments usually have "jcd" appended where I am uncertain.
        //NOTE: Optional parameters are not supported in C# yet so fill in all fields even if just "".
        //NOTE: Be prepared to play around a bit with which fields need values and what those value are.
        //NOTE: In previous versions we used byte[] to return values like this:
        //byte[] returnclip = new byte[200]; //at least twice as long as the text string expected +2 for null, (Unicode is 2 bytes)
        //AutoItX3Declarations.AU3_ClipGet(returnclip, returnclip.Length);
        //clipdata = System.Text.Encoding.Unicode.GetString(returnclip).TrimEnd('\0');

        //Now we are returning Unicode we can use StringBuilder instead like this:
        //StringBuilder clip = new StringBuilder(); //passing a parameter here will not work, we must asign a length
        //clip.Length = 200; //the number of chars expected plus 1 for the terminating null
        //AutoItX3Declarations.AU3_ClipGet(clip,clip.Length);
        //MessageBox.Show(clip.ToString());
        //NOTE: The big advantage of using AutoItX3 like this is that you don't have to register
        //the dll with windows and more importantly you get away from the many issues involved in
        //publishing the application and the binding to the dll required.

        //The below constants were found by Registering AutoItX3.dll in Windows
        //, adding AutoItX3Lib to References in IDE
        //,declaring an instance of it like this:
        // AutoItX3Lib.AutoItX3 autoit;
        // static AutoItX3Lib.AutoItX3Class autoit;
        //,right clicking on the AutoItX3Class and then Goto Definitions
        //and seeing the equivalent of the below in the MetaData Window.
        //So far it is working

        //NOTE: easier way is to use "DLL Export Viewer" utility and get it to list Properties also
        //"DLL Export Viewer" is from http://www.nirsoft.net
        // Definitions
        public const int AU3_INTDEFAULT = -2147483647; // "Default" value for _some_ int parameters (largest negative number)
        public const int error = 1;
        public const int SW_HIDE = 2;
        public const int SW_MAXIMIZE = 3;
        public const int SW_MINIMIZE = 4;
        public const int SW_RESTORE = 5;
        public const int SW_SHOW = 6;
        public const int SW_SHOWDEFAULT = 7;
        public const int SW_SHOWMAXIMIZED = 8;
        public const int SW_SHOWMINIMIZED = 9;
        public const int SW_SHOWMINNOACTIVE = 10;
        public const int SW_SHOWNA = 11;
        public const int SW_SHOWNOACTIVATE = 12;
        public const int SW_SHOWNORMAL = 13;
        public const int version = 110; //was 109 if previous non-unicode version

        /////////////////////////////////////////////////////////////////////////////////
        //// Exported functions of AutoItXC.dll
        /////////////////////////////////////////////////////////////////////////////////

        //AU3_API void WINAPI AU3_Init(void);
        //Uncertain if this is needed jcd
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_Init();

        //AU3_API long AU3_error(void);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_error();

        //AU3_API long WINAPI AU3_AutoItSetOption(LPCWSTR szOption, long nValue);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_AutoItSetOption([MarshalAs(UnmanagedType.LPWStr)] string Option, int Value);

        //AU3_API void WINAPI AU3_BlockInput(long nFlag);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_BlockInput(int Flag);

        //AU3_API long WINAPI AU3_CDTray(LPCWSTR szDrive, LPCWSTR szAction);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_CDTray([MarshalAs(UnmanagedType.LPWStr)] string Drive
        , [MarshalAs(UnmanagedType.LPWStr)] string Action);

        //AU3_API void WINAPI AU3_ClipGet(LPWSTR szClip, int nBufSize);
        //Use like this:
        //StringBuilder clip = new StringBuilder();
        //clip.Length = 4;
        //AutoItX3Declarations.AU3_ClipGet(clip,clip.Length);
        //MessageBox.Show(clip.ToString());
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_ClipGet([MarshalAs(UnmanagedType.LPWStr)]StringBuilder Clip, int BufSize);

        //AU3_API void WINAPI AU3_ClipPut(LPCWSTR szClip);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_ClipPut([MarshalAs(UnmanagedType.LPWStr)] string Clip);

        //AU3_API long WINAPI AU3_ControlClick(LPCWSTR szTitle, LPCWSTR szText, LPCWSTR szControl
        //, LPCWSTR szButton, long nNumClicks, /*[in,defaultvalue(AU3_INTDEFAULT)]*/long nX
        //, /*[in,defaultvalue(AU3_INTDEFAULT)]*/long nY);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_ControlClick([MarshalAs(UnmanagedType.LPWStr)] string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, [MarshalAs(UnmanagedType.LPWStr)] string Control
        , [MarshalAs(UnmanagedType.LPWStr)] string Button, int NumClicks, int X, int Y);

        //AU3_API void WINAPI AU3_ControlCommand(LPCWSTR szTitle, LPCWSTR szText, LPCWSTR szControl
        //, LPCWSTR szCommand, LPCWSTR szExtra, LPWSTR szResult, int nBufSize);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_ControlCommand([MarshalAs(UnmanagedType.LPWStr)] string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, [MarshalAs(UnmanagedType.LPWStr)] string Control
        , [MarshalAs(UnmanagedType.LPWStr)] string Command, [MarshalAs(UnmanagedType.LPWStr)] string Extra
        , [MarshalAs(UnmanagedType.LPWStr)] StringBuilder Result, int BufSize);

        //AU3_API void WINAPI AU3_ControlListView(LPCWSTR szTitle, LPCWSTR szText, LPCWSTR szControl
        //, LPCWSTR szCommand, LPCWSTR szExtra1, LPCWSTR szExtra2, LPWSTR szResult, int nBufSize);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_ControlListView([MarshalAs(UnmanagedType.LPWStr)] string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, [MarshalAs(UnmanagedType.LPWStr)] string Control
        , [MarshalAs(UnmanagedType.LPWStr)] string Command, [MarshalAs(UnmanagedType.LPWStr)] string Extral1
        , [MarshalAs(UnmanagedType.LPWStr)] string Extra2, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder Result
        , int BufSize);

        //AU3_API long WINAPI AU3_ControlDisable(LPCWSTR szTitle, LPCWSTR szText, LPCWSTR szControl);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_ControlDisable([MarshalAs(UnmanagedType.LPWStr)] string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, [MarshalAs(UnmanagedType.LPWStr)] string Control);

        //AU3_API long WINAPI AU3_ControlEnable(LPCWSTR szTitle, LPCWSTR szText, LPCWSTR szControl);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_ControlEnable([MarshalAs(UnmanagedType.LPWStr)] string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, [MarshalAs(UnmanagedType.LPWStr)] string Control);

        //AU3_API long WINAPI AU3_ControlFocus(LPCWSTR szTitle, LPCWSTR szText, LPCWSTR szControl);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_ControlFocus([MarshalAs(UnmanagedType.LPWStr)] string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, [MarshalAs(UnmanagedType.LPWStr)] string Control);

        //AU3_API void WINAPI AU3_ControlGetFocus(LPCWSTR szTitle, LPCWSTR szText, LPWSTR szControlWithFocus
        //, int nBufSize);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_ControlGetFocus([MarshalAs(UnmanagedType.LPWStr)] string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder ControlWithFocus
        , int BufSize);

        //AU3_API void WINAPI AU3_ControlGetHandle(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText
        //, LPCWSTR szControl, LPWSTR szRetText, int nBufSize);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_ControlGetHandle([MarshalAs(UnmanagedType.LPWStr)] string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, [MarshalAs(UnmanagedType.LPWStr)] string Control
        , [MarshalAs(UnmanagedType.LPWStr)] StringBuilder RetText, int BufSize);

        //AU3_API long WINAPI AU3_ControlGetPosX(LPCWSTR szTitle, LPCWSTR szText, LPCWSTR szControl);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_ControlGetPosX([MarshalAs(UnmanagedType.LPWStr)] string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, [MarshalAs(UnmanagedType.LPWStr)] string Control);

        //AU3_API long WINAPI AU3_ControlGetPosY(LPCWSTR szTitle, LPCWSTR szText, LPCWSTR szControl);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_ControlGetPosY([MarshalAs(UnmanagedType.LPWStr)] string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, [MarshalAs(UnmanagedType.LPWStr)] string Control);

        //AU3_API long WINAPI AU3_ControlGetPosHeight(LPCWSTR szTitle, LPCWSTR szText, LPCWSTR szControl);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_ControlGetPosHeight([MarshalAs(UnmanagedType.LPWStr)] string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, [MarshalAs(UnmanagedType.LPWStr)] string Control);

        //AU3_API long WINAPI AU3_ControlGetPosWidth(LPCWSTR szTitle, LPCWSTR szText, LPCWSTR szControl);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_ControlGetPosWidth([MarshalAs(UnmanagedType.LPWStr)] string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, [MarshalAs(UnmanagedType.LPWStr)] string Control);

        //AU3_API void WINAPI AU3_ControlGetText(LPCWSTR szTitle, LPCWSTR szText, LPCWSTR szControl
        //, LPWSTR szControlText, int nBufSize);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_ControlGetText([MarshalAs(UnmanagedType.LPWStr)] string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, [MarshalAs(UnmanagedType.LPWStr)] string Control
        , [MarshalAs(UnmanagedType.LPWStr)]StringBuilder ControlText, int BufSize);

        //AU3_API long WINAPI AU3_ControlHide(LPCWSTR szTitle, LPCWSTR szText, LPCWSTR szControl);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_ControlHide([MarshalAs(UnmanagedType.LPWStr)] string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, [MarshalAs(UnmanagedType.LPWStr)] string Control);

        //AU3_API long WINAPI AU3_ControlMove(LPCWSTR szTitle, LPCWSTR szText, LPCWSTR szControl
        //, long nX, long nY, /*[in,defaultvalue(-1)]*/long nWidth, /*[in,defaultvalue(-1)]*/long nHeight);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_ControlMove([MarshalAs(UnmanagedType.LPWStr)] string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, [MarshalAs(UnmanagedType.LPWStr)] string Control
        , int X, int Y, int Width, int Height);

        //AU3_API long WINAPI AU3_ControlSend(LPCWSTR szTitle, LPCWSTR szText, LPCWSTR szControl
        //, LPCWSTR szSendText, /*[in,defaultvalue(0)]*/long nMode);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_ControlSend([MarshalAs(UnmanagedType.LPWStr)] string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, [MarshalAs(UnmanagedType.LPWStr)] string Control
        , [MarshalAs(UnmanagedType.LPWStr)] string SendText, int Mode);

        //AU3_API long WINAPI AU3_ControlSetText(LPCWSTR szTitle, LPCWSTR szText, LPCWSTR szControl
        //, LPCWSTR szControlText);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_ControlSetText([MarshalAs(UnmanagedType.LPWStr)] string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, [MarshalAs(UnmanagedType.LPWStr)] string Control
        , [MarshalAs(UnmanagedType.LPWStr)] string ControlText);

        //AU3_API long WINAPI AU3_ControlShow(LPCWSTR szTitle, LPCWSTR szText, LPCWSTR szControl);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_ControlShow([MarshalAs(UnmanagedType.LPWStr)] string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, [MarshalAs(UnmanagedType.LPWStr)] string Control);

        //AU3_API void WINAPI AU3_ControlTreeView(LPCWSTR szTitle, LPCWSTR szText, LPCWSTR szControl
        //, LPCWSTR szCommand, LPCWSTR szExtra1, LPCWSTR szExtra2, LPWSTR szResult, int nBufSize);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_ControlTreeView([MarshalAs(UnmanagedType.LPWStr)] string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, [MarshalAs(UnmanagedType.LPWStr)] string Control
        , [MarshalAs(UnmanagedType.LPWStr)] string Command, [MarshalAs(UnmanagedType.LPWStr)] string Extra1
        , [MarshalAs(UnmanagedType.LPWStr)] string Extra2, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder Result, int BufSize);

        //AU3_API void WINAPI AU3_DriveMapAdd(LPCWSTR szDevice, LPCWSTR szShare, long nFlags
        //, /*[in,defaultvalue("")]*/LPCWSTR szUser, /*[in,defaultvalue("")]*/LPCWSTR szPwd
        //, LPWSTR szResult, int nBufSize);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_DriveMapAdd([MarshalAs(UnmanagedType.LPWStr)] string Device
        , [MarshalAs(UnmanagedType.LPWStr)] string Share, int Flags, [MarshalAs(UnmanagedType.LPWStr)] string User
        , [MarshalAs(UnmanagedType.LPWStr)] string Pwd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder Result, int BufSize);

        //AU3_API long WINAPI AU3_DriveMapDel(LPCWSTR szDevice);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_DriveMapDel([MarshalAs(UnmanagedType.LPWStr)] string Device);

        //AU3_API void WINAPI AU3_DriveMapGet(LPCWSTR szDevice, LPWSTR szMapping, int nBufSize);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_DriveMapGet([MarshalAs(UnmanagedType.LPWStr)] string Device
        , [MarshalAs(UnmanagedType.LPWStr)]StringBuilder Mapping, int BufSize);

        //AU3_API long WINAPI AU3_IniDelete(LPCWSTR szFilename, LPCWSTR szSection, LPCWSTR szKey);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_IniDelete([MarshalAs(UnmanagedType.LPWStr)] string Filename
        , [MarshalAs(UnmanagedType.LPWStr)] string Section, [MarshalAs(UnmanagedType.LPWStr)] string Key);

        //AU3_API void WINAPI AU3_IniRead(LPCWSTR szFilename, LPCWSTR szSection, LPCWSTR szKey
        //, LPCWSTR szDefault, LPWSTR szValue, int nBufSize);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_IniRead([MarshalAs(UnmanagedType.LPWStr)] string Filename
        , [MarshalAs(UnmanagedType.LPWStr)] string Section, [MarshalAs(UnmanagedType.LPWStr)] string Key
        , [MarshalAs(UnmanagedType.LPWStr)] string Default, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder Value, int BufSize);

        //AU3_API long WINAPI AU3_IniWrite(LPCWSTR szFilename, LPCWSTR szSection, LPCWSTR szKey
        //, LPCWSTR szValue);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_IniWrite([MarshalAs(UnmanagedType.LPWStr)] string Filename
        , [MarshalAs(UnmanagedType.LPWStr)] string Section, [MarshalAs(UnmanagedType.LPWStr)] string Key
        , [MarshalAs(UnmanagedType.LPWStr)] string Value);

        //AU3_API long WINAPI AU3_IsAdmin(void);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_IsAdmin();

        //AU3_API long WINAPI AU3_MouseClick(/*[in,defaultvalue("LEFT")]*/LPCWSTR szButton
        //, /*[in,defaultvalue(AU3_INTDEFAULT)]*/long nX, /*[in,defaultvalue(AU3_INTDEFAULT)]*/long nY
        //, /*[in,defaultvalue(1)]*/long nClicks, /*[in,defaultvalue(-1)]*/long nSpeed);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_MouseClick([MarshalAs(UnmanagedType.LPWStr)] string Button, int x, int y
        , int clicks, int speed);

        //AU3_API long WINAPI AU3_MouseClickDrag(LPCWSTR szButton, long nX1, long nY1, long nX2, long nY2
        //, /*[in,defaultvalue(-1)]*/long nSpeed);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_MouseClickDrag([MarshalAs(UnmanagedType.LPWStr)] string Button
        , int X1, int Y1, int X2, int Y2, int Speed);

        //AU3_API void WINAPI AU3_MouseDown(/*[in,defaultvalue("LEFT")]*/LPCWSTR szButton);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_MouseDown([MarshalAs(UnmanagedType.LPWStr)] string Button);

        //AU3_API long WINAPI AU3_MouseGetCursor(void);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_MouseGetCursor();

        //AU3_API long WINAPI AU3_MouseGetPosX(void);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_MouseGetPosX();

        //AU3_API long WINAPI AU3_MouseGetPosY(void);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_MouseGetPosY();

        //AU3_API long WINAPI AU3_MouseMove(long nX, long nY, /*[in,defaultvalue(-1)]*/long nSpeed);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_MouseMove(int X, int Y, int Speed);

        //AU3_API void WINAPI AU3_MouseUp(/*[in,defaultvalue("LEFT")]*/LPCWSTR szButton);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_MouseUp([MarshalAs(UnmanagedType.LPWStr)] string Button);

        //AU3_API void WINAPI AU3_MouseWheel(LPCWSTR szDirection, long nClicks);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_MouseWheel([MarshalAs(UnmanagedType.LPWStr)] string Direction, int Clicks);

        //AU3_API long WINAPI AU3_Opt(LPCWSTR szOption, long nValue);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_Opt([MarshalAs(UnmanagedType.LPWStr)] string Option, int Value);

        //AU3_API unsigned long WINAPI AU3_PixelChecksum(long nLeft, long nTop, long nRight, long nBottom
        //, /*[in,defaultvalue(1)]*/long nStep);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_PixelChecksum(int Left, int Top, int Right, int Bottom, int Step);

        //AU3_API long WINAPI AU3_PixelGetColor(long nX, long nY);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_PixelGetColor(int X, int Y);

        //AU3_API void WINAPI AU3_PixelSearch(long nLeft, long nTop, long nRight, long nBottom, long nCol
        //, /*default 0*/long nVar, /*default 1*/long nStep, LPPOINT pPointResult);
        //Use like this:
        //int[] result = {0,0};
        //try
        //{
        // AutoItX3Declarations.AU3_PixelSearch(0, 0, 800, 000,0xFFFFFF, 0, 1, result);
        //}
        //catch { }
        //It will crash if the color is not found, have not been able to determin why jcd
        //The AutoItX3Lib.AutoItX3Class version has similar problems and is the only function to return an object
        //so contortions are needed to get the data from it ie:
        //int[] result = {0,0};
        //object resultObj;
        //AutoItX3Lib.AutoItX3Class autoit = new AutoItX3Lib.AutoItX3Class();
        //resultObj = autoit.PixelSearch(0, 0, 800, 600, 0xFFFF00,0,1);
        //Type t = resultObj.GetType();
        //if(t == typeof(object[]))
        //{
        //object[] obj = (object[])resultObj;
        //result[0] = (int)obj[0];
        //result[1] = (int)obj[1];
        //}
        //When it fails it returns an object = 1 but when it succeeds it is object[X,Y]
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_PixelSearch(int Left, int Top, int Right, int Bottom, int Col, int Var
        , int Step, int[] PointResult);

        //AU3_API long WINAPI AU3_ProcessClose(LPCWSTR szProcess);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_ProcessClose([MarshalAs(UnmanagedType.LPWStr)]string Process);

        //AU3_API long WINAPI AU3_ProcessExists(LPCWSTR szProcess);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_ProcessExists([MarshalAs(UnmanagedType.LPWStr)]string Process);

        //AU3_API long WINAPI AU3_ProcessSetPriority(LPCWSTR szProcess, long nPriority);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_ProcessSetPriority([MarshalAs(UnmanagedType.LPWStr)]string Process, int Priority);

        //AU3_API long WINAPI AU3_ProcessWait(LPCWSTR szProcess, /*[in,defaultvalue(0)]*/long nTimeout);
        //Not checked jcd
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_ProcessWait([MarshalAs(UnmanagedType.LPWStr)]string Process, int Timeout);

        //AU3_API long WINAPI AU3_ProcessWaitClose(LPCWSTR szProcess, /*[in,defaultvalue(0)]*/long nTimeout);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_ProcessWaitClose([MarshalAs(UnmanagedType.LPWStr)]string Process, int Timeout);

        //AU3_API long WINAPI AU3_RegDeleteKey(LPCWSTR szKeyname);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_RegDeleteKey([MarshalAs(UnmanagedType.LPWStr)]string Keyname);

        //AU3_API long WINAPI AU3_RegDeleteVal(LPCWSTR szKeyname, LPCWSTR szValuename);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_RegDeleteVal([MarshalAs(UnmanagedType.LPWStr)]string Keyname
        , [MarshalAs(UnmanagedType.LPWStr)]string ValueName);

        //AU3_API void WINAPI AU3_RegEnumKey(LPCWSTR szKeyname, long nInstance, LPWSTR szResult, int nBufSize);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_RegEnumKey([MarshalAs(UnmanagedType.LPWStr)]string Keyname
        , int Instance, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder Result, int BusSize);

        //AU3_API void WINAPI AU3_RegEnumVal(LPCWSTR szKeyname, long nInstance, LPWSTR szResult, int nBufSize);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_RegEnumVal([MarshalAs(UnmanagedType.LPWStr)]string Keyname
        , int Instance, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder Result, int BufSize);

        //AU3_API void WINAPI AU3_RegRead(LPCWSTR szKeyname, LPCWSTR szValuename, LPWSTR szRetText, int nBufSize);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_RegRead([MarshalAs(UnmanagedType.LPWStr)]string Keyname
        , [MarshalAs(UnmanagedType.LPWStr)]string Valuename, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder RetText, int BufSize);

        //AU3_API long WINAPI AU3_RegWrite(LPCWSTR szKeyname, LPCWSTR szValuename, LPCWSTR szType
        //, LPCWSTR szValue);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_RegWrite([MarshalAs(UnmanagedType.LPWStr)]string Keyname
        , [MarshalAs(UnmanagedType.LPWStr)]string Valuename, [MarshalAs(UnmanagedType.LPWStr)]string Type
        , [MarshalAs(UnmanagedType.LPWStr)]string Value);

        //AU3_API long WINAPI AU3_Run(LPCWSTR szRun, /*[in,defaultvalue("")]*/LPCWSTR szDir
        //, /*[in,defaultvalue(1)]*/long nShowFlags);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_Run([MarshalAs(UnmanagedType.LPWStr)]string Run
        , [MarshalAs(UnmanagedType.LPWStr)]string Dir, int ShowFlags);

        //AU3_API long WINAPI AU3_RunAsSet(LPCWSTR szUser, LPCWSTR szDomain, LPCWSTR szPassword, int nOptions);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_RunAsSet([MarshalAs(UnmanagedType.LPWStr)]string User
        , [MarshalAs(UnmanagedType.LPWStr)]string Domain, [MarshalAs(UnmanagedType.LPWStr)]string Password
        , int Options);

        //AU3_API long WINAPI AU3_RunWait(LPCWSTR szRun, /*[in,defaultvalue("")]*/LPCWSTR szDir
        //, /*[in,defaultvalue(1)]*/long nShowFlags);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_RunWait([MarshalAs(UnmanagedType.LPWStr)]string Run
        , [MarshalAs(UnmanagedType.LPWStr)]string Dir, int ShowFlags);

        //AU3_API void WINAPI AU3_Send(LPCWSTR szSendText, /*[in,defaultvalue("")]*/long nMode);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_Send([MarshalAs(UnmanagedType.LPWStr)] string SendText, int Mode);

        //AU3_API void WINAPI AU3_SendA(LPCSTR szSendText, /*[in,defaultvalue("")]*/long nMode);
        //Not checked jcd
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_SendA([MarshalAs(UnmanagedType.LPStr)] string SendText, int Mode);

        //AU3_API long WINAPI AU3_Shutdown(long nFlags);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_Shutdown(int Flags);

        //AU3_API void WINAPI AU3_Sleep(long nMilliseconds);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_Sleep(int Milliseconds);

        //AU3_API void WINAPI AU3_StatusbarGetText(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText
        //, /*[in,defaultvalue(1)]*/long nPart, LPWSTR szStatusText, int nBufSize);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_StatusbarGetText([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)]string Text, int Part, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder StatusText, int BufSize);

        //AU3_API void WINAPI AU3_ToolTip(LPCWSTR szTip, /*[in,defaultvalue(AU3_INTDEFAULT)]*/long nX
        //, /*[in,defaultvalue(AU3_INTDEFAULT)]*/long nY);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_ToolTip([MarshalAs(UnmanagedType.LPWStr)]string Tip, int X, int Y);

        //AU3_API void WINAPI AU3_WinActivate(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_WinActivate([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)]string Text);

        //AU3_API long WINAPI AU3_WinActive(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinActive([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)]string Text);

        //AU3_API long WINAPI AU3_WinClose(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinClose([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text);

        //AU3_API long WINAPI AU3_WinExists(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinExists([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)]string Text);

        //AU3_API long WINAPI AU3_WinGetCaretPosX(void);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinGetCaretPosX();

        //AU3_API long WINAPI AU3_WinGetCaretPosY(void);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinGetCaretPosY();

        //AU3_API void WINAPI AU3_WinGetClassList(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText
        //, LPWSTR szRetText, int nBufSize);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_WinGetClassList([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)]string Text, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder RetText, int BufSize);

        //AU3_API long WINAPI AU3_WinGetClientSizeHeight(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinGetClientSizeHeight([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)]string Text);

        //AU3_API long WINAPI AU3_WinGetClientSizeWidth(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText); 
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinGetClientSizeWidth([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)]string Text);

        //AU3_API void WINAPI AU3_WinGetHandle(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText
        //, LPWSTR szRetText, int nBufSize);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_WinGetHandle([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)]string Text, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder RetText, int BufSize);

        //AU3_API long WINAPI AU3_WinGetPosX(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinGetPosX([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text);

        //AU3_API long WINAPI AU3_WinGetPosY(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinGetPosY([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text);

        //AU3_API long WINAPI AU3_WinGetPosHeight(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinGetPosHeight([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text);

        //AU3_API long WINAPI AU3_WinGetPosWidth(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinGetPosWidth([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text);

        //AU3_API void WINAPI AU3_WinGetProcess(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText
        //, LPWSTR szRetText, int nBufSize);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_WinGetProcess([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder RetText, int BufSize);

        //AU3_API long WINAPI AU3_WinGetState(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinGetState([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text);

        //AU3_API void WINAPI AU3_WinGetText(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText
        //, LPWSTR szRetText, int nBufSize);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_WinGetText([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder RetText, int BufSize);

        //AU3_API void WINAPI AU3_WinGetTitle(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText
        //, LPWSTR szRetText, int nBufSize);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_WinGetTitle([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder RetText, int BufSize);

        //AU3_API long WINAPI AU3_WinKill(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinKill([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text);

        //AU3_API long WINAPI AU3_WinMenuSelectItem(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText
        //, LPCWSTR szItem1, LPCWSTR szItem2, LPCWSTR szItem3, LPCWSTR szItem4, LPCWSTR szItem5, LPCWSTR szItem6
        //, LPCWSTR szItem7, LPCWSTR szItem8);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinMenuSelectItem([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, [MarshalAs(UnmanagedType.LPWStr)] string Item1
        , [MarshalAs(UnmanagedType.LPWStr)] string Item2, [MarshalAs(UnmanagedType.LPWStr)] string Item3
        , [MarshalAs(UnmanagedType.LPWStr)] string Item4, [MarshalAs(UnmanagedType.LPWStr)] string Item5
        , [MarshalAs(UnmanagedType.LPWStr)] string Item6, [MarshalAs(UnmanagedType.LPWStr)] string Item7
        , [MarshalAs(UnmanagedType.LPWStr)] string Item8);

        //AU3_API void WINAPI AU3_WinMinimizeAll();
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_WinMinimizeAll();

        //AU3_API void WINAPI AU3_WinMinimizeAllUndo();
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern void AU3_WinMinimizeAllUndo();

        //AU3_API long WINAPI AU3_WinMove(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText
        //, long nX, long nY, /*[in,defaultvalue(-1)]*/long nWidth, /*[in,defaultvalue(-1)]*/long nHeight);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinMove([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, int X, int Y, int Width, int Height);

        //AU3_API long WINAPI AU3_WinSetOnTop(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText, long nFlag);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinSetOnTop([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, int Flags);

        //AU3_API long WINAPI AU3_WinSetState(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText, long nFlags);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinSetState([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, int Flags);

        //AU3_API long WINAPI AU3_WinSetTitle(LPCWSTR szTitle,/*[in,defaultvalue("")]*/ LPCWSTR szText
        //, LPCWSTR szNewTitle);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinSetTitle([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, [MarshalAs(UnmanagedType.LPWStr)] string NewTitle);

        //AU3_API long WINAPI AU3_WinSetTrans(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText, long nTrans);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinSetTrans([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, int Trans);

        //AU3_API long WINAPI AU3_WinWait(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText
        //, /*[in,defaultvalue(0)]*/long nTimeout);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinWait([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, int Timeout);

        //AU3_API long WINAPI AU3_WinWaitA(LPCSTR szTitle, /*[in,defaultvalue("")]*/LPCSTR szText
        //, /*[in,defaultvalue(0)]*/long nTimeout);
        //Not checked jcd
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinWaitA([MarshalAs(UnmanagedType.LPStr)]string Title
        , [MarshalAs(UnmanagedType.LPStr)] string Text, int Timeout);

        //AU3_API long WINAPI AU3_WinWaitActive(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText
        //, /*[in,defaultvalue(0)]*/long nTimeout);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinWaitActive([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, int Timeout);

        //AU3_API long WINAPI AU3_WinWaitActiveA(LPCSTR szTitle, /*[in,defaultvalue("")]*/LPCSTR szText
        //, /*[in,defaultvalue(0)]*/long nTimeout);
        //Not checked jcd
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinWaitActiveA([MarshalAs(UnmanagedType.LPStr)]string Title
        , [MarshalAs(UnmanagedType.LPStr)] string Text, int Timeout);

        //AU3_API long WINAPI AU3_WinWaitClose(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText
        //, /*[in,defaultvalue(0)]*/long nTimeout);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinWaitClose([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, int Timeout);

        //AU3_API long WINAPI AU3_WinWaitCloseA(LPCSTR szTitle, /*[in,defaultvalue("")]*/LPCSTR szText
        //, /*[in,defaultvalue(0)]*/long nTimeout);
        //Not checked jcd
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinWaitCloseA([MarshalAs(UnmanagedType.LPStr)]string Title
        , [MarshalAs(UnmanagedType.LPStr)] string Text, int Timeout);

        //AU3_API long WINAPI AU3_WinWaitNotActive(LPCWSTR szTitle, /*[in,defaultvalue("")]*/LPCWSTR szText
        //, /*[in,defaultvalue(0)]*/long nTimeout);
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinWaitNotActive([MarshalAs(UnmanagedType.LPWStr)]string Title
        , [MarshalAs(UnmanagedType.LPWStr)] string Text, int Timeout);

        //AU3_API long WINAPI AU3_WinWaitNotActiveA(LPCSTR szTitle, /*[in,defaultvalue("")]*/LPCSTR szText
        //, /*[in,defaultvalue(0)]*/long nTimeout);
        //Not checked jcd
        [DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern int AU3_WinWaitNotActiveA([MarshalAs(UnmanagedType.LPStr)]string Title
        , [MarshalAs(UnmanagedType.LPStr)] string Text, int Timeout);

    }
    #endregion

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

}
