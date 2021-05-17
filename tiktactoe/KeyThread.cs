using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace tiktactoe
{
    public class KeyThread
    {
        public Thread thread { get; private set; }
        public string Key { get; private set; }

        public KeyThread(Thread t, string s)
        {
            thread = t;
            Key = s;
        }
        /// <summary>
        /// checks if thread is working
        /// </summary>
        /// <returns>returns false if not or not exist, true if activated</returns>
        public bool IsActivated()
        {
            if (thread == null)
                return false;
            return thread.IsAlive;
        }
        public bool Start(ThreadStart ts)
        {
            if (IsActivated())
                return false;
            thread = new Thread(ts);
            thread.Start();
            return true;
        }
        public bool Start()
        {
            if (IsActivated())
                return false;
            thread.Start();
            return true;
        }
        public void Dispose()
        {
            thread.Abort();
        }
    }
}
