class Rectangle
{
    public int Length { get; set; }
    public int Breadth { get; set; }
    public Rectangle(int length, int breadth)
    {
        this.Length = length;
        this.Breadth = breadth;
    }
    public override string ToString() 
    {   
        return $"[Length={Length},Breadth={Breadth},Area={FindArea()}]"; 
    }
    public int FindArea() 
    { 
        return this.Length * this.Breadth; 
    }
    public bool IsAreaGt(Rectangle other)
    { 
        return this.FindArea() > other.FindArea();  
    }
    public bool IsAreaEq(Rectangle other)
    { 
        return this.FindArea() == other.FindArea();  
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