using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _availableQuestions;
    private Random _random;

    public ReflectingActivity()
        : base(
            "Reflecting Activity",
            "This activity will help you reflect on times in your "
            + "life when you have shown strength and resilience. "
            + "This will help you recognize the power you have "
            + "and how you can use it in other aspects of your life.")
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times "
                + "when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience "
                + "that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        _availableQuestions = new List<string>();
    }

    public void Run()
    {
        DisplayStartingMessage();
        _availableQuestions.Clear();

        int promptIndex = _random.Next(_prompts.Count);

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {_prompts[promptIndex]} ---");
        Console.WriteLine();

        Console.WriteLine(
            "When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine(
            "Now ponder each question as it relates to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write($"> {GetRandomQuestion()} ");

            double remainingSeconds =
                (endTime - DateTime.Now).TotalSeconds;

            if (remainingSeconds > 0)
            {
                int pauseSeconds = Math.Min(
                    8, (int)Math.Ceiling(remainingSeconds));

                ShowSpinner(pauseSeconds);
            }

            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    private string GetRandomQuestion()
    {
        if (_availableQuestions.Count == 0)
        {
            _availableQuestions.AddRange(_questions);
        }

        int index = _random.Next(_availableQuestions.Count);
        string question = _availableQuestions[index];
        _availableQuestions.RemoveAt(index);

        return question;
    }
}