class Square
    {
        static int FindSquare(int num) //author: x
        {
            int square = num * num;
            return square;
        }
        static void test1() //user: y
        {
            int square1 = FindSquare(10);
            int square2 = FindSquare(4);
            Console.WriteLine("{0} {1}", square1, square2);
        }
        static void test2() //user: z
        {
            int n = 0;
            n = int.Parse(Console.ReadLine());
            int s = FindSquare(n);
            Console.WriteLine("Square is {0}", s);

        }
        static void Main(string[] args) //user: p
        {
            test1();
            test2();
            Console.ReadKey();
        }        
    }