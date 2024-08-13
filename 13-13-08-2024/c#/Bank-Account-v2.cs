class Account // Savings Account
{
    public string number;
    private float balance;
    public float Balance
    {
        private set {
            if(value < 0 )
            {
                Console.WriteLine("You are not allowed to update the negative balance.\n");
                return;
            }
            if (value > 5000000)
            {
                Console.WriteLine("You are not allowed to update the balance above 5000000.\n");
                return;
            }
            balance = value; 
            //code 
        }
        get { /*code*/return balance; }
    }
    public Account(string _number)
    {
        number = _number;
        Balance = 0;
    }
    public void deposit(float amount) 
    {
        if (amount > 1000000) //Biz Rule 2
        {
            Console.WriteLine("You cannot deposit more than Rs.10 lacks.\nTransaction cancelled.");
            return;
        }
        Balance += amount;
    }
    public void withdraw(float amount)
    {
        if((Balance - amount) < 0 ) //Biz Rule 1
        {
            Console.WriteLine("You cannot withdraw more than your balance.\nTransaction cancelled.");
            return;
        }
        Balance -= amount;
    }
}
internal class Program
{
    static void Main(string[] args) 
    {

        Account sahlaAc = new Account("1001200230034");//balance = 0
        sahlaAc.deposit(500000); //balance = 5,00,000   
        sahlaAc.deposit(200000); //balance = 7,00,000
        sahlaAc.withdraw(75000); //balance = 6,25,000
        Console.WriteLine($"Sahla account balance is {sahlaAc.Balance}");
        sahlaAc.withdraw(700000); //balance = -75,000
        Console.WriteLine($"Sahla account balance is {sahlaAc.Balance}");
        sahlaAc.withdraw(625000); //balance = 0 
        Console.WriteLine($"Sahla account balance is {sahlaAc.Balance}");
        sahlaAc.deposit(1000001); //balance = 0
        Console.WriteLine($"Sahla account balance is {sahlaAc.Balance}");
        sahlaAc.deposit(1000000); //balance = 10,00,000
        Console.WriteLine($"Sahla account balance is {sahlaAc.Balance}");
        //sahlaAc.Balance = 45; //ERR...
        Console.WriteLine($"Sahla account balance is {sahlaAc.Balance}");
        Console.ReadKey();
    }
}