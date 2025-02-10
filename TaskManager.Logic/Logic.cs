namespace TaskManager.Logic;

public class Logic
    {
        public List<Task> tasks = new();
        public void DisplayList()
        {
            Console.WriteLine($"{"ID",10}{"Task",15}{"Completed", 10}");
            foreach (Task t in tasks)

            {
                string IsComplete = t.IsComplete? "[x]" : "[ ]";
                Console.WriteLine($"{t.Id,10}{t.Name,15}{IsComplete,10}");
            }
        }

        public void DeleteTask(int id)
        {
            foreach (Task task in tasks)
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
            Task newTask = new(name, description, time, id);
            tasks.Add(newTask);
        }

        public void MarkTaskAsComplete(int id)
        {
            foreach (Task task in tasks)
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
