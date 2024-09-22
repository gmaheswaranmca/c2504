 // Subject interface
 public interface IWeatherStation
 {
     void Attach(IWeatherDisplay observer);
     void Detach(IWeatherDisplay observer);
     void Notify();
 }

 // Concrete Subject
 public class WeatherStation : IWeatherStation
 {
     private readonly List<IWeatherDisplay> _observers = new List<IWeatherDisplay>();
     private float _temperature;

     public float Temperature
     {
         get => _temperature;
         set
         {
             _temperature = value;
             Notify();
         }
     }

     public void Attach(IWeatherDisplay observer)
     {
         _observers.Add(observer);
     }

     public void Detach(IWeatherDisplay observer)
     {
         _observers.Remove(observer);
     }

     public void Notify()
     {
         foreach (var observer in _observers)
         {
             observer.Update(_temperature);
         }
     }
 }

 // Observer interface
 public interface IWeatherDisplay
 {
     void Update(float temperature);
 }

 // Concrete Observer
 public class TemperatureDisplay : IWeatherDisplay
 {
     public void Update(float temperature)
     {
         Console.WriteLine($"Temperature Display: The current temperature is {temperature}°C");
     }
 }
 internal class Programs
 {

     static void Main()
     {
         // Create a weather station (subject)
         var weatherStation = new WeatherStation();

         // Create displays (observers)
         var tempDisplay = new TemperatureDisplay();

         // Attach observers to the weather station
         weatherStation.Attach(tempDisplay);
         weatherStation.Attach(new TemperatureDisplay());

         // Change the temperature and notify observers
         weatherStation.Temperature = 25.0f;
         weatherStation.Temperature = 30.0f;
     }
     

 }