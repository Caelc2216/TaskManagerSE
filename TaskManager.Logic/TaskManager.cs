namespace TaskManager.Logic
{
    public class ParseSVG(List<string> svgFile)
    {
        private List<string> svgFile = svgFile;
        public List<Task> Tasks { get; set; } = new();
        public List<Task> Parse()
        {
            List<Task> tasks = new List<Task>();
            foreach (string line in svgFile)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 4)
                {
                    string name = parts[0];
                    string description = parts[1];
                    DateTime timeline = DateTime.Parse(parts[2]);
                    int id = int.Parse(parts[3]);
                    bool isComplete = bool.Parse(parts[4]);
                    tasks.Add(new Task(name, description, timeline, id,isComplete));
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
        public string CSV() => $"{Name},{Description},{Timeline},{Id},{IsComplete}";
        public void MarkAsComplete() => IsComplete = !IsComplete;
        public override string ToString() => $"Task: {Name}, Description: {Description}, Timeline: {Timeline}, Id: {Id}";
    }
}