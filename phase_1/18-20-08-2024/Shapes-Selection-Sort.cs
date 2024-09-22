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

    public abstract void Read();
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

    public override void Read()
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
    public override void Read()
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
    static void SelectionSort(Shape[] ar)//##
    {
        int N = ar.Length;
        for (int selectedIndex = 0; selectedIndex < (N - 1); selectedIndex++) //selection logic | for first N-1 elements
        {
            int minIndex = selectedIndex;
            for (int nextIndex = selectedIndex + 1; nextIndex < N; nextIndex++)//seeking min element in next elements
            {
                if ( ar[nextIndex].Lt(ar[minIndex]))//##
                {
                    minIndex = nextIndex;
                }
            }
            if (minIndex != selectedIndex) //swap min element and selected element
            {
                Shape temp = ar[minIndex];//##//swap logic, move to function
                ar[minIndex] = ar[selectedIndex];
                ar[selectedIndex] = temp;
            }
        }
    }
    static void ReadShapes(Shape[] shapes)
    {
        for (int I = 0; I < shapes.Length; I++)
        {
            Console.Write("Shape Type(1-Rectangle, 2-Circle):");
            ShapeType shapeType = (ShapeType)int.Parse(Console.ReadLine());
            switch (shapeType)
            {
                case ShapeType.Rectange:
                    shapes[I] = new Rectangle();
                    break;
                case ShapeType.Circle:
                    shapes[I] = new Circle();
                    break;
            }
            shapes[I].Read();
        }
    }
    static void PrintShapes(Shape[] shapes)
    {
        foreach (Shape shape in shapes)
        {
            Console.Write($"{shape} ");
        }
    }
    static void ProcessShapes()
    {
        Console.Write("Number of shapes:");
        int N = int.Parse(Console.ReadLine());
        Shape[] shapes = new Shape[N];

        ReadShapes(shapes);
        Console.WriteLine("Before sorting:");
        PrintShapes(shapes);
        //Sorting
        SelectionSort(shapes);
        
        Console.WriteLine("After sorting:");
        PrintShapes(shapes);
    }


    static void Main(string[] args)
    {
        ProcessShapes();
    }
}