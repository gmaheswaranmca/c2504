public sealed class Mathematics //we cannot inherit 
{
    private Mathematics() // we cannot create object outside 
    {
        Console.WriteLine("Inside constructor");
    }
    private static Mathematics _instance;

    public static Mathematics Instance()
    {
        if(_instance == null)
        {
            Console.WriteLine("Creating once...");
            _instance = new Mathematics();
        }
        return _instance;
    }

    public double square(double num)
    {
        return num * num;
    }
}

internal class Programs
{

    static void Main()
    {
        Mathematics mathematics1 = Mathematics.Instance();
        Console.WriteLine(mathematics1.square(5));

        Mathematics mathematics2 = Mathematics.Instance();
        Console.WriteLine(mathematics2.square(5));
    }
    

}