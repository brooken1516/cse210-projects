using System;

public class ChecklistGoal:Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
    : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public int GetAmountComleted()
    {
        return _amountCompleted;
    }

    public void SetAmountCompleted(int amount)
    {
        _amountCompleted = amount;
    }

    public override void RecordEvent()
    {
        _amountCompleted = _amountCompleted + 1;
        if (_amountCompleted == _target)
        {
            Console.WriteLine($"You reached your target! Bonus points awarded: {_bonus}");
        }
    }

    public int GetPointsForEvent()
    {
        if (_amountCompleted == _target)
        {
            return GetPoints() + _bonus;
        }
        else
        {
            return GetPoints();
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string status;

        if (_amountCompleted >= _target)
        {
            status = "[X]";
        }
        else
        {
            status = "[ ]";
        }
        return ($"{status} {GetName()} {GetDescription()} -- worth {GetPoints()} each time. Completed {_amountCompleted} / {_target} times. ");
    }

    public override string GetStringRepresentation()
    {
        return ($"ChecklistGoal:{GetName()},{GetDescription()},{GetPoints()},{_target},{_bonus},{_amountCompleted}");
    }
}