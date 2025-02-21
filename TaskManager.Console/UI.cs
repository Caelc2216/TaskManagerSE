using TaskManager.Logic;
using TaskManager.Persistence;
public partial class Program
{
    public static void Main(string[] args)
    {
        reinitialize: string listName;
        
        if (args.Length != 1) {
            Console.Clear();
            Console.Write("What is the name of your task list? ");
            listName = Console.ReadLine() ?? "";
            if (listName == "") goto reinitialize;
        } else {
            listName = args[0];
        }

        bool IsRunning = true;
        List<string> Lines = Persistence.Load(listName)!;
        ParseCSV ParseClass = new(Lines);
        List<Task> todoTasks = ParseClass.Parse();
        Logic UILogic = new() { tasks = todoTasks };

        while (IsRunning)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Welcome to the task manager!\nWhat would you like to do?");
            Console.WriteLine();
            Console.Write("1. Add new task\n2. Remove task\n3. Display task list\n4. Mark task as complete\n5. Close Program\n");
            int userResponse = int.Parse(Console.ReadLine() ?? "");

            switch (userResponse)
            {
                case 1: //Add new task
                    Console.Clear();
                    Console.WriteLine("What is the name of your task?");
                    Console.Write("Task name: ");
                    string taskName = Console.ReadLine() ?? "";
                    Console.WriteLine("Write a brief description of what you need to do for this task.");
                    Console.Write("Task Description: ");
                    string taskDescription = Console.ReadLine() ?? "";

                    Console.Clear();
                    UILogic.AddTask(taskName, taskDescription);
                    Console.WriteLine("Task added to task list.");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                case 2: //Remove task
                    Console.Clear();
                    UILogic.DisplayList();
                    Console.WriteLine("What task would you like to remove?");
                    Console.Write("Task ID: ");
                    int result;
                    while (!int.TryParse(Console.ReadLine() ?? "", out result))
                    {
                        Console.WriteLine("Invalid Input.");
                        Console.Write("Task ID: ");
                    }

                    Console.Clear();

                    try
                    {
                        UILogic.DeleteTask(result);
                    }
                    catch
                    {
                        Console.WriteLine("Task not found.");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                case 3: //Display task list
                    Console.Clear();
                    UILogic.DisplayList();
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                case 4: //Mark task as complete
                    Console.Clear();
                    UILogic.SortAlphabetical();
                    UILogic.DisplayList();
                    Console.WriteLine();
                    Console.WriteLine("Which task would you like to be marked as complete?");
                    Console.Write("Task ID: ");
                    int result2;
                    while (!int.TryParse(Console.ReadLine() ?? "", out result2))
                    {
                        Console.WriteLine("Invalid Input.");
                        Console.Write("Task ID: ");
                    }

                    Console.Clear();

                    try
                    {
                        UILogic.MarkTaskAsComplete(result2);
                    }
                    catch
                    {
                        Console.WriteLine("Task not found.");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                case 5: //Close Program
                    Console.ForegroundColor = default;
                    Console.Clear();
                    // Method for saving data into a .txt file
                    Persistence.Save(listName, UILogic.tasks);
                    Console.WriteLine("Closing program.");
                    Console.ForegroundColor = ConsoleColor.White;
                    IsRunning = false;
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("I am not sure what you meant by that. Please try again.");
                    break;
            }
        }
    }
}