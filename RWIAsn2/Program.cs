using System;
using System.Reflection.Metadata;

namespace RWIAsn2;
public class Program
{
    public static void Main(string[] args)
    {
        var calculator = new RPNCalculator();
        calculator.Add(new Addition());
        calculator.Add(new Subtraction());
        calculator.Add(new Multiplication());
        calculator.Add(new Division());
        calculator.Add(new Logarithm());
        calculator.Add(new Constant("pi", "pi", "Constant pi", Math.PI));
        calculator.Add(new Constant("e", "e", "Constant e", Math.E));
        var parser = new Parser(calculator.SupportedOperators);
        var menu = new Menu();
        var controller = new Controller(calculator, parser, menu);
        controller.Run();
    }
}

