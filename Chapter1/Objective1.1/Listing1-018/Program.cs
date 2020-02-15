using System;
using System.Net.Http;
using System.Threading.Tasks;

/*
 * LISTING 1-18 Async and Await
 */

namespace Listing1_018
{
    public static class Program
    {
        // The entry method of an application can’t be marked as async.
        // Use the .Wait method in Main instead of the await keyword.
        public static void Main()
        {
            Console.WriteLine("\nMain Thread START ------------\n");

            string result = DownloadContent().Result;

            Console.WriteLine(result);

            Console.WriteLine("\nMain Thread END ------------\n");
        }

        public static async Task<string> DownloadContent()
        {
            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine("\nAsync Task START ------\n");

                // GetStringAsync uses asynchronous code internally and returns a Task<string>.
                string result = await client.GetStringAsync("https://sergiovelmay.com");

                Console.WriteLine("\nAsync Task END ------\n");

                return result;
            }
        }
    }
}

/*
CONSOLE:

Main Thread START ------------

Async Task START ------

Async Task END ------

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
</head>
<body>
</body>
</html>

Main Thread END ------------
*/

