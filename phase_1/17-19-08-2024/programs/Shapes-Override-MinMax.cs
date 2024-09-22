public abstract class Shape
{
    // Abstract method to calculate the area
    public abstract double CalculateArea();
    public bool Gt(Shape other)
    {
        return this.CalculateArea() > other.CalculateArea();
    }
    public bool Eq(Shape other)
    {
        return this.CalculateArea() == other.CalculateArea();
    }
    public bool Lt(Shape other)
    {
        return (!Gt(other)) && (!Eq(other));
    }
}
public class Rectangle : Shape
{
    // Properties for Length and Width
    public double Length { get; set; }
    public double Width { get; set; }

    // Constructor to initialize Length and Width
    public Rectangle(double length, double width)
    {
        Length = length;
        Width = width;
    }
    public Rectangle()
    {
        Length = 0;
        Width = 0;
    }

    // Override the CalculateArea method to return the area of the rectangle
    public override double CalculateArea()
    {
        return Length * Width;
    }

    public void Read()
    {
        Console.Write("Length:");
        Length = int.Parse(Console.ReadLine());
        Console.Write("Width:");
        Width = int.Parse(Console.ReadLine());
    }
    public override string ToString()
    {
        return $"[Rectangle, Length = {Length}, Width = {Width}, Area = {CalculateArea()}]";
    }
}

public class Circle : Shape
{
    // Property for Radius
    public double Radius { get; set; }

    // Constructor to initialize Radius
    public Circle(double radius)
    {
        Radius = radius;
    }
    public Circle()
    {
        Radius = 0;
    }

    // Override the CalculateArea method to return the area of the circle
    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
    public void Read()
    {
        Console.Write("Radius:");
        Radius = int.Parse(Console.ReadLine());
    }
    public override string ToString()
    {
        return $"[Circle, Radius = {Radius}, Area = {CalculateArea()}]";
    }
}


enum ShapeType
{
    Rectange = 1,
    Circle = 2
}


internal class Programs
{
    static void ReadShapes()
    {
        ShapeType shapeType;
        double minArea = double.MaxValue;
        double maxArea = double.MinValue;
        Shape minAreaShape = null;
        Shape maxAreaShape = null;

        string readOption = "y";
        do
        {
            Console.Write("Shape Type(1-Rectangle, 2-Circle):");
            shapeType = (ShapeType)int.Parse(Console.ReadLine());

            Shape shape = null;
            switch(shapeType)
            {
                case ShapeType.Rectange:
                    Rectangle rectangle = new Rectangle();
                    rectangle.Read();
                    shape = rectangle;
                    break;
                case ShapeType.Circle:
                    Circle circle = new Circle();
                    circle.Read();
                    shape = circle;
                    break;
            }
            if(shape.CalculateArea() < minArea)
            {
                minArea = shape.CalculateArea();
                minAreaShape = shape;
            }
            if (shape.CalculateArea() > maxArea)
            {
                maxArea = shape.CalculateArea();
                maxAreaShape = shape;
            }

            Console.Write("Are you read one more shape(y/n)?");
            readOption = Console.ReadLine();

        } while (readOption.ToLower() == "y");

        Console.WriteLine($"Min area shape is {minAreaShape}");
        Console.WriteLine($"Max area shape is {maxAreaShape}");
    }
    static void Main(string[] args)
    {
        ReadShapes();

    }
}