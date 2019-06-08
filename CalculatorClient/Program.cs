using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;
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
            //windows auth
            //wsHttpBinding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
            //var endPoint = new EndpointAddress("http://localhost:8036/SecSamples/secureCalc");
            
            // username
//            wsHttpBinding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
//            var endPoint = new EndpointAddress(new Uri("http://localhost:8036/SecSamples/secureCalc"), EndpointIdentity.CreateDnsIdentity("CalculatorService"));
            System.Net.ServicePointManager.ServerCertificateValidationCallback =
                delegate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; };
            
            // certificate
            wsHttpBinding.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;
            var endPoint = new EndpointAddress(new Uri("http://localhost:8036/SecSamples/secureCalc"), EndpointIdentity.CreateDnsIdentity("WCFServer"));
            
            var channel = new CalculatorChannel(wsHttpBinding,endPoint);
            // username    
//            channel.ClientCredentials.UserName.UserName = GetUserName();
//            channel.ClientCredentials.UserName.Password = GetPassword();

            
            channel.ClientCredentials.ClientCertificate.SetCertificate(
                StoreLocation.LocalMachine,
                StoreName.My,
                X509FindType.FindBySubjectName,
                "WCFClient"
                );
            channel.ClientCredentials.ServiceCertificate.SetDefaultCertificate(StoreLocation.LocalMachine,StoreName.My,X509FindType.FindBySubjectName,"WCFServer");
            channel.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
            channel.ClientCredentials.ServiceCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;
            
            channel.Open();

            var result = channel.Add(10.00d, 12.99d);
            Console.WriteLine($"Add result: {result:###.000}");

            channel.Close();

            Console.WriteLine("Press ENTER for exit...");
            Console.ReadLine();

        }

        private static string GetPassword()
        {
            Console.WriteLine("Please, enter the password:");
            return Console.ReadLine();
        }

        private static string GetUserName()
        {
            Console.WriteLine("Please, enter the username:");
            return Console.ReadLine();
        }
    }
}
