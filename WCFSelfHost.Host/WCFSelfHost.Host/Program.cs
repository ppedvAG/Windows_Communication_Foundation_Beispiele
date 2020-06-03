using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace WCFSelfHost.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WCF SelfHost");

            //ServiceHost host = new ServiceHost(typeof(AutoService));  //default: per Call
            var myService = new AutoService();
            ServiceHost host = new ServiceHost(myService);  //singelton

            var smb = new ServiceMetadataBehavior() { HttpGetEnabled = true, HttpGetUrl = new Uri("http://localhost:3/mex") };
            host.Description.Behaviors.Add(smb);

            host.AddServiceEndpoint(typeof(IAutoService), new NetTcpBinding(), "net.tcp://localhost:1");
            host.AddServiceEndpoint(typeof(IAutoService), new NetNamedPipeBinding(), "net.pipe://localhost/autos");
            host.AddServiceEndpoint(typeof(IAutoService), new BasicHttpBinding(), "http://localhost:4/");
            host.AddServiceEndpoint(typeof(IAutoService), new WSHttpBinding(), "http://localhost:5/");

            Binding mexBinding = MetadataExchangeBindings.CreateMexTcpBinding();
            host.AddServiceEndpoint(typeof(IMetadataExchange), mexBinding, "net.tcp://localhost:1/mex");

            host.Open();

            Console.WriteLine("Host gestartet");
            Console.ReadLine();
            host.Close();

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }


}
