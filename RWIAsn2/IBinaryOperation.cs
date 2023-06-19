using System;
namespace RWIAsn2;

public interface IBinaryOperation : IOperation
{
    double Calculate(double operand1, double operand2);
}

