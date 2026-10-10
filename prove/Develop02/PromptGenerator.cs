public class PromptGenerator
{
    private readonly List<string> _prompts = new()
    {
        "What small accomplishment am I proud of today?",
        "Who helped me today, and how can I thank them?",
        "What did I learn from a challenge today?",
        "What moment today would I like to remember?",
        "What am I grateful for that I usually overlook?",
        "What is one kind thing I can do tomorrow?",
        "When did I feel most at peace today?"
    };

    public string GetRandomPrompt()
    {
        return _prompts[Random.Shared.Next(_prompts.Count)];
    }
}

