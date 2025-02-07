using TaskManager;
namespace Logic
{
    public class Logic
    {
        List<TaskManager.Task> tasks = new();
        public void DisplayList()
        {
            Console.WriteLine($"{"ID",10}{"Task",15}");
            foreach (TaskManager.Task t in tasks)
            {
                Console.WriteLine($"{t.Id,10}{t.Name,15}");
            }
        }

        public void DeleteTask(int id)
        {
            foreach (TaskManager.Task task in tasks)
            {
                if (task.Id == id)
                {
                    tasks.Remove(task);
                }
            }
        }

        public void AddTask(string name, string description)
        {
            DateTime time = DateTime.Now;
            int id = DateTime.Now.Millisecond;
            TaskManager.Task newTask = new(name, description, time, id);
            tasks.Add(newTask);
        }

        public void MarkTaskAsComplete(int id)
        {
            foreach (TaskManager.Task task in tasks)
            {
                if (task.Id == id)
                {
                    task.IsComplete = true;
                }
            }
        }

        public void SortAlphabetical()
        {
            tasks.Sort();
        }
    }
}