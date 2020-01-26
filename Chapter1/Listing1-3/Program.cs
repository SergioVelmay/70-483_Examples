using System;
using System.Threading;

/*
 * LISTING 1-3 Using the ParameterizedThreadStart
 */

namespace Chapter1
{
    public static class Program
    {
        public static void Main()
        {
            Thread mythread = new Thread(new ParameterizedThreadStart(ThreadMethod)); // Used to pass some data through the start method of your thread to your worker method.

            mythread.Start(6); // Data to pass through the start method of your thread to your worker method as a parameter (Object).

            mythread.Join();

            Console.WriteLine("Thread_#{0} - END.", Thread.CurrentThread.ManagedThreadId);
        }

        public static void ThreadMethod(Object obj)
        {
            int times = (int)obj; // You can cast the Object to the expected type to use it in your method.

            for (int i = 0; i < times; i++)
            {
                Console.WriteLine("Thread_#{0} - Secondary Thread Process: {1}/{2}", Thread.CurrentThread.ManagedThreadId, i + 1, times);

                Thread.Sleep(0);
            }
        }
    }
}

/*
CONSOLE:

Thread_#4 - Secondary Thread Process: 1/6
Thread_#4 - Secondary Thread Process: 2/6
Thread_#4 - Secondary Thread Process: 3/6
Thread_#4 - Secondary Thread Process: 4/6
Thread_#4 - Secondary Thread Process: 5/6
Thread_#4 - Secondary Thread Process: 6/6
Thread_#1 - END.
*/
