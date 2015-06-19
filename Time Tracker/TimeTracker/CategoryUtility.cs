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
            name = String.Join(" ", name.Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries));

            //If category doesn't exist
            if((from c in GlobalData.Categories where c.DisplayText == name select c).Count() == 0)
            {
                GlobalData.Categories.Add(new Category(GlobalData.GetUniqueID(), name));
                sortCategories();
                GlobalData.mainForm.FixCategoryDisplay();
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
