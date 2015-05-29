using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTracker
{
    public class IssueData
    {
        public String ID;
        public String DisplayText;
        public Category Category;
        public TimeSpan TodaysLoggedTime;

        public IssueData(String id, string displayText, Category category, TimeSpan todaysLoggedTime)
        {
            ID = id;
            DisplayText = displayText;
            Category = category;
            TodaysLoggedTime = todaysLoggedTime;
        }
    }
}
