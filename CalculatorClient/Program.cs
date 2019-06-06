using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using CalculatorClient.Channels;

namespace CalculatorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var wsHttpBinding = new WSHttpBinding(SecurityMode.Message);
            wsHttpBinding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;

            var endPoint = new EndpointAddress("http://localhost:8036/SecSamples/secureCalc");
            var channel = new CalculatorChannel(wsHttpBinding,endPoint);
            channel.Open();

            var result = channel.Add(10.00d, 12.99d);
            Console.WriteLine($"Add result: {result:###.000}");

            channel.Close();

            Console.WriteLine("Press ENTER for exit...");
            Console.ReadLine();

        }
    }
}
