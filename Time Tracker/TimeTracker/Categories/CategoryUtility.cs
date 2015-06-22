using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTracker
{
    class CategoryUtility
    {
        public static bool AddCategory(string name, bool refreshDisplay = true)
        {
            name = String.Join(" ", name.Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries));

            //If category doesn't exist
            if((from c in GlobalData.Categories where c.DisplayText == name select c).Count() == 0)
            {
                GlobalData.Categories.Add(new Category(GlobalData.GetUniqueID(), name));
                sortCategories();
                if(refreshDisplay) GlobalData.mainForm.FixCategoryDisplay();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Only for use when loading from settings file.
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        internal static bool AddCategory(Category cat)
        {
            if(!GlobalData.Categories.Contains(cat))
            {
                GlobalData.Categories.Add(cat);
                sortCategories();
                return true;
            }

            return false;
        }

        internal static bool RemoveCategory(Category cat)
        {
            if (GlobalData.Categories.Contains(cat))
            {
                GlobalData.Categories.Remove(cat);
                sortCategories();
                GlobalData.mainForm.FixCategoryDisplay();
                return true;
            }

            return false;
        }

        internal static bool MergeCategories(Category mergeThis, Category intoThis)
        {
            if (mergeThis != intoThis && GlobalData.Categories.Contains(mergeThis))
            {
                //Replace it in every issue
                foreach (IssueData issue in GlobalData.Issues)
                {
                    if (issue.Category == mergeThis) issue.Category = intoThis;
                }

                //Remove it
                GlobalData.Categories.Remove(mergeThis);
                sortCategories();
                GlobalData.mainForm.FixCategoryDisplay();
                return true;
            }

            return false;
        }

        private static void sortCategories()
        {
            GlobalData.Categories.Sort((a, b) => a.DisplayText.CompareTo(b.DisplayText));
        }
    }
}
