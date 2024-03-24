using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity(string name, string description) : base(name, description)
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

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {

            string prompt = GetRandomPrompt();
            Console.WriteLine("\nConsider the following prompt:");
            Console.WriteLine($"--- {prompt} ---");


            Console.WriteLine("\nWhen you have something in mind, press Enter to continue.");
            Console.ReadLine();

            Console.WriteLine("\nNow ponder on each of the following questions as they related to this experience.");
            Console.Write("You may begin in: ");
            ShowCountDown(3);
            string question = GetRandomQuestion();
            Console.Write($"\n> {question}");
            ShowSpinner(5);

            // Remove the selected question to avoid repetition
            _questions.Remove(question);

            string question2 = GetRandomQuestion();
            Console.Write($"\n> {question2}");
            ShowSpinner(5);

        }

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }

    public string GetRandomQuestion()
    {
        Random random = new Random();
        return _questions[random.Next(_questions.Count)];
    }

    public void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"\nPrompt: {prompt}");
    }

    public void DisplayQuestions()
    {
        foreach (var question in _questions)
        {
            Console.WriteLine($"Question: {question}");
        }
    }
}