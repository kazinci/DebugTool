using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;


namespace FileMonitor
{
    public partial class Settings : Form
    {
        Settings1 set = Settings1.Default;
        public Settings()
        {
            InitializeComponent();            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {           
            set.backupFolder = backupFolderTextBox.Text;
            set.Save();

            set.checkInterval = (int)checkIntervalNumericUpDown.Value;
            set.Save();

            set.useLog = useLogBox.Checked;
            set.Save();

            set.autoClickAndCopy = autoClickBox.Checked;
            set.Save();

            set.sourceDir1 = sourceDir1TextBox.Text;
            set.Save();

            set.sourceDir2 = sourceDir2TextBox.Text;
            set.Save();
            
            ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).Save(ConfigurationSaveMode.Modified);

            this.Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            backupFolderTextBox.Text = set.backupFolder;          
            useLogBox.Checked = set.useLog;
            autoClickBox.Checked = set.autoClickAndCopy;
            sourceDir1TextBox.Text = set.sourceDir1;
            sourceDir2TextBox.Text = set.sourceDir2;
            checkIntervalNumericUpDown.Value = set.checkInterval;
        }             
        
    }
}
