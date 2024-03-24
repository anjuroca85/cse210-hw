public class BreathingActivity : Activity
{
    //This class has no attributes

    public BreathingActivity(string name, string description) : base(name, description) //The constructor for this class
    { }

    //Defining a method below:
    public void Run()
    {
        DisplayStartingMessage();

        Console.Write("\nHow long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        

        int remainingTime = _duration;
        while (remainingTime > 0)
        {
            Console.Write("\nBreathe in...");
            ShowCountDown(3);

            Console.Write("\nNow breathe out...");
            ShowCountDown(5);

            remainingTime -= 8; // Subtracting the total time taken for one breath cycle

            if (remainingTime > 0)
            {
                Console.WriteLine("\nRepeat the breathing cycle...");
                System.Threading.Thread.Sleep(2000); // Pause between breath cycles
            }
        }

        DisplayEndingMessage();
    }
}