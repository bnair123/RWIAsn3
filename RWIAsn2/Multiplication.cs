using System;
namespace RWIAsn2;

public class Multiplication : IOperation
{
    public string Operator => "*";
    public int Precedence => 3;

    public double Perform(double operand1, double operand2)
    {
        return operand1 * operand2;
    }
}



