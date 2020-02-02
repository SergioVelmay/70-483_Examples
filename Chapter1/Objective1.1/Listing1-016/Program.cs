using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

/*
 * LISTING 1-16 Using Parallel.For and Parallel.ForEach
 */

namespace Listing1_016
{
    public static class Program
    {
        public static void Main()
        {
            // Parallelism involves splitting a task into a set of related tasks that can be executed concurrently.
            // You should use the Parallel class only when your code doesn’t have to be executed sequentially.
            // It increases performance only when we have a lot of work to be done that can be executed in parallel.

            Parallel.For(0, 5, i =>
            {
                Console.WriteLine("Parallel.For - Iteration #{1} - Thread {0}", Thread.CurrentThread.ManagedThreadId, i);
                Thread.Sleep(500);
            });

            var numbers = Enumerable.Range(0, 5);
            Parallel.ForEach(numbers, i =>
            {
                Console.WriteLine("Parallel.ForEach - Iteration #{1} - Thread {0}", Thread.CurrentThread.ManagedThreadId, i);
                Thread.Sleep(500);
            });
        }
    }
}

/*
CONSOLE:

Parallel.For - Iteration #1 - Thread 4
Parallel.For - Iteration #0 - Thread 1
Parallel.For - Iteration #4 - Thread 6
Parallel.For - Iteration #2 - Thread 5
Parallel.For - Iteration #3 - Thread 7
Parallel.ForEach - Iteration #3 - Thread 4
Parallel.ForEach - Iteration #1 - Thread 11
Parallel.ForEach - Iteration #0 - Thread 1
Parallel.ForEach - Iteration #4 - Thread 7
Parallel.ForEach - Iteration #2 - Thread 10
*/
