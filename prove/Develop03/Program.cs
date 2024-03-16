using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        //string textScripture = "Trust in the Lord with all thine heart; and lean not unto thine own understanding.\nIn all thy ways acknowledge him, and he shall direct thy paths.";
        string textScripture2 = "And the light shineth in darkness; and the darkness comprehended it not.";

        //Reference entry1 = new Reference("Proverbs", 3, 5, 6);
        //Console.WriteLine(entry1.GetDisplayText() + $" {textScripture}\n");
        Reference entry2 = new Reference("John", 1, 5);
        Console.WriteLine(entry2.GetDisplayText() + $" {textScripture2}\n");

        //Scripture scripture = new Scripture(entry1, textScripture);
        Scripture scripture = new Scripture(entry2, textScripture2);


        Console.WriteLine("Press enter to continue or 'quit' to finish:");
        while (true)
        {
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input)) // If user just presses Enter
            {
                Console.WriteLine("Continuing...");
                // Hide some random words. I selected 3 for this activity
                scripture.HideRandomWords(3);
                // Clear the console screen and then
                // Display the scripture
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());

                // Check if all words are hidden
                if (scripture.IsCompletelyHidden())
                {
                    Console.WriteLine("All words are hidden. Program ending...");
                    break;
                }

            }
            else if (input.Equals("quit", StringComparison.OrdinalIgnoreCase)) // If user types "quit"
            {
                Console.WriteLine("Quitting...");
                break;
            }
            else
            {
                Console.WriteLine("Please either press the enter keyword or type 'quit'");
            }
        }

        //while (input != "quit" && Console.ReadKey(true).Key == ConsoleKey.Enter);

    }
}