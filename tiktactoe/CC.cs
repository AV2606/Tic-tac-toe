using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

namespace tiktactoe
{
    /// <summary>
    /// common commands class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class CC<T>
    {
        public static T[] Sub(T[] arr, int index)
        {
            if (index > arr.Length)
                return arr;
            if (index < 0)
                return arr;
            var temp = new T[arr.Length-1];
            for (int i = 0; i < index; i++)
            {
                temp[i] = arr[i];
            }
            for (int i = index; i < arr.Length-1; i++)
            {
                temp[i] = arr[i + 1];
            }
            return temp;
        }
        public static int MaxIndex(int[] arr)
        {
            int index = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > arr[index])
                    index = i;
            }
            return index;
        }
        public static int MinIndex(int[] arr)
        {
            int index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < arr[index])
                    index = i;
            }
            return index;
        }
        /// <summary>
        /// waits until the <paramref name="condition"/> becomes true.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="interval">the time between 2 checks of the condition in miliseconds</param>
        public static void WaitT(ref bool condition,int interval)
        {
            while(!condition)
            {
                Thread.Sleep(interval);
            }
        }
        /// <summary>
        /// waits until the <paramref name="condition"/> becomes false.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="interval">the time between 2 checks of the condition in miliseconds</param>
        public static void WaitF(ref bool condition, int interval)
        {
            while (condition)
            {
                Thread.Sleep(interval);
            }
        }
        /// <summary>
        /// Sets the X values of the <see cref="Control"/> to the center of its parent.
        /// </summary>
        /// <param name="controls"></param>
        public static void CenterVertical(Control control)
        {
            Control parent = control.Parent;
            control.Location = new Point(parent.Width / 2 - control.Width / 2, control.Location.Y);
        }
        /// <summary>
        /// Sets the Y values of the <see cref="Control"/> to the center of its parent.
        /// </summary>
        /// <param name="controls"></param>
        public static void CenterHorizontal(Control control)
        {
            Control parent = control.Parent;
            control.Location = new Point(control.Location.X,parent.Width / 2 - control.Width / 2);
        }
    }
}
