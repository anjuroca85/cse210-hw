public class SpendingValue : Budget
{
    private Dictionary<string, double> expenses;

    public SpendingValue(string month, int year) : base(month, year)
    {
        expenses = new Dictionary<string, double>();
    }

    public override string CategorizeExpense(string item)
    {
        Console.WriteLine("Available categories:");
        foreach (var cat in GetCategories())
        {
            Console.WriteLine(cat);
        }

        Console.Write($"Enter category for '{item}': ");
        string chosenCategory = Console.ReadLine();

        Console.Write($"Enter amount for '{item}': ");
        double amount = Convert.ToDouble(Console.ReadLine());

        expenses[item] = amount;
        return chosenCategory;
    }

    public override bool IsFinished()
    {
        Console.Write("Do you want to continue entering expenses? (yes/no): ");
        string response = Console.ReadLine().ToLower();
        return response != "yes";
    }

    public void ShowExpenses()
    {
        Console.WriteLine("Spending Items:");
        foreach (var expense in expenses)
        {
            Console.WriteLine($"Item: {expense.Key}, Amount: {expense.Value}");
        }
    }

    public double GetTotalSpent()
    {
        double total = 0;
        foreach (var expense in expenses)
        {
            total += expense.Value;
        }
        return total;
    }
}