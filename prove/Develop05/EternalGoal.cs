public class EternalGoal : Goal
{/*It has no attributes but it represents a component in the system. It still provides meaningful abstraction
 and still encapsulates a logical set of behaviors and responsibilities*/

    //setting the constructor:
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    { }

    //Setting the methods
    public override void RecordEvent()
    {
        // This goal is always considered accomplished
    }

    public override bool IsComplete()
    {
        // This goal is never complete
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"{_shortName},{_description},{_points}";
    }


}