public class Square : Shape
{
    double _side;

    //Constructor
    public Square(double side, string color) : base(color)
    {
        _side = side;
    }


    public override double GetArea()
    {
        double squareArea = Math.Pow(_side, 2);
        return squareArea;
    }
}