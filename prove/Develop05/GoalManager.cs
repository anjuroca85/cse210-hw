using System.Drawing;
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
    {
        Console.WriteLine($"Current Score: {_score}");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"[{i}] {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        int count = 0;
        Console.WriteLine("The goals are:");
        foreach (Goal goal in _goals)
        {
            count += 1;
            string status = goal.IsComplete() ? "X" : " ";
            string[] parts = goal.GetShortName().Split(':');

            if (parts.Length > 1)
            {
                //I change it to colon instead of parentheses as in demo. Colon looks beter to me.
                Console.WriteLine($"{count}. [{status}] {parts[1]}: {goal.GetDetailsString()}");
            }
            else
            {
                Console.WriteLine($"{count}. [{status}] {goal.GetShortName()}: {goal.GetDetailsString()}");
            }


        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("\t1. Simple Goal");
        Console.WriteLine("\t2. Eternal Goal");
        Console.WriteLine("\t3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");


        int goalType = int.Parse(Console.ReadLine());

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (goalType)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, description, points));
                break;

            case 2:
                _goals.Add(new EternalGoal(name, description, points));
                break;

            case 3:
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());

                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;

            default:
                Console.WriteLine("Invalid goal type!");
                break;
        }


    }

    public void RecordEvent()
    {
        int count = 0;
        Console.WriteLine("The goals are:");
        foreach (Goal goal in _goals)
        {
            count += 1;
            string[] parts = goal.GetShortName().Split(':');
            if (parts.Length > 1)
            {
                Console.WriteLine($"{count}. {parts[1]}");

            }
            else
            {
                Console.WriteLine($"{count}. {goal.GetShortName()}");
            }

        }

        Console.Write("Which goal did you accomplish? ");
        int userInputIndex = int.Parse(Console.ReadLine());

        // Adjust the user input index to match zero-based indexing
        int index = userInputIndex - 1;

        if (index >= 0 && index < _goals.Count)
        {
            _goals[index].RecordEvent();

            // If the completed goal is a checklist goal and it's complete,
            // add only its bonus points to the score
            if (_goals[index] is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                int totalPointsEarned = _goals[index].GetPoints() + checklistGoal.GetBonus();
                Console.WriteLine($"Congratulations! You have earned {totalPointsEarned} points!");
                Console.WriteLine($"YOU ARE AMAZING!");
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine("⭐⭐⭐");



                // Add the total points earned to the score
                _score += totalPointsEarned;
            }
            else
            {
                // For other types of goals or incomplete checklist goals, add their base points                
                int totalPointsEarned = _goals[index].GetPoints();
                Console.WriteLine($"Congratulations! You have earned {totalPointsEarned} points!");

                // Add the total points earned to the score
                _score += totalPointsEarned;
            }


            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal index!");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine($"{_score}");

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        _goals.Clear();

        using (StreamReader reader = new StreamReader(fileName))
        {
            // Read the score value from the first line
            string scoreLine = reader.ReadLine();
            _score = int.Parse(scoreLine);

            // Read the rest of the lines containing goal data
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                string name = parts[0];
                string description = parts[1];
                int points = int.Parse(parts[2]);

                switch (parts.Length)
                {
                    case 3:
                        _goals.Add(new EternalGoal(name, description, points));
                        break;

                    case 4:
                        bool isComplete = bool.Parse(parts[3]);
                        //Adding the following to add the status
                        SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                        simpleGoal.SetCompletionStatus(isComplete);
                        _goals.Add(simpleGoal);
                        //_goals.Add(new SimpleGoal(name, description, points));
                        break;

                    case 6:
                        int amountCompleted = int.Parse(parts[5]);//it was 3
                        int target = int.Parse(parts[4]);
                        int bonus = int.Parse(parts[3]);
                        //Adding the following to add the status
                        ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                        checklistGoal.SetAmountCompleted(amountCompleted);
                        _goals.Add(checklistGoal);
                        //_goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                        break;

                    default:
                        Console.WriteLine("Invalid data format in file!");
                        break;
                }
            }
        }

        Console.WriteLine("Goals loaded successfully!");
    }
}