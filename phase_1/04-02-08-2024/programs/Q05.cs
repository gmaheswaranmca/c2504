class Q05
{
    //21_22_24_27_31_36_42_49
    //[Aaryaka, Roshith<networking issue>, Shilpa], 
    static int GetNthTerm_21_22_24_27(int N) 
    {
        int term = 21;  
        int difference = 1;
        int I = 1;
        while ( I <= N ) 
        {
            if( I == N )
            {
                break;
            }
            //
            term = term + difference;
            difference = difference + 1;

            I++;
        }
        return term;
    }
    
    //input=5,output=31
    //input=3,output=24
    //input=7,output=42
    static void TestGetNthTerm_21_22_24_27()
    {
        Console.Write("Enter number of terms:");
        int N = int.Parse(Console.ReadLine());
        int nthTerm = GetNthTerm_21_22_24_27(N);
        Console.WriteLine($"Nth term is {nthTerm}"); 
    }
    static void Main(string[] args) //user: p
    {
        Console.WriteLine("-----TestGetNthTerm_21_22_24_27-----");
        TestGetNthTerm_21_22_24_27();
        Console.WriteLine("-----End TestGetNthTerm_21_22_24_27-----");
        Console.WriteLine("Press any key to contine...");
        Console.ReadKey();
    }
}