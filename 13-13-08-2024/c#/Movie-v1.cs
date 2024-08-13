
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;


namespace ProgramingFundamentalsProject
{
    class Movie
    {
        public int id;
        public string name;
        public Movie(int _id, string _name)
        {
            id = _id;
            name = _name;
        }
        public Movie()
        {
            id = 0;
            name = "";
        }
    }
    internal class Program
    {
        static void Main(string[] args) 
        {
            Movie manjummelBoys = new Movie(1001, "Manjummel Boys");
            Movie aavesham = new Movie();
            aavesham.id = 1002;
            aavesham.name = "Aavesham";

            Console.WriteLine($"id={manjummelBoys.id}, name={manjummelBoys.name}");
            Console.WriteLine($"id={aavesham.id}, name={aavesham.name}");
            Console.ReadKey();
        }



    }
}
/*
Output:
id=1001, name=Manjummel Boys
id=1002, name=Aavesham
*/