using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows;

/*
 * LISTING 1-21 Continuing on a thread pool instead of the UI thread
 */

namespace Listing1_021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // A void returning async method is effectively a fire-and-forget method.
        // You can never inspect the return type, and you can’t see whether any exceptions were thrown.
        // You should use async void methods only when dealing with asynchronous events.
        private async void ButtonClick(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "No Exception thrown despite using ConfigureAwait(false).";

            HttpClient httpClient = new HttpClient();

            string content = await httpClient
                .GetStringAsync("http://sergiovelmay.com")
                .ConfigureAwait(false);
                //.ConfigureAwait(true);

            // If you do something else, such as writing the content to file, 
            // you don’t need to set the SynchronizationContext to be set.
            using (FileStream sourceStream = new FileStream(
                "temp.html", FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync: true))
            {
                byte[] encodedText = Encoding.Unicode.GetBytes(content);
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length)
                .ConfigureAwait(false);
            };

            //textBlock.Text = content; // Thows an Exception
        }
    }
}

/*
EXCEPTION:

System.InvalidOperationException: 
'The calling thread cannot access this object because a different thread owns it.'  
*/

