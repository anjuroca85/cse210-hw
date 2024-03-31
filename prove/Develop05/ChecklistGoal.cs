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

    //A getter
    public int GetBonus()
    {
        return _bonus;
    }

    //Defining the methods:
    //Adding the following so that i can modify the status after loading the file after saving it.
    public void SetAmountCompleted(int amountCompleted)
    {
        _amountCompleted = amountCompleted;
    }

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
        return $"{_shortName},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
    }

    // Override GetDetailsString for ChecklistGoal
    public override string GetDetailsString()
    {
        //return $"[ ] {_shortName}: {_description} -- Currently completed: {_amountCompleted}/{_target}";
        return $"{_description} -- Currently completed: {_amountCompleted}/{_target}";

    }
}
