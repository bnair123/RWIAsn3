using System.Collections.Generic;
using System;

namespace RWIAsn2;

public interface IRPNCalculator
{
    double Calculate(List<Token> tokens);
    List<string> SupportedOperators { get; }
}

public class RPNCalculator : IRPNCalculator
{
    private List<string> _operators = new List<string> { "+", "-", "*", "/" };

    public double Calculate(List<Token> tokens)
    {
        var stack = new Stack<double>();

        foreach (var token in tokens)
        {
            if (token.Type == TokenType.Number)
            {
                stack.Push(token.NumericValue);
            }
            else
            {
                var a = stack.Pop();
                var b = stack.Pop();

                switch (token.Value)
                {
                    case "+":
                        stack.Push(b + a);
                        break;
                    case "-":
                        stack.Push(b - a);
                        break;
                    case "*":
                        stack.Push(b * a);
                        break;
                    case "/":
                        stack.Push(b / a);
                        break;
                }
            }
        }

        return stack.Pop();
    }


    public List<string> SupportedOperators
    {
        get
        {
            return _operators;
        }
    }
}

