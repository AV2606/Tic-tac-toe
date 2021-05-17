using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace tiktactoe
{
    public class ThreadPool
    {
       public static KeyThread[] threads { get; private set; }

        public static void init()
        {
            threads = new KeyThread[0];
        }
        public static void Add(Thread a, string key)
        {
            if (threads.Length != 0)
                for (int i = 0; i < threads.Length; i++)
                {
                    if (threads[i].Key == key)
                        throw new ArgumentException("Cant assign 2 threads with the same key!");
                }
            var temp = new KeyThread[threads.Length + 1];
            for (int i = 0; i < threads.Length; i++)
            {
                temp[i] = threads[i];
            }
            temp[temp.Length - 1] = new KeyThread(a, key);
            threads = temp;
        }
        public static KeyThread Sub(string key)
        {
            KeyThread ret=null;
            for (int i = 0; i < threads.Length; i++)
            {
                if (threads[i].Key == key)
                {
                    ret = threads[i];
                    for (int j = i; j < threads.Length - 1; j++)
                    {
                        threads[j] = threads[j + 1];
                    }
                }
            }
            if (ret != null)
                Sub1();
            return ret;
        }
        public static KeyThread Sub(KeyThread thread)
        {
            KeyThread ret = null;

            for (int i = 0; i < threads.Length; i++)
            {
                if (threads[i] == thread)
                {
                    ret = threads[i];
                    for (int j = i; j < threads.Length - 1; j++)
                    {
                        threads[j] = threads[j + 1];
                    }
                }
            }
            if (ret != null)
                Sub1();
            return ret;
        }
        public static bool Start(int index)
        {
            try
            {
                threads[index].Start();
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }
        public static int FindIndex(string key)
        {
            for (int i = 0; i < threads.Length; i++)
            {
                if (threads[i].Key == key)
                    return i;
            }
            return -1;
        }
        public static int FindIndex(KeyThread thread)
        {
            for (int i = 0; i < threads.Length; i++)
            {
                if (threads[i] == thread)
                    return i;
            }
            return -1;
        }
        public static bool Abort(int index)
        {
                threads[index].thread.Abort();
                Sub(threads[index].Key);
            return true;

        }
        private static void Sub1()
        {
            var temp = new KeyThread[threads.Length - 1];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = threads[i];
            }
            threads = temp;
        }
    }
}
