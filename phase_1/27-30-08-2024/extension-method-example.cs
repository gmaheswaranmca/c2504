public static class MyStringExtension
{
    public static int NumberOfKs(this string str)
    {
        int count = 0;
        foreach(var ch in str)
        {
            if(ch == 'k' || ch == 'K')
            {
                count++;
            }
        }
        return count;
    }
    public static int NumberOfVowels(this string str)
    {
        int count = 0;
        foreach (var ch in str)
        {
            var letter = Char.ToUpper(ch);
            //if (letter == 'A' || letter == 'E' || letter == 'I' || letter == 'O' || letter == 'U')
            if(Char.IsLetter(letter))
            { 
                switch(letter)
                {
                    case 'A':
                    case 'I':
                    case 'E':
                    case 'O':
                    case 'U':
                        count++; break;
                    default:
                        /*consonant*/break;
                }
            }
        }
        return count;
    }
}
internal class Programs
{

    static void Main()
    {
        string alan = "Alan Kuriakose";
        Console.WriteLine(alan.NumberOfKs());
        Console.WriteLine(alan.NumberOfVowels());

        string mahesh = "Maheswaran Govindaraju";
        Console.WriteLine(mahesh.NumberOfKs());

    }
    
}