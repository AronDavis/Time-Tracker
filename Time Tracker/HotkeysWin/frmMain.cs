using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;

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
        private List<CheckBox> checkBoxes = new List<CheckBox>();
        private List<Label> timeRoundedList = new List<Label>();

        private Hotkeys.GlobalHotkey ghk;

        private int indexOfCurrentlySelected;

        public frmMain()
        {
            InitializeComponent();
            ghk = new Hotkeys.GlobalHotkey(Hotkeys.Constants.CTRL + Hotkeys.Constants.ALT + Hotkeys.Constants.SHIFT, Keys.F10, this);

            GlobalData.mainForm = this;

            this.Text = "Time Tracker - " + DateTime.Now.ToString("dddd, MMMM dd yyyy");
        }

        private void HandleHotkey()
        {
            this.Show();
            this.Activate();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Hotkeys.Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            notifyIcon1.Icon = this.Icon;

            ghk.Register();

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
            System.Xml.XmlDocument xmlSetting = new System.Xml.XmlDocument();
            System.Xml.XmlElement xmlRootNode;
            System.Xml.XmlElement xmlIssuesNamesElement;
            System.Xml.XmlElement xmlElementContents;

            //Settings

            xmlRootNode = xmlSetting.CreateElement(strSettingsFileName);

            xmlSetting.AppendChild(xmlRootNode);

            xmlIssuesNamesElement = xmlSetting.CreateElement("IssueNames");

            xmlRootNode.AppendChild(xmlIssuesNamesElement);

            xmlElementContents = xmlSetting.CreateElement(GlobalData.GetUniqueID());
            xmlElementContents.InnerText = "Marquis";

            xmlIssuesNamesElement.AppendChild(xmlElementContents);

            xmlSetting.Save(strDirectory + strSettingsPath + strSettingsFileName + strSettingsFileType);
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

            //DateStuff
            xmlRootNode.SetAttribute("Date", DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year);
            //

            //for every ID in list
            for (int i = 0; i < GlobalData.ListDisplayText.Count; i++)
            {
                xmlElement = xmlTimeLogDoc.CreateElement(GlobalData.ListIDs[i]); //ID HERE

                xmlRootNode.AppendChild(xmlElement);


                xmlElementContents = xmlTimeLogDoc.CreateElement("TimeLoggedToday");
                xmlElementContents.InnerText = TimeSpan.Zero.ToString();
                xmlElement.AppendChild(xmlElementContents);

                xmlElementContents = xmlTimeLogDoc.CreateElement("DisplayText");
                xmlElementContents.InnerText = GlobalData.ListDisplayText[i];
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
                //

                for (int i = 0; i < GlobalData.ListDisplayText.Count; i++)
                {
                    xmlElement = xmlTimeLogDoc.CreateElement(GlobalData.ListIDs[i]);

                    xmlRootNode.AppendChild(xmlElement);


                    xmlElementContents = xmlTimeLogDoc.CreateElement("TimeLoggedToday");
                    xmlElementContents.InnerText = GlobalData.TodaysLoggedTimes[i].ToString();
                    xmlElement.AppendChild(xmlElementContents);

                    xmlElementContents = xmlTimeLogDoc.CreateElement("DisplayText");
                    xmlElementContents.InnerText = GlobalData.ListDisplayText[i];
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
            System.Xml.XmlDocument xmlSetting = new System.Xml.XmlDocument();
            System.Xml.XmlElement xmlRootNode;
            System.Xml.XmlElement xmlElement;
            System.Xml.XmlElement xmlIssueNamesElement;
            System.Xml.XmlElement xmlElementContents;

            xmlRootNode = xmlSetting.CreateElement(strSettingsFileName);

            xmlIssueNamesElement = xmlSetting.CreateElement("IssueNames");
            xmlRootNode.AppendChild(xmlIssueNamesElement);

            for (int i = 0; i < GlobalData.ListDisplayText.Count; i++)
            {
                xmlElement = xmlSetting.CreateElement(GlobalData.ListIDs[i]);
                xmlIssueNamesElement.AppendChild(xmlElement);


                xmlElementContents = xmlSetting.CreateElement("DisplayText");
                xmlElementContents.InnerText = GlobalData.ListDisplayText[i];
                xmlElement.AppendChild(xmlElementContents);

            }

            xmlSetting.AppendChild(xmlRootNode);
            xmlSetting.Save(strDirectory + strSettingsPath + strSettingsFileName + strSettingsFileType);

        }

        private void LoadTodaysTimeLogFile()
        {
            System.Xml.XmlDocument xmlTimeLogFile = new System.Xml.XmlDocument();

            System.Xml.XmlNode xmlRootNode;

            //if the file exists
            if (System.IO.File.Exists(strDirectory + strTimeLogsPath + GetTodaysDateForSave() + strTodaysTimeLogFileName + strTodaysTimeLogFileType))
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
        }

        private void LoadSettingsFile()
        {
            System.Xml.XmlDocument xmlSettingsFile = new System.Xml.XmlDocument();

            System.Xml.XmlNode xmlRootNode;
            System.Xml.XmlNode xmlIssueNamesNode;

            xmlSettingsFile.Load(strDirectory + strSettingsPath + strSettingsFileName + strSettingsFileType);

            xmlRootNode = xmlSettingsFile.SelectSingleNode(strSettingsFileName);
            xmlIssueNamesNode = xmlRootNode.SelectSingleNode("IssueNames");

            for (int i = 0; i < xmlIssueNamesNode.ChildNodes.Count; i++)
            {
                System.Xml.XmlNode xmlNode = xmlIssueNamesNode.ChildNodes[i];

                AddNewIssue(xmlNode.Name, xmlNode.InnerText, TimeSpan.Zero);
            }
        }

        private String GetTodaysDateForSave()
        {
            return (DateTime.Now.ToString("yyyy-MM-dd-"));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ghk.Unregiser())
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
            labels[indexOfCurrentlySelected].Text = (TimeSpan.Parse(labels[indexOfCurrentlySelected].Text) + TimeSpan.FromMilliseconds(activeTimer.Interval)).ToString();

            GlobalData.TodaysLoggedTimes[indexOfCurrentlySelected] = TimeSpan.Parse(labels[indexOfCurrentlySelected].Text) + TimeSpan.FromMilliseconds(activeTimer.Interval);

            SaveTodaysTimeLogFile();

            SumTime();
        }

        private void SumTime()
        {
            TimeSpan sumOfWorkTime = TimeSpan.Zero;
            TimeSpan sumOfBreakTime = TimeSpan.Zero;
            TimeSpan totalTime = TimeSpan.Zero;
            for (int i = 0; i < GlobalData.TodaysLoggedTimes.Count; i++)
            {
                if (checkBoxes[i].Checked == true)
                {
                    sumOfWorkTime += GlobalData.TodaysLoggedTimes[i];
                }
                else
                {
                    sumOfBreakTime += GlobalData.TodaysLoggedTimes[i];
                }

                roundTime(i);
                totalTime += GlobalData.TodaysLoggedTimes[i];
            }

            txtTotalTimeWorkedToday.Text = sumOfWorkTime.ToString();
            txtTotalBreakTime.Text = sumOfBreakTime.ToString();
            txtTotalTime.Text = totalTime.ToString();
        }

        /// <summary>
        /// Round up/down based on specification.
        /// </summary>
        /// <param name="index"></param>
        public void roundTime(int index)
        {
            float minutesToRoundTo = 15;

            float temp = GlobalData.TodaysLoggedTimes[index].Hours;

            float m_and_s = (GlobalData.TodaysLoggedTimes[index].Minutes + (GlobalData.TodaysLoggedTimes[index].Seconds / 60f));

            float m_and_s_Mod = m_and_s % minutesToRoundTo;

            float m_and_s_Floor = (float)Math.Floor(m_and_s / minutesToRoundTo);
            float m_and_s_Ceil = (float)Math.Ceiling(m_and_s / minutesToRoundTo);

            if (m_and_s_Mod >= minutesToRoundTo / 2f)
            {
                //round up
                temp += (m_and_s_Ceil * minutesToRoundTo) / 60f;
            }
            else
            {
                //round down
                temp += (m_and_s_Floor * minutesToRoundTo) / 60f;
            }

            timeRoundedList[index].Text = temp.ToString();
        }

        public void AddNewIssue(String uniqueID, String displayText, TimeSpan timeLogged)
        {
            GlobalData.ListIDs.Add(uniqueID);
            GlobalData.ListDisplayText.Add(displayText);
            GlobalData.TodaysLoggedTimes.Add(timeLogged);

            SaveSettingsFile();

            GenerateNewIssueInterface();
        }

        public void LoadTimeToIssue(String uniqueID, TimeSpan timeLogged)
        {
            int index = GlobalData.ListIDs.IndexOf(uniqueID);
            if (index != -1)
            {
                GlobalData.TodaysLoggedTimes[index] = timeLogged;
                labels[index].Text = timeLogged.ToString();
            }
        }

        public void GenerateNewIssueInterface()
        {
            int i = GlobalData.ListDisplayText.Count - 1;
            RadioButton rbTemp = new RadioButton();
            rbTemp.Name = "rb" + GlobalData.ListIDs[i];
            rbTemp.Left = lblCurrentlySelected.Left;
            rbTemp.Top = 25 + (i * (rbTemp.Height + 5));
            rbTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            rbTemp.Text = GlobalData.ListDisplayText[i];
            rbTemp.Click += new EventHandler(HandleNewIssueSelected);


            radioButtons.Add(rbTemp);
            this.Controls["pnlTop"].Controls["pnlDisplayInfo"].Controls.Add(rbTemp);

            Label lblTemp = new Label();
            lblTemp.Name = "lbl" + GlobalData.ListIDs[i];
            lblTemp.Left = lblTimeToday.Left;
            lblTemp.Top = rbTemp.Top;
            lblTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblTemp.Text = GlobalData.TodaysLoggedTimes[i].ToString();

            labels.Add(lblTemp);
            this.Controls["pnlTop"].Controls["pnlDisplayInfo"].Controls.Add(lblTemp);


            CheckBox chkTemp = new CheckBox();
            chkTemp.Name = "chk" + GlobalData.ListIDs[i];
            chkTemp.Left = lblCountTowardsWorkTime.Left + (int)(lblCountTowardsWorkTime.Width / 2f) - 5;
            chkTemp.Width = 20;
            chkTemp.Top = rbTemp.Top;
            chkTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            chkTemp.Checked = true;

            checkBoxes.Add(chkTemp);
            this.Controls["pnlTop"].Controls["pnlDisplayInfo"].Controls.Add(chkTemp);


            Label timeRoundedTemp = new Label();
            timeRoundedTemp.Name = "lblTR" + GlobalData.ListIDs[i];
            timeRoundedTemp.Left = lblTimeRounded.Left;
            timeRoundedTemp.Top = rbTemp.Top;
            timeRoundedTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            timeRoundedTemp.Text = "0";

            timeRoundedList.Add(timeRoundedTemp);
            this.Controls["pnlTop"].Controls["pnlDisplayInfo"].Controls.Add(timeRoundedTemp);
            
        }

        public void FixIssueInterface()
        {
            for (int i = 0; i < radioButtons.Count; i++)
            {
                radioButtons[i].Top = 25 + (i * (radioButtons[i].Height + 5));
                labels[i].Top = radioButtons[i].Top;
                checkBoxes[i].Top = radioButtons[i].Top;
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
            this.pnlDisplayInfo.Controls.RemoveByKey(checkBoxes[index].Name);
            this.pnlDisplayInfo.Controls.RemoveByKey(timeRoundedList[index].Name);
            
            radioButtons.RemoveAt(index);
            labels.RemoveAt(index);
            checkBoxes.RemoveAt(index);
            timeRoundedList.RemoveAt(index);

            GlobalData.ListDisplayText.RemoveAt(index);
            GlobalData.TodaysLoggedTimes.RemoveAt(index);
            GlobalData.ListIDs.RemoveAt(index);

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
                GlobalData.formAddNewIssue = new AddNewIssue();
            }

            GlobalData.formAddNewIssue.Show();
            GlobalData.formAddNewIssue.Activate();
        }

        private void removeIssuesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (GlobalData.formRemoveIssue.IsDisposed)
            {
                GlobalData.formRemoveIssue = new RemoveIssue();
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
    }
}
