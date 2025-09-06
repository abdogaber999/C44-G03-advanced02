using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Session02_Solution
{
    internal class QueueReverser
    {
        public static void ReverseQueue<T>(Queue<T> queue)
        {
            Stack<T> stack = new Stack<T>();

            // نقل العناصر من الـ Queue للـ Stack
            while (queue.Count > 0)
            {
                stack.Push(queue.Dequeue());
            }

            // نقل العناصر من الـ Stack للـ Queue
            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }
        }

    }
}
