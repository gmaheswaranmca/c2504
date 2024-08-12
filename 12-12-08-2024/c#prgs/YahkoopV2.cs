class YahkoopV2
{
    static void ReadDoctorSalaryTillMinus1()
    {
        int count = 0;
        int countOdd = 0;
        int sum = 0;
        int avg = 0;
        int primeCount = 0;
        int minFourDigitsCount = 0;
        int max = 0, minOdd = 0;
        int oddSum = 0;
        bool isMaxPrime = false;
        int secondMinOdd = 0;

        
        //
        int salary = 0;
        do
        {
            salary = int.Parse(Console.ReadLine());

            if(salary == -1) //to stop input cond
            {
                break;
            }
            if(salary < 0) //validation
            {
                Console.WriteLine("invalid salary");
                continue;
            }

            count++;
            if (IsOdd(salary)) // check for odd number salaries
            {
                countOdd++;
                oddSum += salary;

                if (countOdd == 1)
                {
                    minOdd = salary;                        
                }
                else if(salary < minOdd)// check for minimum salary
                {
                    secondMinOdd = minOdd;
                    minOdd = salary;
                }
            }
            sum = sum + salary;
            if(IsPrime(salary)) // check for prime salaries
            {
                primeCount++;
            }

            if(IsMinimumFourDigits(salary)) // check for 4 digits salaries
            {
                minFourDigitsCount++;
            }

            if (count == 1)
            {
                max = salary;
            }
            else if (salary > max)// check for maximum salary
            { 
                max = salary;
            }
        } while (salary != -1);


        isMaxPrime = IsPrime(max);
        

        avg = sum / count; // to find average
        Console.WriteLine($"Average Salary: {avg}");
        Console.WriteLine($"Prime Salaries#: {primeCount}");
        Console.WriteLine($"Min Four Digits Salaries#: {minFourDigitsCount}");
        Console.WriteLine($"Max Salary#: {max}");
        Console.WriteLine($"Odd Salaries Sum#: {oddSum}");
        Console.WriteLine($"Min Odd Salary#: {minOdd}");
        Console.WriteLine($"Second Min Odd Salary#: {secondMinOdd}");
        if (isMaxPrime) // check if maximum salary is prime
        {
            Console.WriteLine("Maximum salary is also prime ");
        }
        else
        {
            Console.WriteLine("Maximum salary is not prime ");
        }
    }


    /* 
        static bool IsPrime(int salary)
    {
        bool isPrime = true;
        int halfSal = salary / 2;
        //int sqrtSal = (int)Math.Sqrt((double)salary);
        for (int i = 2; i < halfSal; i++) {
                if (salary % i == 0) {
                isPrime = false;
                break;
                }
        }
        return isPrime;
    } */
    static bool IsPrime(int salary)
    {
        bool isPrime = true;
        int sqrtSal = (int)Math.Sqrt((double)salary);
        for (int i = 2; i <= sqrtSal; i++)
        {
            if (salary % i == 0)
            {
                isPrime = false;
                break;
            }
        }
        return isPrime;
    }
    static bool IsMinimumFourDigits(int salary)
    {
        return salary >= 1000;
    }

    static bool IsOdd(int salary)
    {
        return salary % 2 != 0;
    }


    static void TestReadDoctorSalaryTillMinus1()
    {
        ReadDoctorSalaryTillMinus1();
    }

    static void Main(string[] args) 
    {
        Console.WriteLine("-----TestReadDoctorSalaryTillMinus1-----");
        TestReadDoctorSalaryTillMinus1();
        Console.WriteLine("-----End TestReadDoctorSalaryTillMinus1-----");
        Console.WriteLine("Press any key to contine...");
        Console.ReadKey();
    }
}