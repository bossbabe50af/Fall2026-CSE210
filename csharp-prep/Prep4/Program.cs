using System;
class Program
{
    static void Main(string[] args)
    {
        List<int> numbers =new List<int>();
        Console.WriteLine("Enter list of numbers, type 0 when finished.");

        int number = -1;

        do
        {
            //ask for number
        Console.Write("Enter number: ");
        number = int.Parse(Console.ReadLine());

        if (number != 0)
            {
                numbers.Add(number);
            }
        
    }
           while (number != 0);

            int sum = 0;

        foreach (int numberInList in numbers)
            {
                sum += numberInList;
            }

        
        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numbers[0];

        foreach (int currentNumber in numbers)
        {
            if (currentNumber > max)
            {max = currentNumber;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }
}
