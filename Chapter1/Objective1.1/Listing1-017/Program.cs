using System;
using System.Threading;
using System.Threading.Tasks;

/*
 * LISTING 1-17 Using Parallel.Break
 */

namespace Listing1_017
{
    public static class Program
    {
        public static void Main()
        {
            // You can cancel the loop by using the ParallelLoopState object.
            ParallelLoopResult result = Parallel.For(0, 15, (int i, ParallelLoopState loopState) =>
            {
                if (i == 5)
                {
                    Console.WriteLine("Breaking loop...");

                    // Break ensures that all iterations that are currently running will be finished.
                    loopState.Break();
                }

                Console.WriteLine("Parallel iteration #{0}", i);

                Thread.Sleep(500);

                return;
            });
        }
    }
}

/*
CONSOLE:

Parallel iteration #7
Parallel iteration #6
Parallel iteration #2
Parallel iteration #4
Parallel iteration #3
Parallel iteration #1
Parallel iteration #8
Parallel iteration #0
Breaking loop...
Parallel iteration #5
*/
