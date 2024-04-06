public class Analyzer
{
    public void Analyze(Budget[] budgets)
    {
        double totalIncome = 0;
        double totalSpending = 0;

        foreach (var budget in budgets)
        {
            if (budget is IncomeValue)
            {
                totalIncome += (budget as IncomeValue).GetMainIncome();
            }
            else if (budget is SpendingValue)
            {
                totalSpending += (budget as SpendingValue).GetTotalSpent();
            }
        }

        Console.WriteLine($"Total Income: {totalIncome}");
        Console.WriteLine($"Total Spending: {totalSpending}");

        if (totalIncome < totalSpending)
        {
            Console.WriteLine("Warning: You are spending more than your income!");
        }
        else
        {
            Console.WriteLine("Your spending is within your income.");
        }
    }
}
