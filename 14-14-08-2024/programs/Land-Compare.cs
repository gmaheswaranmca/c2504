class Rectangle
{
    public int length;
    public int breadth;
    public Rectangle(int _length, int _breadth)
    {
        length = _length;
        breadth = _breadth;
    }
    public override string ToString() 
    {   
        return $"[Length={length},Breadth={breadth},Area={FindArea()}]"; 
    }
    public int FindArea() 
    { 
        return length * breadth; 
    }
    public bool IsAreaGt(Rectangle other)
    { 
        return FindArea() > other.FindArea();  
    }
    public bool IsAreaEq(Rectangle other)
    { 
        return FindArea() == other.FindArea();  
    }
    /*public bool IsAreaLt(Rectangle second) 
    { 
        Rectangle first = this; 
        return first.FindArea() > second.FindArea(); 
    }*/
}

internal class Program
{
    static void Main(string[] args) 
    {
        Rectangle firstLand = new Rectangle(50, 40);
        Rectangle secondLand = new Rectangle(60, 35);
        if (firstLand.IsAreaGt(secondLand))
        {
            Console.WriteLine($"First Land {firstLand} is greater than Second Land {secondLand}");
        }
        else if (firstLand.IsAreaEq(secondLand))
        {
            Console.WriteLine($"First Land {firstLand} equals Second Land {secondLand}");
        }
        else
        {
            Console.WriteLine($"First Land {firstLand} is less than Second Land {secondLand}");
        }
        Console.ReadKey();
    }
}