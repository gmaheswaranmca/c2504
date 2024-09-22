//Multi - Level Inheritance
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
public class Puppy : Dog
{
    public void Weep()
    {
        Console.WriteLine("Weeping...");
    }
}
internal class Programs
{
    static void Main(string[] args)
    {
        Console.WriteLine("---willow----");
        Dog willow = new Dog();
        willow.Eat();
        willow.Bark();

        Console.WriteLine("---poppy----");
        Puppy poppy = new Puppy();
        poppy.Weep();
        poppy.Bark();
        poppy.Eat();
    }
}