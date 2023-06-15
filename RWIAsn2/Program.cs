using System;
namespace RWIAsn2;
public class Program
{
    public static void Main(string[] args)
    {
        var calculator = new RPNCalculator();
        var parser = new Parser(calculator.SupportedOperators);
        var menu = new Menu();
        var controller = new Controller(calculator, parser, menu);
        controller.Run();
    }
}

