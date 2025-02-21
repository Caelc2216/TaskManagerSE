using System.Linq.Expressions;

namespace TaskManager.Logic;

public class Logic
{
    public List<Task> tasks = [];
    public void DisplayList()
    {
        Console.WriteLine($"{"ID",10}{"Task",15}{"Completed",10}");
        foreach (Task t in tasks)
        {
            string IsComplete = t.IsComplete ? "[x]" : "[ ]";
            Console.WriteLine($"{t.Id,10}{t.Name,15}{IsComplete,10}");
        }
    }
    public void DeleteTask(int id)
    {
        bool taskFound = false;
        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].Id == id)
            {
                taskFound = true;
                tasks.Remove(tasks[i]);
            }
        }

        if (taskFound == false)
        {
            throw new Exception("Task not found");
        }
        else
        {
            Console.WriteLine("Task removed from task list.");
        }
    }
    public void AddTask(string name, string description)
    {
        int id = DateTime.Now.Millisecond;
        Task newTask = new(name, description, DateTime.Now, id);
        tasks.Add(newTask);
    }
    public void MarkTaskAsComplete(int id)
    {
        bool taskFound = false;
        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].Id == id)
            {
                taskFound = true;
                tasks[i].MarkAsComplete();
                break;
            }
        }

        if (taskFound == false)
        {
            throw new Exception("Task not found");
        }
        else
        {
            Console.WriteLine("Task marked as complete.");
        }

        
    }
    public void SortAlphabetical()
    {
        tasks = tasks.OrderBy(t => t.Name).ToList();
    }
}
