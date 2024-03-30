public class SimpleGoal : Goal
{
    //Member variable:
    bool _isComplete; //Because there is no modifier, it defaults to private

    //The constructor
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
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