//Single Level Inheritance
public class Animal
{
    public void Eat()
    {
        Console.WriteLine("Eating...");
    }
}

public class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine("Barking...");
    }
}
internal class Programs
{
    static void Main(string[] args)
    {
        Dog willow = new Dog();
        willow.Eat();
        willow.Bark();
    }
}