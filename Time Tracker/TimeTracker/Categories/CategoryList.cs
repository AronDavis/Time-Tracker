using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTracker
{
    class CategoryList : EventList<Category>
    {
        public CategoryList() : base() {}

        new public void Sort()
        {
            base.Sort((a, b) => a.DisplayText.CompareTo(b.DisplayText));
        }

        internal bool Add(string name, bool refreshDisplay = true)
        {
            name = String.Join(" ", name.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));

            //If category doesn't exist
            if ((from c in GlobalData.Categories where c.DisplayText == name select c).Count() == 0)
            {
                Category cat = new Category(GlobalData.GetUniqueID(), name);
                base.Add(cat);
                Sort();
                if (refreshDisplay) GlobalData.mainForm.FixCategoryDisplay();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Only for use when loading from settings file.
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        new internal bool Add(Category cat)
        {
            if (!Contains(cat))
            {
                //no add event here since we're just loading
                NoEventAdd(cat);
                Sort();
                return true;
            }

            return false;
        }

        new internal bool Remove(Category cat)
        {
            if (Contains(cat))
            {
                base.Remove(cat);
                Sort();
                GlobalData.mainForm.FixCategoryDisplay();
                return true;
            }

            return false;
        }

        internal bool MergeCategories(Category mergeThis, Category intoThis)
        {
            if (mergeThis != intoThis && GlobalData.Categories.Contains(mergeThis))
            {
                //Replace it in every issue
                foreach (IssueData issue in GlobalData.Issues)
                {
                    if (issue.Category == mergeThis) issue.SetCategory(intoThis);
                }

                //Remove it after "merge" so we can undo in proper order
                base.Remove(mergeThis); //TODO: make special merge event
                //base.base.Remove() to get to list


                EventHandler<MergeItemArgs> handler = ItemMerged;
                if (handler != null) handler(this, new MergeItemArgs(mergeThis, intoThis));
                

                Sort();
                GlobalData.mainForm.FixCategoryDisplay();
                return true;
            }

            return false;
        }

        internal event EventHandler<MergeItemArgs> ItemMerged;

        internal class MergeItemArgs : EventArgs
        {
            internal Category MergeThis, IntoThis;

            internal MergeItemArgs(Category mergeThis, Category intoThis)
            {
                MergeThis = mergeThis;
                IntoThis = intoThis;
            }
        }
    }
}
