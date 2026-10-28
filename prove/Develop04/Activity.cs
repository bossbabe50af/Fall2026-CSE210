using System;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write(
            "How long, in seconds, would you like for your session? ");

        while (!int.TryParse(Console.ReadLine(), out _duration)
            || _duration <= 0)
        {
            Console.Write("Please enter a positive whole number: ");
        }

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);

        Console.WriteLine();
        Console.WriteLine(
            $"You have completed another {_duration} seconds of the {_name}.");

        ShowSpinner(3);
        Console.WriteLine();
    }

    public void ShowSpinner(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(frames[index]);
            Thread.Sleep(100);
            Console.Write("\b \b");

            index++;

            if (index == frames.Length)
            {
                index = 0;
            }
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int number = seconds; number > 0; number--)
        {
            string text = number.ToString();
            Console.Write(text);
            Thread.Sleep(1000);

            for (int position = 0; position < text.Length; position++)
            {
                Console.Write("\b");
            }

            for (int position = 0; position < text.Length; position++)
            {
                Console.Write(" ");
            }

            for (int position = 0; position < text.Length; position++)
            {
                Console.Write("\b");
            }
        }
    }
}