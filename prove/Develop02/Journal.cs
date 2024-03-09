using System;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public Journal() //constructor
    { }

    //methods:
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }

    }

    public void SaveToFile(string file)
    {
        Console.WriteLine("Saving to File...");
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry e in _entries)
            {
                outputFile.WriteLine($"Date: {e._date} - Prompt: {e._promptText}");
                outputFile.WriteLine($"{e._entryText}\n");
            }
        }

    }

    public void LoadFromFile(string file)
    {
        try
        {
            string[] linesRead = File.ReadAllLines(file);

            // Clear existing entries before loading new ones
            _entries.Clear();

            for (int i = 0; i < linesRead.Length; i += 3)//This because it is three inputs per entry
            {
                string dateLine = linesRead[i];
                string promptLine = linesRead[i + 1];
                string entryTextLine = linesRead[i + 2];

                Entry loadedEntry = new Entry
                {
                    // From https://learn.microsoft.com/es-es/dotnet/api/system.string.substring?view=net-8.0
                    // I used the string.substring method
                    _date = dateLine.Substring(dateLine.IndexOf(":") + 1).Trim(),
                    _promptText = promptLine.Substring(promptLine.IndexOf(":") + 1).Trim(),
                    _entryText = entryTextLine.Trim()
                };

                _entries.Add(loadedEntry);
            }

            Console.WriteLine("Journal loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }
}

