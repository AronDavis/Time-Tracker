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
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.btnStartStopTimer = new System.Windows.Forms.Button();
            this.pnlDisplayInfo = new System.Windows.Forms.Panel();
            this.lblTimeRounded = new System.Windows.Forms.Label();
            this.lblCountTowardsWorkTime = new System.Windows.Forms.Label();
            this.lblTimeToday = new System.Windows.Forms.Label();
            this.lblCurrentlySelected = new System.Windows.Forms.Label();
            this.activeTimer = new System.Windows.Forms.Timer(this.components);
            this.lblTotalTimeWorkedToday = new System.Windows.Forms.Label();
            this.txtTotalTimeWorkedToday = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewIssueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewIssueToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeIssuesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetSelectedTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetAllTimeTodayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeHotkeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTotalTime = new System.Windows.Forms.Label();
            this.lblTotalTime = new System.Windows.Forms.Label();
            this.txtTotalBreakTime = new System.Windows.Forms.Label();
            this.lblTotalBreakTime = new System.Windows.Forms.Label();
            this.unhideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlDisplayInfo.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Press Ctrl + Alt + Shift + O to bring up the Time Tracker window.";
            this.notifyIcon1.BalloonTipTitle = "Tip!";
            this.notifyIcon1.Text = "Time Tracker";
            this.notifyIcon1.Visible = true;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(489, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 302);
            this.button1.TabIndex = 1;
            this.button1.Text = "Hide";
            this.toolTip1.SetToolTip(this.button1, "Press Ctrl + Alt + Shift + F10 to open a hidden Time Tracker window!");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnStartStopTimer
            // 
            this.btnStartStopTimer.Location = new System.Drawing.Point(15, 9);
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
            this.pnlDisplayInfo.Controls.Add(this.lblTimeRounded);
            this.pnlDisplayInfo.Controls.Add(this.lblCountTowardsWorkTime);
            this.pnlDisplayInfo.Controls.Add(this.lblTimeToday);
            this.pnlDisplayInfo.Controls.Add(this.lblCurrentlySelected);
            this.pnlDisplayInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplayInfo.Location = new System.Drawing.Point(0, 24);
            this.pnlDisplayInfo.Name = "pnlDisplayInfo";
            this.pnlDisplayInfo.Size = new System.Drawing.Size(486, 199);
            this.pnlDisplayInfo.TabIndex = 7;
            // 
            // lblTimeRounded
            // 
            this.lblTimeRounded.AutoSize = true;
            this.lblTimeRounded.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeRounded.Location = new System.Drawing.Point(378, 9);
            this.lblTimeRounded.Name = "lblTimeRounded";
            this.lblTimeRounded.Size = new System.Drawing.Size(89, 13);
            this.lblTimeRounded.TabIndex = 8;
            this.lblTimeRounded.Text = "Time Rounded";
            // 
            // lblCountTowardsWorkTime
            // 
            this.lblCountTowardsWorkTime.AutoSize = true;
            this.lblCountTowardsWorkTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountTowardsWorkTime.Location = new System.Drawing.Point(285, 9);
            this.lblCountTowardsWorkTime.Name = "lblCountTowardsWorkTime";
            this.lblCountTowardsWorkTime.Size = new System.Drawing.Size(68, 13);
            this.lblCountTowardsWorkTime.TabIndex = 7;
            this.lblCountTowardsWorkTime.Text = "Work Time";
            // 
            // lblTimeToday
            // 
            this.lblTimeToday.AutoSize = true;
            this.lblTimeToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeToday.Location = new System.Drawing.Point(194, 9);
            this.lblTimeToday.Name = "lblTimeToday";
            this.lblTimeToday.Size = new System.Drawing.Size(73, 13);
            this.lblTimeToday.TabIndex = 6;
            this.lblTimeToday.Text = "Time Today";
            // 
            // lblCurrentlySelected
            // 
            this.lblCurrentlySelected.AutoSize = true;
            this.lblCurrentlySelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentlySelected.Location = new System.Drawing.Point(12, 9);
            this.lblCurrentlySelected.Name = "lblCurrentlySelected";
            this.lblCurrentlySelected.Size = new System.Drawing.Size(111, 13);
            this.lblCurrentlySelected.TabIndex = 5;
            this.lblCurrentlySelected.Text = "Currently Selected";
            // 
            // activeTimer
            // 
            this.activeTimer.Interval = 60000;
            this.activeTimer.Tick += new System.EventHandler(this.AddTheElapsedTime);
            // 
            // lblTotalTimeWorkedToday
            // 
            this.lblTotalTimeWorkedToday.AutoSize = true;
            this.lblTotalTimeWorkedToday.Location = new System.Drawing.Point(194, 14);
            this.lblTotalTimeWorkedToday.Name = "lblTotalTimeWorkedToday";
            this.lblTotalTimeWorkedToday.Size = new System.Drawing.Size(89, 13);
            this.lblTotalTimeWorkedToday.TabIndex = 9;
            this.lblTotalTimeWorkedToday.Text = "Total Work Time:";
            // 
            // txtTotalTimeWorkedToday
            // 
            this.txtTotalTimeWorkedToday.AutoSize = true;
            this.txtTotalTimeWorkedToday.Location = new System.Drawing.Point(337, 14);
            this.txtTotalTimeWorkedToday.Name = "txtTotalTimeWorkedToday";
            this.txtTotalTimeWorkedToday.Size = new System.Drawing.Size(49, 13);
            this.txtTotalTimeWorkedToday.TabIndex = 10;
            this.txtTotalTimeWorkedToday.Text = "00:00:00";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(486, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 302);
            this.splitter1.TabIndex = 12;
            this.splitter1.TabStop = false;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.pnlDisplayInfo);
            this.pnlTop.Controls.Add(this.menuStrip1);
            this.pnlTop.Controls.Add(this.panel2);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(486, 302);
            this.pnlTop.TabIndex = 13;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(486, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timerToolStripMenuItem,
            this.addNewIssueToolStripMenuItem1,
            this.hideToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // timerToolStripMenuItem
            // 
            this.timerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startTimerToolStripMenuItem,
            this.stopTimerToolStripMenuItem});
            this.timerToolStripMenuItem.Name = "timerToolStripMenuItem";
            this.timerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.timerToolStripMenuItem.Text = "Timer";
            // 
            // startTimerToolStripMenuItem
            // 
            this.startTimerToolStripMenuItem.Name = "startTimerToolStripMenuItem";
            this.startTimerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startTimerToolStripMenuItem.Text = "Start Timer";
            this.startTimerToolStripMenuItem.Click += new System.EventHandler(this.btnStartTimer_Click);
            // 
            // stopTimerToolStripMenuItem
            // 
            this.stopTimerToolStripMenuItem.Enabled = false;
            this.stopTimerToolStripMenuItem.Name = "stopTimerToolStripMenuItem";
            this.stopTimerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.stopTimerToolStripMenuItem.Text = "Stop Timer";
            this.stopTimerToolStripMenuItem.Click += new System.EventHandler(this.btnStartTimer_Click);
            // 
            // addNewIssueToolStripMenuItem1
            // 
            this.addNewIssueToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewIssueToolStripMenuItem2,
            this.removeIssuesToolStripMenuItem1});
            this.addNewIssueToolStripMenuItem1.Name = "addNewIssueToolStripMenuItem1";
            this.addNewIssueToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.addNewIssueToolStripMenuItem1.Text = "Issues";
            // 
            // addNewIssueToolStripMenuItem2
            // 
            this.addNewIssueToolStripMenuItem2.Name = "addNewIssueToolStripMenuItem2";
            this.addNewIssueToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.addNewIssueToolStripMenuItem2.Text = "Add New Issue";
            this.addNewIssueToolStripMenuItem2.Click += new System.EventHandler(this.addNewIssueToolStripMenuItem2_Click);
            // 
            // removeIssuesToolStripMenuItem1
            // 
            this.removeIssuesToolStripMenuItem1.Name = "removeIssuesToolStripMenuItem1";
            this.removeIssuesToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.removeIssuesToolStripMenuItem1.Text = "Remove Issues";
            this.removeIssuesToolStripMenuItem1.Click += new System.EventHandler(this.removeIssuesToolStripMenuItem1_Click);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "Exit";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetSelectedTimeToolStripMenuItem,
            this.resetAllTimeTodayToolStripMenuItem});
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.resetToolStripMenuItem.Text = "Reset";
            // 
            // resetSelectedTimeToolStripMenuItem
            // 
            this.resetSelectedTimeToolStripMenuItem.Name = "resetSelectedTimeToolStripMenuItem";
            this.resetSelectedTimeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.resetSelectedTimeToolStripMenuItem.Text = "Selected Time";
            this.resetSelectedTimeToolStripMenuItem.Click += new System.EventHandler(this.resetSelectedTimeToolStripMenuItem_Click);
            // 
            // resetAllTimeTodayToolStripMenuItem
            // 
            this.resetAllTimeTodayToolStripMenuItem.Name = "resetAllTimeTodayToolStripMenuItem";
            this.resetAllTimeTodayToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.resetAllTimeTodayToolStripMenuItem.Text = "All Time";
            this.resetAllTimeTodayToolStripMenuItem.Click += new System.EventHandler(this.resetAllTimeTodayToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeHotkeysToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // changeHotkeysToolStripMenuItem
            // 
            this.changeHotkeysToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unhideToolStripMenuItem});
            this.changeHotkeysToolStripMenuItem.Name = "changeHotkeysToolStripMenuItem";
            this.changeHotkeysToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.changeHotkeysToolStripMenuItem.Text = "Change Hotkeys";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtTotalTime);
            this.panel2.Controls.Add(this.lblTotalTime);
            this.panel2.Controls.Add(this.txtTotalBreakTime);
            this.panel2.Controls.Add(this.lblTotalBreakTime);
            this.panel2.Controls.Add(this.btnStartStopTimer);
            this.panel2.Controls.Add(this.txtTotalTimeWorkedToday);
            this.panel2.Controls.Add(this.lblTotalTimeWorkedToday);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 223);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(486, 79);
            this.panel2.TabIndex = 12;
            // 
            // txtTotalTime
            // 
            this.txtTotalTime.AutoSize = true;
            this.txtTotalTime.Location = new System.Drawing.Point(337, 45);
            this.txtTotalTime.Name = "txtTotalTime";
            this.txtTotalTime.Size = new System.Drawing.Size(49, 13);
            this.txtTotalTime.TabIndex = 14;
            this.txtTotalTime.Text = "00:00:00";
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.AutoSize = true;
            this.lblTotalTime.Location = new System.Drawing.Point(194, 45);
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(60, 13);
            this.lblTotalTime.TabIndex = 13;
            this.lblTotalTime.Text = "Total Time:";
            // 
            // txtTotalBreakTime
            // 
            this.txtTotalBreakTime.AutoSize = true;
            this.txtTotalBreakTime.Location = new System.Drawing.Point(337, 27);
            this.txtTotalBreakTime.Name = "txtTotalBreakTime";
            this.txtTotalBreakTime.Size = new System.Drawing.Size(49, 13);
            this.txtTotalBreakTime.TabIndex = 12;
            this.txtTotalBreakTime.Text = "00:00:00";
            // 
            // lblTotalBreakTime
            // 
            this.lblTotalBreakTime.AutoSize = true;
            this.lblTotalBreakTime.Location = new System.Drawing.Point(194, 27);
            this.lblTotalBreakTime.Name = "lblTotalBreakTime";
            this.lblTotalBreakTime.Size = new System.Drawing.Size(94, 13);
            this.lblTotalBreakTime.TabIndex = 11;
            this.lblTotalBreakTime.Text = "Total Break Time: ";
            // 
            // unhideToolStripMenuItem
            // 
            this.unhideToolStripMenuItem.Name = "unhideToolStripMenuItem";
            this.unhideToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.unhideToolStripMenuItem.Text = "Unhide";
            this.unhideToolStripMenuItem.Click += new System.EventHandler(this.unhideToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(526, 302);
            this.ControlBox = false;
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.button1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Time Tracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.pnlDisplayInfo.ResumeLayout(false);
            this.pnlDisplayInfo.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnStartStopTimer;
        private System.Windows.Forms.Panel pnlDisplayInfo;
        private System.Windows.Forms.Label lblTimeToday;
        private System.Windows.Forms.Label lblCurrentlySelected;
        private System.Windows.Forms.Timer activeTimer;
        private System.Windows.Forms.Label lblTotalTimeWorkedToday;
        private System.Windows.Forms.Label txtTotalTimeWorkedToday;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewIssueToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addNewIssueToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem removeIssuesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem timerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startTimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopTimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetSelectedTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetAllTimeTodayToolStripMenuItem;
        private System.Windows.Forms.Label lblCountTowardsWorkTime;
        private System.Windows.Forms.Label txtTotalBreakTime;
        private System.Windows.Forms.Label lblTotalBreakTime;
        private System.Windows.Forms.Label txtTotalTime;
        private System.Windows.Forms.Label lblTotalTime;
        private System.Windows.Forms.Label lblTimeRounded;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeHotkeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unhideToolStripMenuItem;
    }
}

