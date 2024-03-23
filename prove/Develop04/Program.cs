using System;

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
                    Console.WriteLine("Option1");
                    break;

                case 2:
                    Console.WriteLine("Option2");
                    break;
                case 3:
                    Console.WriteLine("Option3");
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