using System.ServiceModel;
using CalculatorLibrary;

namespace CalculatorClient.Interfaces
{
    public interface ICalculatorChannel : ICalculator, IClientChannel
    {
        
    }
}