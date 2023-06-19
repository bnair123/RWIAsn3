using System;
namespace RWIAsn2;

public class Logarithm : IOperation
{
    public string Operator => "log";
    public int Precedence => 4;

    public double Perform(double operand1, double operand2)
    {
        if (operand1 <= 0)
        {
            throw new ArgumentException("Logarithm base must be positive and not equal to 1.");
        }
        return Math.Log(operand2, operand1);
    }
}



