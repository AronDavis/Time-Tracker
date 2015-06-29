using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTracker
{
    static class EventLog
    {
        #region Issue
        internal static void NewIssueAdded(object sender, EventList<IssueData>.ItemArgs e)
        {
            HandleNewIssueAdded(e.item);
        }

        internal static void IssueRemoved(object sender, EventList<IssueData>.ItemArgs e)
        {
            HandleIssueRemoved(e.item);
        }

        private static void HandleNewIssueAdded(IssueData issue)
        {
            EventUtility.AddEvent(new Event(DateTime.Now, Event.EventType.NewIssue));
        }

        private static void HandleIssueRemoved(IssueData issue)
        {
            EventUtility.AddEvent(new Event(DateTime.Now, Event.EventType.RemoveIssue));
        }
        #endregion

        #region Category
        internal static void NewCategoryAdded(object sender, CategoryList.ItemArgs e)
        {
            HandleNewCategoryAdded(e.item);
        }

        private static void  HandleNewCategoryAdded(Category cat)
        {
            EventUtility.AddEvent(new Event(DateTime.Now, Event.EventType.NewCategory));
        }


        internal static void CategoryRemoved(object sender, CategoryList.ItemArgs e)
        {
            HandleCategoryRemoved(e.item);
        }        

        private static void HandleCategoryRemoved(Category cat)
        {
            EventUtility.AddEvent(new Event(DateTime.Now, Event.EventType.RemoveCategory));
        }

        internal static void CategoryMerged(object sender, CategoryList.MergeItemArgs e)
        {
            HandleCategoryMerged(e.MergeThis, e.IntoThis);
        }

        private static void  HandleCategoryMerged(Category mergeThis, Category intoThis)
        {
            EventUtility.AddEvent(new Event(DateTime.Now, Event.EventType.MergeCategory));
        }
        #endregion     

        internal static void ChangedIssueCategory(IssueData issue, Category oldCat, Category newCat)
        {
            EventUtility.AddEvent(new Event(DateTime.Now, Event.EventType.ChangedIssueCategory));
        }

        #region Timer
        internal static void TimerStarted(object sender, EventTimer.TimerArgs e)
        {
            HandleTimerStarted(e.time);
        }

        private static void HandleTimerStarted(DateTime timeStarted)
        {
            EventUtility.AddEvent(new Event(DateTime.Now, Event.EventType.StartTimer));
        }

        internal static void TimerStopped(object sender, EventTimer.TimerArgs e)
        {
            HandleTimerStopped(e.time);
        }

        private static void HandleTimerStopped(DateTime timeStarted)
        {
            EventUtility.AddEvent(new Event(DateTime.Now, Event.EventType.StopTimer));
        }
        #endregion

        internal static void TimeReset(IssueData issue)
        {
            EventUtility.AddEvent(new Event(DateTime.Now, Event.EventType.ResetTime));
        }
        internal static void ActiveIssueChanged(IssueData newActive)
        {
            EventUtility.AddEvent(new Event(DateTime.Now, Event.EventType.SwitchedActiveIssue));
        }
    }
}
