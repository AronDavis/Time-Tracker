using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using TimeTracker.Hotkeys;

namespace TimeTracker
{
    public partial class frmChangeHotkey : Form
    {
        private bool ctrl = false;
        private bool alt = false;
        private string hotKey = "";

        private const string CONTROL = "ctrl", ALT = "alt", SHIFT = "shift";
        public frmChangeHotkey()
        {
            InitializeComponent();
            
            //enable form level key listening
            KeyPreview = true;
        }

        private void frmChangeHotkey_Load(object sender, EventArgs e)
        {
            //unregister on load so not to interfere with change
            GlobalData.HotKey.Unregiser();

            lblHotKey.Text = GlobalData.HotKey.ToString();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            GlobalHotkey hk = new GlobalHotkey(ctrl, alt, (Keys)Enum.Parse(typeof(Keys), hotKey));

            //test registering the hotkey
            if (hk.Register())
            {
                //unregister (will be reregistered on close)
                hk.Unregiser();

                //store as the global hot key
                GlobalData.HotKey = hk;

                Close();
            }
            else
            {
                MessageBox.Show("Hotkey already registered.  Try another hotkey.");
            }
        }

        //keys recently pressed down (and timestamps)
        private List<keyDown> recentKeysDown = new List<keyDown>();

        //keys currently down
        private HashSet<string> keysDown = new HashSet<string>();

        private void frmChangeHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            //ignore ONLY modifiers
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey
                || e.KeyCode == Keys.Alt || e.KeyCode == Keys.Menu
                || e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey || e.KeyCode == Keys.Shift || e.KeyCode == Keys.ShiftKey)
                return;

            bool ctrlPressed = e.Control;
            bool altPressed = e.Alt;

            //log modifiers as down
            if (ctrlPressed) newKeyDown(CONTROL);
            if (altPressed) newKeyDown(ALT);

            //log key as down
            newKeyDown(e.KeyCode.ToString());
        }

        private void frmChangeHotkey_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey)
            {
                newKeyUp(CONTROL);
            }
            else if(e.KeyCode == Keys.Alt || e.KeyCode == Keys.Menu)
            {
                newKeyUp(ALT);
            }
            else if(e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey || e.KeyCode == Keys.Shift || e.KeyCode == Keys.ShiftKey)
            {
                //ignore shift
            }
            else
            {
                newKeyUp(e.KeyCode.ToString());
            }
        }

        private void newKeyDown(string key)
        {
            //if we haven't logged the key yet, log it
            if (!keysDown.Contains(key)) keysDown.Add(key);

            //add it to recent (no matter what) for time stamp
            recentKeysDown.Add(new keyDown(key)); //TODO: make it smart!  Refresh time if already exists (instead of add)

            if (recentKeysDown.Count > 250) //TODO: smart version won't need buffer
            {
                MessageBox.Show("Keys held down for too long.  Please try again.");
                recentKeysDown.Clear();
            }
        }

        private void newKeyUp(string key)
        {
            //remove the key if it was pressed down
            if (keysDown.Contains(key))
            {
                keysDown.Remove(key);

                //if there are no remaining keys down, all keys lifted
                if (keysDown.Count == 0) AllKeysLifted();
            }
        }

        /// <summary>
        /// Fires when all keys were recently lifted (requires keypress)
        /// </summary>
        private void AllKeysLifted()
        {
            //cache current time
            DateTime time = DateTime.Now;

            //set threshold to know what keys to include
            TimeSpan threshold = new TimeSpan(0,0,0,0,500);

            //temp storage for keys to be included
            HashSet<string> keys = new HashSet<string>();

            bool mainKeyFound = false;
            for (int i = recentKeysDown.Count - 1; i >= 0; i--)
            {
                keyDown key = recentKeysDown[i];
                if (time - key.timeDown <= threshold && !keys.Contains(key.name))
                {
                    if(key.name != CONTROL && key.name != ALT && key.name != SHIFT)
                    {
                        if (mainKeyFound) break;
                        else mainKeyFound = true;
                    }
                    keys.Add(key.name);
                }
            }

            bool ctrlPressed = false,
                altPressed = false;
            string k = "";

            foreach(string key in keys)
            {
                if (key == CONTROL) ctrlPressed = true;
                else if (key == ALT) altPressed = true;
                else if (key == SHIFT) ;//no shift
                else k = key;
            }
            
            recentKeysDown.Clear();

            //update label
            lblHotKey.Text = (ctrlPressed ? "Ctrl + " : "")
                + (altPressed ? "Alt + " : "") 
                + k;

            ctrl = ctrlPressed;
            alt = altPressed;
            hotKey = k;
        }

        /// <summary>
        /// Class for storing key name and when key went down
        /// </summary>
        private class keyDown
        {
            public string name;
            public DateTime timeDown { get; private set; }

            public keyDown(string name)
            {
                this.name = name;
                timeDown = DateTime.Now;
            }
        }

        private void frmChangeHotkey_FormClosed(object sender, FormClosedEventArgs e)
        {
            GlobalData.HotKey.Register();
        }
    }
}
