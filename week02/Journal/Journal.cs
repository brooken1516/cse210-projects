using System;

public class Journal
{
    public List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry theEntry in _entries)
        {
            theEntry.Display();
            Console.WriteLine();
        }
    }

    public void DisplayChronological()
    {
        Console.WriteLine("\n--- Journal Entries in Chronological Order ---\n");

        var sortedEntries = _entries
            .OrderBy(e => DateTime.Parse(e._date))
            .ToList();

        foreach (Entry anEntry in sortedEntries)
        {
            anEntry.Display();
        }

        Console.WriteLine("\n--- End of Entries ---\n");

    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry anEntry in _entries)
            {
                outputFile.WriteLine($"{anEntry._date}|{anEntry._promptText}|{anEntry._entryText}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        _entries.Clear();

        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                string[] parts = line.Split('|');
                if (parts.Length >= 3)
                {
                    string date = parts[0].Trim();
                    string prompt = parts[1].Trim();
                    string response = parts[2].Trim();

                    Entry anEntry = new Entry(prompt, response);
                    anEntry._date = date;
                    _entries.Add(anEntry);
                }
            }
        }
    }
}