using System;

public class Scripture
{
    //Defining attributes with private modifiers to add part of the encapsulation process
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    //The following is the constructor for this class. This instead of using getters and setters:
    public Scripture(Reference reference, string text)
    {

    }

    // The following below are the methods, using public mofifiers
    public void HideRandomWords(int numberToHide)
    {

    }

    public string GetDisplayText()
    {
        return "";
    }

    public bool IsCompletelyHidden()
    {
        return true;
    }

}