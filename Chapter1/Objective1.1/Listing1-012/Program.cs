using System;
using System.Threading.Tasks;

/*
 * LISTING 1-12 Attaching child tasks to a parent task
 */

namespace Listing1_012
{
    public static class Program
    {
        public static void Main()
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                Console.WriteLine("Parent Task running...");

                var results = new Int32[3];

                // A Task can also have several child Tasks.
                new Task(() => results[0] = 111, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = 222, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = 333, TaskCreationOptions.AttachedToParent).Start();
                // We have to create three Tasks all with the same options.

                return results;
            });

            // The parent Task finishes when all the child tasks are ready.
            var finalTask = parent.ContinueWith(
                parentTask => {
                    foreach (int i in parentTask.Result)
                    {
                        Console.WriteLine("Child Task result: {0}", i);
                    }
                }
            );

            // The finalTask runs only after the parent Task is finished.
            finalTask.Wait();

            Console.WriteLine("Parent Task completed.");
        }
    }
}

/*
CONSOLE:

Parent Task running...
Child Task result: 111
Child Task result: 222
Child Task result: 333
Parent Task completed.
*/
