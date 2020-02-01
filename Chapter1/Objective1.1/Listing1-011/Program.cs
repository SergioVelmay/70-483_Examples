using System;
using System.Threading.Tasks;

/*
 * LISTING 1-11 Scheduling different continuation tasks
 */

namespace Listing1_011
{
    public static class Program
    {
        public static void Main()
        {
            Task myTask = Task.Run(() =>
            {
                Console.WriteLine("Procesing Task...");
            });

            // The ContinueWith method has overloads to configure when the continuation will run.

            // Continuation runs only on Canceled.
            myTask.ContinueWith((prevTask) =>
            {
                Console.WriteLine("Task Canceled...");
            }, 
            TaskContinuationOptions.OnlyOnCanceled);

            // Continuation runs only on Faulted.
            myTask.ContinueWith((prevTask) =>
            {
                Console.WriteLine("Task Faulted...");
            }, 
            TaskContinuationOptions.OnlyOnFaulted);

            // Continuation runs only on Completed.
            var completedTask = myTask.ContinueWith((prevTask) =>
            {
                Console.WriteLine("Task Completed...");
            }, 
            TaskContinuationOptions.OnlyOnRanToCompletion);

            Console.WriteLine("Task start.");
            completedTask.Wait();
            Console.WriteLine("Task end.");         
        }
    }
}

/*
CONSOLE:

Task start.
Procesing Task...
Task Completed...
Task end.
*/
