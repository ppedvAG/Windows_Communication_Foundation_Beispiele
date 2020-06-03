using ServiceReference1;
using System.Windows;

namespace CoreWPFClient
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

        private async void Lade(object sender, RoutedEventArgs e)
        {
            var client = new Service1Client(Service1Client.EndpointConfiguration.BasicHttpBinding_IService1);
            myGrid.ItemsSource = await client.GetAllPizzaAsync();
        }

    }
}
