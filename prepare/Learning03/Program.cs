using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning03 World!");

        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(6);
        Fraction fraction3 = new Fraction(6, 7);

        fraction1.SetTop(3);
        fraction1.SetBottom(4);

        Console.WriteLine(fraction1.GetTop());
        Console.WriteLine(fraction1.GetBottom());

        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());

        Fraction fraction4 = new Fraction(1, 3);

        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());

        Console.WriteLine(fraction4.GetFractionString());
        Console.WriteLine(fraction4.GetDecimalValue());

        Fraction randomFraction = new Fraction();
        Random random = new Random();

        for (int i = 1; i <= 20; i++)
        {
            int top = random.Next(1, 11);
            int bottom = random.Next(1, 11);
            randomFraction.SetTop(top);
            randomFraction.SetBottom(bottom);
            Console.WriteLine($"Fraction {i}: string: {randomFraction.GetFractionString()} Number: {randomFraction.GetDecimalValue()}");
        }



    }
}