using System;
using System.Threading;

/*
 * LISTING 1-5 Using the ThreadStaticAttribute
 */

namespace Chapter1
{
    public static class Program
    {
        [ThreadStatic] // By marking a field with the ThreadStatic attribute, each thread gets its own copy of a field.
        public static int _field;

        public static void Main()
        {
            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    _field++;

                    Console.WriteLine("Thread_A_#{0} - Field value: {1}", Thread.CurrentThread.ManagedThreadId, _field);
                }
            }).Start();

            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    _field++;

                    Console.WriteLine("Thread_B_#{0} - Field value: {1}", Thread.CurrentThread.ManagedThreadId, _field);
                }
            }).Start();
        }
    }
}

/*
CONSOLE (with ThreadStatic):

Thread_B_#6 - Field value: 1
Thread_A_#5 - Field value: 1
Thread_A_#5 - Field value: 2
Thread_A_#5 - Field value: 3
Thread_A_#5 - Field value: 4
Thread_A_#5 - Field value: 5
Thread_A_#5 - Field value: 6
Thread_A_#5 - Field value: 7
Thread_A_#5 - Field value: 8
Thread_A_#5 - Field value: 9
Thread_A_#5 - Field value: 10
Thread_B_#6 - Field value: 2
Thread_B_#6 - Field value: 3
Thread_B_#6 - Field value: 4
Thread_B_#6 - Field value: 5
Thread_B_#6 - Field value: 6
Thread_B_#6 - Field value: 7
Thread_B_#6 - Field value: 8
Thread_B_#6 - Field value: 9
Thread_B_#6 - Field value: 10

CONSOLE (without attribute):

Thread_A_#5 - Field value: 1
Thread_B_#6 - Field value: 2
Thread_B_#6 - Field value: 4
Thread_B_#6 - Field value: 5
Thread_B_#6 - Field value: 6
Thread_B_#6 - Field value: 7
Thread_B_#6 - Field value: 8
Thread_B_#6 - Field value: 9
Thread_B_#6 - Field value: 10
Thread_B_#6 - Field value: 11
Thread_B_#6 - Field value: 12
Thread_A_#5 - Field value: 3
Thread_A_#5 - Field value: 13
Thread_A_#5 - Field value: 14
Thread_A_#5 - Field value: 15
Thread_A_#5 - Field value: 16
Thread_A_#5 - Field value: 17
Thread_A_#5 - Field value: 18
Thread_A_#5 - Field value: 19
Thread_A_#5 - Field value: 20
*/
