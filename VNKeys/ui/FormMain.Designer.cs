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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportBug = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReqFeature = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLink = new System.Windows.Forms.ToolStripStatusLabel();
            this.chkOff = new System.Windows.Forms.RadioButton();
            this.chkOn = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlCurrentKieuGo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblSpring,
            this.lblLink});
            this.statusStrip.Location = new System.Drawing.Point(0, 223);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(408, 25);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuAbout});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(408, 29);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(46, 25);
            this.menuFile.Text = "File";
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(104, 26);
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1,
            this.menuReportBug,
            this.menuReqFeature});
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(64, 25);
            this.menuAbout.Text = "About";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(201, 26);
            this.aboutToolStripMenuItem1.Text = "About";
            // 
            // menuReportBug
            // 
            this.menuReportBug.Name = "menuReportBug";
            this.menuReportBug.Size = new System.Drawing.Size(201, 26);
            this.menuReportBug.Text = "Report a bug";
            // 
            // menuReqFeature
            // 
            this.menuReqFeature.Name = "menuReqFeature";
            this.menuReqFeature.Size = new System.Drawing.Size(201, 26);
            this.menuReqFeature.Text = "Request a feature";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 29);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(10, 5);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(408, 194);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ddlCurrentKieuGo);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.chkOff);
            this.tabPage1.Controls.Add(this.chkOn);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(400, 157);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(493, 227);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblSpring
            // 
            this.lblSpring.Name = "lblSpring";
            this.lblSpring.Size = new System.Drawing.Size(313, 20);
            this.lblSpring.Spring = true;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 20);
            // 
            // lblLink
            // 
            this.lblLink.IsLink = true;
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(76, 20);
            this.lblLink.Text = "vnkeys.net";
            this.lblLink.Click += new System.EventHandler(this.lblLink_Click);
            // 
            // chkOff
            // 
            this.chkOff.AutoSize = true;
            this.chkOff.Location = new System.Drawing.Point(206, 7);
            this.chkOff.Name = "chkOff";
            this.chkOff.Size = new System.Drawing.Size(59, 24);
            this.chkOff.TabIndex = 9;
            this.chkOff.TabStop = true;
            this.chkOff.Text = "OFF";
            this.chkOff.UseVisualStyleBackColor = true;
            // 
            // chkOn
            // 
            this.chkOn.AutoSize = true;
            this.chkOn.Location = new System.Drawing.Point(131, 6);
            this.chkOn.Name = "chkOn";
            this.chkOn.Size = new System.Drawing.Size(50, 24);
            this.chkOn.TabIndex = 8;
            this.chkOn.TabStop = true;
            this.chkOn.Text = "ON";
            this.chkOn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Gõ tiếng Việt:";
            // 
            // ddlCurrentKieuGo
            // 
            this.ddlCurrentKieuGo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCurrentKieuGo.FormattingEnabled = true;
            this.ddlCurrentKieuGo.Location = new System.Drawing.Point(131, 41);
            this.ddlCurrentKieuGo.Name = "ddlCurrentKieuGo";
            this.ddlCurrentKieuGo.Size = new System.Drawing.Size(168, 28);
            this.ddlCurrentKieuGo.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Kiểu gõ:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 248);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
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
        private System.Windows.Forms.ComboBox ddlCurrentKieuGo;
        private System.Windows.Forms.Label label2;
    }
}