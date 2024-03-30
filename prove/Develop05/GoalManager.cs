using System.Xml.Serialization;

public class GoalManager
{
    //Setting the attributes (member variables), including a list type Goal.
    List<Goal> _goals;
    public int _score;

    //setting the constructor
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    //Setting up the methods, including start that is called by the Program class
    public void Start()
    {
        bool exit = false;
        while (!exit)
        {

            Console.WriteLine($"\nYou have {_score} points.\n");
            Console.WriteLine("Menu options:");
            Console.WriteLine("\t1. Create New Goal");
            Console.WriteLine("\t2. List Goals");
            Console.WriteLine("\t3. Save Goals");
            Console.WriteLine("\t4. Load Goals");
            Console.WriteLine("\t5. Record Event");
            Console.WriteLine("\t6. Quit");
            Console.Write("Select a choice from the menu: ");

            string userInput = Console.ReadLine();
            int choice = int.Parse(userInput);

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;

                case 2:
                    ListGoalDetails();
                    break;

                case 3:
                    SaveGoals();
                    break;

                case 4:
                    LoadGoals();
                    break;

                case 5:
                    RecordEvent();
                    break;

                case 6:
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice! Please enter a number between 1 and 6.");
                    break;
            }


        }

    }

    public void DisplayPlayerInfo()
    { }

    public void ListGoalNames()
    { }

    public void ListGoalDetails()
    { }

    public void CreateGoal()
    { }

    public void RecordEvent()
    { }

    public void SaveGoals()
    { }

    public void LoadGoals()
    { }
}