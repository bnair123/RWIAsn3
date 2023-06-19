using System;
namespace RWIAsn2;

public class Subtraction : IOperation
{
    public string Operator => "-";
    public int Precedence => 2;

    public double Perform(double operand1, double operand2)
    {
        return operand1 - operand2;
    }
}



