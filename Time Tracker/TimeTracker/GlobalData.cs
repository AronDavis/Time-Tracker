using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTracker.Hotkeys;

namespace TimeTracker
{
    public static class GlobalData
    {
        public static GlobalHotkey HotKey;

        public static List<String> ListIDs = new List<String>();
        public static List<String> ListDisplayText = new List<String>();
        public static List<TimeSpan> TodaysLoggedTimes = new List<TimeSpan>();
        public static List<String> ListCategoryDisplayText = new List<String>();
        public static List<String> ListCategories= new List<String>();

        public static frmMain mainForm;
        public static frmChangeHotkey changeHotkeyForm;

        public static frmAddNewIssue formAddNewIssue = new frmAddNewIssue();
        public static frmRemoveIssue formRemoveIssue = new frmRemoveIssue();

        public static String GetUniqueID()
        {
            return ("ID" + DateTime.Now.ToString("yyyyMMddhhmmssffftt"));
        }
    }
}
