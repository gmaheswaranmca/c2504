    /*
     1/4 + 2/4 = 6 / 8 = 3 / 4
     a        c         (a * d) + (c * b)       
    ----  + -----   =  ------------------
     b        d             b * d
     */
    class MyUtil
    {
        public static int FindGCD(int a, int b) //HCF
        {
            while (a != b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            return a;
        }
    }
    class RationalNumber 
    {
        public int Numerator { get; set; }
        private int denominator;
        public int Denominator 
        { 
            get 
            { 
                return denominator; 
            } 
            set 
            {
                if (denominator == 0)
                {
                    denominator = 1;
                }
                denominator = value; 
            }  
        }

        public RationalNumber(int _numerator, int _denominator)
        {
            // throw ERR this.Denominator = 0
            if(_denominator == 0)
            {
                _denominator = 1;
            }
            this.Numerator = _numerator;
            this.Denominator = _denominator;
        }
        public RationalNumber Add(RationalNumber other)
        {
            RationalNumber sum = new RationalNumber(0,0);
            sum.Numerator = (this.Numerator * other.Denominator) + (other.Numerator * this.Denominator);
            sum.Denominator = this.Denominator * other.Denominator;

            int gcd = MyUtil.FindGCD(sum.Numerator, sum.Denominator);
            sum.Numerator = sum.Numerator / gcd;
            sum.Denominator = sum.Denominator / gcd;
            return sum;
        }
        
        public override string ToString()
        {
            return $"[{Numerator} / {Denominator}]";
        }

    }
    internal class TestComplexNumber
    {
        static void Main(string[] args)
        {
            //Console.WriteLine($"gcd(6, 12) = {MyUtil.FindGCD(6, 12)}");

            RationalNumber firstNo = new RationalNumber(1, 4);
            RationalNumber secondNo = new RationalNumber(1, 2);
            RationalNumber result = firstNo.Add(secondNo);
            Console.WriteLine($"{firstNo} + {secondNo} = {result}");

        }
    }