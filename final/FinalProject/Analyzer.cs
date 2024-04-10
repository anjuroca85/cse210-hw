public class Analyzer
{
    public static void Analyze(IncomeValue income, SpendingValue spending)
    {
        float availableBalance = income.GetAmount() - spending.GetAmount();

        if (availableBalance < 0)
        {
            Console.WriteLine("Warning: You are spending more than your income!");
            Console.WriteLine($"Income: ${income.GetAmount()}");
            Console.WriteLine($"Spending: ${spending.GetAmount()}");
            Console.WriteLine($"Available balance: ${availableBalance}");
        }
        else
        {
            Console.WriteLine("Your spending is within your income limit.");
            Console.WriteLine($"Income: ${income.GetAmount()}");
            Console.WriteLine($"Spending: ${spending.GetAmount()}");
            Console.WriteLine($"Available balance: ${availableBalance}");
        }
    }
}