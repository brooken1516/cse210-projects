using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;
    private int _nextLevelThreshold;
    private int _level;

    public GoalManager()
    {
        _score = 0;
        _nextLevelThreshold = 500;
        _level = 1;
    }

    public void Start()
    {
        while (true)
        {
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Please select a menu option for your chosen activity.");
            Console.WriteLine("Menu Options:\n1. Create Goal\n2. List Goals\n3. Save Goals\n4. Load Goals\n5. Record Event\n6. Quit\n");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                CreateGoal();
            }

            else if (choice == "2")
            {
                ListGoalDetails();
            }

            else if (choice == "3")
            {
                SaveGoals();
            }

            else if (choice == "4")
            {
                LoadGoals();
            }

            else if (choice == "5")
            {
                RecordEvent();
            }

            else if (choice == "6")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice, please try a number 1-6.");
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Your current score is: {_score}. Your current level is: {_level} ");

        int completedGoals = 0;
        foreach (Goal goal in _goals)
        {
            if (goal.IsComplete())
            {
                completedGoals = completedGoals + 1;
            }
        }

        Console.WriteLine($"Total goal count: {_goals.Count}. Completed goals: {completedGoals}. ");
    }

    public void ListGoalNames()
    {
        int goalNumber = 1;

        foreach (Goal goal in _goals)
        {
            string status;

            if (goal.IsComplete())
            {
                status = "[X]";
            }
            else
            {
                status = "[ ]";
            }
            Console.WriteLine($"{goalNumber}. {status} {goal.GetName()}. ");

            goalNumber = goalNumber + 1;
        }
    }

    public void ListGoalDetails()
    {
        int goalNumber = 1;

        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{goalNumber}. {goal.GetDetailsString()}. ");
            goalNumber = goalNumber + 1;
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Choose your goal type number (example 1,2,3): \n 1. Simple \n 2. Eternal \n 3. Checklist ");
        string goalTypeInput = Console.ReadLine();
        Console.WriteLine("What is the goal name? ");
        string name = Console.ReadLine();
        Console.WriteLine("Describe your goal: ");
        string description = Console.ReadLine();
        Console.WriteLine("How many points is this goal worth? ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal;

        if (goalTypeInput == "1")
        {
            newGoal = new SimpleGoal(name, description, points);
        }
        else if (goalTypeInput == "2")
        {
            newGoal = new EternalGoal(name, description, points);
        }
        else
        {
            Console.WriteLine("Enter target number of completions: ");
            int target = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter bonus points: ");
            int bonus = int.Parse(Console.ReadLine());

            newGoal = new ChecklistGoal(name, description, points, target, bonus);
        }
        _goals.Add(newGoal);
        Console.WriteLine("Goal created sucessfully! ");
    }

    public void RecordEvent()
    {
        int goalNumber = 1;

        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{goalNumber}. {goal.GetName()}. ");
            goalNumber = goalNumber + 1;
        }

        Console.WriteLine("Enter the number of the goal you accomplished: ");
        int selectedGoalNumber = int.Parse(Console.ReadLine());
        Goal selectedGoal = _goals[selectedGoalNumber - 1];

        selectedGoal.RecordEvent();

        int pointsEarned = 0;

        if (selectedGoal is ChecklistGoal checklist)
        {
            pointsEarned = checklist.GetPointsForEvent();

        }
        else
        {
            pointsEarned = selectedGoal.GetPoints();
        }

        _score += pointsEarned;

        Console.WriteLine($"Congratulations! You earned {pointsEarned} points! Your total score is now {_score}. ");

        while (_score >= _nextLevelThreshold)
        {
            _level++;
            Console.WriteLine($"You Leveled Up! You are now at level {_level}. Keep going! ");
            _nextLevelThreshold += 500;
        }
    }

    public void SaveGoals()
    {
        string filename = "goals.txt";

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.WriteLine("What is file name you would like to load? (Example: goals.txt) ");
        string filename = Console.ReadLine();

        if (!System.IO.File.Exists(filename))
        {
            Console.WriteLine("File not found. ");
            return;
        }

        string[] lines = System.IO.File.ReadAllLines(filename);

        if (lines.Length == 0)
        {
            Console.WriteLine("File is empty. ");
            return;
        }

        if (!int.TryParse(lines[0], out int parsedScore))
        {
            Console.WriteLine("Saved score was invalid; resetting to 0. ");
            _score = 0;
        }
        else
        {
            _score = parsedScore;
        }

        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];

            string[] parts = line.Split(":");
            string goalType = parts[0];
            string goalData = parts[1];

            if (goalType == "SimpleGoal")
            {
                string[] fields = goalData.Split(',');
                string name = fields[0];
                string description = fields[1];
                int points = int.Parse(fields[2]);
                bool isComplete = bool.Parse(fields[3]);

                SimpleGoal newGoal = new SimpleGoal(name, description, points, isComplete);
                _goals.Add(newGoal);
            }

            else if (goalType == "EternalGoal")
            {
                string[] fields = goalData.Split(',');
                string name = fields[0];
                string description = fields[1];
                int points = int.Parse(fields[2]);

                EternalGoal newGoal = new EternalGoal(name, description, points);
                _goals.Add(newGoal);
            }

            else
            {
                string[] fields = goalData.Split(',');
                string name = fields[0];
                string description = fields[1];
                int points = int.Parse(fields[2]);
                int _target = int.Parse(fields[3]);
                int _bonus = int.Parse(fields[4]);
                int _amountCompleted = int.Parse(fields[5]);

                ChecklistGoal newGoal = new ChecklistGoal(name, description, points, _target, _bonus);
                newGoal.SetAmountCompleted(_amountCompleted);
                _goals.Add(newGoal);
            }
        }
    }
}