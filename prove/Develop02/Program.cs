using System.Text.Json;

// Exceeding requirements: entries include an optional mood. 
// JSON storage preserves commas, quotation marks, and newlines without separator collisions. 

// Invalid files are rejected before replacing the current journal, and file errors are
// reported without ending the program.

//AI Assistance Acknowledgement 
// I used ChatGPT as a learning and debugging resource.
// It assisted helping me with reviewing C# syntax, identifying errors,
// understanding abstraction, and reviewing the Journal program.
// I reviewed all or any suggestions of changes and I tested the program's
// writing, displaying, saving, and loading features.
public class Program
{
    public static void Main()
    {
        //creates the journal and prompt generator objects        
        Journal journal = new();
        PromptGenerator prompts = new();
        Console.WriteLine("Welcome to the Journal Program!");

        //keeps displaying the menu until prompted with 5 to quit
        while (true)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");
            Console.Write("What would you like to do? ");
            string? choice = Console.ReadLine();

            //exits the program if the user chooses 5
            if (choice == null || choice.Trim() == "5")
                return;
            //runs the action from the selected menu
            switch (choice.Trim())
            {
                case "1":
                    //selects random prompt and get the users response
                    string prompt = prompts.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string? response = Console.ReadLine();
                    if (response == null) return;
                    //allow the user to record optional mood
                    Console.Write("Mood (optional; press Enter to skip): ");
                    string mood = Console.ReadLine() ?? "";
                    //creates a new entry adds it to the journal
                    journal.AddEntry(new Entry
                    {
                        _date = DateTime.Now.ToShortDateString(),
                        _prompt = prompt,
                        _response = response,
                        _mood = mood
                    });
                    Console.WriteLine("Entry added.");
                    break;
                //displays every entry currently stroed in the journal
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                case "4":
                    //ask for a filename when loading or saving user data
                    Console.Write("Filename (for example, journal.json): ");
                    string? filename = Console.ReadLine();
                    //prevents empty filename from being used
                    if (string.IsNullOrWhiteSpace(filename))
                    {
                        Console.WriteLine("Please enter a filename.");
                        break;
                    }
                    try
                    {
                        if (choice.Trim() == "3")
                        {
                            //loads saved emtries
                            journal.LoadFromFile(filename.Trim());
                            Console.WriteLine($"Loaded {journal.GetCount()} entries.");
                        }
                        else
                        {
                            //saves all current journal entries to a file
                            journal.SaveToFile(filename.Trim());
                            Console.WriteLine($"Saved {journal.GetCount()} entries.");
                        }
                    }
                    catch (Exception error) when (error is IOException ||
                        error is UnauthorizedAccessException || error is JsonException ||
                        error is ArgumentException || error is NotSupportedException)
                    {
                        //Display file error without terminating the program
                        Console.WriteLine($"Unable to complete the file operation: {error.Message}");
                    }
                    break;
                default:
                    //handles menu choices outside value range
                    Console.WriteLine("Please choose a number from 1 to 5.");
                    break;
            }
        }
    }
}

//AI Assistance Acknowledgement 
// I used ChatGPT as a learning and debugging resource.
// It assisted helping me with reviewing C# syntax, identifying errors,
// understanding abstraction, and reviewing the Journal program.
// I reviewed all or any suggestions of changes and I tested the program's
// writing, displaying, saving, and loading features.
