﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class frmRemoveIssue : Form
    {
        private List<CheckBox> checkBoxes = new List<CheckBox>();

        public frmRemoveIssue()
        {
            InitializeComponent();
        }

        public void GenerateIssueInterface()
        {
            pnlMiddle.Controls.Clear();
            for (int i = 0; i < GlobalData.Issues.Count; i++)
            {
                CheckBox chkTemp = new CheckBox();
                string ID = DateTime.Now.ToString("yyyyMMddhhmmssffftt");
                chkTemp.Name = "chk" + ID;
                chkTemp.Left = lblIssuesToRemove.Left + 5;
                chkTemp.Top = i * (chkTemp.Height + 5);
                chkTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                chkTemp.Text = GlobalData.Issues[i].DisplayText;

                checkBoxes.Add(chkTemp);
                pnlMiddle.Controls.Add(chkTemp);
            }
        }

        private void btnRemoveIssues_Click(object sender, EventArgs e)
        {
            for (int i = checkBoxes.Count - 1; i >= 0; i--)
            {
                if (checkBoxes[i].Checked == true)
                {
                    RemoveThisIssue(i);
                }
            }

            ResetFormAndHide();
        }

        private void ResetForm()
        {
            for (int i = checkBoxes.Count - 1; i >= 0; i--)
            {
                pnlMiddle.Controls.RemoveByKey(checkBoxes[i].Name);
                checkBoxes.RemoveAt(i);
            }
        }

        private void RemoveThisIssue(int index)
        {
            pnlMiddle.Controls.RemoveByKey(checkBoxes[index].Name);
            GlobalData.mainForm.RemoveIssueFromInterface(index);
            checkBoxes.RemoveAt(index);
        }

        public void ShowThisForm()
        {
            GenerateIssueInterface();
            this.Show();
            this.Activate();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetFormAndHide();
        }

        private void ResetFormAndHide()
        {
            ResetForm();
            this.Hide();
        }
    }
}
