using System;

public class Word
{
    //Defining attributes with private modifiers to add part of the encapsulation process
    private string _text;
    private bool _isHidden;

    //The following is the constructor for this class. This instead of using getters and setters:
    public Word(string text)
    {

    }

    // The following below are the methods, using public mofifiers
    public void Hide()
    {

    }

    public void Show()
    {

    }

    public bool IsHidden()
    {
        return true;
    }

    public string GetDisplayText()
    {
        return "";
    }

}