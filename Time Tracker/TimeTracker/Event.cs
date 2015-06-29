using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTracker
{
    class Event
    {
        internal enum EventType
        {
            NewIssue,
            RemoveIssue,
            NewCategory,
            RemoveCategory,
            MergeCategory,
            ChangedIssueCategory,
            StartTimer,
            StopTimer,
            ResetTime,
            SwitchedActiveIssue
        }

        internal DateTime Time;
        internal EventType eType;

        public Event(DateTime time, EventType type)
        {
            Time = time;
            eType = type;
        }
    }
}
