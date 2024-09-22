internal class Programs
{
    /*
        to remove the duplicates in sorted array 

        for each element from second element onwards
            element and previous element are compared, 
            if not matched, 
                add to the distinct array 

        Edge case:
            add the first element 
    */
    static void Main()
    {
        float[] salaries = { 10, 20, 30, 50, 50, 60, 60, 60, 70, 80, 80 };

        float[] distinctSalaries = new float[100]; int distinctSize = 0;

        distinctSalaries[distinctSize] = salaries[0];
        distinctSize++;

        for(int I = 1; I < salaries.Length; I++)
        {
            if (salaries[I-1] == salaries[I])
            {
                continue;
            }

            distinctSalaries[distinctSize] = salaries[I];
            distinctSize++;
        }
        for (int I = 0; I < distinctSize; I++)
        {
            Console.Write($"{distinctSalaries[I]} ");
        }
    }
}