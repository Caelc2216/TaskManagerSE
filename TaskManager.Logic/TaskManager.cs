namespace TaskManager.Logic
{
    public class ParseCSV(List<string> csvFile)
    {
        private readonly List<string> csvFile = csvFile;
        public List<Task> Tasks { get; set; } = [];
        public List<Task> Parse()
        {
            List<Task> tasks = [];
            foreach (string line in csvFile)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 4)
                {
                    string name = parts[0];
                    string description = parts[1];
                    DateTime timeline = DateTime.Parse(parts[2]);
                    int id = int.Parse(parts[3]);
                    bool isComplete;
                    
                    try {
                        isComplete = bool.Parse(parts[4]);
                    }
                    catch {
                        isComplete = false;
                    }
                    tasks.Add(new Task(name, description, timeline, id, isComplete));
                }
                else {
                    throw new ArgumentException("Invalid number of arguments!");
                }
            }
            return tasks;
        }
    }
    public class Task(string Name, string Description, DateTime Timeline, int Id, bool IsComplete = false)
    {
        public string Name { get; set; } = Name;
        public string Description { get; set; } = Description;
        public DateTime Timeline { get; set; } = Timeline;
        public int Id { get; set; } = Id;
        public bool IsComplete { get; set; } = IsComplete;
        public void MarkAsComplete() => IsComplete = !IsComplete;
        public override string ToString() => $"{Name},{Description},{Timeline},{Id},{IsComplete}";
    }
}