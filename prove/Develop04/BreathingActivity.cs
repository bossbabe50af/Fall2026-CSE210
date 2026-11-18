using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you "
            + "through breathing in and out slowly. Clear your "
            + "mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        int remainingSeconds = GetDuration();

        while (remainingSeconds > 0)
        {
            int breathSeconds = Math.Min(4, remainingSeconds);

            Console.Write("Breathe in... ");
            ShowCountDown(breathSeconds);
            Console.WriteLine();

            remainingSeconds = remainingSeconds - breathSeconds;

            if (remainingSeconds > 0)
            {
                breathSeconds = Math.Min(6, remainingSeconds);

                Console.Write("Breathe out... ");
                ShowCountDown(breathSeconds);
                Console.WriteLine();

                remainingSeconds = remainingSeconds - breathSeconds;
            }
        }

        DisplayEndingMessage();
    }
}