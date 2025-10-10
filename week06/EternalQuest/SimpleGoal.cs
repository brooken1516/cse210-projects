using System;

public class SimpleGoal:Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isCompleted = false)
    : base(name, description, points)
    {
        _isComplete = isCompleted;
    }

    public bool GetIsComplete()
    {
        return _isComplete;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return ($"{status} {GetName()} {GetDescription()} -- worth {GetPoints()} points. ");
    }

    public override string GetStringRepresentation()
    {
        return ($"SimpleGoal:{GetName()},{GetDescription()},{GetPoints()},{GetIsComplete()}");
    }
}