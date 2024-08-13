using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args) 
    {
        private int id;
        private string name;
        private string skill;
        private string place;
        private float salary;
        public TrainerV2(int id, string name, string skill, string place, float salary)
        {
            this.id = id;
            this.name = name;
            this.skill = skill;
            this.place = place;
            this.salary = salary;
        }

        public TrainerV2()
        {
            this.id = 0;
            this.name = "";
            this.skill = "";
            this.place = "";
            this.salary = 0;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Skill { get => skill; set => skill = value; }
        public string Place { get => place; set => place = value; }
        public float Salary { get => salary; set => salary = value; }
    }

    internal class TestTrainerV2
    {
        static void MainTrainerV2(string[] args)
        {
            TrainerV2 mahesh = new TrainerV2(10, "Mahesh", "C#",
                    "Mysore", 9000);
            Console.WriteLine($"Mahesh={mahesh.Id},{mahesh.Name},{mahesh.Skill},{mahesh.Place},{mahesh.Salary}");
            TrainerV2 mishel = new TrainerV2();
            mishel.Id = 20;
            mishel.Name = "Mishel";
            mishel.Skill = "WPF";
            mishel.Place = "Idukki";
            mishel.Salary = 11000;
            Console.WriteLine($"Mishel={mishel.Id},{mishel.Name},{mishel.Skill},{mishel.Place},{mishel.Salary}");
        }
    }
}
