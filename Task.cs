namespace TaskManager {
    public class Task(string Name, string Description, DateTime Timeline, int Id) {
        public string Name { get; set; } = Name;
        public string Description { get; set; } = Description;
        public DateTime Timeline { get; set; } = Timeline;
        public int Id { get; set; } = Id;
        public bool IsComplete { get; set; } = false;
        public void MarkAsComplete() => IsComplete = !IsComplete;
        public override string ToString() =>  $"Task: {Name}, Description: {Description}, Timeline: {Timeline}, Id: {Id}";
    }