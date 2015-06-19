using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TimeTracker.Hotkeys
{
    public class GlobalHotkey
    {
        private int modifier;
        public int key { get; private set; }
        private IntPtr hWnd;
        private int id;
        public bool ctrl { get; private set; }
        public bool alt { get; private set; }

        public GlobalHotkey(bool ctrl, bool alt, Keys key)
        {
            this.ctrl = ctrl;
            this.alt = alt;
            this.modifier = (ctrl ? HKConstants.CTRL : 0) + (alt ? HKConstants.ALT : 0);
            this.key = (int)key;
            this.hWnd = GlobalData.mainForm.Handle;
            id = this.GetHashCode();
        }

        public static GlobalHotkey Parse(string text)
        {

            return new GlobalHotkey(Convert.ToBoolean(Char.GetNumericValue(text[0])), Convert.ToBoolean(Char.GetNumericValue(text[1])), (Keys)int.Parse(text.Substring(2)));
        }

        public bool Register()
        {
            return RegisterHotKey(hWnd, id, modifier, key);
        }

        public bool Unregister()
        {
            return UnregisterHotKey(hWnd, id);
        }

        public override int GetHashCode()
        {
            return modifier ^ key ^ hWnd.ToInt32();
        }

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public override string ToString()
        {
            return (ctrl ? "Ctrl + " : "") + (alt ? "Alt + " : "") + ((Keys)key).ToString();
        }
    }
}
