using System;

namespace RWIAsn2;
/*
 Controller It’s the class that serves as a bridge between the user and the calculator. It contains
references to both the Parser and Calculator objects as well as the TextMenu class. Those are passed
as arguments to the Controller’s constructor. It uses Parser for input validation and splitting it into
tokens and Calculator for evaluating lexed expressions. The communication with a user is done through
the TextMenu class. The Run method of the Controller class contains an infinite loop that accepts user
input, interprets it and reacts accordingly by calling the methods of its subobjects.
 */
public interface IController
{
    void Run();
}

public class Controller : IController
{
    private IRPNCalculator _calculator;
    private IParser _parser;
    private IMenu _menu;

    public Controller(IRPNCalculator calculator, IParser parser, IMenu menu)
    {
        _calculator = calculator;
        _parser = parser;
        _menu = menu;
    }

    public void Run()
    {
        _menu.ShowMenu();

        string input = string.Empty;

        do
        {
            Console.Write("> ");
            input = Console.ReadLine() ?? "quit";

            switch (input)
            {
                case "q":
                    break;
                case "h":
                    _menu.ShowHelp();
                    break;
                case "o":
                    _menu.ShowOperations();
                    break;
                default:
                    // An RPN expression is expected here
                    try
                    {
                        var split = _parser.Tokenize(input);
                        if (split.Count != 0)
                        {
                            var tokens = _parser.Lex(split);
                            var result = _calculator.Calculate((List<Token>)tokens);
                            Console.WriteLine($"\n {result}\n");
                        }
                    }
                    // If the input is not valid, an exception is thrown by calculator or parser
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
            }

        } while (!input.ToLower().Equals("q"));

        Console.WriteLine("\n Calculator is quitting. Bye!");
    }
}

