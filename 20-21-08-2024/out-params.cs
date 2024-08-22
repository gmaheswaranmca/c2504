    internal class Programs
    {
        long findSumExtended(long a, long b, out long diff, out long prod,
            out long quotient, out long remaninder)
        {
            //long x = diff + prod;//ERR, using out arg before updating to 'out' arg throws ERR
            long sum = a + b;
            diff = a - b;
            prod = a * b;
            quotient = a / b;
            remaninder = a % b; //All out args should be updated before returning from the fn
            //long x = diff + prod;//No ERR, using out arg after updating to 'out' arg is VALID
            return sum;
        }
        static void Main(string[] args)
        {
            Programs programs = new Programs();
            long s, d=10, p=20, q=30, r=40;
            s = programs.findSumExtended(20, 3, out d, out p, out q, out r);
            Console.WriteLine($"sum={s}, diff={d}, prod={p}, quotient={q}, remaninder={r}");
            //23, 17, 60, 6, 2
        }
    }