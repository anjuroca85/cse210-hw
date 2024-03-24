using System;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description) //The constructor for the base class.
    {
        _name = name;
        _description = description;
    }

    //Defining methods
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} activity.\n");
        Console.WriteLine(_description);

    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\n\nWell done!!");
        ShowSpinner(5);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name} Activity.");
        ShowSpinner(5);

    }

    public void ShowSpinner(int seconds)
    {
        // for (int i = 5; i > 0; i--)
        // {
        //     Console.Write("/");

        //     Thread.Sleep(500);
        //     Console.Write("\b \b"); // Erase the / character

        //     Console.Write("-"); // Replace it with the - character

        //     Thread.Sleep(500);
        //     Console.Write("\b \b"); // Erase the - character

        //     Console.Write("\\");

        //     Thread.Sleep(500);
        //     Console.Write("\b \b"); // Erase the \ character

        //     Console.Write("|"); // Replace it with the - character

        //     Thread.Sleep(500);
        //     Console.Write("\b \b"); // Erase the | character
        // }

        List<string> animationSpinner = new List<string>();
        animationSpinner.Add("/");
        animationSpinner.Add("-");
        animationSpinner.Add("\\");
        animationSpinner.Add("|");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            string spinner = animationSpinner[i];
            Console.Write(spinner);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            i++;

            if (i >= animationSpinner.Count)
            {
                i = 0;
            }

        }



    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);

            Thread.Sleep(1000);
            Console.Write("\b \b"); // Erase the i character by moving one left and then a space and then left arrow again.


        }


    }

}