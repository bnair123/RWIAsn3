using System;

namespace RWIAsn2;
/*
 The TextMenu class is responsible for displaying information to a user. It takes a List of
strings as its constructor argument that contains help for all the operations obtained from the calculator.
The TextMenu class exposes the methods:
• ShowMenu, this method prints the main menu to the user.
• ShowOperations, this method prints the help for all the operations obtained from the calculator.
• ShowHelp, this method prints the extended help for the calculator that explains the RPN syntax
 */
public interface IMenu
{
    void ShowMenu();
    void ShowHelp();
    void ShowOperations();
}

public class Menu : IMenu
{
    public void ShowMenu()
    {
        Console.WriteLine("Enter your expression or: ");
        Console.WriteLine("(h) Show help");
        Console.WriteLine("(o) Show supported operations");
        Console.WriteLine("(q) Quit");
    }

    public void ShowHelp()
    {
        Console.WriteLine("Enter expressions in RPN notation, for instance to calculate: 2 + 3 * 4, enter '2 3 4 * +'");
    }

    public void ShowOperations()
    {
        Console.WriteLine("Supported operations: +, -, *, /");
    }
}



