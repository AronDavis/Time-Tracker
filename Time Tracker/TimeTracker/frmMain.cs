﻿using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using TimeTracker.Hotkeys;

namespace TimeTracker
{
    public partial class frmMain : Form
    {
        private System.Xml.XmlDocument xmlDoc, xmlTodaysLog;
        private String strDirectory = @"C:\Program Files\TimeTracker\";
        private const String strSettingsPath = @"Settings\",
            strSettingsFileName = "Settings",
            strSettingsFileType = ".xml",
            strTimeLogsPath = @"Time Logs\",
            strTodaysTimeLogFileName = "TimeLog",
            strTodaysTimeLogFileType = ".xml";
        

        private List<RadioButton> radioButtons = new List<RadioButton>();
        private List<Label> labels = new List<Label>();
        private List<ComboBox> comboBoxes = new List<ComboBox>();
        private List<Label> timeRoundedList = new List<Label>();

        private int indexOfCurrentlySelected;

        public frmMain()
        {
            InitializeComponent();

            GlobalData.mainForm = this;

            //default to ctrl + alt + F10
            GlobalData.HotKey = new GlobalHotkey(true, true, Keys.F10);            

            this.Text = "Time Tracker - " + DateTime.Now.ToString("dddd, MMMM dd yyyy");
        }

        private void HandleHotkey()
        {
            this.Show();
            this.Activate();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == HKConstants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            notifyIcon1.Icon = this.Icon;

            GlobalData.HotKey.Register();

            System.IO.Directory.CreateDirectory(strDirectory);
            System.IO.Directory.CreateDirectory(strDirectory + strSettingsPath);
            System.IO.Directory.CreateDirectory(strDirectory + strTimeLogsPath);

            if (!System.IO.File.Exists(strDirectory + strSettingsPath + strSettingsFileName + strSettingsFileType))
            {
                CreateNewSettingsFile();
            }
            LoadSettingsFile();

            if (!System.IO.File.Exists(strDirectory + strTimeLogsPath + GetTodaysDateForSave() + strTodaysTimeLogFileName + strTodaysTimeLogFileType))
            {
                CreateNewTimeLog();
            }
            LoadTodaysTimeLogFile();

            if (radioButtons.Count > 0)
            {
                radioButtons[0].Checked = true;
            }

            SumTime();

            activeTimer.Interval = (int)TimeSpan.FromSeconds(1).TotalMilliseconds;
        }

        private void CreateNewSettingsFile()
        {
            GlobalData.Categories.Clear();
            GlobalData.Issues.Clear();

            GlobalData.Categories.Add(new Category(GlobalData.GetUniqueID(), "Work"));
            GlobalData.Categories.Add(new Category(GlobalData.GetUniqueID(), "Break"));

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            System.Xml.XmlElement rootNode;
            System.Xml.XmlElement categoriesNode;
            System.Xml.XmlElement issuesNode;
            System.Xml.XmlElement iNode;

            //Settings node
            rootNode = doc.CreateElement(strSettingsFileName);

            //Add settings node
            doc.AppendChild(rootNode);


            //Create categories node
            categoriesNode = doc.CreateElement("Categories");

            //Add categories to root
            rootNode.AppendChild(categoriesNode);


            //Create category
            System.Xml.XmlElement catNode = doc.CreateElement(GlobalData.Categories[0].ID);
            catNode.InnerText = GlobalData.Categories[0].DisplayText;

            //Add work cat to categories
            categoriesNode.AppendChild(catNode);

            //Create category
            catNode = doc.CreateElement(GlobalData.Categories[1].ID);
            catNode.InnerText = GlobalData.Categories[1].DisplayText;

            //Add break cat to categories
            categoriesNode.AppendChild(catNode);


            //Create issues node
            issuesNode = doc.CreateElement("Issues");

            //Add issues node to root
            rootNode.AppendChild(issuesNode);


            //Create new issue with a UID
            iNode = doc.CreateElement(GlobalData.GetUniqueID());

            //Add issue to issues node
            issuesNode.AppendChild(iNode);


            //Create name node
            System.Xml.XmlElement nameNode = doc.CreateElement("Name");
            nameNode.InnerText = "Training";
            
            //Add name to issue
            iNode.AppendChild(nameNode);

            
            //Create category node
            catNode = doc.CreateElement("Category");
            catNode.InnerText = GlobalData.Categories[0].ID;

            //Add category to issue
            iNode.AppendChild(catNode);


            doc.Save(strDirectory + strSettingsPath + strSettingsFileName + strSettingsFileType);
        }

        private void CreateNewTimeLog()
        {
            System.Xml.XmlDocument xmlTimeLogDoc = new System.Xml.XmlDocument();
            System.Xml.XmlElement xmlRootNode;
            System.Xml.XmlElement xmlElement;
            System.Xml.XmlElement xmlElementContents;

            //Settings

            xmlRootNode = xmlTimeLogDoc.CreateElement(strTodaysTimeLogFileName);

            xmlTimeLogDoc.AppendChild(xmlRootNode);

            //Date
            xmlRootNode.SetAttribute("Date", DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year);

            //for every issue in list
            for (int i = 0; i < GlobalData.Issues.Count; i++)
            {
                IssueData issue = GlobalData.Issues[i];
                xmlElement = xmlTimeLogDoc.CreateElement(issue.ID); //ID HERE

                xmlRootNode.AppendChild(xmlElement);


                xmlElementContents = xmlTimeLogDoc.CreateElement("TimeLoggedToday");
                xmlElementContents.InnerText = TimeSpan.Zero.ToString();
                xmlElement.AppendChild(xmlElementContents);

                xmlElementContents = xmlTimeLogDoc.CreateElement("DisplayText");
                xmlElementContents.InnerText = issue.DisplayText;
                xmlElement.AppendChild(xmlElementContents);
            }

            xmlTimeLogDoc.Save(strDirectory + strTimeLogsPath + GetTodaysDateForSave() + strTodaysTimeLogFileName + strTodaysTimeLogFileType);
        }

        private void SaveTodaysTimeLogFile()
        {
            if (System.IO.File.Exists(strDirectory + strTimeLogsPath + GetTodaysDateForSave() + strTodaysTimeLogFileName + strTodaysTimeLogFileType))
            {
                System.Xml.XmlDocument xmlTimeLogDoc = new System.Xml.XmlDocument();
                System.Xml.XmlElement xmlRootNode;
                System.Xml.XmlElement xmlElement;
                System.Xml.XmlElement xmlElementContents;

                xmlRootNode = xmlTimeLogDoc.CreateElement(strTodaysTimeLogFileName);

                //DateStuff
                xmlRootNode.SetAttribute("Date", DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year);
                ///////////

                for (int i = 0; i < GlobalData.Issues.Count; i++)
                {
                    xmlElement = xmlTimeLogDoc.CreateElement(GlobalData.Issues[i].ID);

                    xmlRootNode.AppendChild(xmlElement);


                    xmlElementContents = xmlTimeLogDoc.CreateElement("TimeLoggedToday");
                    xmlElementContents.InnerText = GlobalData.Issues[i].TodaysLoggedTime.ToString();
                    xmlElement.AppendChild(xmlElementContents);

                    xmlElementContents = xmlTimeLogDoc.CreateElement("DisplayText");
                    xmlElementContents.InnerText = GlobalData.Issues[i].DisplayText;
                    xmlElement.AppendChild(xmlElementContents);
                }
                xmlTimeLogDoc.AppendChild(xmlRootNode);
                xmlTimeLogDoc.Save(strDirectory + strTimeLogsPath + GetTodaysDateForSave() + strTodaysTimeLogFileName + strTodaysTimeLogFileType);
            }
            else
            {
                CreateNewTimeLog();
                LoadTodaysTimeLogFile();
                SaveTodaysTimeLogFile();
            }
        }

        private void SaveSettingsFile()
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            System.Xml.XmlElement rootNode;
            System.Xml.XmlElement categoriesNode;
            System.Xml.XmlElement catNode;
            System.Xml.XmlElement issuesNode;
            System.Xml.XmlElement iNode;
            System.Xml.XmlElement xmlElementContents;

            rootNode = doc.CreateElement(strSettingsFileName);
            doc.AppendChild(rootNode);

            categoriesNode = doc.CreateElement("Categories");
            rootNode.AppendChild(categoriesNode);

            //Go through categories
            for (int i = 0; i < GlobalData.Categories.Count; i++)
            {
                Category cat = GlobalData.Categories[i];
                catNode = doc.CreateElement(cat.ID);
                catNode.InnerText = cat.DisplayText;
                
                //add cat
                categoriesNode.AppendChild(catNode);
            }

            issuesNode = doc.CreateElement("Issues");
            rootNode.AppendChild(issuesNode);

            //Go through active items
            for (int i = 0; i < GlobalData.Issues.Count; i++)
            {
                IssueData issue = GlobalData.Issues[i];
                iNode = doc.CreateElement(issue.ID);
                issuesNode.AppendChild(iNode);


                //add name
                xmlElementContents = doc.CreateElement("Name");
                xmlElementContents.InnerText = issue.DisplayText;
                iNode.AppendChild(xmlElementContents);

                //add category
                xmlElementContents = doc.CreateElement("Category");
                xmlElementContents.InnerText = issue.Category.ID;
                iNode.AppendChild(xmlElementContents);
            }

            doc.Save(strDirectory + strSettingsPath + strSettingsFileName + strSettingsFileType);

        }

        private void LoadTodaysTimeLogFile()
        {
            System.Xml.XmlDocument xmlTimeLogFile = new System.Xml.XmlDocument();

            System.Xml.XmlNode xmlRootNode;

            try
            {
                //load it
                xmlTimeLogFile.Load(strDirectory + strTimeLogsPath + GetTodaysDateForSave() + strTodaysTimeLogFileName + strTodaysTimeLogFileType);

                //get the root node
                xmlRootNode = xmlTimeLogFile.SelectSingleNode(strTodaysTimeLogFileName);

                //loop through all of the stored issues
                for (int i = 0; i < xmlRootNode.ChildNodes.Count; i++)
                {
                    //get the current issue
                    System.Xml.XmlNode xmlNode = xmlRootNode.ChildNodes[i];

                    //load its time
                    LoadTimeToIssue(xmlNode.Name, TimeSpan.Parse(xmlNode.SelectSingleNode("TimeLoggedToday").InnerText));
                }
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                MessageBox.Show("Could not find today's time log file." + Environment.NewLine + "Directory not found." + Environment.NewLine + "Creating new time log file.");
                CreateNewTimeLog();
                LoadTodaysTimeLogFile();

            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show("Could not find today's time log file." + Environment.NewLine + "Creating new time log file.");
                CreateNewTimeLog();
                LoadTodaysTimeLogFile();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show("Could not load today's time log file." + Environment.NewLine
                    + "Would you like to try again?" + Environment.NewLine
                    + ex.Message, "Try Again", MessageBoxButtons.YesNo);

                if (result == System.Windows.Forms.DialogResult.Yes) LoadSettingsFile();
                else
                {
                    result = MessageBox.Show("Would you like to create a new time log file?", "Create New Time Log File", MessageBoxButtons.YesNo);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        CreateNewTimeLog();
                        LoadTodaysTimeLogFile();
                    }
                }
            }
        }

        private void LoadSettingsFile()
        {
            GlobalData.Categories.Clear();
            GlobalData.Issues.Clear();

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();

            System.Xml.XmlNode rootNode;
            System.Xml.XmlNode issuesNode;
            System.Xml.XmlNode categoriesNode;

            try
            {
                doc.Load(strDirectory + strSettingsPath + strSettingsFileName + strSettingsFileType);

                rootNode = doc.SelectSingleNode(strSettingsFileName);

                GlobalData.Issues.Clear();
                categoriesNode = rootNode.SelectSingleNode("Categories");
                for (int i = 0; i < categoriesNode.ChildNodes.Count; i++)
                {
                    System.Xml.XmlNode catNode = categoriesNode.ChildNodes[i];

                    GlobalData.Categories.Add(new Category(catNode.Name, catNode.InnerText));
                }

                issuesNode = rootNode.SelectSingleNode("Issues");

                for (int i = 0; i < issuesNode.ChildNodes.Count; i++)
                {
                    System.Xml.XmlNode xmlNode = issuesNode.ChildNodes[i];

                    System.Xml.XmlNode nameNode = xmlNode.SelectSingleNode("Name");

                    System.Xml.XmlNode catNode = xmlNode.SelectSingleNode("Category");

                    AddNewIssue(xmlNode.Name, nameNode.InnerText, catNode.InnerText, TimeSpan.Zero);
                }
            }
            catch(System.IO.DirectoryNotFoundException ex)
            {
                MessageBox.Show("Could not find settings file." + Environment.NewLine + "Directory not found." + Environment.NewLine + "Creating new settings file.");
                CreateNewSettingsFile();
                LoadSettingsFile();

            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show("Could not find settings file." + Environment.NewLine + "Creating new settings file.");
                CreateNewSettingsFile();
                LoadSettingsFile();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show("Could not load settings file." + Environment.NewLine 
                    + "Would you like to try again?", "Try Again", MessageBoxButtons.YesNo);

                if (result == System.Windows.Forms.DialogResult.Yes) LoadSettingsFile();
                else
                {
                    result = MessageBox.Show("Would you like to create a new settings file?", "Create New Settings File", MessageBoxButtons.YesNo);
                    if(result == System.Windows.Forms.DialogResult.Yes)
                    {
                        CreateNewSettingsFile();
                        LoadSettingsFile();
                    }
                }
            }
        }

        private String GetTodaysDateForSave()
        {
            return (DateTime.Now.ToString("yyyy-MM-dd-"));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!GlobalData.HotKey.Unregiser())
                MessageBox.Show("Hotkey failed to unregister!");

            notifyIcon1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HideEverything();
        }

        private void btnStartTimer_Click(object sender, EventArgs e)
        {
            if (btnStartStopTimer.Text == "Start Timer")
            {
                if (radioButtons.Count <= 0)
                {
                    MessageBox.Show("There are no issues to track time for.");
                    return;
                }

                for (int i = 0; i < radioButtons.Count; i++)
                {
                    if (radioButtons[i].Checked == true)
                    {
                        indexOfCurrentlySelected = i;
                        activeTimer.Start();
                    }
                }

                if (activeTimer.Enabled)
                {
                    btnStartStopTimer.Text = "Stop Timer";
                    startTimerToolStripMenuItem.Enabled = false;
                    stopTimerToolStripMenuItem.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No issue was selected.");
                }
            }
            else
            {
                activeTimer.Stop();
                btnStartStopTimer.Text = "Start Timer";
                startTimerToolStripMenuItem.Enabled = true;
                stopTimerToolStripMenuItem.Enabled = false;
            }
                       
        }

        private void AddTheElapsedTime(object sender, EventArgs e)
        {           
            GlobalData.Issues[indexOfCurrentlySelected].TodaysLoggedTime += TimeSpan.FromMilliseconds(activeTimer.Interval);
            labels[indexOfCurrentlySelected].Text = GlobalData.Issues[indexOfCurrentlySelected].TodaysLoggedTime.ToString();

            SaveTodaysTimeLogFile();

            SumTime();
        }

        private void SumTime()
        {
            TimeSpan sumOfWorkTime = TimeSpan.Zero;
            TimeSpan sumOfBreakTime = TimeSpan.Zero;
            TimeSpan totalTime = TimeSpan.Zero;
            for (int i = 0; i < GlobalData.Issues.Count; i++)
            {
                if (comboBoxes[i].SelectedItem.ToString() == "Work") //TODO: make this work with categories
                {
                    sumOfWorkTime += GlobalData.Issues[i].TodaysLoggedTime;
                }
                else
                {
                    sumOfBreakTime += GlobalData.Issues[i].TodaysLoggedTime;
                }

                UpdateRoundedTimeDisplay(i);
                totalTime += GlobalData.Issues[i].TodaysLoggedTime;
            }

            txtTotalTimeWorkedToday.Text = sumOfWorkTime.ToString();
            txtTotalBreakTime.Text = sumOfBreakTime.ToString();
            txtTotalTime.Text = totalTime.ToString();
        }

        /// <summary>
        /// Round up/down and display
        /// </summary>
        /// <param name="index"></param>
        public void UpdateRoundedTimeDisplay(int index)
        {
            TimeSpan roundTo = new TimeSpan(0, 15, 0);

            long roundedTicks = (long)Math.Round((double)(GlobalData.Issues[index].TodaysLoggedTime.Ticks) / roundTo.Ticks) * roundTo.Ticks;

            TimeSpan rounded = new TimeSpan(roundedTicks);
            timeRoundedList[index].Text = (rounded.Hours + (rounded.Minutes/60.0)).ToString();
        }

        public void AddNewIssue(String uniqueID, String displayText, String categoryID, TimeSpan timeLogged)
        {
            GlobalData.Issues.Add(new IssueData(uniqueID, displayText, GlobalData.GetCategoryByID(categoryID), timeLogged));

            SaveSettingsFile();

            GenerateNewIssueInterface();
        }

        public void LoadTimeToIssue(String uniqueID, TimeSpan timeLogged)
        {
            int index = GlobalData.GetIssueIndexByID(uniqueID);
            if (index != -1)
            {
                GlobalData.Issues[index].TodaysLoggedTime = timeLogged;
                labels[index].Text = timeLogged.ToString();
            }
        }

        public void GenerateNewIssueInterface()
        {
            int i = GlobalData.Issues.Count - 1;
            IssueData issue = GlobalData.Issues[i];
            RadioButton rbTemp = new RadioButton();
            rbTemp.Name = "rb" + issue.ID;
            rbTemp.Left = lblCurrentlySelected.Left;
            rbTemp.Top = 25 + (i * (rbTemp.Height + 5));
            rbTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            rbTemp.Text = issue.DisplayText;
            rbTemp.Click += new EventHandler(HandleNewIssueSelected);


            radioButtons.Add(rbTemp);
            this.Controls["pnlTop"].Controls["pnlDisplayInfo"].Controls.Add(rbTemp);

            Label lblTemp = new Label();
            lblTemp.Name = "lbl" + issue.ID;
            lblTemp.Left = lblTimeToday.Left;
            lblTemp.Top = rbTemp.Top;
            lblTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblTemp.Text = issue.TodaysLoggedTime.ToString();

            labels.Add(lblTemp);
            this.Controls["pnlTop"].Controls["pnlDisplayInfo"].Controls.Add(lblTemp);


            ComboBox cbTemp = new ComboBox();
            cbTemp.Name = "cb" + issue.ID;
            cbTemp.Left = lblCountTowardsWorkTime.Left;
            cbTemp.Top = rbTemp.Top;
            cbTemp.Width = lblCountTowardsWorkTime.Width;
            //cbTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            cbTemp.Items.AddRange(GlobalData.Categories.ToArray());
            cbTemp.SelectedIndex = GlobalData.Categories.IndexOf(issue.Category);
            cbTemp.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTemp.SelectedIndexChanged += issueCategory_SelectedIndexChanged; //listen for change
            

            comboBoxes.Add(cbTemp);
            this.Controls["pnlTop"].Controls["pnlDisplayInfo"].Controls.Add(cbTemp);
            cbTemp.BringToFront();


            Label timeRoundedTemp = new Label();
            timeRoundedTemp.Name = "lblTR" + issue.ID;
            timeRoundedTemp.Left = lblTimeRounded.Left;
            timeRoundedTemp.Top = rbTemp.Top;
            timeRoundedTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            timeRoundedTemp.Text = "0";

            timeRoundedList.Add(timeRoundedTemp);
            this.Controls["pnlTop"].Controls["pnlDisplayInfo"].Controls.Add(timeRoundedTemp);

            
        }

        private void issueCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            int i = GlobalData.GetIssueIndexByID(cb.Name.Remove(0, 2));
            GlobalData.Issues[i].Category = (Category)cb.SelectedItem;
            SaveSettingsFile();
        }

        public void FixIssueInterface()
        {
            for (int i = 0; i < radioButtons.Count; i++)
            {
                radioButtons[i].Top = 25 + (i * (radioButtons[i].Height + 5));
                labels[i].Top = radioButtons[i].Top;
                comboBoxes[i].Top = radioButtons[i].Top;
                timeRoundedList[i].Top = radioButtons[i].Top;
            }
        }

        private void HandleNewIssueSelected(object sender, EventArgs e)
        {
            for (int i = 0; i < radioButtons.Count; i++)
            {
                if (radioButtons[i].Checked == true)
                {
                    indexOfCurrentlySelected = i;
                }
            }
        }

        public void RemoveIssueFromInterface(int index)
        {
            if (index == indexOfCurrentlySelected)
            {
                if (activeTimer.Enabled)
                {
                    activeTimer.Stop();
                    btnStartStopTimer.Text = "Start Timer";
                    MessageBox.Show("Timer was stopped due to removing the active issue.");
                }
            }
            
            this.pnlDisplayInfo.Controls.RemoveByKey(radioButtons[index].Name);
            this.pnlDisplayInfo.Controls.RemoveByKey(labels[index].Name);
            this.pnlDisplayInfo.Controls.RemoveByKey(comboBoxes[index].Name);
            this.pnlDisplayInfo.Controls.RemoveByKey(timeRoundedList[index].Name);
            
            radioButtons.RemoveAt(index);
            labels.RemoveAt(index);
            comboBoxes.RemoveAt(index);
            timeRoundedList.RemoveAt(index);

            GlobalData.Issues.RemoveAt(index);

            SaveSettingsFile();
            SaveTodaysTimeLogFile();
            SumTime();
            FixIssueInterface();
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideEverything();
        }

        private void HideEverything()
        {
            GlobalData.mainForm.Hide();
            GlobalData.formAddNewIssue.Hide();
            GlobalData.formRemoveIssue.Hide();
        }


        private void addNewIssueToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (GlobalData.formAddNewIssue.IsDisposed)
            {
                GlobalData.formAddNewIssue = new frmAddNewIssue();
            }

            GlobalData.formAddNewIssue.Show();
            GlobalData.formAddNewIssue.Activate();
        }

        private void removeIssuesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (GlobalData.formRemoveIssue.IsDisposed)
            {
                GlobalData.formRemoveIssue = new frmRemoveIssue();
            }
            GlobalData.formRemoveIssue.ShowThisForm();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveSettingsFile();
            SaveTodaysTimeLogFile();
            notifyIcon1.Visible = false;
            this.Close();
        }

        private void resetSelectedTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labels[indexOfCurrentlySelected].Text = TimeSpan.Zero.ToString();
            SumTime();
            SaveTodaysTimeLogFile();
        }

        private void resetAllTimeTodayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < labels.Count; i++)
            {
                labels[i].Text = TimeSpan.Zero.ToString();
            }
        }

        private void changeHotkeysToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void unhideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalData.changeHotkeyForm == null || GlobalData.changeHotkeyForm.IsDisposed)
            {
                GlobalData.changeHotkeyForm = new frmChangeHotkey();
                GlobalData.changeHotkeyForm.Show();
            }
            else GlobalData.changeHotkeyForm.Focus();
            
        }
    }
}