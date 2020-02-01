using System;
using System.Threading;

/*
 * LISTING 1-6 Using ThreadLocal<T>
 */

namespace Chapter1
{
    public static class Program
    {
        public static ThreadLocal<int> _field = // To use local data in a thread and initialize it for each thread.
            new ThreadLocal<int>(() => // This class takes a delegate to a method that initializes the value.
            {
                return Thread.CurrentThread.ManagedThreadId; // Used to ask for information about the thread that’s executing.
            });

        public static void Main()
        {
            new Thread(() =>
            {
                Console.WriteLine("Thread_A_#{0} - New field value: {1}", Thread.CurrentThread.ManagedThreadId, _field.Value);

                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine("Thread_A_#{0} - {1}/{2}", Thread.CurrentThread.ManagedThreadId, x+1, _field.Value);
                }
            }).Start();

            new Thread(() =>
            {
                Console.WriteLine("Thread_B_#{0} - New field value: {1}", Thread.CurrentThread.ManagedThreadId, _field.Value);

                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine("Thread_B_#{0} - {1}/{2}", Thread.CurrentThread.ManagedThreadId, x+1, _field.Value);
                }
            }).Start();
        }
    }
}

/*
CONSOLE:

Thread_B_#5 - New field value: 5
Thread_A_#4 - New field value: 4
Thread_B_#5 - 1/5
Thread_B_#5 - 2/5
Thread_B_#5 - 3/5
Thread_B_#5 - 4/5
Thread_B_#5 - 5/5
Thread_A_#4 - 1/4
Thread_A_#4 - 2/4
Thread_A_#4 - 3/4
Thread_A_#4 - 4/4
*/

