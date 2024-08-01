class TestIsDoctorSalaryMin6DigitsGirish
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
    // input=67894, ouput=no output
    static void TestIsDoctorSalaryMin6Digits()
    {
        int doctorSalary = int.Parse(Console.ReadLine());
        if( IsDoctorSalaryMin6Digits(doctorSalary) )
        {
            Console.WriteLine("Doctor gets 6 digits salary");
        }
    }
    static void Main(string[] args) //user: p
    {
        TestIsDoctorSalaryMin6Digits();
        Console.WriteLine("Press any key to contine...");
        Console.ReadKey();
    }        
}