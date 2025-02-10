namespace TaskManager.Persistence;
using TaskManager.Logic;

public static class Persistence
{
    public static bool Save(string fileName, List<Task> Tasks)
    {
        List<string> lines = [];
        foreach (Task task in Tasks) lines.Add(task.CSV());
        try
        {
            File.WriteAllLines($"{fileName}.txt", lines);
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
            return [.. File.ReadAllLines($"{fileName}.txt")];
        }
        catch
        {
            File.WriteAllLines($"{fileName}.txt", new List<string>());
            return [];
        }
    }
}