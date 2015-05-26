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

        public static frmMain mainForm;
        public static frmChangeHotkey changeHotkeyForm;

        public static AddNewIssue formAddNewIssue = new AddNewIssue();
        public static RemoveIssue formRemoveIssue = new RemoveIssue();

        public static String GetUniqueID()
        {
            return ("ID" + DateTime.Now.ToString("yyyyMMddhhmmssffftt"));
        }
    }
}
