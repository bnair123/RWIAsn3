using System;
namespace RWIAsn2;

public interface IUnaryOperation : IOperation
{
    double Calculate(double operand);
}

