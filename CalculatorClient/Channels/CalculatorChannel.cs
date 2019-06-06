using System.ServiceModel;
using CalculatorLibrary;

namespace CalculatorClient.Channels
{
    public class CalculatorChannel : ClientBase<ICalculator>, ICalculator
    {
        public CalculatorChannel()
        {
            
        }

        public CalculatorChannel(string endpointConfigurationName)
            : base(endpointConfigurationName)
        {

        }

        public CalculatorChannel(string endpointConfigurationName, string remoteAddress)
            :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public CalculatorChannel(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress)
            :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public CalculatorChannel(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress)
            :
            base(binding, remoteAddress)
        {
        }


        public double Add(double a, double b)
        {
            return base.Channel.Add(a, b);
        }

        public double Sub(double a, double b)
        {
            return base.Channel.Sub(a, b);
        }

        public double Mul(double a, double b)
        {
            return base.Channel.Mul(a, b);
        }

        public double Div(double a, double b)
        {
            return base.Channel.Div(a, b);
        }
    }
}