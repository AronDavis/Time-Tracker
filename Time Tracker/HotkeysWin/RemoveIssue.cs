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
    public partial class RemoveIssue : Form
    {
        private List<CheckBox> checkBoxes = new List<CheckBox>();

        public RemoveIssue()
        {
            InitializeComponent();
            GenerateIssueInterface();
        }


        public void GenerateIssueInterface()
        {

            for (int i = 0; i < GlobalData.ListDisplayText.Count; i++)
            {

                CheckBox chkTemp = new CheckBox();
                string ID = DateTime.Now.ToString("yyyyMMddhhmmssffftt");
                chkTemp.Name = "chk" + ID;
                chkTemp.Left = lblIssuesToRemove.Left;
                chkTemp.Top = 25 + (i * (chkTemp.Height + 5));
                chkTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                chkTemp.Text = GlobalData.ListDisplayText[i];


                checkBoxes.Add(chkTemp);
                this.Controls.Add(chkTemp);
            }
        }

        public void FixIssueInterface()
        {
            for (int i = 0; i < checkBoxes.Count; i++)
            {
                checkBoxes[i].Top = 25 + (i * (checkBoxes[i].Height + 5));
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
                this.Controls.RemoveByKey(checkBoxes[i].Name);
                checkBoxes.RemoveAt(i);
            }
        }

        private void RemoveThisIssue(int index)
        {
            this.Controls.RemoveByKey(checkBoxes[index].Name);
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
