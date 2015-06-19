using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeTracker
{
    public static class StaticForm
    {
        public static void Open<T>(ref T form) where T : Form, new()
        {
            if (form == null || form.IsDisposed) form = new T();

            form.Show();
            form.Activate();
        }
    }
}
