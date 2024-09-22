class Minnu
{
    static void ReadPatientAgeTillBelowZero()
    {
        int count = 0;
        int countOdd = 0;
        int sum = 0;
        int avg = 0;
        int primeSum = 0;
        int teenagerSum = 0;
        int min = int.MaxValue;
        int oddSum = 0;
        bool isMinPrime = false;
        int maxAdult = int.MinValue, secondMaxAdult = int.MinValue;

        
        //
        int age = 0;
        do
        {
            age = int.Parse(Console.ReadLine());

            if(age < 0) //to stop input cond
            {
                break;
            }
            if(age == 0) //validation
            {
                Console.WriteLine("invalid age");
                continue;
            }

            count++;
            if (IsOdd(age)) // check for odd number ages
            {
                countOdd++;
                oddSum += age;
            }
            if (IsAdult(age)) // check for adult age
            {
                if (age > maxAdult)// check for max adult age
                {
                    if (maxAdult != int.MaxValue)
                    {
                        secondMaxAdult = maxAdult;
                    }
                    maxAdult = age;
                }
                else if (age > secondMaxAdult && age != maxAdult)
                {
                    secondMaxAdult = age;
                }
            }
            sum = sum + age;
            if(IsPrime(age)) // check for prime ages
            {
                primeSum += age;
            }

            if(IsTeenager(age)) // check for teenager
            {
                teenagerSum += age;
            }

            if (age < min)// check for min age
            { 
                min = age;
            }
        } while (!(age < 0));


        isMinPrime = IsPrime(min);
        

        avg = sum / count; // to find average
        Console.WriteLine($"Average Age: {avg}");
        Console.WriteLine($"Prime Ages sum: {primeSum}"); //Anjana NK
        Console.WriteLine($"Teenagers' Age Sum: {teenagerSum}"); 
        Console.WriteLine($"Min Age#: {min}");
        Console.WriteLine($"Odd Age Sum#: {oddSum}");
        if(secondMaxAdult == int.MaxValue)
        { 
            Console.WriteLine("Second Max Adult Age does not exist");
        }
        else
        {
            Console.WriteLine($"Second Max Adult Age#: {secondMaxAdult}");
        }
            
        if (isMinPrime) // check if Minimum age is prime
        {
            Console.WriteLine("Minimum age is also prime");
        }
        else
        {
            Console.WriteLine("Minimum age is not prime");
        }
    }

    static bool IsPrime(int age)
    {
        bool isPrime = true;
        int sqrtAge = (int)Math.Sqrt((double)age);
        for (int i = 2; i <= sqrtAge; i++)
        {
            if (age % i == 0)
            {
                isPrime = false;
                break;
            }
        }
        return isPrime;
    }
    static bool IsTeenager(int age)
    {
        return ((age >= 13) && (age <= 19));
    }
    static bool IsAdult(int age)
    {
        return  (age > 19);
    }

    static bool IsOdd(int age)
    {
        return age % 2 != 0;
    }


    static void TestReadPatientAgeTillBelowZero()
    {
        ReadPatientAgeTillBelowZero();
    }

    static void Main(string[] args) 
    {
        Console.WriteLine("-----TestReadPatientAgeTillBelowZero-----");
        TestReadPatientAgeTillBelowZero();
        Console.WriteLine("-----End TestReadPatientAgeTillBelowZero-----");
        Console.WriteLine("Press any key to contine...");
        Console.ReadKey();
    }

    
}