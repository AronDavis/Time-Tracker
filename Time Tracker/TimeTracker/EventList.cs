using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTracker
{
    internal class EventList<T> : List<T>
    {
        public EventList() : base() { }

        //new to show intention of hiding base Add
        new public void Add(T item)
        {
            base.Add(item);

            throwItemEvent(ItemAdded, item);
        }

        public void NoEventAdd(T item) { base.Add(item);}

        //new to show intention of hiding base Remove
        new public void Remove(T item)
        {
            base.Remove(item);
            throwItemEvent(ItemRemoved, item);
        }

        //new to show intention of hiding base RemoveAt
        new public void RemoveAt(int index)
        {
            T item = this[index];
            base.RemoveAt(index);
            throwItemEvent(ItemRemoved, item);
        }

        private void throwItemEvent(EventHandler<ItemArgs> handler, T item)
        {
            if (handler != null) handler(this, new ItemArgs(item));
        }


        internal event EventHandler<ItemArgs> ItemAdded;
        internal event EventHandler<ItemArgs> ItemRemoved;

        internal class ItemArgs: EventArgs
        {
            internal T item { get; set; }

            internal ItemArgs(T item)
            {
                this.item = item;
            }
        }
    }
}
