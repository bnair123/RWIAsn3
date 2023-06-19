using System;
namespace RWIAsn2;

public interface IConstant
{
    string Key { get; }
    double Value { get; }
}

public class Constant : IConstant
{
    public string Key { get; private set; }
    public double Value { get; private set; }

    public Constant(string key, double value)
    {
        Key = key;
        Value = value;
    }
}



