public class Entry
{
    //store info for one journal entry
    public string _date = "";
    public string _prompt = "";
    public string _response = "";
    public string _mood = "";

    public void Display()
    {
        //displays the date, prompt, and response
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");

        //displays the mood only if user enters one
        if (!string.IsNullOrWhiteSpace(_mood))
            Console.WriteLine($"Mood: {_mood}");

        //adds blank line between journal entried 
        Console.WriteLine();
    }
}
