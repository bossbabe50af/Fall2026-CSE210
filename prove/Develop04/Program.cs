using System;

class Program
{
    static void Main(string[] args)
    {
        // Exceeds requirements: reflection questions do not repeat
        // until every question has been used within that session.

        BreathingActivity breathingActivity = new BreathingActivity();
        ReflectingActivity reflectingActivity = new ReflectingActivity();
        ListingActivity listingActivity = new ListingActivity();

        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    breathingActivity.Run();
                    break;

                case "2":
                    reflectingActivity.Run();
                    break;

                case "3":
                    listingActivity.Run();
                    break;

                case "4":
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Please choose 1, 2, 3, or 4.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}