using System;
using System.Threading.Tasks;

/*
 * LISTING 1-10 Adding a continuation
 */

namespace Chapter1
{
    public static class Program
    {
        public static void Main()
        {
            Task<int> myTask = Task.Run(() =>
            {
                Console.WriteLine("Procesing Task...");
                return 30;
            // To execute another operation as soon as the Task finishes.
            }).ContinueWith((prevTask) =>
            {
                Console.WriteLine("Task first return: {0}", prevTask.Result);
                Console.WriteLine("Continuing Task...");
                return prevTask.Result * 3;
            });

            Console.WriteLine("Task start.");
            Console.WriteLine("Task final result: {0}", myTask.Result);
            Console.WriteLine("Task end.");
        }
    }
}

/*
CONSOLE:

Task start.
Procesing Task...
Task first return: 30
Continuing Task...
Task final result: 90
Task end.
*/
