using System;
using System.Threading;

/*
 * LISTING 2-14 Using a where clause on a class definition
 */

namespace Chapter1
{
    public static class Program
    {
        public static void Main()
        {
            bool stopped = false; // The better way to stop a thread is by using a shared variable that both threads can access.

            Thread mythread = new Thread(new ThreadStart(() => // The thread is initialized with a lambda expression.
            {
                while (!stopped) // The thread keeps running until stopped becomes true.
                {
                    Console.WriteLine("Thread_#{0} - Secondary thread still running...", Thread.CurrentThread.ManagedThreadId);

                    Thread.Sleep(1000);
                }
            }));

            mythread.Start();

            Console.WriteLine("Thread_#{0} - ----- PRESS ANY KEY TO EXIT -----", Thread.CurrentThread.ManagedThreadId);

            Console.ReadKey();

            Console.WriteLine();

            stopped = true;

            mythread.Join(); // The Join method causes the console application to wait till the thread finishes execution.

            Console.WriteLine("Thread_#{0} - END.", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
/*
CONSOLE:

Thread_#1 - ----- PRESS ANY KEY TO EXIT -----
Thread_#5 - Secondary thread still running...
Thread_#5 - Secondary thread still running...
Thread_#5 - Secondary thread still running...
Thread_#5 - Secondary thread still running...
Thread_#5 - Secondary thread still running...
-
Thread_#1 - END.
*/
