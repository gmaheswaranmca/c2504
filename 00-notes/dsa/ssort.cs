    class Programs
    {
        static void SelectionSort(long[] ar)
        {
            int N = ar.Length;//
                              //select element from first element till element before last element 'second last element'
            for (int selectedIndex = 0; selectedIndex < (N - 1); selectedIndex++) //selection logic | for first N-1 elements
            {
                int minIndex = selectedIndex;//init min element index
                                             //check is there any 'min number' in the 'next elements' after 'selected element'
                for (int nextIndex = selectedIndex + 1; nextIndex < N; nextIndex++)//pass //seeking min element in next elements
                {
                    if (ar[nextIndex] < ar[minIndex]) //if there lesser element in the next element
                    {
                        minIndex = nextIndex; //change the min element index
                    }
                }
                if (minIndex != selectedIndex) //swap min element and selected element
                {
                    long temp = ar[minIndex];//swap logic, move to function
                    ar[minIndex] = ar[selectedIndex];
                    ar[selectedIndex] = temp;
                }
                //TRACE//Console.Write($"\nSI={selectedIndex},MI={minIndex}:"); print(ar);
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
            //long[] ar = { 3, 7, 2, 4 };
            Console.Write("Before sort:"); print(ar);
            SelectionSort(ar);
            Console.Write("\nAfter sort :"); print(ar);
            Console.WriteLine();
        }
    }