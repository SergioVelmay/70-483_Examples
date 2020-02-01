using System;
using System.Threading.Tasks;

/*
 * LISTING 1-13 Using a TaskFactory
 */

namespace Listing1_013
{
    public static class Program
    {
        public static void Main()
        {
            Task<String[]> parent = Task.Run(() =>
            {
                Console.WriteLine("Parent Task running...");

                var results = new String[3];

                // A TaskFactory is created with a certain configuration. 
                TaskFactory myTaskFactory = new TaskFactory(
                    TaskCreationOptions.AttachedToParent,
                    TaskContinuationOptions.ExecuteSynchronously
                );

                // Now, we can create Tasks with the same configuration.
                myTaskFactory.StartNew(() => {
                    Console.WriteLine("1st child Task running...");
                    results[0] = "1st child Task result OK.";
                });
                myTaskFactory.StartNew(() => {
                    Console.WriteLine("2nd child Task running...");
                    results[1] = "2nd child Task result OK.";
                });
                myTaskFactory.StartNew(() => {
                    Console.WriteLine("3rd child Task running...");
                    results[2] = "3rd child Task result OK.";
                });

                return results;
            });

            var finalTask = parent.ContinueWith(
                parentTask => {
                    foreach (string taskEnded in parentTask.Result)
                    {
                        Console.WriteLine(taskEnded);
                    }
                }
            );

            finalTask.Wait();

            Console.WriteLine("Parent Task completed.");
        }
    }
}

/*
CONSOLE:

Parent Task running...
1st child Task running...
2nd child Task running...
3rd child Task running...
1st child Task result OK.
2nd child Task result OK.
3rd child Task result OK.
Parent Task completed.
*/
