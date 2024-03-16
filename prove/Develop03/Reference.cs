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

    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {

    }


    // The following below are the methods, using public mofifiers
    public string GetDisplayText()
    {
        return "";
    }

    //Possible getters and setters.

}