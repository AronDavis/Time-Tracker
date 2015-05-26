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
    public partial class AddNewIssue : Form
    {
        public AddNewIssue()
        {
            InitializeComponent();
            txtIssueName.Focus();
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
            GlobalData.mainForm.AddNewIssue(GlobalData.GetUniqueID(), txtIssueName.Text, TimeSpan.Zero);

            ResetAndHide();
        }

        private void ResetAndHide()
        {
            txtIssueName.Text = "";
            this.Hide();
        }
    }
}
