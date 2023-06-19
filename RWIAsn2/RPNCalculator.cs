using System.Collections.Generic;
using System;

namespace RWIAsn2;

public interface IRPNCalculator
{
    double Calculate(List<Token> tokens);
    List<string> SupportedOperators { get; }
}

public class RPNCalculator : IRPNCalculator, ICollection<IOperation>
{
    private List<IOperation> _operations;

    public RPNCalculator()
    {
        _operations = new List<IOperation>();
    }

    

    public void Add(IOperation item)
    {
        _operations.Add(item);
    }

    public void Clear()
    {
        _operations.Clear();
    }

    public bool Contains(IOperation item)
    {
        return _operations.Contains(item);
    }

    public void CopyTo(IOperation[] array, int arrayIndex)
    {
        _operations.CopyTo(array, arrayIndex);
    }

    public bool Remove(IOperation item)
    {
        return _operations.Remove(item);
    }

    public int Count
    {
        get { return _operations.Count; }
    }

    public bool IsReadOnly
    {
        get { return false; }
    }

    public IEnumerator<IOperation> GetEnumerator()
    {
        return _operations.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return _operations.GetEnumerator();
    }

    public List<string> SupportedOperators => _operations.Select(op => op.Operator).ToList();
    public IList<IConstant> Constants { get; private set; }


    public double Calculate(List<Token> tokens)
    {
        var stack = new Stack<double>();

        foreach (var token in tokens)
        {
            if (token.Type == TokenType.Number)
            {
                stack.Push(token.NumericValue);
            }
            else // Operator
            {
                var operation = _operations.Find(op => op.Operator == token.Value);
                if (operation == null)
                {
                    throw new InvalidOperationException($"Unsupported operator: {token.Value}");
                }

                if (stack.Count < 2)
                {
                    throw new InvalidOperationException("Invalid expression");
                }

                var operand2 = stack.Pop();
                var operand1 = stack.Pop();
                var result = operation.Perform(operand1, operand2);

                stack.Push(result);
            }
        }

        if (stack.Count != 1)
        {
            throw new InvalidOperationException("Invalid expression");
        }

        return stack.Pop();
    }

}


