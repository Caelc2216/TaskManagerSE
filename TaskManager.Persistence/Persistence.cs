namespace TaskManager.Persistence;
using TaskManager.Logic;

public static class Persistence
{
    public static bool Save(string fileName, List<Task> Tasks)
    {
        List<string> lines = new List<string>();
        foreach (Task task in Tasks) lines.Add(task.CSV());
        try
        {
            File.WriteAllLines($"{fileName}.svg", lines);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        return true;
    }

    public static List<string>? Load(string fileName)
    {
        try
        {
            return [.. File.ReadAllLines($"{fileName}.svg")];
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }
}