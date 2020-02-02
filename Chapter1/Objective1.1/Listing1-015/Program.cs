using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

/*
 * LISTING 1-15 Using Task.WaitAny
 */

namespace Listing1_015
{
    public static class Program
    {
        public static void Main()
        {
            Task<int>[] tasks = new Task<int>[3];

            tasks[0] = Task.Run(() => { Thread.Sleep(3500); return 111; });
            tasks[1] = Task.Run(() => { Thread.Sleep(1600); return 222; });
            tasks[2] = Task.Run(() => { Thread.Sleep(2400); return 333; });

            Console.WriteLine("Tasks start.");

            while (tasks.Length > 0)
            {
                //  The WaitAny method waits until one of the tasks is finished.
                int i = Task.WaitAny(tasks);

                // Keeping track of which Tasks are finished.
                Task<int> completedTask = tasks[i];

                // Process a completed Task as soon as it finishes.
                Console.WriteLine("Task {0} completed. Result: {1}", completedTask.Id, completedTask.Result);

                var temp = tasks.ToList();

                temp.RemoveAt(i);

                tasks = temp.ToArray();
            }

            Console.WriteLine("Tasks end.");
        }
    }
}

/*
CONSOLE:

Tasks start.
Task 1 completed. Result: 222
Task 2 completed. Result: 333
Task 3 completed. Result: 111
Tasks end.
 */
