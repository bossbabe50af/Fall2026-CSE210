
using System.Text.Json;

public class Journal
{
    private List<Entry> _entries = new();

    public int GetCount()
    {
        return _entries.Count;
    }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is empty.");
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.IncludeFields = true;
        options.WriteIndented = true;

        string json = JsonSerializer.Serialize(_entries, options);
        File.WriteAllText(filename, json);
    }

    public void LoadFromFile(string filename)
    {
        // Validate the file before replacing the current journal.
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.IncludeFields = true;

        string json = File.ReadAllText(filename);

        List<Entry>? loaded =
            JsonSerializer.Deserialize<List<Entry>>(json, options);

        if (loaded == null)
        {
            throw new InvalidDataException(
                "The file does not contain valid journal entries.");
        }

        foreach (Entry entry in loaded)
        {
            if (entry == null ||
                string.IsNullOrWhiteSpace(entry._date) ||
                string.IsNullOrWhiteSpace(entry._prompt) ||
                entry._response == null ||
                entry._mood == null)
            {
                throw new InvalidDataException(
                    "The file does not contain valid journal entries.");
            }
        }

        _entries = loaded;
    }
}