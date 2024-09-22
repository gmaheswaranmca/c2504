6. Given an array of integers 
   where every number is repeating two times. 
   Find the number which is occuring only once.
   [consecutive repeating numbers]

   2 2 3 3 4 4 5 6 6    ==> 5
   2 3 3 4 4 5 5 6 6    ==>    
   2 2 3 3 4 4 5 5 6    ==>

internal class Programs
{
    
    static void Main()
    {
        //float[] salaries = { 2, 2 ,3, 3, 4, 4, 5, 6, 6 };
        //float[] salaries = { 2, 3, 3, 4, 4, 5, 5, 6, 6 };
        float[] salaries = { 2, 2, 3, 3, 4, 4, 5, 5, 6 };
        bool isNonRepeatedExist = false; //Edge case for last element 
        for (int i = 0; i < salaries.Length-1; i+=2)
        {
            if (salaries[i] != salaries[i + 1])
            {
                Console.WriteLine(salaries[i]);
                isNonRepeatedExist = true; //Edge case for last element 
                break;
            }
        }
        if(!isNonRepeatedExist) //Edge case for last element //&& salaries.Length % 2 == 1
        {
            Console.WriteLine(salaries[salaries.Length - 1]);
        }
    }
}