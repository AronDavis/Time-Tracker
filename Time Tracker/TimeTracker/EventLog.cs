using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTracker
{
    static class EventLog
    {
        public enum LogType
        {
            NewIssue,
            RemoveIssue,
            NewCategory,
            MergeCategory,
            ChangedIssueCategory,
            StartTimer,
            StopTimer,
            ResetTime,
            SwitchedActiveIssue
        }

        #region Issue
        internal static void NewIssueAdded(object sender, EventList<IssueData>.ItemArgs e)
        {
            HandleNewIssueAdded(e.item);
        }

        internal static void IssueRemoved(object sender, EventList<IssueData>.ItemArgs e)
        {
            HandleIssueRemoved(e.item);
        }

        private static bool HandleNewIssueAdded(IssueData issue)
        {
            return false;
        }

        private static bool HandleIssueRemoved(IssueData issue)
        {
            return false;
        }
        #endregion

        #region Category
        internal static void NewCategoryAdded(object sender, CategoryList.ItemArgs e)
        {
            HandleNewCategoryAdded(e.item);
        }

        private static bool HandleNewCategoryAdded(Category cat)
        {
            return false;
        }


        internal static void CategoryRemoved(object sender, CategoryList.ItemArgs e)
        {
            HandleCategoryRemoved(e.item);
        }        

        private static bool HandleCategoryRemoved(Category cat)
        {
            return false;
        }


        internal static void CategoryMerged(object sender, CategoryList.MergeItemArgs e)
        {
            HandleCategoryMerged(e.MergeThis, e.IntoThis);
        }

        private static bool HandleCategoryMerged(Category mergeThis, Category intoThis)
        {
            return false;
        }
        #endregion     

        internal static bool ChangedIssueCategory(IssueData issue, Category oldCat, Category newCat)
        {
            return false;
        }

        #region Timer
        internal static void TimerStarted(object sender, EventTimer.TimerArgs e)
        {
            HandleTimerStarted(e.time);
        }

        private static bool HandleTimerStarted(DateTime timeStarted)
        {
            return false;
        }

        internal static void TimerStopped(object sender, EventTimer.TimerArgs e)
        {
            HandleTimerStopped(e.time);
        }

        private static bool HandleTimerStopped(DateTime timeStarted)
        {
            return false;
        }
        #endregion

        internal static bool TimeReset(IssueData issue)
        {
            return false;
        }
        internal static bool ActiveIssueChanged(IssueData newActive)
        {
            return false;
        }
    }
}
