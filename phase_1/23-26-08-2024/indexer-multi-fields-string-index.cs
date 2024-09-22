    public class EmployeeSalaries
    {
        private double firstSalary;
        private double secondSalary;
        private double thirdSalary;
        private double fourthSalary;

        public double this[string index]
        {
            get
            {
                double sal = 0.0;
                switch (index)
                {
                    case "one":
                        sal = firstSalary; break;
                    case "two":
                        sal = secondSalary; break;
                    case "three":
                        sal = thirdSalary; break;
                    case "four":
                        sal = fourthSalary; break;
                }
                return sal;
            }
            set
            {
                switch (index)
                {
                    case "one":
                        firstSalary = value; break;
                    case "two":
                        secondSalary = value; break;
                    case "three":
                        thirdSalary = value; break;
                    case "four":
                        fourthSalary = value; break;
                }
            }
        }
    }
    internal class Programs
    {


        static void Main(string[] args)
        {

            EmployeeSalaries employeeSalaries = new EmployeeSalaries();
            Console.WriteLine($"Enter 4 salries one by one.");
            
            Console.Write($"Salary at one:");
            employeeSalaries["one"] = double.Parse(Console.ReadLine());

            Console.Write($"Salary at two:");
            employeeSalaries["two"] = double.Parse(Console.ReadLine());

            Console.Write($"Salary at three:");
            employeeSalaries["three"] = double.Parse(Console.ReadLine());

            Console.Write($"Salary at four:");
            employeeSalaries["four"] = double.Parse(Console.ReadLine());

            Console.WriteLine($"Salary Matrix:");
            
            Console.Write($"{employeeSalaries["one"]} ");
            Console.Write($"{employeeSalaries["two"]} ");
            Console.Write($"{employeeSalaries["three"]} ");
            Console.Write($"{employeeSalaries["four"]} ");

            Console.WriteLine();
        }
    }