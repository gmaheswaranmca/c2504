class TestCountMin6DigitsSalariedDoctorsAnnMariya
{
    //Yahkoob | Gopika[ok] | Dijol[ok|qn] | Collin[ok] | Neha[ok] | Aaryaka[ok|qn] | Shilpa[ok|qn] | Keerthana[ok|qn]
    //Ann Maria[ok|qn]
    //Anjana E R[ok] | Neha[ok|qn] | Sarika[ok|qn]
    //GladsyJoshy | Kuriakose[qn] | Minnu[qn] | Athulya[qn]
    static bool IsDoctorSalaryMin6Digits(int doctorSalary) //Ann Mariya version
    {
        return doctorSalary >= 100000;
    }

    static int CountMin6DigitsSalariedDoctors(int [] salaries, int size)
    {
        int count = 0;
        for(int I = 0; I <= size-1; I++)
        { 
            if (IsDoctorSalaryMin6Digits(salaries[I]))
            {
                count += 1;
            }
        }
        return count;
    }
    // input=3,[67894,67894356,678943], output=Number of Min 6 Digits Salaried Doctors : 2
    // input=4,[400,50000,60000000,700000], output=Number of Min 6 Digits Salaried Doctors : 2
    // input=4,[400000,50000,60000000,700000], output=Number of Min 6 Digits Salaried Doctors : 3
    //Note: Salaries -> array of salaries 
    static void TestCountMin6DigitsSalariedDoctors()
    {
        Console.Write("Number of Doctors:");
        int size = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter one by one doctors salries.");
        int[] salaries = new int[size]; //new int[size] allocates the int memblocks of size "size" [Minnu|Sarika]
        for (int I = 0; I <= size - 1; I++)
        {
            Console.Write($"Salary of {I + 1}th Doctor:");
            salaries[I] = int.Parse(Console.ReadLine());
        }
        int sixDigitsSalariedCount = CountMin6DigitsSalariedDoctors(salaries, size);
        Console.WriteLine($"Number of Min 6 Digits Salaried Doctors : {sixDigitsSalariedCount}");
    }

    static void Main(string[] args) //user: p
    {
        Console.WriteLine("------------------------TestCountMin6DigitsSalariedDoctors------------------------------");
        TestCountMin6DigitsSalariedDoctors();
        Console.WriteLine("------------------------End TestCountMin6DigitsSalariedDoctors------------------------------");
        Console.WriteLine("Press any key to contine...");
        Console.ReadKey();
    }
}