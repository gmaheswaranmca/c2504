class Circle
{
    public int Radius { set; get; }

    public Circle(int _radius)
    {
        this.Radius = _radius;
    }
    public float FindCircumference()
    {
        return 2 * (float)Math.PI * Radius;
    }
    public bool IsCircumferenceGt(Circle other)
    {
        return this.FindCircumference() > other.FindCircumference();
    }
    public bool IsCircumferenceEq(Circle other)
    {
        return this.FindCircumference() == other.FindCircumference();
    }
    public override string ToString()
    {
        return $"[Radius={this.Radius},Circumference={this.FindCircumference()}]";
    }

}
internal class Program
{
    static void Main(string[] args)
    {
        Circle firstCircle = new Circle(10);
        Circle secondCircle = new Circle(15);
        if (firstCircle.IsCircumferenceGt(secondCircle))
        {
            Console.WriteLine($"first circle {firstCircle} is greater than second circle {secondCircle}");
        }
        else if (firstCircle.IsCircumferenceEq(secondCircle))
        {
            Console.WriteLine($"first circle {firstCircle} is equal to second circle {secondCircle}");
        }
        else
        {
            Console.WriteLine($"first circle {firstCircle} is less than to second circle {secondCircle}");
        }
    }
}