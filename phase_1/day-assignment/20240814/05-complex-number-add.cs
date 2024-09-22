class ComplexNumber
{
    public int Real { get; set; }
    public int Imaginary { get; set; }

    public ComplexNumber(int _real, int _imaginary)
    {
        this.Real = _real;
        this.Imaginary = _imaginary;
    }
    public ComplexNumber Add(ComplexNumber other)
    {
        ComplexNumber sum = new ComplexNumber(0,0);
        sum.Real = this.Real + other.Real;
        sum.Imaginary = this.Imaginary + other.Imaginary;
        return sum;
    }
    public override string ToString()
    {
        return $"[ComplexNumber={Real} + i{Imaginary}]";
    }

}
internal class TestComplexNumber
{
    static void Main(string[] args)
    {
        ComplexNumber firstNo = new ComplexNumber(3, 4);
        ComplexNumber secondNo = new ComplexNumber(5, 3);
        ComplexNumber result = firstNo.Add(secondNo);
        Console.WriteLine($"{firstNo} + {secondNo} = {result}");

    }
}