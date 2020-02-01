using System;
using System.Threading;

/*
 * LISTING 1-7 Queuing some work to the thread pool
 */

namespace Chapter1
{
    public static class Program
    {
        public static void Main()
        {
            ThreadPool.QueueUserWorkItem((s) => // The threads are sended back to the pool where they can be reused whenever a request comes in.
            {
                Console.WriteLine("Thread_A_#{0} - Working on thread A from threadpool.", Thread.CurrentThread.ManagedThreadId);
            });

            ThreadPool.QueueUserWorkItem((s) => // A queued work item is picked up by an available thread from the pool.
            {
                Console.WriteLine("Thread_B_#{0} - Working on thread B from threadpool.", Thread.CurrentThread.ManagedThreadId);
            });

            ThreadPool.QueueUserWorkItem((s) => // The thread pool limits the available number of threads, you do get a lesser degree of parallelism than using the regular Thread class.
            {
                Console.WriteLine("Thread_C_#{0} - Working on thread C from threadpool.", Thread.CurrentThread.ManagedThreadId);
            });

            Console.WriteLine("Main_Thread_#{3} - ThreadPool Count: {2}, Completed: {0}, Pendig: {1}", ThreadPool.CompletedWorkItemCount, ThreadPool.PendingWorkItemCount, ThreadPool.ThreadCount, Thread.CurrentThread.ManagedThreadId);
        }
    }
}

/*
CONSOLE:

Thread_C_#6 - Working on thread C from threadpool.
Thread_B_#4 - Working on thread B from threadpool.
Main_Thread_#1 - ThreadPool Count: 4, Completed: 0, Pendig: 3
Thread_A_#5 - Working on thread A from threadpool.
 */
