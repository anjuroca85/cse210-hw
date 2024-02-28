using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What's your grade percentage? ");
        int gradePercentage = int.Parse(Console.ReadLine());

        string letter;
        string sign;

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        if (((gradePercentage % 10) >= 7) && !(letter == "A" || letter == "F"))
        {
            sign = "+";
        }

        else if (((gradePercentage % 10) < 3) && !(letter == "F"))
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        Console.WriteLine($"You got {letter}{sign}.");


        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed.");
        }
        else
        {
            Console.WriteLine("You did not pass. Please try again next time!");
        }
    }
}