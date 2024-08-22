 internal class Programs
 {
     void swap(ref long a, ref long b)
     {
         long t = a;
         a = b;
         b = t;
     }
     static void Main(string[] args)
     {
         Programs programs = new Programs();
         long x = 10, y = 20;
         Console.WriteLine($"Before swap: x={x}, y={y}");
         programs.swap(ref x, ref y);
         Console.WriteLine($"After swap: x={x}, y={y}");
         //23, 17, 60, 6, 2
     }
 }