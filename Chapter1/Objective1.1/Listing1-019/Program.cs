using System;
using System.Threading;
using System.Threading.Tasks;

/*
 * LISTING 1-19 Scalability versus responsiveness
 */

namespace Listing1_019
{
    public static class Program
    {
        // To view Threads during debug: 
        // Debug / Windows / Threads
        // Debug / Windows / Parallel Stacks
        public static void Main()
        {
            Console.WriteLine("Thread: {0} - Main Thread START", Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("Thread: {0} - SleepAsyncA START", Thread.CurrentThread.ManagedThreadId);
            SleepAsyncA(1000);
            //SleepAsyncA(1000).Wait();
            Console.WriteLine("Thread: {0} - SleepAsyncA END", Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("Thread: {0} - SleepAsyncB START", Thread.CurrentThread.ManagedThreadId);
            SleepAsyncB(1000);
            //SleepAsyncB(1000).Wait();
            Console.WriteLine("Thread: {0} - SleepAsyncB END", Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("Thread: {0} - Main Thread END", Thread.CurrentThread.ManagedThreadId);
        }

        // The SleepAsyncA method uses a thread from the thread pool while sleeping.
        public static Task SleepAsyncA(int millisecondsTimeout)
        {
            Console.WriteLine("Thread: {0} - SleepAsyncA RUNNING...", Thread.CurrentThread.ManagedThreadId);
            return Task.Run(() => Thread.Sleep(millisecondsTimeout));
        }

        // The SleepAsyncB method does not occupy a thread while waiting for the timer to run giving you scalability.
        public static Task SleepAsyncB(int millisecondsTimeout)
        {
            Console.WriteLine("Thread: {0} - SleepAsyncB RUNNING...", Thread.CurrentThread.ManagedThreadId);
            TaskCompletionSource<bool> taskCompletionSource = null;
            var timer = new Timer(delegate { taskCompletionSource.TrySetResult(true); }, null, -1, -1);
            taskCompletionSource = new TaskCompletionSource<bool>(timer);
            timer.Change(millisecondsTimeout, -1);
            return taskCompletionSource.Task;
        }
    }
}

/*
CONSOLE:

Thread: 1 - Main Thread START
Thread: 1 - SleepAsyncA START
Thread: 1 - SleepAsyncA RUNNING...
Thread: 1 - SleepAsyncA END
Thread: 1 - SleepAsyncB START
Thread: 1 - SleepAsyncB RUNNING...
Thread: 1 - SleepAsyncB END
Thread: 1 - Main Thread END
*/

