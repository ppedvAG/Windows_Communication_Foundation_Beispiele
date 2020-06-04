using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
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
            userNameTb.Text = "Fred";

            SetUi(false);
        }

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
            var tcp = new NetTcpBinding();
            var cf = new DuplexChannelFactory<IServer>(this, tcp, new EndpointAddress("net.tcp://localhost:1"));
            var server = cf.CreateChannel();
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
            throw new NotImplementedException();
        }

        public void ShowText(string text)
        {
            chatLb.Items.Add(text);
        }

        public void ShowUserlist(IEnumerable<string> users)
        {
            throw new NotImplementedException();
        }

        public void ShowVoice(Stream voice)
        {
            throw new NotImplementedException();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {

        }
    }
}
