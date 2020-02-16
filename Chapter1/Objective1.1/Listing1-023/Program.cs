using System;
using System.Linq;

/*
 * LISTING 1-23 Unordered parallel query
 */

namespace Listing1_023
{
    class Program
    {
        public static void Main()
        {
            var numbers = Enumerable.Range(0, 10);

            var parallelResult = numbers.AsParallel()
                .Where(number => number % 2 == 0)
                .ToArray();

            for (int i = 0; i < parallelResult.Length; i++)
                Console.WriteLine("Number #{0}: {1}", i+1, parallelResult[i]);
        }
    }
}

/*
CONSOLE:

Number #1: 4
Number #2: 0
Number #3: 6
Number #4: 8
Number #5: 2
*/