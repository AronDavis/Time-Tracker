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
            this.lblCountTowardsWorkTime = new System.Windows.Forms.Label();
            this.lblTimeToday = new System.Windows.Forms.Label();
            this.lblCurrentlySelected = new System.Windows.Forms.Label();
            this.activeTimer = new System.Windows.Forms.Timer(this.components);
            this.lblTotalTimeWorkedToday = new System.Windows.Forms.Label();
            this.txtTotalTimeWorkedToday = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
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
            this.changeHideUnhideHotkeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roundingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbRoundDirections = new System.Windows.Forms.ToolStripComboBox();
            this.downToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.txtTotalTime = new System.Windows.Forms.Label();
            this.lblTotalTime = new System.Windows.Forms.Label();
            this.txtTotalBreakTime = new System.Windows.Forms.Label();
            this.lblTotalBreakTime = new System.Windows.Forms.Label();
            this.trayIconContextMenu.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnlBottom.SuspendLayout();
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
            this.pnlDisplayInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplayInfo.Location = new System.Drawing.Point(0, 59);
            this.pnlDisplayInfo.Name = "pnlDisplayInfo";
            this.pnlDisplayInfo.Size = new System.Drawing.Size(526, 273);
            this.pnlDisplayInfo.TabIndex = 7;
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
            // lblCountTowardsWorkTime
            // 
            this.lblCountTowardsWorkTime.AutoSize = true;
            this.lblCountTowardsWorkTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountTowardsWorkTime.Location = new System.Drawing.Point(285, 38);
            this.lblCountTowardsWorkTime.Name = "lblCountTowardsWorkTime";
            this.lblCountTowardsWorkTime.Size = new System.Drawing.Size(68, 13);
            this.lblCountTowardsWorkTime.TabIndex = 7;
            this.lblCountTowardsWorkTime.Text = "Work Time";
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
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblTimeRounded);
            this.pnlTop.Controls.Add(this.lblCountTowardsWorkTime);
            this.pnlTop.Controls.Add(this.menuStrip1);
            this.pnlTop.Controls.Add(this.lblTimeToday);
            this.pnlTop.Controls.Add(this.lblCurrentlySelected);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(526, 59);
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
            this.menuStrip1.Size = new System.Drawing.Size(526, 24);
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
            this.timerToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.timerToolStripMenuItem.Text = "Timer";
            // 
            // startTimerToolStripMenuItem
            // 
            this.startTimerToolStripMenuItem.Name = "startTimerToolStripMenuItem";
            this.startTimerToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.startTimerToolStripMenuItem.Text = "Start Timer";
            this.startTimerToolStripMenuItem.Click += new System.EventHandler(this.btnStartTimer_Click);
            // 
            // stopTimerToolStripMenuItem
            // 
            this.stopTimerToolStripMenuItem.Enabled = false;
            this.stopTimerToolStripMenuItem.Name = "stopTimerToolStripMenuItem";
            this.stopTimerToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.stopTimerToolStripMenuItem.Text = "Stop Timer";
            this.stopTimerToolStripMenuItem.Click += new System.EventHandler(this.btnStartTimer_Click);
            // 
            // addNewIssueToolStripMenuItem1
            // 
            this.addNewIssueToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewIssueToolStripMenuItem2,
            this.removeIssuesToolStripMenuItem1});
            this.addNewIssueToolStripMenuItem1.Name = "addNewIssueToolStripMenuItem1";
            this.addNewIssueToolStripMenuItem1.Size = new System.Drawing.Size(105, 22);
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
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
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
            this.resetSelectedTimeToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.resetSelectedTimeToolStripMenuItem.Text = "Selected Time";
            this.resetSelectedTimeToolStripMenuItem.Click += new System.EventHandler(this.resetSelectedTimeToolStripMenuItem_Click);
            // 
            // resetAllTimeTodayToolStripMenuItem
            // 
            this.resetAllTimeTodayToolStripMenuItem.Name = "resetAllTimeTodayToolStripMenuItem";
            this.resetAllTimeTodayToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.resetAllTimeTodayToolStripMenuItem.Text = "All Time";
            this.resetAllTimeTodayToolStripMenuItem.Click += new System.EventHandler(this.resetAllTimeTodayToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeHideUnhideHotkeyToolStripMenuItem,
            this.roundingToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // changeHideUnhideHotkeyToolStripMenuItem
            // 
            this.changeHideUnhideHotkeyToolStripMenuItem.Name = "changeHideUnhideHotkeyToolStripMenuItem";
            this.changeHideUnhideHotkeyToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.changeHideUnhideHotkeyToolStripMenuItem.Text = "Change Hide/Unhide Hotkey";
            this.changeHideUnhideHotkeyToolStripMenuItem.Click += new System.EventHandler(this.changeHideUnhideHotkeyToolStripMenuItem_Click);
            // 
            // roundingToolStripMenuItem
            // 
            this.roundingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.upToolStripMenuItem,
            this.downToolStripMenuItem});
            this.roundingToolStripMenuItem.Name = "roundingToolStripMenuItem";
            this.roundingToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.roundingToolStripMenuItem.Text = "Rounding";
            // 
            // upToolStripMenuItem
            // 
            this.upToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbRoundDirections});
            this.upToolStripMenuItem.Name = "upToolStripMenuItem";
            this.upToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.upToolStripMenuItem.Text = "Direction";
            // 
            // cbRoundDirections
            // 
            this.cbRoundDirections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRoundDirections.Name = "cbRoundDirections";
            this.cbRoundDirections.Size = new System.Drawing.Size(121, 23);
            this.cbRoundDirections.SelectedIndexChanged += new System.EventHandler(this.cbRoundDirections_SelectedIndexChanged);
            // 
            // downToolStripMenuItem
            // 
            this.downToolStripMenuItem.Name = "downToolStripMenuItem";
            this.downToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.downToolStripMenuItem.Text = "Round To...";
            this.downToolStripMenuItem.Click += new System.EventHandler(this.downToolStripMenuItem_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.txtTotalTime);
            this.pnlBottom.Controls.Add(this.lblTotalTime);
            this.pnlBottom.Controls.Add(this.txtTotalBreakTime);
            this.pnlBottom.Controls.Add(this.lblTotalBreakTime);
            this.pnlBottom.Controls.Add(this.btnStartStopTimer);
            this.pnlBottom.Controls.Add(this.txtTotalTimeWorkedToday);
            this.pnlBottom.Controls.Add(this.lblTotalTimeWorkedToday);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 332);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(526, 80);
            this.pnlBottom.TabIndex = 12;
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(526, 412);
            this.Controls.Add(this.pnlDisplayInfo);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Time Tracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.trayIconContextMenu.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Button btnStartStopTimer;
        private System.Windows.Forms.Panel pnlDisplayInfo;
        private System.Windows.Forms.Label lblTimeToday;
        private System.Windows.Forms.Label lblCurrentlySelected;
        private System.Windows.Forms.Timer activeTimer;
        private System.Windows.Forms.Label lblTotalTimeWorkedToday;
        private System.Windows.Forms.Label txtTotalTimeWorkedToday;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;
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
        private System.Windows.Forms.ToolStripMenuItem changeHideUnhideHotkeyToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip trayIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem trayUnhide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem trayExit;
        private System.Windows.Forms.ToolStripMenuItem roundingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cbRoundDirections;
    }
}

