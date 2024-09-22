static void InsertionSort(Shape[] ar)//##
{
    int N = ar.Length;
    for (int UI = 1; UI < N; UI++) //unsorted list, forward traversal 
    {
        Shape target = ar[UI];//##
        long TI = UI; //init target index
        int SI = UI - 1; //init for sorted list, backward traversal 
        while (SI >= 0 && ar[SI].Gt(target)) //##//'cond for sorted list' and 'is element greater'
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