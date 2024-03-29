﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double a, double b);

        [OperationContract]
        double Sub(double a, double b);

        [OperationContract]
        double Mul(double a, double b);

        [OperationContract]
        double Div(double a, double b);
    }
}
