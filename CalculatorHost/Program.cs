using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
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
            
            // Message
            wsHttpBinding.Security.Mode = SecurityMode.Message;
            // windows auth
            //wsHttpBinding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
            // username
            //wsHttpBinding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
            // certificate
            wsHttpBinding.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;

            var contract = typeof(ICalculator);
            var service = typeof(CalculatorService);

            var uri = new Uri("http://localhost:8036/SecSamples/");
            
            var serviceHost = new ServiceHost(service,uri);
            serviceHost.AddServiceEndpoint(contract, wsHttpBinding, "secureCalc");
            //username and certificate
            serviceHost.Credentials.ServiceCertificate.SetCertificate(
                StoreLocation.CurrentUser,
                StoreName.My,
                X509FindType.FindBySubjectName,
                "CalculatorService"
                );
            //certificate
            serviceHost.Credentials.ClientCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.ChainTrust;
            serviceHost.Credentials.ClientCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;
            serviceHost.Credentials.ClientCertificate.SetCertificate(
                StoreLocation.CurrentUser,
                StoreName.My,
                X509FindType.FindBySubjectName,
                "WCFUser");
                
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
