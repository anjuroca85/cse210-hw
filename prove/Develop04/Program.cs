using System;
using System.Threading; // Importing the System.Threading namespace for Thread.Sleep()

class Program
{
    static void Main(string[] args)
    {
        int choice;
        do
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("\t1. Start breathing activity");
            Console.WriteLine("\t2. Start reflecting activity");
            Console.WriteLine("\t3. Start listing activity");
            Console.WriteLine("\t4. Quit");

            Console.Write("Select a choice from the menu: ");
            string usrInput = Console.ReadLine();
            choice = int.Parse(usrInput);

            switch (choice)
            {
                case 1:
                    string message = "This activity will help you relax by walking you through breathing in and out slowly.\nClear your mind and focus on your breathing.";
                    BreathingActivity breathingActivity = new BreathingActivity("Breathing", message);
                    breathingActivity.Run();
                    break;

                case 2:
                    string reflectingMessage = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
                    ReflectingActivity reflectingActivity = new ReflectingActivity("Reflecting", reflectingMessage);
                    reflectingActivity.Run();
                    break;

                case 3:
                    string listingMessage = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
                    ListingActivity listingActivity = new ListingActivity("Listing", listingMessage);
                    listingActivity.Run();
                    break;

                case 4:
                    break;

                default:
                    Console.WriteLine("Please enter only a number from 1 to 4!");
                    break;

            }

        } while (choice != 4);

    }
}