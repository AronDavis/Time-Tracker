using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTracker
{
    public static class GlobalData
    {
        public static List<String> ListIDs = new List<String>();
        public static List<String> ListDisplayText = new List<String>();
        public static List<TimeSpan> TodaysLoggedTimes = new List<TimeSpan>();

        public static frmMain mainForm = new frmMain();

        public static AddNewIssue formAddNewIssue = new AddNewIssue();
        public static RemoveIssue formRemoveIssue = new RemoveIssue();

        public static String GetUniqueID()
        {
            return ("ID" + DateTime.Now.ToString("yyyyMMddhhmmssffftt"));
        }
    }
}
