using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("aqua", 5);

        Rectangle rectangle = new Rectangle("yellow", 5, 7);

        Circle circle = new Circle("blue", 7);

        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}. ");
            Console.WriteLine($"Area: {shape.GetArea():F2}. ");
        }
    }   
}