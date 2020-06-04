using System;
using System.Collections.Generic;
using System.Linq;
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
            host.AddServiceEndpoint(typeof(IServer), tcp, "net.tcp://localhost:1");

            var wsDual = new WSDualHttpBinding();
            host.AddServiceEndpoint(typeof(IServer), wsDual, "http://localhost:2");



            host.Open();
            Console.WriteLine("Server gestartet");
            Console.ReadLine();
            host.Close();

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
