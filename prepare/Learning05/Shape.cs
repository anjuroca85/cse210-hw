using System.Drawing;

public abstract class Shape
{
    string _color; //Setting up a member variable that will be in all classes.

    public string GetColor() //getter
    {
        return _color;
    }

    public void SetColor(string color) //setter
    {
        _color = color;
    }

    //Setting up the constructor

    public Shape(string color)
    {
        _color = color;
    }

    // public virtual double GetArea()
    // {
    //     return 0;
    // }

    public abstract double GetArea();

}