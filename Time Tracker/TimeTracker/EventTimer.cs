using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeTracker
{
    class EventTimer : Timer
    {
        public EventTimer(System.ComponentModel.IContainer container):base(container){}

        new internal void Start()
        {
            base.Start();
            throwTimerEvent(TimerStarted);
        }

        new internal void Stop()
        {
            base.Stop();
            throwTimerEvent(TimerStopped);
        }

        private void throwTimerEvent(EventHandler<TimerArgs> handler)
        {
            if (handler != null) handler(this, new TimerArgs());
        }

        internal EventHandler<TimerArgs> TimerStarted;
        internal EventHandler<TimerArgs> TimerStopped;
        internal class TimerArgs : EventArgs
        {
            internal DateTime time;

            internal TimerArgs()
            {
                time = DateTime.Now;
            }
        }
    }
}
