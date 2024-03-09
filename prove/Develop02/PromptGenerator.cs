using System;
using System.IO;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>();
    public Random _rndIndex = new Random();

    public PromptGenerator() // constructor
    {
    }

    //Method:
    public string GetRandomPrompt()
    {
        string filename = "myFile.txt";
        string[] lines = File.ReadAllLines(filename);

        _prompts.Clear(); // Clear the existing prompts

        foreach (string line in lines)
        {
            _prompts.Add(line);
        }

        if (_prompts.Count > 0)
        {
            int randomIndex = _rndIndex.Next(_prompts.Count);
            return _prompts[randomIndex];
        }
        else
        {
            return "No prompts available";
        }
    }
}