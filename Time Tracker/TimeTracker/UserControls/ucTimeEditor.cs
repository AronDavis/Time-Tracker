using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace TimeTracker
{
    public partial class ucTimeEditor : UserControl
    {
        bool enterPressed = false;
        new public EventHandler LostFocus;
        new public EventHandler EnterPressed;
        new public EventHandler EscapePressed;
        public int AlignmentOffset { get; private set; }

        public DateTime Value { 
            get
            {
                return dtp.Value;
            }

            set
            {
                dtp.Value = value;
            }
        }

        public ucTimeEditor()
        {
            InitializeComponent();
            AlignmentOffset = btnSave.Width + btnCancel.Width;
        }

        private void ucTimeEditor_Load(object sender, EventArgs e)
        {
            dtp.CustomFormat = "HH:mm:ss";
        }

        new public void Focus()
        {
            dtp.Focus();
        }

        public TimeSpan GetTime()
        {
            return new TimeSpan(dtp.Value.Ticks - dtp.Value.Date.Ticks);
        }

        public void Reset()
        {
            enterPressed = false;
            dtp.Value = dtp.Value.Date;
        }

        private void dtp_KeyPress(object sender, KeyPressEventArgs e)
        {
            enterPressed = (e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == Convert.ToChar(Keys.Return));

            if (e.KeyChar == Convert.ToChar(Keys.Escape)) EscapePressed(this, new EventArgs());

            if (enterPressed) btnSave_Click(btnSave, new EventArgs());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(EnterPressed != null) EnterPressed(this,new EventArgs());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (EscapePressed != null) EscapePressed(this, new EventArgs());
        }
    }
}
