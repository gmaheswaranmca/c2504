    public class EmployeeSalaries
    {
        private double[,] salaryMatrix;
        public EmployeeSalaries(int rows, int cols)
        {
            salaryMatrix = new double[rows,cols];
        }

        public double this[int rowIndex, int colIndex]
        {
            get
            {
                return salaryMatrix[rowIndex,colIndex];
            }
            set
            {
                salaryMatrix[rowIndex, colIndex] = value;
            }
        }
    }
    internal class Programs
    {
       

        static void Main(string[] args)
        {
            Console.Write("Number of Rows in Salary Matrix:"); 
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Number of Columns in Salary Matrix:");
            int cols = int.Parse(Console.ReadLine());
            EmployeeSalaries employeeSalaries = new EmployeeSalaries(rows,cols);
            Console.WriteLine($"Enter {rows}x{cols} salary matrix row by row.");
            for (int I = 0; I < rows; I++)
            {
                for (int J = 0; J < cols; J++)
                {
                    Console.Write($"Salary at {I},{J}:");
                    employeeSalaries[I,J] = double.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine($"Salary Matrix:");
            for (int I = 0; I < rows; I++)
            {
                for (int J = 0; J < cols; J++)
                {
                    Console.Write($"{employeeSalaries[I,J]} ");
                }
                Console.WriteLine();
            }
        }
    }