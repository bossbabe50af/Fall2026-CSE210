using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private Random _random;

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good "
            + "things in your life by having you list as many "
            + "things as you can in a certain area.")
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        int index = _random.Next(_prompts.Count);

        Console.WriteLine("List as many responses as you can:");
        Console.WriteLine();
        Console.WriteLine($"--- {_prompts[index]} ---");
        Console.WriteLine();
        Console.WriteLine("Press Enter after each item.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        List<string> entries = GetListFromUser();

        Console.WriteLine();
        Console.WriteLine($"You listed {entries.Count} items!");

        DisplayEndingMessage();
    }

    private List<string> GetListFromUser()
    {
        List<string> entries = new List<string>();
        string currentEntry = "";
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        Console.Write("> ");

        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();

                    if (!string.IsNullOrWhiteSpace(currentEntry))
                    {
                        entries.Add(currentEntry.Trim());
                    }

                    currentEntry = "";
                    Console.Write("> ");
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (currentEntry.Length > 0)
                    {
                        currentEntry = currentEntry.Substring(
                            0, currentEntry.Length - 1);

                        Console.Write("\b \b");
                    }
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    currentEntry = currentEntry + key.KeyChar;
                    Console.Write(key.KeyChar);
                }
            }
            else
            {
                Thread.Sleep(20);
            }
        }

        Console.WriteLine();
        Console.WriteLine("Time is up!");

        return entries;
    }
}