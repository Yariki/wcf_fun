using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using CalculatorLibrary;

namespace CalculatorHost
{
    class Program
    {
        static void Main(string[] args)
        {
            (new Program()).run();
        }

        private void run()
        {
            var wsHttpBinding = new WSHttpBinding();
            wsHttpBinding.Security.Mode = SecurityMode.Message;
            wsHttpBinding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;

            var contract = typeof(ICalculator);
            var service = typeof(CalculatorService);

            var uri = new Uri("http://localhost:8036/SecSamples/");
            
            var serviceHost = new ServiceHost(service,uri);
            serviceHost.AddServiceEndpoint(contract, wsHttpBinding, "secureCalc");

            var metadata = new ServiceMetadataBehavior();
            metadata.HttpGetEnabled = true;
            serviceHost.Description.Behaviors.Add(metadata);

            serviceHost.Open();
            Console.WriteLine("Listening");
            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();

            serviceHost.Close();
        }
    }
}
