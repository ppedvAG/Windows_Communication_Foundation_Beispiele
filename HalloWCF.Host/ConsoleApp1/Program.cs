using ServiceReference1;
using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
         static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var client = new Service1Client(Service1Client.EndpointConfiguration.NetTcpBinding_IService1);
            foreach (var item in await client.GetAllPizzaAsync())
            {
                Console.WriteLine(item.Name);
            } 
            


            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
