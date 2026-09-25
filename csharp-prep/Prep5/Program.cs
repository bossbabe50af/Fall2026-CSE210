using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string userName = PromptUserName();
        int number = PromptUserNumber();

        int squaredNumber = SquareNumber(number);

        int bYear;
        PromptUserBirthYear(out bYear);

        DisplayResult(userName, squaredNumber, bYear);
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();

        return userName;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number? ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    static void PromptUserBirthYear(out int bYear)
    {
        Console.Write("Enter the birth year that you were born: ");
        bYear = int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        int squaredNumber = number * number;

        return squaredNumber;
    }

    static void DisplayResult(string userName, int squaredNumber, int bYear)
    {
        int currentYear = DateTime.Now.Year;
        int age = currentYear - bYear;

        Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");
        Console.WriteLine($"{userName}, you will turn {age} this year.");
    }
}