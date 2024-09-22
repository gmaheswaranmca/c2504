class IsDoctorSalaryMin6DigitsSarikaTwoTests
{
    //Yahkoob | Gopika[ok] | Dijol[ok|qn] | Collin[ok] | Neha[ok] | Aaryaka[ok|qn] | Shilpa[ok|qn] | Keerthana[ok|qn]
    //Ann Maria[ok|qn]
    static bool IsDoctorSalaryMin6Digits(int doctorSalary)
    {
        int salary = doctorSalary;

        int count = 0;
        while (salary > 0)
        {
            int digit = salary % 10;
            count += 1;
            salary = salary / 10;
        }

        return count >= 6;
    }
    // input=678943, output="Doctor gets 6 digits salary"
    // input=67894, ouput="Doctor does not get 6 digits salary"
    // input=67894356, output="Doctor gets 6 digits salary"
    //Anjana E R[ok] | Neha[ok|qn] | Sarika[ok|qn]
    static void TestIsDoctorSalaryMin6DigitsOrNot()
    {
        Console.WriteLine("Enter doctor salary:");
        int doctorSalary = int.Parse(Console.ReadLine());
        if(IsDoctorSalaryMin6Digits(doctorSalary))
        { 
            Console.WriteLine("Doctor gets Min 6 digits salary");
        }
        else
        {
            Console.WriteLine("Doctor does not get Min 6 digits salary");
        }
    }
    // input=678943, output="Doctor gets 6 digits salary"
    // input=67894, ouput=no output
    // input=67894356, output="Doctor gets 6 digits salary"
    static void TestIsDoctorSalaryMin6Digits()
    {
        Console.WriteLine("Enter doctor salary:");
        int doctorSalary = int.Parse(Console.ReadLine());
        if (IsDoctorSalaryMin6Digits(doctorSalary))
        {
            Console.WriteLine("Doctor gets Min 6 digits salary");
        }
    }
    static void Main(string[] args) //user: p
    {
        Console.WriteLine("--------------------TestIsDoctorSalaryMin6Digits--------------------");
        TestIsDoctorSalaryMin6Digits();
        Console.WriteLine("--------------------End of TestIsDoctorSalaryMin6Digits--------------------");
        Console.WriteLine("--------------------TestIsDoctorSalaryMin6DigitsOrNot--------------------");
        TestIsDoctorSalaryMin6DigitsOrNot();
        Console.WriteLine("--------------------End of TestIsDoctorSalaryMin6Digits--------------------");
        Console.WriteLine("Press any key to contine...");
        Console.ReadKey();
    }
}