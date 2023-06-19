using System;
namespace RWIAsn2;

public class Division : IOperation
{
    public string Operator => "/";
    public int Precedence => 3;

    public double Perform(double operand1, double operand2)
    {
        if (operand2 == 0)
        {
            throw new DivideByZeroException();
        }
        return operand1 / operand2;
    }
}


