using System;
using System.Globalization;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Joiurnal Program!");
        int number;

        Journal myJournal = new Journal(); // Create a single instance of Journal to be used in diff cases.

        do
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            Console.Write("What would you like to do? ");
            string usrInput = Console.ReadLine();
            number = int.Parse(usrInput);

            switch (number)
            {
                case 1:
                    PromptGenerator prompt = new PromptGenerator();
                    Entry promptEntry = new Entry();
                    //Journal addEnt = new Journal();

                    string userPrompt = prompt.GetRandomPrompt();
                    Console.WriteLine(userPrompt);
                    promptEntry._promptText = userPrompt;
                    Console.Write("> ");

                    string userAnswer = Console.ReadLine();
                    promptEntry._entryText = userAnswer;

                    myJournal.AddEntry(promptEntry);
                    break;

                case 2:
                    myJournal.DisplayAll();
                    break;

                case 3:
                    Console.WriteLine("What is the filename?");
                    string loadFileName = Console.ReadLine();
                    myJournal.LoadFromFile(loadFileName);
                    break;

                case 4:
                    Console.WriteLine("What is the filename?");
                    string saveFileName = Console.ReadLine();
                    myJournal.SaveToFile(saveFileName);
                    break;

                case 5:
                    break;

                default:
                    Console.WriteLine("Please enter only a number from 1 to 5!");
                    break;

            }
        } while (number != 5);

    }
}