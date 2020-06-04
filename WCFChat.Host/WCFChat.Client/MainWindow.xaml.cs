using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WCFChat.Contracts;

namespace WCFChat.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IClient
    {
        public MainWindow()
        {
            InitializeComponent();
            userNameTb.Text = $"Fred {Guid.NewGuid().ToString().Substring(0, 4)}";

            if (!!!!true)
            {
                var tcp = new NetTcpBinding();
                tcp.Security.Mode = SecurityMode.Transport;
                tcp.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;

                tcp.MaxReceivedMessageSize = int.MaxValue;
                EndpointIdentity identity = EndpointIdentity.CreateDnsIdentity("MyROOTCert");
                EndpointAddress address = new EndpointAddress(new Uri("net.tcp://localhost:1"), identity);


                cf = new DuplexChannelFactory<IServer>(this, tcp, address);
                cf.Credentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.Root,
                X509FindType.FindByThumbprint, "14295bd222c188a881dbe88585333dd564a5b57a");
                cf.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;

            


            }
            else
            {
                var wsDual = new WSDualHttpBinding();
                wsDual.Security.Mode = WSDualHttpSecurityMode.Message;
                cf = new DuplexChannelFactory<IServer>(this, wsDual, new EndpointAddress("http://localhost:2"));
            }

            SetUi(false);
        }

        DuplexChannelFactory<IServer> cf = null;
        IServer server = null;

        private void SetUi(bool loggedIn)
        {
            userNameTb.IsEnabled = !loggedIn;
            loginBtn.IsEnabled = !loggedIn;

            logoutBtn.IsEnabled = loggedIn;
            sendImageBtn.IsEnabled = loggedIn;
            sendTextBtn.IsEnabled = loggedIn;
            sendVoiceBtn.IsEnabled = loggedIn;
            msgTb.IsEnabled = loggedIn;
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            server = cf.CreateChannel();
            server.Login(userNameTb.Text);
        }

        public void LoginResponse(bool ok)
        {
            SetUi(ok);
        }

        public void LogoutResponse(bool ok)
        {
            SetUi(!ok);
        }

        public void ShowImage(Stream image)
        {

            var ms = new MemoryStream();
            image.CopyTo(ms);
            ms.Position = 0;

            var vb = new Viewbox();

            var img = new Image();
            img.BeginInit();
            img.Source = BitmapFrame.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            img.Stretch = Stretch.None;
            img.EndInit();
            vb.Child = img;
            chatLb.Items.Add(vb);
        }

        public void ShowText(string text)
        {
            chatLb.Items.Add(text);
        }

        public void ShowUserlist(IEnumerable<string> users)
        {
            UsersLb.ItemsSource = users;
        }

        public void ShowVoice(Stream voice)
        {
            throw new NotImplementedException();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            server.Logout();
        }

        private void SendText(object sender, RoutedEventArgs e)
        {
            server.SendText(msgTb.Text);
            msgTb.Clear();
        }

        private void SendImage(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog()
            {
                Filter = "Bilder|*.png;*.jpg|Alle Dateien|*.*"
            };

            if (dlg.ShowDialog().Value)
            {
                using (var file = File.OpenRead(dlg.FileName))
                    server.SendImage(file);
            }
        }
    }
}
