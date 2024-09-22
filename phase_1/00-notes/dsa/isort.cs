using System;
class Programs
{
    /*
        UI - index of unsorted list 
        SI - index of sorted list 
        TI - index of target ie first element of the unsorted list 
        */
    static void InsertionSort(long[] ar)
    {
        int N = ar.Length;
        for (int UI = 1; UI < N; UI++) //unsorted list, forward traversal 
        {
            long target = ar[UI];
            int TI = UI; //init target index
            int SI = UI - 1; //init for sorted list, backward traversal 
            while (SI >= 0 && ar[SI] > target) //'cond for sorted list' and 'is element greater'
            {
                ar[SI + 1] = ar[SI];//'shift right' parallel to 'SL traversal'
                TI = SI; //change TI if any greater el in the SL
                SI--; //decrement for sorted list 
            }
            if (TI != UI)
            {
                ar[TI] = target;
            }
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
        long[] ar = {100, 88, 90, 45, 85, 67, 110, 40, 77, 92, 13, 62 };
        Console.Write("Before sort:"); print(ar);
        InsertionSort(ar);
        Console.Write("\nAfter sort :"); print(ar);
    }

    
}