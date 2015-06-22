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
        internal void SetupLogEvents()
        {
            GlobalData.Issues.ItemAdded += EventLog.NewIssueAdded;
            GlobalData.Issues.ItemRemoved += EventLog.IssueRemoved;
            GlobalData.Categories.ItemAdded += EventLog.NewCategoryAdded;
            GlobalData.Categories.ItemRemoved += EventLog.CategoryRemoved;
            GlobalData.Categories.ItemMerged += EventLog.CategoryMerged;
        }
    }
}
