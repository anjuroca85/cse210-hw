public class Circle : Shape
{
    double _radius;

    public Circle(double radius, string color) : base(color)
    {
        _radius = radius;
    }


    public override double GetArea()
    {
        double circleArea = Math.PI * Math.Pow(_radius, 2);
        return circleArea;
    }
}