    delegate void DWriteLine(string str);
    internal class Programs
    {
        static void Print(string a)
        {
            Console.WriteLine(a);
        }
        static void Main()
        {
            //Console.WriteLine("Hello World!!!");
            //Console.WriteLine("Hi Ashna!");
            //Console.WriteLine("Hi Collin!");

            DWriteLine wr = Console.WriteLine; //DWriteLine wr = new DWriteLine(Console.WriteLine);
            wr("Hello World!!!");
            wr("Hi Ashna!");
            wr("Hi Collin!");
            

            //DWriteLine rl = Console.ReadLine; //why? //signature of "Console.ReadLine" and "DWriteLine" are not matched
            DWriteLine rPrint = Print;//new DWriteLine(Print)
            rPrint("I am printing...");

            DWriteLine rPrintLettersOneByOne = PrintLettersOneByOne;
            rPrintLettersOneByOne += PrintLettersCount;//multi casting //delegate var refers many functions at a time

            rPrintLettersOneByOne("Obj");

            rPrintLettersOneByOne -= PrintLettersOneByOne;
            rPrintLettersOneByOne("Oriented");
        }

        static void PrintLettersOneByOne(string x)
        {
            foreach(var letter in x)
            {
                Console.WriteLine(letter);
            }
        }
        static void PrintLettersCount(string x) //Note: Dont use Length function 
        {
            int c = 0;
            foreach (var letter in x)
            {
                c++;
            }
            Console.WriteLine($"Count is {c}");
        }
    }