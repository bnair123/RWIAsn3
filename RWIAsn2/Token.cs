using System;

namespace RWIAsn2;
/*
 Token This class represents a token in the RPN notation. A token can be an operator or a number.
A TokenType enum is used to distinguish between the two. The constructor of the class takes a string
(e.g. “3” or “sqrt”), and the TokenType as arguments. If the TokenType is number, the string is parsed to
a double value in the constructor. This value can be later retrieved using the NumericValue property.
The original string is stored in the Value property.
 */
public enum TokenType
{
    Number,
    Operator
}

public class Token
{
    public TokenType Type { get; set; }
    public string Value { get; set; }
    public double NumericValue { get; set; }

    public Token(TokenType type, string value, double numericValue = 0)
    {
        Type = type;
        Value = value;
        if (type == TokenType.Number)
        {
            NumericValue = numericValue;
        }
    }


}

