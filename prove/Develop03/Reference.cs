using System;

public class Reference
{
    //Defining attributes with private modifiers to add part of the encapsulation process
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    //The following are the two constructors for this class. This instead of using getters and setters:
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;

    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }


    // The following below are the methods, using public mofifiers
    public string GetDisplayText()
    {
        string reference;

        //The following is a check whether we are using one verse or many.

        if (_endVerse != 0)
        {
            reference = $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
        else
        {
            reference = $"{_book} {_chapter}:{_verse}";
        }

        return reference;
    }

    //Possible getters and setters. Not used :)

}