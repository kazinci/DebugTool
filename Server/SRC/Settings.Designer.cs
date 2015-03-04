namespace FileMonitor
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.backupFolderTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkIntervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.autoClickBox = new System.Windows.Forms.CheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.useLogBox = new System.Windows.Forms.CheckBox();
            this.sourceDir2TextBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.sourceDir1TextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkIntervalNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(52, 230);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(171, 230);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // backupFolderTextBox
            // 
            this.backupFolderTextBox.Location = new System.Drawing.Point(13, 24);
            this.backupFolderTextBox.Name = "backupFolderTextBox";
            this.backupFolderTextBox.Size = new System.Drawing.Size(255, 20);
            this.backupFolderTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Backup Folder:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Check Interval (secs):";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.checkIntervalNumericUpDown);
            this.panel2.Controls.Add(this.autoClickBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.useLogBox);
            this.panel2.Controls.Add(this.sourceDir2TextBox);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.sourceDir1TextBox);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.backupFolderTextBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(5, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 215);
            this.panel2.TabIndex = 21;
            // 
            // checkIntervalNumericUpDown
            // 
            this.checkIntervalNumericUpDown.Location = new System.Drawing.Point(126, 131);
            this.checkIntervalNumericUpDown.Name = "checkIntervalNumericUpDown";
            this.checkIntervalNumericUpDown.Size = new System.Drawing.Size(142, 20);
            this.checkIntervalNumericUpDown.TabIndex = 30;
            // 
            // autoClickBox
            // 
            this.autoClickBox.AutoSize = true;
            this.autoClickBox.Checked = true;
            this.autoClickBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoClickBox.Location = new System.Drawing.Point(97, 177);
            this.autoClickBox.Name = "autoClickBox";
            this.autoClickBox.Size = new System.Drawing.Size(15, 14);
            this.autoClickBox.TabIndex = 28;
            this.autoClickBox.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(10, 177);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(84, 13);
            this.label24.TabIndex = 29;
            this.label24.Text = "Auto-click+Copy";
            // 
            // useLogBox
            // 
            this.useLogBox.AutoSize = true;
            this.useLogBox.Checked = true;
            this.useLogBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useLogBox.Location = new System.Drawing.Point(97, 159);
            this.useLogBox.Name = "useLogBox";
            this.useLogBox.Size = new System.Drawing.Size(15, 14);
            this.useLogBox.TabIndex = 20;
            this.useLogBox.UseVisualStyleBackColor = true;
            // 
            // sourceDir2TextBox
            // 
            this.sourceDir2TextBox.Location = new System.Drawing.Point(13, 102);
            this.sourceDir2TextBox.Name = "sourceDir2TextBox";
            this.sourceDir2TextBox.Size = new System.Drawing.Size(255, 20);
            this.sourceDir2TextBox.TabIndex = 17;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(10, 160);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(43, 13);
            this.label19.TabIndex = 21;
            this.label19.Text = "Use log";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(142, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "2nd Folder with ERROR files";
            // 
            // sourceDir1TextBox
            // 
            this.sourceDir1TextBox.Location = new System.Drawing.Point(13, 63);
            this.sourceDir1TextBox.Name = "sourceDir1TextBox";
            this.sourceDir1TextBox.Size = new System.Drawing.Size(255, 20);
            this.sourceDir1TextBox.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(138, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "1st Folder with ERROR files";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 267);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkIntervalNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox backupFolderTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox sourceDir1TextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox sourceDir2TextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox useLogBox;
        private System.Windows.Forms.CheckBox autoClickBox;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.NumericUpDown checkIntervalNumericUpDown;
    }
}