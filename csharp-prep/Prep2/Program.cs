using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade average?");
        string answer = Console.ReadLine();
        int average = int.Parse(answer);

        string letter = "";

        if (average >= 90)
        { letter = "A"; }

        else if (average >= 80)
        { letter = "B"; }
        

        else if (average >= 70)
        { letter = "C"; }

        else if (average >= 60)
        { letter = "D"; }

        else
        { letter = "F"; }

        Console.WriteLine($"Your grade is: {letter}");

        if (average >= 70)

            Console.WriteLine("You passed!");

        else
        {
            Console.WriteLine("You have not made it yet!");
        }


    }
}
