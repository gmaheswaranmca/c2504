using System;
class Programs
{
    static void InsertionSort(long[] ar)
    {
        int N = ar.Length;
        for (int unsortedIndex = 1; unsortedIndex < N; unsortedIndex++) //unsorted list, forward traversal 
        {
            long target = ar[unsortedIndex];
            int targetIndex = unsortedIndex; //init target index

            for (int sortedIndex = unsortedIndex - 1; sortedIndex >= 0; sortedIndex--) // sorted list, backward traversal 
            {
                //if no any greater element
                if (!(ar[sortedIndex] > target))
                {
                    break;
                }
                //if any greater element
                ar[sortedIndex + 1] = ar[sortedIndex];//'shift right' 
                targetIndex = sortedIndex; //change targetIndex 
            }

            if (targetIndex != unsortedIndex)
            {
                ar[targetIndex] = target;
            }
            //TRACE//Console.Write($"\nunsortedIndex={unsortedIndex},targetIndex={targetIndex}:"); print(ar);
        }

    }
    private static void print(long[] ar)
    {
        foreach (long num in ar)
        {
            Console.Write($"{num} ");
        }
    }
    static void Main(string[] args)
    {
        //long[] ar = { 7, 4, 3, 5, 8, 10, 2, 6 };
        //long[] ar = {3, 5, 8, 10 };
        long[] ar = { 100, 88, 90, 45, 85, 67, 110, 40, 77, 92, 13, 62 };
        Console.Write("Before sort:"); print(ar);
        InsertionSort(ar);
        Console.Write("\nAfter sort :"); print(ar);
        Console.WriteLine();
    }
}