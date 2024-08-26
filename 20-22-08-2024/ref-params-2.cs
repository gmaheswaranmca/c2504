//to use ref alternative to out 
    internal class Programs
    {
        long findSumExtended(long a, long b, ref long diff, ref long prod,
            ref long quotient, ref long remaninder)
        {
            
            long sum = a + b;
            diff = a - b;
            prod = a * b;
            quotient = a / b;
            remaninder = a % b; 
            return sum;
        }
        static void Main(string[] args)
        {
            Programs programs = new Programs();
            long s, d = 10, p = 20, q = 30, r = 40;
            s = programs.findSumExtended(20, 3, ref d, ref p, ref q, ref r);
            Console.WriteLine($"sum={s}, diff={d}, prod={p}, quotient={q}, remaninder={r}");
            //23, 17, 60, 6, 2
        }
    }