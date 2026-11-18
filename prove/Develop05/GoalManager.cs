
using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            Console.WriteLine($"\nYou have {_score} points.");
            // Creativity: I added a level-up system that increases the player's
            // level for every 500 points earned. This provides extra motivation
            // as players complete goals and earn rewards.
            int level = (_score / 500) + 1;
            Console.WriteLine($"Your current level is {level}!");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine() ?? "";

        if (type != "1" && type != "2" && type != "3")
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine() ?? "";

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine() ?? "";

        Console.Write("What is the amount of points associated with this goal? ");
        if (!int.TryParse(Console.ReadLine(), out int points) || points < 0)
        {
            Console.WriteLine("Please enter a valid point amount.");
            return;
        }

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else
        {
            Console.Write("How many times does this goal need to be accomplished? ");
            if (!int.TryParse(Console.ReadLine(), out int target) || target <= 0)
            {
                Console.WriteLine("Please enter a positive number.");
                return;
            }

            Console.Write("What is the bonus for accomplishing it that many times? ");
            if (!int.TryParse(Console.ReadLine(), out int bonus) || bonus < 0)
            {
                Console.WriteLine("Please enter a valid bonus.");
                return;
            }

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }

        Console.WriteLine("Goal created successfully!");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("Create a goal first.");
            return;
        }

        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }

        Console.Write("Which goal did you accomplish? ");
        if (!int.TryParse(Console.ReadLine(), out int number) ||
            number < 1 || number > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal goal = _goals[number - 1];
        int earned = goal.RecordEvent();
        _score += earned;

        if (earned > 0)
        {
            Console.WriteLine($"Congratulations! You earned {earned} points!");
        }
        else
        {
            Console.WriteLine("This goal is already complete.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine() ?? "";

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);

                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine("Goals saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unable to save goals: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine() ?? "";

        try
        {
            string[] lines = File.ReadAllLines(filename);
            int loadedScore = int.Parse(lines[0]);
            List<Goal> loadedGoals = new List<Goal>();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':', 2);
                string[] details = parts[1].Split(',');

                string name = details[0];
                string description = details[1];
                int points = int.Parse(details[2]);

                if (parts[0] == "SimpleGoal")
                {
                    SimpleGoal goal = new SimpleGoal(name, description, points);

                    if (bool.Parse(details[3]))
                    {
                        goal.RecordEvent();
                    }

                    loadedGoals.Add(goal);
                }
                else if (parts[0] == "EternalGoal")
                {
                    loadedGoals.Add(new EternalGoal(name, description, points));
                }
                else if (parts[0] == "ChecklistGoal")
                {
                    int bonus = int.Parse(details[3]);
                    int target = int.Parse(details[4]);
                    int completed = int.Parse(details[5]);

                    ChecklistGoal goal = new ChecklistGoal(
                        name, description, points, target, bonus);

                    for (int count = 0; count < completed; count++)
                    {
                        goal.RecordEvent();
                    }

                    loadedGoals.Add(goal);
                }
            }

            _goals = loadedGoals;
            _score = loadedScore;
            Console.WriteLine("Goals loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unable to load goals: {ex.Message}");
        }
    }
}
