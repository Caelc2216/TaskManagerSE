static bool Save(string fileName, List<String> lines) {
    try {
        File.WriteAllLines($"{fileName}.svg", lines);
    }
    catch (Exception e) {
        Console.WriteLine(e.Message);
        return false;
    }
    return true;
}

static List<string>? Load(string fileName) {
    try {
        return [..File.ReadAllLines($"{fileName}.svg")];
    }
    catch (Exception e) {
        Console.WriteLine(e.Message);
        return null;
    }
}