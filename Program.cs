/*
This is a simple task generator built using c#
*/

using TaskAllocator;

class Program
{
    public static void Main()
    {
        var dashboardMessage = @"Welcome to the dashboard 
        Press 1 to search for your name.
        press 2 to view all names (you must be an admin to do this).
        press 3 to add new name (you must be an admin to do this).
        press q to exit.: ";
        bool condition = true;
        var namesList = new List<ClassTask>() {
            new("Awwal"),
            new("Tawab"),
            new("Khalilur-Rahamn"),
            new("Saleem-Ahmad"),
            new("AhmadRaza"),
            new("AbdulBasit"),
            new("AbudlHafeez"),
            new("Odus"),
            new("Faruq"),
            new("Abdulraheem"),
            new("Abdullahi"),
            new("Olayiwola"),
            new("Tahir"),
            new("Agbola"),

        };

        while (condition)
        {
            Console.WriteLine(dashboardMessage);
            string userChoice = Console.ReadLine()!;
            if (userChoice == "1")
            {
                ClassTask.NameSearch(namesList);
            }
            else if (userChoice == "2")
            {
                ClassTask.ViewAllNames(namesList);
            }
            else if (userChoice == "3")
            {
                ClassTask.AddName(namesList);
            }
            else if (userChoice.Equals("q", StringComparison.OrdinalIgnoreCase))
            {
                ClassTask.MessageWithColor("You exited");
                condition = false;
            }
            else
            {
                ClassTask.MessageWithColor("You did not follow the instructions");
            }
        }
    }
}