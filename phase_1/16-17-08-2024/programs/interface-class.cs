public interface IFlyable
{
    void Fly();
}
public class Crow : IFlyable
{
    public void Fly()
    {
        Console.WriteLine("Crow is Flying...");
    }

}
public class Parrot : IFlyable
{
    public void Fly()
    {
        Console.WriteLine("Parrot is Flying...");
    }
}




internal class Programs
{
    static void TestFlyable(IFlyable bird)
    {
        bird.Fly();
    }
    static void Main(string[] args)
    {

        /*
         
        IFlyable fly1 = new Crow();
        fly1.Fly();
        Crow crow1 = (Crow)fly1;
        crow1.Fly();

        IFlyable fly2 = new Parrot();          
        fly2.Fly();
        Parrot parrot1 = (Parrot)fly2;
        parrot1.Fly();
        */
        TestFlyable(new Crow());//"Crow is Flying..."
        TestFlyable(new Crow());//"Crow is Flying..."
        TestFlyable(new Parrot());//"Parrot is Flying..."

        Console.WriteLine("Testing birds in the trees of the district");
        IFlyable[] flys = { new Crow(), new Crow(), new Crow(), new Crow(), new Parrot() };
        foreach(IFlyable fly in flys)
        {
            TestFlyable(fly);
        }
    }
}