using System;

public class EternalGoal:Goal
{
    public EternalGoal(string name, string description, int points)
    : base(name, description, points)
    {

    }

    public override void RecordEvent()
    {
        // never complete so just recorde the action.
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        string status = "[ ]";
        return ($"{status} {GetName()} {GetDescription()} -- worth {GetPoints()} points. ");
    }

    public override string GetStringRepresentation()
    {
        return ($"EternalGoal:{GetName()},{GetDescription()},{GetPoints()}");
    }
}