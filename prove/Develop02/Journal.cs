
using System.Text.Json;

public class Journal
{
    //stores all journal entries as a list
    private List<Entry> _entries = new();
    //returns number of entries currently in the journal
    public int GetCount()
    {
        return _entries.Count;
    }
    //adds new entry to the journal
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }
    //displays every stored entry in journal
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
    //save the complete journal to a JSON file
    public void SaveToFile(string filename)
    {
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.IncludeFields = true;
        options.WriteIndented = true;

        string json = JsonSerializer.Serialize(_entries, options);
        File.WriteAllText(filename, json);
    }
    //load saved entries from JSON file
    public void LoadFromFile(string filename)
    {
        // configuration to read the entry fields
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.IncludeFields = true;

        string json = File.ReadAllText(filename);

        List<Entry>? loaded =
            JsonSerializer.Deserialize<List<Entry>>(json, options);
        // Check that the file contains a valid journal list.
        if (loaded == null)
        {
            throw new InvalidDataException(
                "The file does not contain valid journal entries.");
        }
        // Validate each entry before changing the current journal.
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
        // Replace the current journal only after validation succeeds.
        _entries = loaded;
    }
}