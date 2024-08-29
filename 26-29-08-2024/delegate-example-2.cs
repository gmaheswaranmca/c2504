public delegate double DCalc(double a, double b);

public class Calculator
{
    public static double Add(double x, double y)
    {
        return x + y;
    }
    
}

internal class Programs
{

    static void Main()
    {
        DCalc rCalc = Calculator.Add;
        Console.WriteLine("sum = {0}", rCalc(10, 20));//30

        
    }
   
}