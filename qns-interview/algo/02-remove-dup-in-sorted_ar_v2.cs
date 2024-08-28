internal class Programs
{
    /*
        to remove the duplicates in sorted array 

        for each element till before last element 
            element and next element are compared, 
            if not matched, 
                add to the distinct array 

        Edge case:
            for the last element, 
            we cannot have the next element,
            so, here we have to assume for last element, the next element is different.
            ie. add the last element 
    */
    static void Main()
    {
        float[] salaries = { 10, 10, 20, 30, 50, 50, 60, 60, 60, 70, 80, 80 };

        float[] distinctSalaries = new float[100]; int distinctSize = 0;

        for(int I = 0; I <= (salaries.Length - 2); I++)
        {
            if (salaries[I] == salaries[I+1])
            {
                continue;
            }
            distinctSalaries[distinctSize] = salaries[I];
            distinctSize++;
        }
        
        distinctSalaries[distinctSize] = salaries[salaries.Length - 1];
        distinctSize++;
        
        for (int I = 0; I < distinctSize; I++)
        {
            Console.Write($"{distinctSalaries[I]} ");
        }
    }
}



=====================
internal class Programs
{
    /*
        
    */
    static void Main()
    {
        float[] salaries = { 10, 10, 20, 30, 50, 50, 60, 60, 60, 70, 80, 80 };

        float[] distinctSalaries = new float[100]; int distinctSize = 0;

        for(int I = 0; I <= (salaries.Length - 2); I++)
        {
            if (salaries[I] == salaries[I+1])
            {
                continue;
            }
            distinctSalaries[distinctSize] = salaries[I];
            distinctSize++;
        }
        
        distinctSalaries[distinctSize] = salaries[salaries.Length - 1];
        distinctSize++;
        
        for (int I = 0; I < distinctSize; I++)
        {
            Console.Write($"{distinctSalaries[I]} ");
        }
    }
}