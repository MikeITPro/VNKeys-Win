namespace VNKeys.ui
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLink = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportBug = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReqFeature = new System.Windows.Forms.ToolStripMenuItem();
            this.questionsAnswersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chekForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ddlTypingMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkOff = new System.Windows.Forms.RadioButton();
            this.chkOn = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkToSystemTray = new System.Windows.Forms.CheckBox();
            this.chkConfirmExit = new System.Windows.Forms.CheckBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblSpring,
            this.lblLink});
            this.statusStrip.Location = new System.Drawing.Point(0, 226);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(408, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // lblSpring
            // 
            this.lblSpring.Name = "lblSpring";
            this.lblSpring.Size = new System.Drawing.Size(316, 17);
            this.lblSpring.Spring = true;
            // 
            // lblLink
            // 
            this.lblLink.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLink.IsLink = true;
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(77, 17);
            this.lblLink.Text = "vnkeys.net";
            this.lblLink.Click += new System.EventHandler(this.lblLink_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.menuStrip.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuAbout,
            this.supportToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(408, 26);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(46, 22);
            this.menuFile.Text = "File";
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(102, 22);
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuReportBug,
            this.menuReqFeature,
            this.questionsAnswersToolStripMenuItem});
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(68, 22);
            this.menuAbout.Text = "Hỗ Trợ";
            // 
            // menuReportBug
            // 
            this.menuReportBug.Name = "menuReportBug";
            this.menuReportBug.Size = new System.Drawing.Size(224, 22);
            this.menuReportBug.Text = "Report a bug";
            this.menuReportBug.Click += new System.EventHandler(this.menuReportBug_Click);
            // 
            // menuReqFeature
            // 
            this.menuReqFeature.Name = "menuReqFeature";
            this.menuReqFeature.Size = new System.Drawing.Size(224, 22);
            this.menuReqFeature.Text = "Request a feature";
            this.menuReqFeature.Click += new System.EventHandler(this.menuReqFeature_Click);
            // 
            // questionsAnswersToolStripMenuItem
            // 
            this.questionsAnswersToolStripMenuItem.Name = "questionsAnswersToolStripMenuItem";
            this.questionsAnswersToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.questionsAnswersToolStripMenuItem.Text = "Questions && Answers";
            this.questionsAnswersToolStripMenuItem.Click += new System.EventHandler(this.questionsAnswersToolStripMenuItem_Click);
            // 
            // supportToolStripMenuItem
            // 
            this.supportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chekForUpdatesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.supportToolStripMenuItem.Name = "supportToolStripMenuItem";
            this.supportToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
            this.supportToolStripMenuItem.Text = "About";
            this.supportToolStripMenuItem.Click += new System.EventHandler(this.supportToolStripMenuItem_Click);
            // 
            // chekForUpdatesToolStripMenuItem
            // 
            this.chekForUpdatesToolStripMenuItem.Name = "chekForUpdatesToolStripMenuItem";
            this.chekForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.chekForUpdatesToolStripMenuItem.Text = "Kiểm tra phiên bản mới";
            this.chekForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.chekForUpdatesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.aboutToolStripMenuItem.Text = "About VNKeys";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(10, 5);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(408, 200);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ddlTypingMode);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.chkOff);
            this.tabPage1.Controls.Add(this.chkOn);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(400, 166);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ddlCurrentKieuGo
            // 
            this.ddlTypingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTypingMode.FormattingEnabled = true;
            this.ddlTypingMode.Location = new System.Drawing.Point(131, 41);
            this.ddlTypingMode.Name = "ddlCurrentKieuGo";
            this.ddlTypingMode.Size = new System.Drawing.Size(168, 25);
            this.ddlTypingMode.TabIndex = 11;
            this.ddlTypingMode.SelectedIndexChanged += new System.EventHandler(this.ddlCurrentKieuGo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Kiểu gõ:";
            // 
            // chkOff
            // 
            this.chkOff.AutoSize = true;
            this.chkOff.Location = new System.Drawing.Point(206, 7);
            this.chkOff.Name = "chkOff";
            this.chkOff.Size = new System.Drawing.Size(56, 21);
            this.chkOff.TabIndex = 9;
            this.chkOff.Text = "OFF";
            this.chkOff.UseVisualStyleBackColor = true;
            this.chkOff.CheckedChanged += new System.EventHandler(this.chkOff_CheckedChanged);
            // 
            // chkOn
            // 
            this.chkOn.AutoSize = true;
            this.chkOn.Location = new System.Drawing.Point(131, 6);
            this.chkOn.Name = "chkOn";
            this.chkOn.Size = new System.Drawing.Size(48, 21);
            this.chkOn.TabIndex = 8;
            this.chkOn.Text = "ON";
            this.chkOn.UseVisualStyleBackColor = true;
            this.chkOn.CheckedChanged += new System.EventHandler(this.chkOn_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Gõ tiếng Việt:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkToSystemTray);
            this.tabPage2.Controls.Add(this.chkConfirmExit);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(400, 166);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkToSystemTray
            // 
            this.chkToSystemTray.AutoSize = true;
            this.chkToSystemTray.Checked = true;
            this.chkToSystemTray.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkToSystemTray.Location = new System.Drawing.Point(9, 34);
            this.chkToSystemTray.Name = "chkToSystemTray";
            this.chkToSystemTray.Size = new System.Drawing.Size(187, 21);
            this.chkToSystemTray.TabIndex = 1;
            this.chkToSystemTray.Text = "Thu nhỏ vào system tray";
            this.chkToSystemTray.UseVisualStyleBackColor = true;
            // 
            // chkConfirmExit
            // 
            this.chkConfirmExit.AutoSize = true;
            this.chkConfirmExit.Location = new System.Drawing.Point(9, 7);
            this.chkConfirmExit.Name = "chkConfirmExit";
            this.chkConfirmExit.Size = new System.Drawing.Size(253, 21);
            this.chkConfirmExit.TabIndex = 0;
            this.chkConfirmExit.Text = "Xác nhận trước khi thoát ứng dụng";
            this.chkConfirmExit.UseVisualStyleBackColor = true;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 248);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuReportBug;
        private System.Windows.Forms.ToolStripMenuItem menuReqFeature;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblSpring;
        private System.Windows.Forms.ToolStripStatusLabel lblLink;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RadioButton chkOff;
        private System.Windows.Forms.RadioButton chkOn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlTypingMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkConfirmExit;
        private System.Windows.Forms.CheckBox chkToSystemTray;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem supportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem questionsAnswersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chekForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}