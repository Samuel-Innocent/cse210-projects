using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1; // Creative addition: Level system!

    public void Start()
    {
        while (true)
        {
            Console.WriteLine($"\nYour current score: {_score} | Level {_level}");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter a short description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points for completing this goal: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Enter target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
        }
    }

    private void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        int index = 1;
        foreach (Goal goal in _goals)
        {
            string checkBox = goal.IsComplete() ? "[X]" : "[ ]";
            if (goal is ChecklistGoal checklist)
            {
                Console.WriteLine($"{index}. {checkBox} {goal.GetName()} ({goal.GetDescription()}) - Completed {checklist.GetCurrentCount()}/{checklist.GetTargetCount()}");
            }
            else
            {
                Console.WriteLine($"{index}. {checkBox} {goal.GetName()} ({goal.GetDescription()})");
            }
            index++;
        }
    }

    private void RecordEvent()
    {
        Console.WriteLine("Which goal did you accomplish?");
        ListGoals();
        Console.Write("Enter goal number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int pointsEarned = _goals[index].RecordEvent();
        _score += pointsEarned;
        Console.WriteLine($"You earned {pointsEarned} points!");

        // Creative Feature: Leveling System
        if (_score >= _level * 1000)
        {
            _level++;
            Console.WriteLine($"🎉 You leveled up! You are now Level {_level}!");
            Console.WriteLine("Keep going—you’re doing great!");
        }
    }

    private void SaveGoals()
    {
        Console.Write("Enter filename to save to: ");
        string fileName = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(fileName))
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

    private void LoadGoals()
    {
        Console.Write("Enter filename to load from: ");
        string fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(fileName);
        _score = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);
        _goals.Clear();

        for (int i = 2; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string type = parts[0];
            string[] data = parts[1].Split("|");

            if (type == "SimpleGoal")
            {
                _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
            }
            else if (type == "ChecklistGoal")
            {
                _goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]),
                                             int.Parse(data[4]), int.Parse(data[3]), int.Parse(data[5])));
            }
        }

        Console.WriteLine("Goals loaded successfully!");
    }
}
