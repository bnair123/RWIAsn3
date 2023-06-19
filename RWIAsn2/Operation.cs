using System;
namespace RWIAsn2;

public abstract class Operation : IOperation
{
    public string Name { get; }
    public string Operator { get; }
    public string Description { get; }

    // Declare Precedence and Perform as abstract
    public abstract int Precedence { get; }
    public abstract double Perform(double operand1, double operand2);

    protected Operation(string name, string oper, string description)
    {
        Name = name;
        Operator = oper;
        Description = description;
    }
}

