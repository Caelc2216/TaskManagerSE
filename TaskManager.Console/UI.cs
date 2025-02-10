/* Class Name Task
DisplayMenu()
DeleteTask()
AddTask()
MarkTaskAsComplete()
Save()
Load()
SortAlphabetical()
*/

using System;
// using TaskManager.Persistence;
using TaskManager.Logic;

public partial class Program
{
    public static void Main(string[] args)
    {
        // Persistence.Load(); //Add name of the file
        bool IsRunning = true;
        string listName;
        List<TaskManager.Task> todoTasks = new();
        Logic UILogic = new Logic();

        while (IsRunning)
        {
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
                    UILogic.AddTask(todoTasks, taskName, taskDescription);
                    Console.WriteLine("Task added to task list.");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                case 2: //Remove task
                    Console.Clear();
                    UILogic.DisplayList(todoTasks);
                    Console.WriteLine("What task would you like to remove?");
                    Console.Write("Task ID: ");
                    int taskRemove = int.Parse(Console.ReadLine() ?? "");

                    Console.Clear();
                    UILogic.DeleteTask(todoTasks, taskRemove);
                    Console.WriteLine("Task removed from task list.");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                case 3: //Display task list
                    Console.Clear();
                    UILogic.DisplayList(todoTasks);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                case 4: //Mark task as complete
                    Console.Clear();
                    UILogic.SortAlphabetical(todoTasks);
                    UILogic.DisplayList(todoTasks);
                    Console.WriteLine();
                    Console.WriteLine("Which task would you like to be marked as complete?");
                    Console.Write("Task ID: ");
                    int taskCompleted = int.Parse(Console.ReadLine() ?? "");

                    Console.Clear();
                    UILogic.MarkTaskAsComplete(todoTasks, taskCompleted);
                    Console.WriteLine("Task marked as complete.");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                case 5: //Close Program
                    Console.Clear();
                    // Persistence.Save(listName, tasks);
                    Console.WriteLine("Closing program.");
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