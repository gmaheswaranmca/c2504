// Adaptee class (legacy system)
public class OldLogger
{
    public void LogMessage(string message)
    {
        Console.WriteLine("Old Logger: " + message);
    }
}
// Target interface
public interface ILogger
{
    void Log(string message);
}
// Adapter class
public class LoggerAdapter : ILogger
{
    private readonly OldLogger _oldLogger;

    public LoggerAdapter(OldLogger oldLogger)
    {
        _oldLogger = oldLogger;
    }

    public void Log(string message)
    {
        // Adapt the method call to the old logger's method
        _oldLogger.LogMessage(message);
    }
}
internal class Programs
{

    static void Main()
    {
        // Existing client code expects ILogger interface
        ILogger logger = new LoggerAdapter(new OldLogger());
        logger.Log("This is a log message.");
    }
    

}