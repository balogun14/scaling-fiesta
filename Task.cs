using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace TaskAllocator
{
    public class ClassTask
    {
        public string name;
        public int count;
        private static string[] task = new string[] { "Classroom", "Toilet", "serving", "dishwashing", "Dining-room" };
        private static readonly Random random = new();
        private static readonly string adminPass = "#AQWER";
        public ClassTask(string name)
        {
            this.name = name;
            this.count++;

        }

        public static void AddName(List<ClassTask> taskList)
        {
            Console.WriteLine(Environment.NewLine);
            bool check = Authenticate();
            if (check == true)
            {
                MessageWithColor("Welcome Admin");
                Console.Write("What is the name you want to add: ");
                string userChoice = Console.ReadLine()!;
                taskList.Add(new ClassTask(userChoice));
                MessageWithColor($"{userChoice} was added");
            }
            else
            {
                MessageWithColor("Wrong Pass", ConsoleColor.DarkRed);
            }
        }
        public static void NameSearch(List<ClassTask> taskList)
        {
            Console.WriteLine(Environment.NewLine);
            Console.Write("What is the name you want to search: ");
            string userChoice = Console.ReadLine()!;
            var nameEntered = new ClassTask(userChoice);
            var result = taskList.FindAll(nameEntered => nameEntered.name!.Contains(userChoice, StringComparison.OrdinalIgnoreCase));
            if (result == null)
            {
                MessageWithColor("No result found..", ConsoleColor.DarkRed);
                return;
            }
            foreach (var item in result)
            {
                int number = random.Next(0, task.Length);
                Console.WriteLine($"{item.name} you were assigned to {task[number]}");
                Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
            }
        }
        public static void ViewAllNames(List<ClassTask> classTasks)
        {
            Console.WriteLine(Environment.NewLine);
            var check = Authenticate();
            if (check == true)
            {
                MessageWithColor("Welcome Admin");
                foreach (var item in classTasks)
                {
                    int number = random.Next(0, task.Length);
                    Console.WriteLine($"{item.name} was assigned to {task[number]}");
                    Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
                }
            }else
            {
                MessageWithColor("Wrong Pass", ConsoleColor.DarkRed);
            }
        }
        public static void MessageWithColor(string message, ConsoleColor consoleColor = ConsoleColor.Green)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        private static bool Authenticate()
        {
            Console.Write("What is the pass: ");
            string userPass = Console.ReadLine()!;
            if (userPass.Equals(adminPass))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}