using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        //int magicNumber;
        int guess;
        //Console.Write("What's the magic number? ");
        //magicNumber = int.Parse(Console.ReadLine());

        int count = 0;

        string response = "yes";

        while (response == "yes")
        {
            Random rnd = new Random();
            int magicNumber = rnd.Next(1, 101);

            do
            {
                Console.Write("What is your guess from 1 to 100? ");
                guess = int.Parse(Console.ReadLine());

                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                    ++count;
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                    ++count;
                }
                else
                {
                    count++;
                    Console.WriteLine($"You guessed it in {count} times");
                    count = 0;
                    Console.WriteLine("Do you want to play again?");
                    response = Console.ReadLine();
                }
            } while (guess != magicNumber);

        }
    }
}