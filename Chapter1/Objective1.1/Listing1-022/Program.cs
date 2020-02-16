﻿using System;
using System.Linq;

/*
 * LISTING 1-22 Using AsParallel
 */

namespace Listing1_022
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(0, 100000000);
            Console.WriteLine("Enumerable CREATED - Count: {0}M", numbers.Count() / 1000000);
            Console.WriteLine("Parallel Query RUNNING...");
            var parallelResult = numbers.AsParallel()
                .Where(i => i % 2 == 0)
                .ToArray();
            Console.WriteLine("Parallel Query END");
            Console.WriteLine("Enumerable FILTERED - Count: {0}M", parallelResult.Count() / 1000000);
        }
    }
}

/*
CONSOLE:

Enumerable CREATED - Count: 100M
Parallel Query RUNNING...
Parallel Query END
Enumerable FILTERED - Count: 50M
 */
