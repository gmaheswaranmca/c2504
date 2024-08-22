internal class Programs
{
    public class Complex
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex { Real = c1.Real + c2.Real, Imaginary = c1.Imaginary + c2.Imaginary };
        }
        public override string ToString()
        {
            return $"{this.Real}+i{this.Imaginary}";
        }
    }

    static void Main(string[] args)
    {

        Complex c1 = new Complex { Real = 1, Imaginary = 2 };
        Complex c2 = new Complex { Real = 3, Imaginary = 4 };
        Complex result = c1 + c2;
        Console.WriteLine($"{c1} + {c2} = {result}");
        
    }
}