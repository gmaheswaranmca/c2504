public delegate double DCalc(double a, double b);//1 define delegate
public delegate void DOnAfterSubtract();
public class Calculator
{
    public event DOnAfterSubtract OnAfterSubtract;//2. event is defined // delegate ref variable is the event
    //event is wrapper of the delegate
    public double Subtract(double x, double y)
    //OnAfterSubtract is the callback function
    {
        double d = x - y;
        if (OnAfterSubtract != null)
        {
            OnAfterSubtract();//3. event generated
        }
        
        return d;
    }
}

internal class Programs
{
    
    static void Main()
    {
        Calculator calc1 = new Calculator();
        calc1.OnAfterSubtract += OnAfterSubtract1;//5. Attach the event handler of calc1's OnAfterSubtract
        double d1 = calc1.Subtract(20, 15);
        Console.WriteLine($"20-15={d1}");//5


        Calculator calc2 = new Calculator();
        calc2.OnAfterSubtract += OnAfterSubtract2;//5. Attach the event handler of calc2's OnAfterSubtract
        double d2 = calc2.Subtract(20, 3);
        Console.WriteLine($"20-3={d2}");//17


        Calculator calc3 = new Calculator();
        double d3 = calc3.Subtract(15, 3);
        Console.WriteLine($"15-3={d3}");//12
    }        
    static void OnAfterSubtract1() //4. defining event handler of object calc1's event OnAfterSubtract
    {
        Console.WriteLine("20, 15 Subtraction completed.");
    }
    static void OnAfterSubtract2() //4. defining event handler of object calc2's event OnAfterSubtract
    {
        Console.WriteLine("20, 3 Subtraction completed.");
    }
}