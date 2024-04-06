public class IncomeValue : Budget
{
    private double mainIncome;

    public IncomeValue(string month, int year, double mainIncome) : base(month, year)
    {
        this.mainIncome = mainIncome;
    }

    public override string CategorizeExpense(string item)
    {
        return "Income";
    }

    public override bool IsFinished()
    {
        return true;
    }

    public void UpdateMainIncome(double additionalIncome)
    {
        mainIncome += additionalIncome;
    }

    public double GetMainIncome()
    {
        return mainIncome;
    }
}