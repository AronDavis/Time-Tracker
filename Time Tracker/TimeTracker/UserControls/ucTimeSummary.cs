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
            table.Columns.Add(new DataColumn("ID"));
            table.Columns.Add(new DataColumn("Category"));
            table.Columns.Add(new DataColumn("Total Time"));
            table.Columns.Add(new DataColumn("Time Rounded"));
            RefreshRows();
            dgvTimeSummary.DataSource = table;
            dgvTimeSummary.Columns[0].Visible = false;
        }

        public void RefreshRows()
        {
            if (table.Rows.Count != GlobalData.Categories.Count)
            {
                table.Rows.Clear();

                for (int i = 0; i < GlobalData.Categories.Count; i++)
                {
                    DataRow row = table.NewRow();
                    row.SetField<string>(0, GlobalData.Categories[i].ID);
                    row.SetField<Category>(1, GlobalData.Categories[i]);
                    row.SetField<TimeSpan>(2, new TimeSpan());
                    row.SetField<TimeSpan>(3, new TimeSpan());
                    table.Rows.Add(row);
                }
            }
        }

        public void Update()
        {
            RefreshRows();
            TimeSpan[] categoryTimeSums = new TimeSpan[GlobalData.Categories.Count];

            for (int i = 0; i < GlobalData.Issues.Count; i++)
            {
                Category cat = GlobalData.Issues[i].Category;

                int catIndex = GlobalData.Categories.IndexOf(cat);
                categoryTimeSums[catIndex] += GlobalData.Issues[i].TodaysLoggedTime;
            }

            
            for(int i = 0; i < categoryTimeSums.Length; i++)
            {
                DataRow row = table.Select(String.Format("ID = '{0}'", GlobalData.Categories[i].ID))[0];
                row.SetField<TimeSpan>(2, categoryTimeSums[i]);
                row.SetField<TimeSpan>(3, TimeUtility.Round(categoryTimeSums[i], GlobalData.RoundTo, GlobalData.RoundDirection));
            }
        }
    }
}
