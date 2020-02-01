using System;
using System.Threading;

/*
 * LISTING 1-1 Creating a thread with the Thread class
 */

namespace Chapter1
{
    public static class Program
    {
        public static void Main()
        {
            Thread mythread = new Thread(new ThreadStart(ThreadMethod));

            mythread.Start();

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("Thread_#{0} - Main Thread: Do some work: m{1}", Thread.CurrentThread.ManagedThreadId, i);

                Thread.Sleep(0); // Used to signal that this thread is finished and to immediately switch to another thread.
            }

            mythread.Join(); // Called on the main thread to let it wait until the secondary thread finishes.

            Console.WriteLine("Thread_#{0} - END.", Thread.CurrentThread.ManagedThreadId);
        }

        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Thread_#{0} - Secondary Thread Process: s{1}", Thread.CurrentThread.ManagedThreadId, i);

                Thread.Sleep(0); // Used to signal that this thread is finished and to immediately switch to another thread.
            }

            Console.WriteLine("Thread_#{0} - END.", Thread.CurrentThread.ManagedThreadId);
        }
    }
}

/*
CONSOLE:

Thread_#1 - Main Thread: Do some work: m0
Thread_#4 - Secondary Thread Process: s0
Thread_#4 - Secondary Thread Process: s1
Thread_#4 - Secondary Thread Process: s2
Thread_#1 - Main Thread: Do some work: m1
Thread_#1 - Main Thread: Do some work: m2
Thread_#4 - Secondary Thread Process: s3
Thread_#4 - Secondary Thread Process: s4
Thread_#4 - Secondary Thread Process: s5
Thread_#4 - Secondary Thread Process: s6
Thread_#4 - Secondary Thread Process: s7
Thread_#4 - Secondary Thread Process: s8
Thread_#4 - Secondary Thread Process: s9
Thread_#1 - Main Thread: Do some work: m3
Thread_#4 - END.
Thread_#1 - Main Thread: Do some work: m4
Thread_#1 - Main Thread: Do some work: m5
Thread_#1 - END.
*/
