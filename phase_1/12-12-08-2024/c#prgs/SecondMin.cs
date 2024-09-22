static void Main2()
{   //Anjan ER doubt 
    int minSal = int.MaxValue; // 0...
    int secondMinSal = int.MaxValue;

    while (true)
    {
        Console.Write("Enter salary (-1 to stop): ");
        int sal = Convert.ToInt32(Console.ReadLine());
        if (sal == -1)
            break;
        if (sal < minSal)              // 51 53  | 53 51
        {
            if(minSal != int.MaxValue)
                secondMinSal = minSal; //        | MAX->53
            minSal = sal;              // 51     | 53->51
        }
        else if (sal < secondMinSal && sal != minSal)
            secondMinSal = sal;
    }

    if (secondMinSal == int.MaxValue)
        Console.WriteLine("There is no second minimum salary.");
    else
        Console.WriteLine("The second minimum salary is: " + secondMinSal);
}