internal class Programs
{
    static int FindCharInArray(char[] ar, int N, char target)
    {
        int index = 0;
        foreach (var ch in ar)
        {
            if(ch == target) return index;
            index++;
        }

        return -1;
    }
    static void Main()
    {
        Console.Write("Enter string:");
        string sentence = Console.ReadLine();
        
        char [] letters = new char[1000]; int numOfLetters = 0;
        int[] counts = new int[1000];

        foreach(var ch in sentence)
        {
            int pos = FindCharInArray(letters, numOfLetters, ch);
            if (pos != -1)
            {
                counts[pos]++;
                continue;
            }

            letters[numOfLetters] = ch;
            counts[numOfLetters] = 1;
            numOfLetters++;
        }            
        for (int I = 0; I < numOfLetters; I++)
        {
            Console.WriteLine($"{letters[I]} occurred {counts[I]} times.");
            //Console.WriteLine($"number of frequency of {letters[I]} is {counts[I]}.");
        }
    }
}