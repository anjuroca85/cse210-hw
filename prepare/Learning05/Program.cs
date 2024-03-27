using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        Square squareCal = new Square(3, "blue");
        Rectangle rectangleCal = new Rectangle(5, 3, "red");
        Circle circleCal = new Circle(1, "green");

        // string colorSquare = squareCal.GetColor();
        // double areaSquare = squareCal.GetArea();

        // string colorRectangle = rectangleCal.GetColor();
        // double areaRectangle = rectangleCal.GetArea();

        // string colorCircle = circleCal.GetColor();
        // double areaCircle = circleCal.GetArea();

        List<Shape> shapes = new List<Shape>();
        shapes.Add(squareCal);
        shapes.Add(rectangleCal);
        shapes.Add(circleCal);

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();
            Console.WriteLine($"The square color is {color} and the square area is {area:N2}");

        }

        // Console.WriteLine($"The square color is {colorSquare} and the square area is {areaSquare}");
        // Console.WriteLine($"The rectangle color is {colorRectangle} and the rectangle area is {areaRectangle}");
        // Console.WriteLine($"The circle color is {colorCircle} and the circle area is {areaCircle:N2}");

    }
}