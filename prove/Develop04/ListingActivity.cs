using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    private int _count;

    public ListingActivity(string name, string description) : base(name, description)
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.Write("\nHow long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nGet ready...");
        ShowSpinner(5);
        Console.WriteLine();

        Console.WriteLine("List as many responses you can to the following propmt:");
        GetRandomPrompt();

        //Console.WriteLine("\nWhen you have something in mind, press Enter to continue.");
        //Console.ReadLine();

        Console.Write("\nYou may begin in: ");
        ShowCountDown(5);

        Console.WriteLine("\nBegin listing items:");
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        _count = GetListFromUser(endTime).Count;

        Console.WriteLine($"\nYou listed {_count} items.");

        DisplayEndingMessage();
    }

    public void GetRandomPrompt()
    {
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine($"--- {prompt} ---");
    }


    public List<string> GetListFromUser(DateTime endTime)
    {
        List<string> itemList = new List<string>();
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) // Check for empty input to exit
                break;
            itemList.Add(input);
        }
        return itemList;
    }
}
