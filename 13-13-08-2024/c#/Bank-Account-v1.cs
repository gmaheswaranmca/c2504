
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;


namespace ProgramingFundamentalsProject
{
    class Account // Savings Account
    {
        public string number;
        private float balance;
        public float Balance
        {
            private set { balance = value; }
            get { return balance; }
        }
        public Account(string _number)
        {
            number = _number;
            Balance = 0;
        }
        public void deposit(float amount) 
        {
            Balance += amount;
        }
        public void withdraw(float amount)
        {
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
}
