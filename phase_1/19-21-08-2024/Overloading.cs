   public class Calculator
   {
       // Method to add two integers
       public int Add(int a, int b)
       {
           Console.WriteLine("int Add(int a, int b)");
           return a + b;
       }

       // Overloaded method to add three integers
       public int Add(int a, int b, int c)
       {
           Console.WriteLine("int Add(int a, int b, int c)");
           return a + b + c;
       }

       // Overloaded method to add two double values
       public double Add(double a, double b)
       {
           Console.WriteLine("double Add(double a, double b)");
           return a + b;
       }
       // Overloaded method to add two double values
       public double Add(double a, int b)
       {
           Console.WriteLine("double Add(double a, int b)");
           return a + b;
       }
       // Overloaded method to concatenate two strings
       public string Add(string a, string b)
       {
           Console.WriteLine("string Add(string a, string b)");
           return a + b;
       }
   }
   internal class Programs
   {
       static void Main(string[] args)
       {
           Calculator calculator = new Calculator();

           int sum1 = calculator.Add(5, 10);           // Calls Add(int, int)
           int sum2 = calculator.Add(5, 10, 15);       // Calls Add(int, int, int)
           double sum3 = calculator.Add(5.5, 10.5);    // Calls Add(double, double)
           string concatenated = calculator.Add("Hello, ", "World!");  // Calls Add(string, string)
           double sum4 = calculator.Add(5.5, 10); // Calls Add(double, int)
           double sum5 = calculator.Add(5, 10.5); // Calls Add(double, double)



           Console.WriteLine(sum1);       // Output: 15
           Console.WriteLine(sum2);       // Output: 30
           Console.WriteLine(sum3);       // Output: 16.0
           Console.WriteLine(concatenated);  // Output: Hello, World!
           Console.WriteLine(sum4);  // Output: 15.5
           Console.WriteLine(sum5);    // Output: 15.5
       }
   }