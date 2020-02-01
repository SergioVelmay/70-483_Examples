using System;
using System.Threading;
using System.Threading.Tasks;

/*
 * LISTING 1-8 Starting a new Task
 */

namespace Chapter1
{
    public static class Program
    {
        public static void Main()
        {
            Task myTask = Task.Run(() => // A Task represents some work that should be done.
            {
                for (int x = 0; x < 9; x++)
                {
                    // The Task scheduler uses threads from the thread pool to execute the Task.
                    Console.Write("Thread {0} - ", Thread.CurrentThread.ManagedThreadId);

                    for (int y = x; y < 9; y++)
                    {
                        Console.Write('*');
                    }

                    Console.WriteLine();
                }
            });

            Console.WriteLine("Thread {0} - TASK START", Thread.CurrentThread.ManagedThreadId);

            myTask.Wait(); // Start a new Task and wait until it’s finished.

            Console.WriteLine("Thread {0} - TASK END", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
/*
CONSOLE:

Thread 1 - TASK START
Thread 4 - *********
Thread 4 - ********
Thread 4 - *******
Thread 4 - ******
Thread 4 - *****
Thread 4 - ****
Thread 4 - ***
Thread 4 - **
Thread 4 - *
Thread 1 - TASK END
*/
