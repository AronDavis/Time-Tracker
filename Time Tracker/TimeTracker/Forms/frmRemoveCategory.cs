using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class frmRemoveCategory : Form
    {
        public frmRemoveCategory()
        {
            InitializeComponent();
            cbCategory.Focus();
        }

        private void frmAddNewIssue_Load(object sender, EventArgs e)
        {
            cbCategory.Items.AddRange(GlobalData.Categories.ToArray());
            cbCategory.SelectedIndex = 0;

            cbMergeInto.Items.AddRange(GlobalData.Categories.ToArray());
            cbMergeInto.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetAndHide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MergeAndClose();
        }

        private void MergeAndClose()
        {
            Category mergeThis = (Category)cbCategory.SelectedItem;
            Category intoThis = (Category)cbMergeInto.SelectedItem;
            if (CategoryUtility.MergeCategories(mergeThis, intoThis))
            {
                GlobalData.mainForm.SaveSettingsFile();
                ResetAndHide();
            }
            else
            {
                MessageBox.Show(String.Format("Cannot merge \"{0}\" into \"{1}\".", mergeThis.DisplayText, intoThis.DisplayText));
                cbCategory.Focus();
            }
        }

        private void ResetAndHide()
        {
            cbCategory.SelectedIndex = 0;
            cbMergeInto.SelectedIndex = 0;
            this.Hide();
        }
    }
}
