using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private string[] _levelTitles = { "Novice", "Apprentice", "Adventurer", "Expert", "Master", "Champion", "Legend", "Grandmaster", "Immortal", "Transcendent" };

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
    }

    private int GetPointsForLevel(int level)
    {
        // Points required for each level (exponential growth)
        return (level - 1) * 1000;
    }

    private void UpdateLevel()
    {
        int oldLevel = _level;

        // Calculate current level based on score
        _level = 1;
        while (_score >= GetPointsForLevel(_level + 1))
        {
            _level++;
        }

        // Check if leveled up
        if (_level > oldLevel)
        {
            Console.WriteLine("\n╔════════════════════════════════════════╗");
            Console.WriteLine("║               LEVEL UP!                ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine($"You've reached Level {_level}: {GetLevelTitle()}!");
            Console.WriteLine($"Keep up the great work!\n");
        }
    }

    private string GetLevelTitle()
    {
        if (_level <= _levelTitles.Length)
        {
            return _levelTitles[_level - 1];
        }
        return "Transcendent"; // Max title
    }

    private void DisplayLevelProgress()
    {
        int currentLevelPoints = GetPointsForLevel(_level);
        int nextLevelPoints = GetPointsForLevel(_level + 1);
        int pointsInCurrentLevel = _score - currentLevelPoints;
        int pointsNeededForLevel = nextLevelPoints - currentLevelPoints;

        double progressPercent = (double)pointsInCurrentLevel / pointsNeededForLevel * 100;

        // Create progress bar
        int barWidth = 30;
        int filledWidth = (int)(progressPercent / 100 * barWidth);
        string progressBar = "[" + new string('█', filledWidth) + new string('░', barWidth - filledWidth) + "]";

        Console.WriteLine($"Level {_level}: {GetLevelTitle()}");
        Console.WriteLine($"{progressBar} {progressPercent:F1}%");
        Console.WriteLine($"Points: {pointsInCurrentLevel}/{pointsNeededForLevel} to next level");
    }

    public void Start()
    {
        bool running = true;

        while (running)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine("\n══════════════════════════════════════");
        Console.WriteLine($"             Player Stats             ");
        Console.WriteLine("══════════════════════════════════════");
        Console.WriteLine($"Total Points: {_score}");
        DisplayLevelProgress();
        Console.WriteLine("══════════════════════════════════════");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;

        switch (typeChoice)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        if (newGoal != null)
        {
            _goals.Add(newGoal);
            Console.WriteLine("Goal created successfully!");
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            int pointsEarned = _goals[goalIndex].RecordEvent();

            if (pointsEarned > 0)
            {
                _score += pointsEarned;
                Console.WriteLine($"\nCongratulations! You have earned {pointsEarned} points!");
                Console.WriteLine($"You now have {_score} points.");

                // Check for level up
                UpdateLevel();
            }
            else
            {
                Console.WriteLine("This goal has already been completed or cannot be recorded.");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            writer.WriteLine(_level);

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            _goals.Clear();

            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _level = int.Parse(lines[1]);

            for (int i = 2; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(new char[] { ':' }, 2);
                string goalType = parts[0];
                string[] data = parts[1].Split(',');

                Goal goal = null;

                switch (goalType)
                {
                    case "SimpleGoal":
                        goal = new SimpleGoal(data[0], data[1], int.Parse(data[2]));
                        ((SimpleGoal)goal).SetComplete(bool.Parse(data[3]));
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal(data[0], data[1], int.Parse(data[2]));
                        break;
                    case "ChecklistGoal":
                        goal = new ChecklistGoal(data[0], data[1], int.Parse(data[2]),
                                                 int.Parse(data[3]), int.Parse(data[4]));
                        ((ChecklistGoal)goal).SetAmountCompleted(int.Parse(data[5]));
                        break;
                }

                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }

            Console.WriteLine("Goals loaded successfully!");
            Console.WriteLine($"Welcome back, Level {_level} {GetLevelTitle()}!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}