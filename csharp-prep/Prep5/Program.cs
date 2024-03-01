using System;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        return userName;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int favNum = int.Parse(Console.ReadLine());
        return favNum;
    }

    static int SquareNumber()
    {
        double squareNum = Math.Pow(PromptUserNumber(), 2);
        int sqrtNum = (int)squareNum;
        return sqrtNum;
    }

    static void DisplayResult(string name, int number)
    {
        Console.Write($"{name}, the square of your number is {number}");
    }
    static void Main(string[] args)
    {
        DisplayWelcome();
        DisplayResult(PromptUserName(), SquareNumber());
    }
}