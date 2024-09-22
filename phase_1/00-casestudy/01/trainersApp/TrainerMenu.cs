using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingFundamentalsProject
{
    internal class TrainerMenu
    {
        public static void Menu()
        {
            TrainerUI ui = new TrainerUI();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nTrainer Management System");
                Console.WriteLine("1. Create Trainer");
                Console.WriteLine("2. Read Trainer");
                Console.WriteLine("3. Update Trainer");
                Console.WriteLine("4. Delete Trainer");
                Console.WriteLine("5. List All Trainers");
                Console.WriteLine("6. Exit");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ui.CreateTrainer();
                        break;
                    case "2":
                        ui.ReadTrainer();
                        break;
                    case "3":
                        ui.UpdateTrainer();
                        break;
                    case "4":
                        ui.DeleteTrainer();
                        break;
                    case "5":
                        ui.ListAllTrainers();
                        break;
                    case "6":
                        running = false;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
