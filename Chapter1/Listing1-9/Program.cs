using System;
using System.Threading.Tasks;

/*
 * LISTING 1-9 Using a Task that returns a value.
 */

namespace Chapter1
{
    public static class Program
    {
        public static void Main()
        {
            // You can use Task<T> class if a Task should return a value.
            Task<int> myTask = Task.Run(() =>
            {
                Console.WriteLine("Procesing Task...");

                return 30;
            });

            Console.WriteLine("Task start.");
            // The Result property on a Task will force to wait until the Task is finished before continuing.
            Console.WriteLine("Task result: {0}", myTask.Result);
            // If the Task is not finished, this call will block the current thread.
            Console.WriteLine("Task end.");
        }
    }
}

/*
CONSOLE:

Task start.
Procesing Task...
Task result: 30
Task end.
*/
