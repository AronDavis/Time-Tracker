using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class ucTimeSummary : UserControl
    {
        DataTable table;
        public ucTimeSummary()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            table = new DataTable("TotalTime");
            table.Columns.Add(new DataColumn("Category"));
            table.Columns.Add(new DataColumn("Total Time"));
            table.Columns.Add(new DataColumn("Time Rounded"));
            for (int i = 0; i < GlobalData.Categories.Count; i++)
            {
                DataRow row = table.NewRow();
                row.SetField<Category>(0, GlobalData.Categories[i]);
                row.SetField<TimeSpan>(1, new TimeSpan());
                row.SetField<TimeSpan>(2, new TimeSpan());
                table.Rows.Add(row);
            }

            dgvTimeSummary.DataSource = table;
        }

        public void Update()
        {

            TimeSpan[] categoryTimeSums = new TimeSpan[GlobalData.Categories.Count];

            for (int i = 0; i < GlobalData.Issues.Count; i++)
            {
                Category cat = GlobalData.Issues[i].Category;

                int catIndex = GlobalData.Categories.IndexOf(cat);
                categoryTimeSums[catIndex] += GlobalData.Issues[i].TodaysLoggedTime;
            }

            
            for(int i = 0; i < categoryTimeSums.Length; i++)
            {
                DataRow row = table.Select(String.Format("Category = '{0}'", GlobalData.Categories[i]))[0];
                row.SetField<TimeSpan>(1, categoryTimeSums[i]);
                row.SetField<TimeSpan>(2, TimeUtility.Round(categoryTimeSums[i], GlobalData.RoundTo, GlobalData.RoundDirection));
            }
        }
    }
}
