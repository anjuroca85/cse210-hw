public class ChecklistGoal : Goal
{
    //Defining the member variables.
    int _amountCompleted;
    int _target;
    int _bonus;

    //Defining the constructor
    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    //Defining the methods:
    public override void RecordEvent()
    {
        _amountCompleted++;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetStringRepresentation()
    {
        return $"{_shortName},{_description},{_points},{_amountCompleted},{_target},{_bonus}";
    }

    // Override GetDetailsString for ChecklistGoal
    public override string GetDetailsString()
    {
        return $"[ ] {_shortName}: {_description} Completed {_amountCompleted}/{_target} times";
    }
}
