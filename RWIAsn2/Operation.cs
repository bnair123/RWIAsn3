using System;
namespace RWIAsn2;

public abstract class Operation : IOperation
{
    public string Name { get; }
    public string Operator { get; }
    public string Description { get; }

    protected Operation(string name, string oper, string description)
    {
        Name = name;
        Operator = oper;
        Description = description;
    }
}
