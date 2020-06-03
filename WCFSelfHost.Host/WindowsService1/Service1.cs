using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WCFSelfHost.Host;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        ServiceHost host = null;

        protected override void OnStart(string[] args)
        {
            //ServiceHost host = new ServiceHost(typeof(AutoService));  //default: per Call
            var myService = new AutoService();
             host = new ServiceHost(myService);  //singelton

            var smb = new ServiceMetadataBehavior() { HttpGetEnabled = true, HttpGetUrl = new Uri("http://localhost:3/mex") };
            host.Description.Behaviors.Add(smb);

            host.AddServiceEndpoint(typeof(IAutoService), new NetTcpBinding(), "net.tcp://localhost:1");
            host.AddServiceEndpoint(typeof(IAutoService), new NetNamedPipeBinding(), "net.pipe://localhost/autos");
            host.AddServiceEndpoint(typeof(IAutoService), new BasicHttpBinding(), "http://localhost:4/");
            host.AddServiceEndpoint(typeof(IAutoService), new WSHttpBinding(), "http://localhost:5/");

            Binding mexBinding = MetadataExchangeBindings.CreateMexTcpBinding();
            host.AddServiceEndpoint(typeof(IMetadataExchange), mexBinding, "net.tcp://localhost:1/mex");

            host.Open();

            
        }

        protected override void OnStop()
        {
            host?.Close();
        }
    }
}
