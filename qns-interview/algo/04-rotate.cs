Rotate given array from the specified index. 
    - Left rotate at index k [Print]
    - Right rotate at index k [Print]
    - Left rotate at index k [Copy]
    - Right rotate at index k [Copy]
    Here, k is the index at which rotation takes place 

- Left rotate at index k [Print]
internal class Programs
{
    
    static void Main()
    {
        float[] salaries = { 10, 20, 30, 40, 50, 60, 70 }; int k = 1;
        //rotate left 10 :  20, 30, 40, 50, 60, 70 10
        //rotate left 20:   30, 40, 50, 60, 70 10 20
        //salaries[k+1 .. end] + salaries[0..k]
        for(int I = k + 1; I < salaries.Length; I++) //from at k+1 till end 
        {
            Console.Write($"{salaries[I]} ");
        }
        for (int I = 0; I <= k; I++) //from first element till at k
        {
            Console.Write($"{salaries[I]} ");
        }

    }
}

- Left rotate at index k [Copy]
internal class Programs
{
   
    static void Main()
    {
        float[] salaries = { 10, 20, 30, 40, 50, 60, 70 }; int k = 1;
        float[] rotated = new float[1000]; int size = 0;
        //rotate left 10 :  20, 30, 40, 50, 60, 70 10
        //rotate left 20:   30, 40, 50, 60, 70 10 20
        //salaries[k+1 .. end] + salaries[0..k]
        for(int I = k + 1; I < salaries.Length; I++) //from at k+1 till end 
        {
            rotated[size] = salaries[I]; size++;
        }
        for (int I = 0; I <= k; I++) //from first element till at k
        {
            rotated[size] = salaries[I]; size++;
        }
        for (int I = 0; I < size; I++)
        {
            Console.Write($"{rotated[I]} ");
        }

    }
}

- Right rotate at index k [Print]
internal class Programs
{
   
    static void Main()
    {
        float[] salaries = { 10, 20, 30, 40, 50, 60, 70 }; int k = 5;
        //rotate right 70 :  70 10 20, 30, 40, 50, 60,  
        //rotate left 60:   60 70 10 20, 30, 40, 50
        //salaries[k .. end] + salaries[0..k-1]
        for(int I = k ; I < salaries.Length; I++) //from at k till end 
        {
            Console.Write($"{salaries[I]} ");
        }
        for (int I = 0; I <= k-1; I++) //from first element before at k
        {
            Console.Write($"{salaries[I]} ");
        }

    }
}

- Right rotate at index k [Copy]
internal class Programs
{
   
    static void Main()
    {
        float[] salaries = { 10, 20, 30, 40, 50, 60, 70 }; int k = 5;
        //rotate right 70 :  70 10 20, 30, 40, 50, 60,  
        //rotate left 60:   60 70 10 20, 30, 40, 50
        float[] rotated = new float[1000]; int size = 0;
        //salaries[k .. end] + salaries[0..k-1]
        for(int I = k ; I < salaries.Length; I++) //from at k till end 
        {
            rotated[size] = salaries[I]; size++;
        }
        for (int I = 0; I <= k-1; I++) //from first element before at k
        {
            rotated[size] = salaries[I]; size++;
        }
        for (int I = 0; I < size; I++)
        {
            Console.Write($"{rotated[I]} ");
        }

    }
}

//Left rotate at k(rotateIndex) [rotate in place] by left shift 
internal class Programs
{
    
    static void Main()
    {
        float[] salaries = { 10, 20, 30, 40, 50, 60, 70 }; int k = 1;

        for (int J = 1; J <= (k + 1); J++)
        {
            float target = salaries[0];
            for (int i = 1; i < salaries.Length; i++)
            {
                salaries[i - 1] = salaries[i];
            }
            salaries[salaries.Length - 1] = target;
        }
        for (int I = 0; I < salaries.Length; I++)
        {
            Console.Write($"{salaries[I]} ");
        }

    }
}


``` left rotate first element 
float target = salaries[0];
for (int i = 1; i < salaries.Length; i++)
{
    salaries[i - 1] = salaries[i];
}
salaries[salaries.Length - 1] = target;
```

Here, 
    1. take out first element 
        ```float target = salaries[0];```
    2. shift left from second elements till end 
        ```
        for (int i = 1; i < salaries.Length; i++)
        {
            salaries[i - 1] = salaries[i];
        }```
    3. place taken out element at last 
     ```salaries[salaries.Length - 1] = target;```

The outer loop - number of times to be rotated 
    for (int J = 1; J <= (k + 1); J++)
{
        ...
}
Here, 
    (k + 1) is number of times to be rotated 
        ie number of elements to be rotated 

//Right rotate at k(rotateIndex) [rotate in place] [by right shift]
internal class Programs
{
    
    static void Main()
    {
        float[] salaries = { 10, 20, 30, 40, 50, 60, 70 }; int k = 5;

        for (int J = 1; J <= (salaries.Length - k); J++)
        { 
            float target = salaries[salaries.Length - 1];
            for (int i = salaries.Length - 2; i >= 0; i--)
            {
                salaries[i + 1] = salaries[i];
            }
            salaries[0] = target;
        }
        for (int I = 0; I < salaries.Length; I++)
        {
            Console.Write($"{salaries[I]} ");
        }
    }
}

1. take out the last element 
```float target = salaries[salaries.Length - 1];```
2. from one element before last element till first element
   shift right
``` 
for (int i = salaries.Length - 2; i >= 0; i--)
{
    salaries[i + 1] = salaries[i];
}
```
3. copy the taken out element to the first element 
```salaries[0] = target;```