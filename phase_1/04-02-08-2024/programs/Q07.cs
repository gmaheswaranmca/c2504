class Q07
{
    //[Ashna, Neha, Nivya, Kuriakose[doubt], Rishwin[discussion], Giris]
    
    static void PrintNumTriangleMirroredRightAngle(int N)
    { 
        for(int I = 1; I <= N; I++ )
        { 
            for(int J = 1; J <= N-I; J++)
            {
                Console.Write("  "); //2 spaces
            }
            for(int J = 1; J <= I; J++)
            {
                Console.Write($"{J} ");//num and space
            }
            Console.WriteLine();//new line 
        }
    }
    //input=4,output=4 lines triangle 
    //input=5,output=5 lines triangle 
    //input=7,output=7 lines triangle 
    static void TestPrintNumTriangleMirroredRightAngle()
    {
        Console.Write("Enter number of lines:");
        int N = int.Parse(Console.ReadLine());
        PrintNumTriangleMirroredRightAngle(N);
    }
    static void Main(string[] args) //user: p
    {
        Console.WriteLine("-----TestPrintNumTriangleMirroredRightAngle-----");
        TestPrintNumTriangleMirroredRightAngle();
        Console.WriteLine("-----End TestPrintNumTriangleMirroredRightAngle-----");
        Console.WriteLine("Press any key to contine...");
        Console.ReadKey();
    }
}