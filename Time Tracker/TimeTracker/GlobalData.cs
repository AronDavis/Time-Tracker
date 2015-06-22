using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTracker.Hotkeys;

namespace TimeTracker
{
    public static class GlobalData
    {
        internal const String strDirectory = @"C:\Program Files\TimeTracker\";
        internal const String strSettingsPath = @"Settings\",
            strSettingsFileName = "Settings",
            strSettingsFileType = ".xml",
            strTimeLogsPath = @"Time Logs\",
            strTodaysTimeLogFileName = "TimeLog", //no space due to xml root node (could be fixed)
            strTodaysTimeLogFileType = ".xml",
            strEventLogPath = @"Event Log\",
            strEventLogFileName = "EventLog",
            strEventLogFileType = ".xml";

        public static TimeUtility.RoundDirection RoundDirection = TimeUtility.RoundDirection.Average;
        public static TimeSpan RoundTo = new TimeSpan(0, 15, 0);
        public static GlobalHotkey HotKey;

        internal static EventList<IssueData> Issues = new EventList<IssueData>();

        public static int GetIssueIndexByID(String id)
        {
            for(int i = 0; i < Issues.Count; i++)
            {
                if (Issues[i].ID == id) return i;
            }
            return -1;
        }

        internal static CategoryList Categories = new CategoryList();

        public static Category GetCategoryByID(String id)
        {
            foreach(Category c in Categories)
            {
                if (c.ID == id) return c;
            }
            return null;
        }

        public static int GetCategoryIndexByID(String id)
        {
            for (int i = 0; i < Categories.Count; i++)
            {
                if (Categories[i].ID == id) return i;
            }
            return -1;
        }

        public static frmMain mainForm;
        public static frmChangeHotkey formChangeHotkey = new frmChangeHotkey();
        public static frmAddNewIssue formAddNewIssue = new frmAddNewIssue();
        public static frmRemoveIssue formRemoveIssue = new frmRemoveIssue();
        public static frmAddNewCategory formAddNewCategory = new frmAddNewCategory();
        public static frmRemoveCategory formRemoveCategory = new frmRemoveCategory();
        
        public static String GetUniqueID()
        {
            return "ID" + (Guid.NewGuid()).ToString().Replace("-","");
        }
    }
}
