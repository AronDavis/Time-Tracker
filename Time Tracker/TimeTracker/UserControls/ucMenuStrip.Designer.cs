namespace TimeTracker
{
    partial class ucMenuStrip
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miIssues = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewIssueToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeIssuesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddNewCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetSelectedTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetAllTimeTodayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeHideUnhideHotkeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miRounding = new System.Windows.Forms.ToolStripMenuItem();
            this.upToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbRoundDirections = new System.Windows.Forms.ToolStripComboBox();
            this.downToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtRoundTo = new System.Windows.Forms.ToolStripTextBox();
            this.miRemoveCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timerToolStripMenuItem,
            this.miIssues,
            this.categoriesToolStripMenuItem,
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
            this.startTimerToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.startTimerToolStripMenuItem.Text = "Start Timer";
            // 
            // stopTimerToolStripMenuItem
            // 
            this.stopTimerToolStripMenuItem.Enabled = false;
            this.stopTimerToolStripMenuItem.Name = "stopTimerToolStripMenuItem";
            this.stopTimerToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.stopTimerToolStripMenuItem.Text = "Stop Timer";
            // 
            // miIssues
            // 
            this.miIssues.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewIssueToolStripMenuItem2,
            this.removeIssuesToolStripMenuItem1});
            this.miIssues.Name = "miIssues";
            this.miIssues.Size = new System.Drawing.Size(152, 22);
            this.miIssues.Text = "Issues";
            // 
            // addNewIssueToolStripMenuItem2
            // 
            this.addNewIssueToolStripMenuItem2.Name = "addNewIssueToolStripMenuItem2";
            this.addNewIssueToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.addNewIssueToolStripMenuItem2.Text = "Add New Issue";
            // 
            // removeIssuesToolStripMenuItem1
            // 
            this.removeIssuesToolStripMenuItem1.Name = "removeIssuesToolStripMenuItem1";
            this.removeIssuesToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.removeIssuesToolStripMenuItem1.Text = "Remove Issues";
            // 
            // categoriesToolStripMenuItem
            // 
            this.categoriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAddNewCategory,
            this.miRemoveCategory});
            this.categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            this.categoriesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.categoriesToolStripMenuItem.Text = "Categories";
            // 
            // miAddNewCategory
            // 
            this.miAddNewCategory.Name = "miAddNewCategory";
            this.miAddNewCategory.Size = new System.Drawing.Size(174, 22);
            this.miAddNewCategory.Text = "Add New Category";
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "Exit";
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
            // 
            // resetAllTimeTodayToolStripMenuItem
            // 
            this.resetAllTimeTodayToolStripMenuItem.Name = "resetAllTimeTodayToolStripMenuItem";
            this.resetAllTimeTodayToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.resetAllTimeTodayToolStripMenuItem.Text = "All Time";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeHideUnhideHotkeyToolStripMenuItem,
            this.miRounding});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // changeHideUnhideHotkeyToolStripMenuItem
            // 
            this.changeHideUnhideHotkeyToolStripMenuItem.Name = "changeHideUnhideHotkeyToolStripMenuItem";
            this.changeHideUnhideHotkeyToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.changeHideUnhideHotkeyToolStripMenuItem.Text = "Change Hide/Unhide Hotkey";
            // 
            // miRounding
            // 
            this.miRounding.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.upToolStripMenuItem,
            this.downToolStripMenuItem});
            this.miRounding.Name = "miRounding";
            this.miRounding.Size = new System.Drawing.Size(227, 22);
            this.miRounding.Text = "Rounding";
            // 
            // upToolStripMenuItem
            // 
            this.upToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbRoundDirections});
            this.upToolStripMenuItem.Name = "upToolStripMenuItem";
            this.upToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.upToolStripMenuItem.Text = "Direction";
            // 
            // cbRoundDirections
            // 
            this.cbRoundDirections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRoundDirections.Name = "cbRoundDirections";
            this.cbRoundDirections.Size = new System.Drawing.Size(121, 23);
            // 
            // downToolStripMenuItem
            // 
            this.downToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtRoundTo});
            this.downToolStripMenuItem.Name = "downToolStripMenuItem";
            this.downToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.downToolStripMenuItem.Text = "Round To...";
            // 
            // txtRoundTo
            // 
            this.txtRoundTo.Name = "txtRoundTo";
            this.txtRoundTo.Size = new System.Drawing.Size(100, 23);
            // 
            // miRemoveCategory
            // 
            this.miRemoveCategory.Name = "miRemoveCategory";
            this.miRemoveCategory.Size = new System.Drawing.Size(174, 22);
            this.miRemoveCategory.Text = "Remove Category";
            // 
            // ucMenuStrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip1);
            this.Name = "ucMenuStrip";
            this.Size = new System.Drawing.Size(526, 24);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem addNewIssueToolStripMenuItem2;
        public System.Windows.Forms.ToolStripMenuItem removeIssuesToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem timerToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem miIssues;
        public System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem resetSelectedTimeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem resetAllTimeTodayToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem changeHideUnhideHotkeyToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem miRounding;
        public System.Windows.Forms.ToolStripMenuItem upToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem downToolStripMenuItem;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        public System.Windows.Forms.ToolStripComboBox cbRoundDirections;
        public System.Windows.Forms.ToolStripTextBox txtRoundTo;
        public System.Windows.Forms.ToolStripMenuItem startTimerToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem stopTimerToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem categoriesToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem miAddNewCategory;
        internal System.Windows.Forms.ToolStripMenuItem miRemoveCategory;
    }
}
