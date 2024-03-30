using System;
using System.Collections.Generic;
using System.IO;

public abstract class Goal
{
    //This is the base class for all goal types.
    //Defining member variables (attributes). I used protected so they can be accessed in the derived classes.
    protected string _shortName;
    protected string _description;
    protected int _points;//int because the guideline uses int constructors but outline specifies string type for attribute.

    //Defining the constructor with specific parameters
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    //Defining Methods, some abstract, others with a body, therefore is an abstract class and not Interface class.
    //First, let's start with abstract methods to be overridden by derived classes
    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();

    // Now, a default implementation of GetDetailsString, but still using virtual keyboard so it can be overridden.
    public virtual string GetDetailsString()
    {
        return $"[ ] {_shortName}: {_description}";
    }

}