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
        foreach (Task task in tasks)
        {
            if (task.Id == id)
            {
                taskFound = true;
                tasks.Remove(task);
            }
        }

        if (taskFound == false)
        {
            throw new Exception("Task not found");
        }
    }
    public void AddTask(string name, string description)
    {
        DateTime time = DateTime.Now;
        int id = DateTime.Now.Millisecond;
        Task newTask = new(name, description, time, id);
        tasks.Add(newTask);
    }
    public void MarkTaskAsComplete(int id)
    {
        bool taskFound = false;
        foreach (Task task in tasks)
        {
            if (task.Id == id)
            {
                task.IsComplete = true;
            }
        }

        if (taskFound == false)
        {
            throw new Exception("Task not found");
        }

        
    }
    public void SortAlphabetical()
    {
        tasks.Sort();
    }
}
