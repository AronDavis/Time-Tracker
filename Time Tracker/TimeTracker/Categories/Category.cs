using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTracker
{
    public class Category
    {
        public String ID;
        public String DisplayText;

        public Category(string id, string displayText)
        {
            ID = id;
            DisplayText = displayText;
        }

        public override string ToString()
        {
            return DisplayText;
        }
    }
}
