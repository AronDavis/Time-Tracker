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
    public partial class frmAddNewCategory : Form
    {
        public frmAddNewCategory()
        {
            InitializeComponent();
            txtCategoryName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetAndHide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddAndClose();
        }

        private void txtCategoryName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddAndClose();
            }
        }

        private void AddAndClose()
        {
            if (CategoryUtility.AddCategory(txtCategoryName.Text))
            {
                GlobalData.mainForm.SaveSettingsFile();
                ResetAndHide();
            }
            else
            {
                MessageBox.Show("Category already exists.");
                txtCategoryName.Focus();
                txtCategoryName.SelectAll();
            }
        }

        private void ResetAndHide()
        {
            txtCategoryName.Text = "";
            this.Hide();
        }
    }
}
