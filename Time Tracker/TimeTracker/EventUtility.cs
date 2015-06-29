using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTracker
{
    class EventUtility
    {
        public static void Sort(List<Event> events)
        {
            events.Sort((a, b) => a.Time.CompareTo(b.Time));
        }

        public static void AddEvent(Event eve)
        {
            GlobalData.Events.Add(eve);
            GlobalData.mainForm.SaveEventLogFile();
        }
    }
}
