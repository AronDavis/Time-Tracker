using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTracker.Hotkeys;

namespace TimeTracker
{
    public static class GlobalData
    {
        public static TimeUtility.RoundDirection RoundDirection = TimeUtility.RoundDirection.Average;
        public static TimeSpan RoundTo = new TimeSpan(0, 15, 0);
        public static GlobalHotkey HotKey;

        public static List<IssueData> Issues = new List<IssueData>();

        public static int GetIssueIndexByID(String id)
        {
            for(int i = 0; i < Issues.Count; i++)
            {
                if (Issues[i].ID == id) return i;
            }
            return -1;
        }

        public static List<Category> Categories = new List<Category>();

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

        
        public static String GetUniqueID()
        {
            return "ID" + (Guid.NewGuid()).ToString().Replace("-","");
        }
    }
}
