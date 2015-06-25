namespace TimeTracker
{
    partial class frmMain
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
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trayUnhide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.trayExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStartStopTimer = new System.Windows.Forms.Button();
            this.pnlDisplayInfo = new System.Windows.Forms.Panel();
            this.lblTimeRounded = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblTimeToday = new System.Windows.Forms.Label();
            this.lblCurrentlySelected = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlTop = new System.Windows.Forms.Panel();
            this.ucMenuStrip1 = new TimeTracker.ucMenuStrip();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.ucTimeSummary1 = new TimeTracker.ucTimeSummary();
            this.pnlTopOfBottom = new System.Windows.Forms.Panel();
            this.lblTotalTime = new System.Windows.Forms.Label();
            this.txtTotalTime = new System.Windows.Forms.Label();
            this.splitTopBottom = new System.Windows.Forms.Splitter();
            this.activeTimer = new TimeTracker.EventTimer(this.components);
            this.trayIconContextMenu.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlTopOfBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayIcon.BalloonTipText = "Press Ctrl + Alt + Shift + O to bring up the Time Tracker window.";
            this.trayIcon.BalloonTipTitle = "Tip!";
            this.trayIcon.ContextMenuStrip = this.trayIconContextMenu;
            this.trayIcon.Text = "Time Tracker";
            this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseClick);
            // 
            // trayIconContextMenu
            // 
            this.trayIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayUnhide,
            this.toolStripSeparator1,
            this.trayExit});
            this.trayIconContextMenu.Name = "trayIconContextMenu";
            this.trayIconContextMenu.Size = new System.Drawing.Size(113, 54);
            // 
            // trayUnhide
            // 
            this.trayUnhide.Name = "trayUnhide";
            this.trayUnhide.Size = new System.Drawing.Size(112, 22);
            this.trayUnhide.Text = "Unhide";
            this.trayUnhide.Click += new System.EventHandler(this.trayUnhide_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // trayExit
            // 
            this.trayExit.Name = "trayExit";
            this.trayExit.Size = new System.Drawing.Size(112, 22);
            this.trayExit.Text = "Exit";
            this.trayExit.Click += new System.EventHandler(this.trayExit_Click);
            // 
            // btnStartStopTimer
            // 
            this.btnStartStopTimer.Location = new System.Drawing.Point(12, 6);
            this.btnStartStopTimer.Name = "btnStartStopTimer";
            this.btnStartStopTimer.Size = new System.Drawing.Size(75, 23);
            this.btnStartStopTimer.TabIndex = 5;
            this.btnStartStopTimer.Text = "Start Timer";
            this.btnStartStopTimer.UseVisualStyleBackColor = true;
            this.btnStartStopTimer.Click += new System.EventHandler(this.btnStartTimer_Click);
            // 
            // pnlDisplayInfo
            // 
            this.pnlDisplayInfo.AutoScroll = true;
            this.pnlDisplayInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplayInfo.Location = new System.Drawing.Point(0, 59);
            this.pnlDisplayInfo.Name = "pnlDisplayInfo";
            this.pnlDisplayInfo.Size = new System.Drawing.Size(526, 273);
            this.pnlDisplayInfo.TabIndex = 7;
            this.pnlDisplayInfo.Click += new System.EventHandler(this.pnlDisplayInfo_Click);
            // 
            // lblTimeRounded
            // 
            this.lblTimeRounded.AutoSize = true;
            this.lblTimeRounded.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeRounded.Location = new System.Drawing.Point(378, 38);
            this.lblTimeRounded.Name = "lblTimeRounded";
            this.lblTimeRounded.Size = new System.Drawing.Size(89, 13);
            this.lblTimeRounded.TabIndex = 8;
            this.lblTimeRounded.Text = "Time Rounded";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(285, 38);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(57, 13);
            this.lblCategory.TabIndex = 7;
            this.lblCategory.Text = "Category";
            // 
            // lblTimeToday
            // 
            this.lblTimeToday.AutoSize = true;
            this.lblTimeToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeToday.Location = new System.Drawing.Point(194, 38);
            this.lblTimeToday.Name = "lblTimeToday";
            this.lblTimeToday.Size = new System.Drawing.Size(73, 13);
            this.lblTimeToday.TabIndex = 6;
            this.lblTimeToday.Text = "Time Today";
            // 
            // lblCurrentlySelected
            // 
            this.lblCurrentlySelected.AutoSize = true;
            this.lblCurrentlySelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentlySelected.Location = new System.Drawing.Point(12, 38);
            this.lblCurrentlySelected.Name = "lblCurrentlySelected";
            this.lblCurrentlySelected.Size = new System.Drawing.Size(111, 13);
            this.lblCurrentlySelected.TabIndex = 5;
            this.lblCurrentlySelected.Text = "Currently Selected";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.ucMenuStrip1);
            this.pnlTop.Controls.Add(this.lblTimeRounded);
            this.pnlTop.Controls.Add(this.lblCategory);
            this.pnlTop.Controls.Add(this.lblTimeToday);
            this.pnlTop.Controls.Add(this.lblCurrentlySelected);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(526, 59);
            this.pnlTop.TabIndex = 13;
            // 
            // ucMenuStrip1
            // 
            this.ucMenuStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucMenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.ucMenuStrip1.Name = "ucMenuStrip1";
            this.ucMenuStrip1.Size = new System.Drawing.Size(526, 24);
            this.ucMenuStrip1.TabIndex = 9;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.ucTimeSummary1);
            this.pnlBottom.Controls.Add(this.pnlTopOfBottom);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 332);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(526, 191);
            this.pnlBottom.TabIndex = 12;
            // 
            // ucTimeSummary1
            // 
            this.ucTimeSummary1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTimeSummary1.Location = new System.Drawing.Point(0, 39);
            this.ucTimeSummary1.Name = "ucTimeSummary1";
            this.ucTimeSummary1.Size = new System.Drawing.Size(526, 152);
            this.ucTimeSummary1.TabIndex = 15;
            // 
            // pnlTopOfBottom
            // 
            this.pnlTopOfBottom.Controls.Add(this.btnStartStopTimer);
            this.pnlTopOfBottom.Controls.Add(this.lblTotalTime);
            this.pnlTopOfBottom.Controls.Add(this.txtTotalTime);
            this.pnlTopOfBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopOfBottom.Location = new System.Drawing.Point(0, 0);
            this.pnlTopOfBottom.Name = "pnlTopOfBottom";
            this.pnlTopOfBottom.Size = new System.Drawing.Size(526, 39);
            this.pnlTopOfBottom.TabIndex = 16;
            this.pnlTopOfBottom.Click += new System.EventHandler(this.pnlTopOfBottom_Click);
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.AutoSize = true;
            this.lblTotalTime.Location = new System.Drawing.Point(399, 11);
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(60, 13);
            this.lblTotalTime.TabIndex = 13;
            this.lblTotalTime.Text = "Total Time:";
            // 
            // txtTotalTime
            // 
            this.txtTotalTime.AutoSize = true;
            this.txtTotalTime.Location = new System.Drawing.Point(465, 11);
            this.txtTotalTime.Name = "txtTotalTime";
            this.txtTotalTime.Size = new System.Drawing.Size(49, 13);
            this.txtTotalTime.TabIndex = 14;
            this.txtTotalTime.Text = "00:00:00";
            // 
            // splitTopBottom
            // 
            this.splitTopBottom.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitTopBottom.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitTopBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitTopBottom.Location = new System.Drawing.Point(0, 329);
            this.splitTopBottom.Name = "splitTopBottom";
            this.splitTopBottom.Size = new System.Drawing.Size(526, 3);
            this.splitTopBottom.TabIndex = 14;
            this.splitTopBottom.TabStop = false;
            // 
            // activeTimer
            // 
            this.activeTimer.Interval = 60000;
            this.activeTimer.Tick += new System.EventHandler(this.AddTheElapsedTime);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(526, 523);
            this.Controls.Add(this.splitTopBottom);
            this.Controls.Add(this.pnlDisplayInfo);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Name = "frmMain";
            this.Text = "Time Tracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.trayIconContextMenu.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlTopOfBottom.ResumeLayout(false);
            this.pnlTopOfBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Button btnStartStopTimer;
        private System.Windows.Forms.Panel pnlDisplayInfo;
        private System.Windows.Forms.Label lblTimeToday;
        private System.Windows.Forms.Label lblCurrentlySelected;
        private EventTimer activeTimer;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label txtTotalTime;
        private System.Windows.Forms.Label lblTotalTime;
        private System.Windows.Forms.Label lblTimeRounded;
        private System.Windows.Forms.ContextMenuStrip trayIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem trayUnhide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem trayExit;
        private ucTimeSummary ucTimeSummary1;
        private ucMenuStrip ucMenuStrip1;
        private System.Windows.Forms.Splitter splitTopBottom;
        private System.Windows.Forms.Panel pnlTopOfBottom;
    }
}

