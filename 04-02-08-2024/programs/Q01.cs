class Q01
{
    static void PrintSeries10_12_14(int numOfTerms)
    {
        int term = 10;
        for (int I = 1; I <= numOfTerms ; I++)
        {
            Console.Write($"{term} ");
            term = term + 2;
        }
    }
    // input=5, output=10 12 14 16 18
    // input=8, output=10 12 14 16 18 20 22 24
    // input=3, output=10 12 14
    static void TestPrintSeries10_12_14()
    {
        Console.Write("Enter number of terms:");
        int numOfTerms = int.Parse(Console.ReadLine());
        Console.Write("Series: ");
        PrintSeries10_12_14(numOfTerms);
        Console.WriteLine();
    }

    static void Main(string[] args) //user: p
    {
        Console.WriteLine("--------------TestPrintSeries10_12_14...--------------");
        TestPrintSeries10_12_14();
        Console.WriteLine("--------------End TestPrintSeries10_12_14...--------------");
        Console.WriteLine("Press any key to contine...");
        Console.ReadKey();
    }
}