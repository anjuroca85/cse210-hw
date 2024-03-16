using System;

public class Scripture
{
    //Defining attributes with private modifiers to add part of the encapsulation process
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    //The following is the constructor for this class. This instead of using getters and setters:
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        //creating the list, and splitting up the words in the string to create Word objects for each one and put them in the list.
        string[] wordArray = text.Split(" ");
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }

    }

    // The following below are the methods, using public mofifiers
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        for (int i = 0; i < numberToHide; i++)
        {
            int index = random.Next(_words.Count);
            _words[index].Hide();
        }
    }

    public string GetDisplayText()
    {
        string displayText = "";
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";//GetDisplayText() method of the Word class.
        }
        return displayText.Trim();//removes all leading or trailing white-space characters.
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

}