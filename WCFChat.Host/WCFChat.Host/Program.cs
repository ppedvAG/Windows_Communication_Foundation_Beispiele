using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFChat.Contracts;

namespace WCFChat.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** WCF CHAT HOST ***");

            var host = new ServiceHost(typeof(ChatServer));

            var tcp = new NetTcpBinding();
            tcp.MaxReceivedMessageSize = int.MaxValue;
            tcp.Security.Mode = SecurityMode.TransportWithMessageCredential;
            tcp.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;


            host.AddServiceEndpoint(typeof(IServer), tcp, "net.tcp://localhost:1");


            var wsDual = new WSDualHttpBinding();
            wsDual.Security.Mode = WSDualHttpSecurityMode.Message;
            host.AddServiceEndpoint(typeof(IServer), wsDual, "http://localhost:2");
            //     host.Credentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.Root,
            //         X509FindType.FindByThumbprint, "14295bd222c188a881dbe88585333dd564a5b57a");

            host.Credentials.ServiceCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.Root,
                X509FindType.FindByThumbprint, "14295bd222c188a881dbe88585333dd564a5b57a");

            host.Credentials.ClientCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;

            host.Open();
            Console.WriteLine("Server gestartet");
            Console.ReadLine();
            host.Close();

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
