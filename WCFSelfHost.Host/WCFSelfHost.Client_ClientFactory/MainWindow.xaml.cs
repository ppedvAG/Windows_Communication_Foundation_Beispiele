using System;
using System.ServiceModel;
using System.Windows;
using WCFSelfHost.Host;

namespace WCFSelfHost.Client_ClientFactory
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

        private void Laden(object sender, RoutedEventArgs e)
        {
            ChannelFactory<IAutoService> cf = new ChannelFactory<IAutoService>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:1"));

            IAutoService client = cf.CreateChannel();

            myGrid.ItemsSource = client.GetAutos();
        }

        private void LadenBasic(object sender, RoutedEventArgs e)
        {
            var cf = new ChannelFactory<IAutoService>(new BasicHttpBinding(), new EndpointAddress("http://localhost:4"));

            IAutoService client = cf.CreateChannel();

            myGrid.ItemsSource = client.GetAutos();
        }

        private void LadenWS(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Leider nicht im .NET Core :-(");

            return;
            var cf = new ChannelFactory<IAutoService>(new WSHttpBinding(), new EndpointAddress("http://localhost:5"));

            IAutoService client = cf.CreateChannel();

            myGrid.ItemsSource = client.GetAutos();
        }

        private void LadenIPC(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Leider nicht im .NET Core :-(");
            //var cf = new ChannelFactory<IAutoService>(new Net(), new EndpointAddress("net.pipe://localhost/autos"));

            //IAutoService client = cf.CreateChannel();

            //myGrid.ItemsSource = client.GetAutos();
        }

        private void AddAuto(object sender, RoutedEventArgs e)
        {
            ChannelFactory<IAutoService> cf = new ChannelFactory<IAutoService>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:1"));

            IAutoService client = cf.CreateChannel();

            client.AddAuto(new Auto() { Hersteller = "LALA", PS = DateTime.Now.Second * 3, Farbe = "NEU", Modell = "NEU" });
        }

        private void AddAutoFail(object sender, RoutedEventArgs e)
        {
            //ChannelFactory<IAutoService> cf = new ChannelFactory<IAutoService>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:1"));
            var cf = new ChannelFactory<IAutoService>(new BasicHttpBinding(), new EndpointAddress("http://localhost.fiddler:4"));

            IAutoService client = cf.CreateChannel();

            try
            {
                client.AddAuto(new Auto() { Hersteller = "LALA", PS = DateTime.Now.Second * 3, Farbe = "Rosa", Modell = "NEU" });
            }
            catch (FaultException<RosaAutoFault> fe)
            {
                MessageBox.Show($"{fe.Reason} {fe.Detail.ErrorCount}");
            }
            catch (FaultException fe)
            {
                MessageBox.Show(fe.Message);
            }
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            var sel = myGrid.SelectedItem as Auto; //boxing :-(
            if (sel != null)
            {
                var cf = new ChannelFactory<IAutoService>(new BasicHttpBinding(), new EndpointAddress("http://localhost.fiddler:4"));

                IAutoService client = cf.CreateChannel();
                client.UpdateAuto(sel);
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (myGrid.SelectedItem is Auto sel) //pattern matching :-)
            {
                var cf = new ChannelFactory<IAutoService>(new BasicHttpBinding(), new EndpointAddress("http://localhost.fiddler:4"));

                IAutoService client = cf.CreateChannel();
                client.DeleteAuto(sel);
            }
        }
    }
}
