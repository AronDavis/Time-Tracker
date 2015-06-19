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
    public partial class frmAddNewIssue : Form
    {
        public frmAddNewIssue()
        {
            InitializeComponent();
            txtIssueName.Focus();
        }

        private void frmAddNewIssue_Load(object sender, EventArgs e)
        {
            cbCategory.Items.AddRange(GlobalData.Categories.ToArray());
            cbCategory.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetAndHide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddAndClose();
        }

        private void txtIssueName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddAndClose();
            }
        }

        private void AddAndClose()
        {
            GlobalData.mainForm.AddNewIssue(GlobalData.GetUniqueID(), txtIssueName.Text, ((Category)cbCategory.SelectedItem).ID, TimeSpan.Zero);
            GlobalData.mainForm.SaveSettingsFile();
            ResetAndHide();
        }

        private void ResetAndHide()
        {
            txtIssueName.Text = "";
            this.Hide();
        }
    }
}
