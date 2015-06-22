using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using TimeTracker.Hotkeys;
using System.Linq;

namespace TimeTracker
{
    public partial class frmMain : Form
    {
        private bool trueExit = false;

        private System.Xml.XmlDocument xmlDoc, xmlTodaysLog;        

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

        private void ToggleHidden()
        {
            if(!Visible) Unhide();
            else HideEverything();            
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == HKConstants.WM_HOTKEY_MSG_ID) ToggleHidden();

            base.WndProc(ref m);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            foreach (TimeUtility.RoundDirection dir in Enum.GetValues(typeof(TimeUtility.RoundDirection)))
            {
                ucMenuStrip1.cbRoundDirections.Items.Add(dir);
            }

            ucMenuStrip1.cbRoundDirections.SelectedItem = GlobalData.RoundDirection;
            ucMenuStrip1.txtRoundTo.Text = GlobalData.RoundTo.TotalMinutes.ToString();

            trayIcon.Icon = this.Icon;         

            System.IO.Directory.CreateDirectory(GlobalData.strDirectory);
            System.IO.Directory.CreateDirectory(GlobalData.strDirectory + GlobalData.strSettingsPath);
            System.IO.Directory.CreateDirectory(GlobalData.strDirectory + GlobalData.strTimeLogsPath);
            System.IO.Directory.CreateDirectory(GlobalData.strDirectory + GlobalData.strEventLogPath);

            if (!System.IO.File.Exists(GlobalData.strDirectory + GlobalData.strSettingsPath + GlobalData.strSettingsFileName + GlobalData.strSettingsFileType))
            {
                CreateNewSettingsFile();
            }
            LoadSettingsFile();

            if (!System.IO.File.Exists(GlobalData.strDirectory + GlobalData.strTimeLogsPath + GetTodaysDateForSave() + GlobalData.strTodaysTimeLogFileName + GlobalData.strTodaysTimeLogFileType))
            {
                CreateNewTimeLog();
            }
            LoadTodaysTimeLogFile();

            if (radioButtons.Count > 0)
            {
                radioButtons[0].Checked = true;
            }

            ucTimeSummary1.Initialize();
            SumTime();

            activeTimer.Interval = (int)TimeSpan.FromSeconds(1).TotalMilliseconds;

            SetupMenuEvents();
            SetupLogEvents();
        }

        private void CreateNewSettingsFile()
        {
            GlobalData.Categories.Clear();
            GlobalData.Issues.Clear();

            CategoryUtility.AddCategory("Work", false);
            CategoryUtility.AddCategory("Break", false);

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            System.Xml.XmlElement rootNode;
            System.Xml.XmlElement categoriesNode;
            System.Xml.XmlElement issuesNode;
            System.Xml.XmlElement iNode;

            //Settings node
            rootNode = doc.CreateElement(GlobalData.strSettingsFileName);

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


            doc.Save(GlobalData.strDirectory + GlobalData.strSettingsPath + GlobalData.strSettingsFileName + GlobalData.strSettingsFileType);
        }

        private void CreateNewTimeLog()
        {
            System.Xml.XmlDocument xmlTimeLogDoc = new System.Xml.XmlDocument();
            System.Xml.XmlElement xmlRootNode;
            System.Xml.XmlElement xmlElement;
            System.Xml.XmlElement xmlElementContents;

            //Settings

            xmlRootNode = xmlTimeLogDoc.CreateElement(GlobalData.strTodaysTimeLogFileName);

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

            xmlTimeLogDoc.Save(GlobalData.strDirectory + GlobalData.strTimeLogsPath + GetTodaysDateForSave() + GlobalData.strTodaysTimeLogFileName + GlobalData.strTodaysTimeLogFileType);
        }

        private void SaveTodaysTimeLogFile()
        {
            if (System.IO.File.Exists(GlobalData.strDirectory + GlobalData.strTimeLogsPath + GetTodaysDateForSave() + GlobalData.strTodaysTimeLogFileName + GlobalData.strTodaysTimeLogFileType))
            {
                System.Xml.XmlDocument xmlTimeLogDoc = new System.Xml.XmlDocument();
                System.Xml.XmlElement xmlRootNode;
                System.Xml.XmlElement xmlElement;
                System.Xml.XmlElement xmlElementContents;

                xmlRootNode = xmlTimeLogDoc.CreateElement(GlobalData.strTodaysTimeLogFileName);

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
                xmlTimeLogDoc.Save(GlobalData.strDirectory + GlobalData.strTimeLogsPath + GetTodaysDateForSave() + GlobalData.strTodaysTimeLogFileName + GlobalData.strTodaysTimeLogFileType);
            }
            else
            {
                CreateNewTimeLog();
                LoadTodaysTimeLogFile();
                SaveTodaysTimeLogFile();
            }
        }

        internal void SaveSettingsFile()
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            System.Xml.XmlElement rootNode;
            System.Xml.XmlElement categoriesNode;
            System.Xml.XmlElement catNode;
            System.Xml.XmlElement issuesNode;
            System.Xml.XmlElement iNode;
            System.Xml.XmlElement xmlElementContents;

            rootNode = doc.CreateElement(GlobalData.strSettingsFileName);
            doc.AppendChild(rootNode);

            System.Xml.XmlElement hotkeyNode = doc.CreateElement("HotKey");
            hotkeyNode.InnerText = (GlobalData.HotKey.ctrl ? "1" : "0") + (GlobalData.HotKey.alt ? "1" : "0") + GlobalData.HotKey.key;
            rootNode.AppendChild(hotkeyNode);

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

            doc.Save(GlobalData.strDirectory + GlobalData.strSettingsPath + GlobalData.strSettingsFileName + GlobalData.strSettingsFileType);

        }

        private void LoadTodaysTimeLogFile()
        {
            System.Xml.XmlDocument xmlTimeLogFile = new System.Xml.XmlDocument();

            System.Xml.XmlNode xmlRootNode;

            try
            {
                //load it
                xmlTimeLogFile.Load(GlobalData.strDirectory + GlobalData.strTimeLogsPath + GetTodaysDateForSave() + GlobalData.strTodaysTimeLogFileName + GlobalData.strTodaysTimeLogFileType);

                //get the root node
                xmlRootNode = xmlTimeLogFile.SelectSingleNode(GlobalData.strTodaysTimeLogFileName);

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
                doc.Load(GlobalData.strDirectory + GlobalData.strSettingsPath + GlobalData.strSettingsFileName + GlobalData.strSettingsFileType);

                rootNode = doc.SelectSingleNode(GlobalData.strSettingsFileName);

                System.Xml.XmlNode hotkeyNode = rootNode.SelectSingleNode("HotKey");
                if (hotkeyNode == null) GlobalData.HotKey = new GlobalHotkey(true, true, Keys.F10);
                else GlobalData.HotKey = GlobalHotkey.Parse(hotkeyNode.InnerText);
                GlobalData.HotKey.Register();

                categoriesNode = rootNode.SelectSingleNode("Categories");
                for (int i = 0; i < categoriesNode.ChildNodes.Count; i++)
                {
                    System.Xml.XmlNode catNode = categoriesNode.ChildNodes[i];

                    CategoryUtility.AddCategory(new Category(catNode.Name, catNode.InnerText));
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
            if (!trueExit)
            {
                e.Cancel = true;
                HideEverything();
            }

            SaveSettingsFile();
            SaveTodaysTimeLogFile();
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
                    ucMenuStrip1.startTimerToolStripMenuItem.Enabled = false;
                    ucMenuStrip1.stopTimerToolStripMenuItem.Enabled = true;
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
                ucMenuStrip1.startTimerToolStripMenuItem.Enabled = true;
                ucMenuStrip1.stopTimerToolStripMenuItem.Enabled = false;
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
            TimeSpan totalTime = TimeSpan.Zero;

            for (int i = 0; i < GlobalData.Issues.Count; i++)
            {
                UpdateRoundedTimeDisplay(i);
                totalTime += GlobalData.Issues[i].TodaysLoggedTime;
            }

            ucTimeSummary1.Update();
            txtTotalTime.Text = totalTime.ToString();
        }

        /// <summary>
        /// Round up/down and display
        /// </summary>
        /// <param name="index"></param>
        public void UpdateRoundedTimeDisplay(int index)
        {
            TimeSpan rounded = TimeUtility.Round(GlobalData.Issues[index].TodaysLoggedTime, GlobalData.RoundTo, GlobalData.RoundDirection);
            timeRoundedList[index].Text = TimeUtility.FormatRoundedTime(rounded, TimeUtility.RoundIncrementMode.Hours);
        }

        public void AddNewIssue(String uniqueID, String displayText, String categoryID, TimeSpan timeLogged)
        {
            GlobalData.Issues.Add(new IssueData(uniqueID, displayText, GlobalData.GetCategoryByID(categoryID), timeLogged));        

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
            rbTemp.Left = lblCurrentlySelected.Left + 5;
            rbTemp.Top = i * (rbTemp.Height + 5);
            rbTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            rbTemp.Text = issue.DisplayText;
            rbTemp.Click += new EventHandler(HandleNewIssueSelected);


            radioButtons.Add(rbTemp);
            pnlDisplayInfo.Controls.Add(rbTemp);

            Label lblTemp = new Label();
            lblTemp.Name = "lbl" + issue.ID;
            lblTemp.Left = lblTimeToday.Left;
            lblTemp.Top = rbTemp.Top;
            lblTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblTemp.Text = issue.TodaysLoggedTime.ToString();

            labels.Add(lblTemp);
            pnlDisplayInfo.Controls.Add(lblTemp);


            ComboBox cbTemp = new ComboBox();
            cbTemp.Name = "cb" + issue.ID;
            cbTemp.Left = lblCategory.Left;
            cbTemp.Top = rbTemp.Top;
            cbTemp.Width = lblCategory.Width;
            //cbTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            cbTemp.Items.AddRange(GlobalData.Categories.ToArray());
            cbTemp.SelectedIndex = GlobalData.Categories.IndexOf(issue.Category);
            cbTemp.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTemp.SelectedIndexChanged += issueCategory_SelectedIndexChanged; //listen for change
            

            comboBoxes.Add(cbTemp);
            pnlDisplayInfo.Controls.Add(cbTemp);
            cbTemp.BringToFront();


            Label timeRoundedTemp = new Label();
            timeRoundedTemp.Name = "lblTR" + issue.ID;
            timeRoundedTemp.Left = lblTimeRounded.Left;
            timeRoundedTemp.Top = rbTemp.Top;
            timeRoundedTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            timeRoundedTemp.Text = "0";

            timeRoundedList.Add(timeRoundedTemp);
            pnlDisplayInfo.Controls.Add(timeRoundedTemp);
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
                radioButtons[i].Top = i * (radioButtons[i].Height + 5);
                labels[i].Top = radioButtons[i].Top;
                comboBoxes[i].Top = radioButtons[i].Top;
                timeRoundedList[i].Top = radioButtons[i].Top;
            }
        }

        public void FixCategoryDisplay()
        {
            for(int i = 0; i < GlobalData.Issues.Count; i++)
            {
                IssueData issue= GlobalData.Issues[i];
                ComboBox cb = comboBoxes[i];

                cb.Items.Clear();
                cb.Items.AddRange(GlobalData.Categories.ToArray());

                //if original category still exists, set it back to what it was originally
                if (cb.Items.Contains(issue.Category)) cb.SelectedItem = issue.Category;
                else cb.SelectedIndex = -1;
            }
            ucTimeSummary1.RefreshRows();
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

        private void HideEverything()
        {
            GlobalData.mainForm.Hide();
            GlobalData.formAddNewIssue.Hide();
            GlobalData.formRemoveIssue.Hide();
            GlobalData.formChangeHotkey.Hide();
            trayIcon.Visible = true;
        }

        private void Unhide()
        {
            GlobalData.mainForm.Show();
            GlobalData.mainForm.Activate();

            trayIcon.Visible = false;
        }

        private void trayUnhide_Click(object sender, EventArgs e)
        {
            Unhide();
        }

        private void trayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            Unhide();
        }

        private void trayExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void Exit()
        {
            trueExit = true;
            if (!GlobalData.HotKey.Unregister())
                MessageBox.Show("Hotkey failed to unregister!");
            Close();
        }
    }
}
