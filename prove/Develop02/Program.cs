using System.Text.Json;

// Exceeding requirements: entries include an optional mood. JSON storage preserves
// commas, quotation marks, and newlines without separator collisions. Invalid
// files are rejected before replacing the current journal, and file errors are
// reported without ending the program.
public class Program
{
    public static void Main()
    {
        Journal journal = new();
        PromptGenerator prompts = new();
        Console.WriteLine("Welcome to the Journal Program!");

        while (true)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");
            Console.Write("What would you like to do? ");
            string? choice = Console.ReadLine();
            if (choice == null || choice.Trim() == "5")
                return;

            switch (choice.Trim())
            {
                case "1":
                    string prompt = prompts.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string? response = Console.ReadLine();
                    if (response == null) return;
                    Console.Write("Mood (optional; press Enter to skip): ");
                    string mood = Console.ReadLine() ?? "";
                    journal.AddEntry(new Entry
                    {
                        _date = DateTime.Now.ToShortDateString(),
                        _prompt = prompt,
                        _response = response,
                        _mood = mood
                    });
                    Console.WriteLine("Entry added.");
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                case "4":
                    Console.Write("Filename (for example, journal.json): ");
                    string? filename = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(filename))
                    {
                        Console.WriteLine("Please enter a filename.");
                        break;
                    }
                    try
                    {
                        if (choice.Trim() == "3")
                        {
                            journal.LoadFromFile(filename.Trim());
                            Console.WriteLine($"Loaded {journal.GetCount()} entries.");
                        }
                        else
                        {
                            journal.SaveToFile(filename.Trim());
                            Console.WriteLine($"Saved {journal.GetCount()} entries.");
                        }
                    }
                    catch (Exception error) when (error is IOException ||
                        error is UnauthorizedAccessException || error is JsonException ||
                        error is ArgumentException || error is NotSupportedException)
                    {
                        Console.WriteLine($"Unable to complete the file operation: {error.Message}");
                    }
                    break;
                default:
                    Console.WriteLine("Please choose a number from 1 to 5.");
                    break;
            }
        }
    }
}
