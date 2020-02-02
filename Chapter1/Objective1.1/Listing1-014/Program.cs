using System;
using System.Threading;
using System.Threading.Tasks;

/*
 * LISTING 1-14 Using Task.WaitAll
 */

namespace Listing1_014
{
    public static class Program
    {
        public static void Main()
        {

            Task[] tasks = new Task[3];

            tasks[0] = Task.Run(() => {
                Thread.Sleep(2000);
                Console.WriteLine("1st Task completed in 2000ms");
                return 1;
            });

            tasks[1] = Task.Run(() => {
                Thread.Sleep(2000);
                Console.WriteLine("2nd Task completed in 2000ms");
                return 2;
            });

            tasks[2] = Task.Run(() => {
                Thread.Sleep(2000);
                Console.WriteLine("3rd Task completed in 2000ms");
                return 3;
            });

            Console.WriteLine("Tasks start.");

            //The method WaitAll waits for multiple Tasks to finish before continuing execution.
            Task.WaitAll(tasks);
            // All three Tasks are executed simultaneously, and the whole run takes approximately 2000ms instead of 6000ms.

            Console.WriteLine("Tasks end.");
        }
    }
}

/*
CONSOLE:

Tasks start.
3rd Task completed in 2000ms
1st Task completed in 2000ms
2nd Task completed in 2000ms
Tasks end.
*/