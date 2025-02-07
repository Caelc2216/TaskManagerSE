namespace TaskManager
{
    public class ParseSVG(List<string> svgFile)
    {
        private List<string> svgFile;
        public List<Task> Tasks { get; set; } = new List<Task>();

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
                    tasks.Add(new Task(name, description, timeline, id));
                }
            }
            return tasks;
        }
    }
    public class Task(string Name, string Description, DateTime Timeline, int Id)
    {
        public string Name { get; set; } = Name;
        public string Description { get; set; } = Description;
        public DateTime Timeline { get; set; } = Timeline;
        public int Id { get; set; } = Id;
        public bool IsComplete { get; set; } = false;
        public string CSV() => $"{Name},{Description},{Timeline},{Id}";
        public void MarkAsComplete() => IsComplete = !IsComplete;
        public override string ToString() => $"Task: {Name}, Description: {Description}, Timeline: {Timeline}, Id: {Id}";
    }
}