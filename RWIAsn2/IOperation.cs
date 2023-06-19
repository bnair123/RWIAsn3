using System;
namespace RWIAsn2;

public interface IOperation
{
    string Operator { get; }
    int Precedence { get; }
    double Perform(double operand1, double operand2);
}


