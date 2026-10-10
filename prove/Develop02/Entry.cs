public class Entry
{
    public string _date = "";
    public string _prompt = "";
    public string _response = "";
    public string _mood = "";

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");


        if (!string.IsNullOrWhiteSpace(_mood))
            Console.WriteLine($"Mood: {_mood}");

        Console.WriteLine();
    }
}
