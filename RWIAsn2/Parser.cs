using System;
using System.Collections.Generic;
using System.Linq;

namespace RWIAsn2
{
    public interface IParser
    {
        IList<string> SupportedOperators { get; }
        IList<string> Tokenize(string expression);
        IList<Token> Lex(IList<string> tokens);
    }

    public class Parser : IParser
    {
        public IList<string> SupportedOperators { get; private set; }

        public Parser(IList<string> supportedOperators)
        {
            SupportedOperators = supportedOperators ?? new List<string>();
        }

        public IList<string> Tokenize(string expression)
        {
            return expression.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public IList<Token> Lex(IList<string> tokens)
        {
            IList<Token> lexedTokens = new List<Token>();

            foreach (var token in tokens)
            {
                if (SupportedOperators.Contains(token))
                {
                    lexedTokens.Add(new Token(TokenType.Operator, token));
                }
                else if (double.TryParse(token, out var numericValue))
                {
                    lexedTokens.Add(new Token(TokenType.Number, token, numericValue));
                }
                else
                {
                    throw new FormatException($"Invalid token: {token}");
                }
            }

            return lexedTokens;
        }

    }

}