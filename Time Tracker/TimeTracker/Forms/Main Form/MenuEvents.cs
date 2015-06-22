using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using TimeTracker.Hotkeys;
using System.Linq;

namespace TimeTracker
{
    public partial class frmMain : Form
    {
        public void SetupMenuEvents()
        {
            ucMenuStrip1.hideToolStripMenuItem.Click += hideToolStripMenuItem_Click;
            ucMenuStrip1.addNewIssueToolStripMenuItem2.Click += addNewIssueToolStripMenuItem2_Click;
            ucMenuStrip1.removeIssuesToolStripMenuItem1.Click += removeIssuesToolStripMenuItem1_Click;
            ucMenuStrip1.closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            ucMenuStrip1.resetSelectedTimeToolStripMenuItem.Click += resetSelectedTimeToolStripMenuItem_Click;
            ucMenuStrip1.resetAllTimeTodayToolStripMenuItem.Click += resetAllTimeTodayToolStripMenuItem_Click;
            ucMenuStrip1.changeHideUnhideHotkeyToolStripMenuItem.Click += changeHideUnhideHotkeyToolStripMenuItem_Click;
            ucMenuStrip1.cbRoundDirections.SelectedIndexChanged += cbRoundDirections_SelectedIndexChanged;
            ucMenuStrip1.txtRoundTo.KeyDown += txtRoundTo_KeyDown;
            ucMenuStrip1.miRounding.Click += miRounding_Click;
            ucMenuStrip1.startTimerToolStripMenuItem.Click += btnStartTimer_Click;
            ucMenuStrip1.stopTimerToolStripMenuItem.Click += btnStartTimer_Click;
            ucMenuStrip1.miAddNewCategory.Click += miAddNewCategory_Click;
            ucMenuStrip1.miRemoveCategory.Click += miRemoveCategory_Click;
        }

        void miRemoveCategory_Click(object sender, EventArgs e)
        {
            StaticForm.Open<frmRemoveCategory>(ref GlobalData.formRemoveCategory);
        }

        void miAddNewCategory_Click(object sender, EventArgs e)
        {
            StaticForm.Open<frmAddNewCategory>(ref GlobalData.formAddNewCategory);
        }

        private void addNewIssueToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            StaticForm.Open<frmAddNewIssue>(ref GlobalData.formAddNewIssue);
        }

        private void removeIssuesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StaticForm.Open<frmRemoveIssue>(ref GlobalData.formRemoveIssue);

            GlobalData.formRemoveIssue.GenerateIssueInterface();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void resetSelectedTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalData.Issues[indexOfCurrentlySelected].ResetTime();
            SumTime();
            SaveTodaysTimeLogFile();
        }

        private void resetAllTimeTodayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < labels.Count; i++)
            {
                GlobalData.Issues[i].ResetTime();
            }
        }

        private void changeHideUnhideHotkeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalData.formChangeHotkey.IsDisposed)
            {
                GlobalData.formChangeHotkey = new frmChangeHotkey();
            }

            GlobalData.formChangeHotkey.Show();
            GlobalData.formChangeHotkey.Activate();

        }
        
        private void cbRoundDirections_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalData.RoundDirection = (TimeUtility.RoundDirection)ucMenuStrip1.cbRoundDirections.SelectedItem;
            SumTime();
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideEverything();
        }

        private void txtRoundTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                int minutes;

                if (int.TryParse(ucMenuStrip1.txtRoundTo.Text, out minutes))
                {
                    GlobalData.RoundTo = new TimeSpan(0, minutes, 0);
                    SumTime();
                }
                else MessageBox.Show("Please enter a whole number.");
            }
        }

        private void miRounding_Click(object sender, EventArgs e)
        {
            ucMenuStrip1.txtRoundTo.Text = GlobalData.RoundTo.TotalMinutes.ToString();
        }
    }
}
