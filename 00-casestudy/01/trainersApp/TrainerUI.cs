using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingFundamentalsProject
{
    internal class TrainerUI
    {
        private TrainerDAO trainerDAO = new TrainerDAO();

        public void CreateTrainer()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Place: ");
            string place = Console.ReadLine();
            Console.Write("Enter Skill: ");
            string skill = Console.ReadLine();

            Trainer trainer = new Trainer(0, name, place, skill);

            trainerDAO.Create(trainer);
            Console.WriteLine("Trainer created successfully.");
        }

        public void ReadTrainer()
        {
            Console.Write("Enter Trainer ID: ");
            int id = int.Parse(Console.ReadLine());

            Trainer trainer = trainerDAO.Read(id);
            if (trainer != null)
            {
                Console.WriteLine($"ID: {trainer.id}");
                Console.WriteLine($"Name: {trainer.name}");
                Console.WriteLine($"Place: {trainer.place}");
                Console.WriteLine($"Skill: {trainer.skill}");
            }
            else
            {
                Console.WriteLine("Trainer not found.");
            }
        }

        public void UpdateTrainer()
        {
            Console.Write("Enter Trainer ID: ");
            int id = int.Parse(Console.ReadLine());

            Trainer trainer = trainerDAO.Read(id);
            if (trainer != null)
            {
                Console.Write("Enter new Name: ");
                trainer.name = Console.ReadLine();
                Console.Write("Enter new Place: ");
                trainer.place = Console.ReadLine();
                Console.Write("Enter new Skill: ");
                trainer.skill = Console.ReadLine();

                trainerDAO.Update(trainer);
                Console.WriteLine("Trainer updated successfully.");
            }
            else
            {
                Console.WriteLine("Trainer not found.");
            }
        }

        public void DeleteTrainer()
        {
            Console.Write("Enter Trainer ID: ");
            int id = int.Parse(Console.ReadLine());

            trainerDAO.Delete(id);
            Console.WriteLine("Trainer deleted successfully.");
        }

        public void ListAllTrainers()
        {
            List<Trainer> trainers = trainerDAO.ListAll();
            foreach (Trainer trainer in trainers)
            {
                Console.WriteLine($"ID: {trainer.id}, Name: {trainer.name}, Place: {trainer.place}, Skill: {trainer.skill}");
            }
        }
    }
}
