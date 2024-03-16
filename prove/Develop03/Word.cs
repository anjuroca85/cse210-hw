using System;

public class Word
{
    //Defining attributes with private modifiers to add part of the encapsulation process
    private string _text;
    private bool _isHidden;

    //The following is the constructor for this class. This instead of using getters and setters:
    public Word(string text)
    {
        _text = text;
        _isHidden = false; // Words are visible by default as per the help in the activity.
    }

    // The following below are the methods, using public mofifiers
    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;// based on the previous two methods, this one will evaluate to one of those.
    }

    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text; //Ternary conditional operator to print the words either as they are or hidden.
    }

}