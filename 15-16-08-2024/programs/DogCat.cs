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

    public class Cat : Animal
    {
        public void Meow()
        {
            Console.WriteLine("Meowing...");
        }
    }
    internal class Programs
    {
        static void Main(string[] args)
        {
            Dog willow = new Dog();
            Console.WriteLine("---willow---"); willow.Bark(); willow.Eat();

            Cat hudson = new Cat();
            Console.WriteLine("---hudson---"); hudson.Meow(); hudson.Eat();
        }
    }