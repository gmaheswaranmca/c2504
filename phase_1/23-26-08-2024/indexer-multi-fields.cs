    public class EmployeeSalaries
    {
        private double firstSalary;
        private double secondSalary;
        private double thirdSalary;
        private double fourthSalary;
        
        public double this[int index]
        {
            get
            {
                double sal = 0.0;
                switch (index)
                {
                    case 0:
                        sal = firstSalary; break;
                    case 1:
                        sal = secondSalary; break;
                    case 2:
                        sal = thirdSalary; break;
                    case 3:
                        sal = fourthSalary; break;
                }
                return sal;
            }
            set
            {
                switch (index)
                {
                    case 0:
                        firstSalary = value; break;
                    case 1:
                        secondSalary = value; break;
                    case 2:
                        thirdSalary = value; break;
                    case 3:
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
            for (int I = 0; I < 4; I++)
            {
                Console.Write($"Salary at {I}:");
                employeeSalaries[I] = double.Parse(Console.ReadLine());
            }
            Console.WriteLine($"Salary Matrix:");
            for (int I = 0; I < 4; I++)
            {                
                Console.Write($"{employeeSalaries[I]} ");
            }
            Console.WriteLine();
        }
    }