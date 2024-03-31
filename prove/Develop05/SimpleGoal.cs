public class SimpleGoal : Goal
{
    //Member variable:
    bool _isComplete;

    //The constructor
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    //Adding the following so that i can modify the status after loading the file after saving it.
    public void SetCompletionStatus(bool isComplete)
    {
        _isComplete = isComplete;
    }

    //The methods. First two are overridding abstract methods.The last one is overriding a virtual one.
    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"{_shortName},{_description},{_points},{_isComplete}";
    }
}