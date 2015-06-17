using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTracker
{
    class CategoryUtility
    {

        public static bool AddCategory(string name)
        {
            if((from c in GlobalData.Categories where c.DisplayText == name select c).Count() == 0)
            {
                GlobalData.Categories.Add(new Category(GlobalData.GetUniqueID(), name));
                return true;
            }

            return false;
        }
    }
}
