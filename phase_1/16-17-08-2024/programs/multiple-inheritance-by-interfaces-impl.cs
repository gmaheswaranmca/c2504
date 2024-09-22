public interface IFlyable
{
    void Fly();
}
public interface ISwimmable
{
    void Swim();
}
public class Duck : IFlyable, ISwimmable
{
    public void Fly()
    {
        Console.WriteLine("Duck is Flying...");
    }

    public void Swim()
    {
        Console.WriteLine("Duck is Swimming...");
    }
}







internal class Programs
{
    
    static void Main(string[] args)
    {
        ISwimmable swim1 = new Duck();
        IFlyable fly1 = (IFlyable)swim1;
        Duck duck1 = (Duck)swim1;
        Console.WriteLine("-------- swimmable being ----------");
        swim1.Swim();
        Console.WriteLine("-------- flyable being ----------");
        fly1.Fly();
        Console.WriteLine("-------- duck ----------");
        duck1.Swim();
        duck1.Fly();

    }
}