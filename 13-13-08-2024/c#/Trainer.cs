class Trainer
{
    public int id;
    public string name;
    public string skill;
    public string place;
    public float salary;

    
}

class Program
{
    static void Main(string[] args) 
    {
        Trainer mahesh = new Trainer();
        mahesh.id = 10;
        mahesh.name = "Mahesh";
        mahesh.skill = "C#";
        mahesh.place = "Mysore";
        mahesh.salary = 9000;

        Trainer mishel = new Trainer();
        mishel.id = 20;
        mishel.name = "Mishel";
        mishel.skill = "WPF";
        mishel.place = "Idukki";
        mishel.salary = 11000;

        Console.WriteLine($"Mahesh={mahesh.id},{mahesh.name},{mahesh.skill},{mahesh.place},{mahesh.salary}");
        Console.WriteLine($"Mishel={mishel.id},{mishel.name},{mishel.skill},{mishel.place},{mishel.salary}");
        Console.ReadKey();
    }

    
}