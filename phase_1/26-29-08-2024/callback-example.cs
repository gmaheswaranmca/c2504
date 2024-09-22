public delegate double DCalc(double a, double b);
public delegate void DOnAfterSubtract();
public class Calculator
{
    
    public double Subtract(double x, double y, DOnAfterSubtract OnAfterSubtract = null)
    //OnAfterSubtract is the callback function
    {
        double d = x - y;
        if (OnAfterSubtract != null)
        {
            OnAfterSubtract();
        }

        return d;
    }
}

internal class Programs
{

    static void Main()
    {
        Calculator calc1 = new Calculator();
        double d1 = calc1.Subtract(20, 15, OnAfterSubtract1);
        Console.WriteLine($"20-15={d1}");//5

        Calculator calc2 = new Calculator();
        double d2 = calc2.Subtract(20, 3, OnAfterSubtract2);
        Console.WriteLine($"20-3={d2}");//17

        Calculator calc3 = new Calculator();
        double d3 = calc3.Subtract(15, 3);
        Console.WriteLine($"15-3={d3}");//12
    }
    static void OnAfterSubtract1()
    {
        Console.WriteLine("20, 15 Subtraction completed.");
    }
    static void OnAfterSubtract2()
    {
        Console.WriteLine("20, 3 Subtraction completed.");
    }
}