using System;

public class Entry
{
    DateTime theCurrentTime = DateTime.Now;

    public string _date;
    public string _promptText;
    public string _entryText;

    public Entry() // Constructor
    {
        _date = theCurrentTime.ToShortDateString(); //I added it here so it can be used later when saving the file too.
    }


    //method:
    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}\n");
    }
}