using System.Net.Http;
using System.Windows;

/*
 * LISTING 1-20 Using ConfigureAwait
 */

namespace Listing1_020
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

        // Button event handler that downloads a website and then puts the result in a label.
        private async void ButtonClick(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();

            string content = await httpClient
                .GetStringAsync("http://sergiovelmay.com")
                // This example throws an exception because of the ConfigureAwait(false).
                .ConfigureAwait(false);
                //.ConfigureAwait(true);

            // This line is not executed on the UI thread because of the ConfigureAwait(false).
            textBlock.Text = content;
        }
    }
}

/*
EXCEPTION:

System.InvalidOperationException: 
'The calling thread cannot access this object because a different thread owns it.'  
*/
