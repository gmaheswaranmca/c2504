public class AppConfig
{
    public static int numberOfUsers;
    public static int eachUserNumberOfVisits;

    static AppConfig()
    {
        Console.WriteLine("Static Constr");
        numberOfUsers = 10;
        eachUserNumberOfVisits = 20;
    }

    public int a;
    public AppConfig()
    {
        Console.WriteLine("instance parameterless Constr");
        this.a = 10; 
    }
}
internal class Programs
{
    static void Main(string[] args)
    {
        AppConfig config1 = new AppConfig();
        Console.WriteLine($"numberOfUsers={AppConfig.numberOfUsers} eachUserNumberOfVisits={AppConfig.eachUserNumberOfVisits}");
    }
}