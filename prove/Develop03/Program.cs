using System;

class Program
{
    // Exceeds requirements: randomly chooses a scripture from a small library,
    // including a verse range. Each round hides only words still visible, so
    // every Enter press makes progress without selecting already hidden words.
    static void Main(string[] args)
    {
        Scripture[] library =
        {
            new Scripture(new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture(new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me.")
        };
        Scripture scripture = library[Random.Shared.Next(library.Length)];

        while (true)
        {
            // Redirected output is supported for automated checks and saved sessions.
            if (!Console.IsOutputRedirected)
            {
                Console.Clear();
            }
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.Write("Press Enter to hide words, or type quit to finish: ");
            string input = Console.ReadLine();
            if (input == null || input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
            if (string.IsNullOrWhiteSpace(input))
            {
                scripture.HideRandomWords(3);
            }
        }
    }
}
