using System;
using System.Threading;

/*
 * LISTING 1-2 Using a background thread
 */

namespace Listing1_002
{
    public static class Program
    {
        public static void Main()
        {
            Thread mythread = new Thread(new ThreadStart(ThreadMethod));

            //mythread.IsBackground = true; // Don't wait to this secondary thread (background) to finish before exit the program.
            mythread.IsBackground = false; // Wait to this secondary thread in foreground to finish before exit the program.

            mythread.Start();

            Console.WriteLine("Thread_#{0} - THE PROGRAM WOULD END NOW.", Thread.CurrentThread.ManagedThreadId);
        }

        public static void ThreadMethod()
        {
            int times = 9;

            for (int i = 0; i < times; i++)
            {
                Console.WriteLine("Thread_#{0} - Secondary Thread Process: {1}/{2}", Thread.CurrentThread.ManagedThreadId, i + 1, times);

                Thread.Sleep(200); // Used to wait a number of miliseconds before switch to another thread.
            }
        }
    }
}

/*
CONSOLE (true):

Thread_#5 - Secondary Thread Process: 1/9
Thread_#1 - THE PROGRAM WOULD END NOW.

CONSOLE (false):

Thread_#5 - Secondary Thread Process: 1/9
Thread_#1 - THE PROGRAM WOULD END NOW.
Thread_#5 - Secondary Thread Process: 2/9
Thread_#5 - Secondary Thread Process: 3/9
Thread_#5 - Secondary Thread Process: 4/9
Thread_#5 - Secondary Thread Process: 5/9
Thread_#5 - Secondary Thread Process: 6/9
Thread_#5 - Secondary Thread Process: 7/9
Thread_#5 - Secondary Thread Process: 8/9
Thread_#5 - Secondary Thread Process: 9/9
*/
