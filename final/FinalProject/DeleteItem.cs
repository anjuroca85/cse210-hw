public class DeleteItem : Budget
{
    private List<string> enteredItems;

    public DeleteItem(string month, int year) : base(month, year)
    {
        enteredItems = new List<string>();
    }

    public void AddItemToDelete(string item)
    {
        enteredItems.Add(item);
    }

    public void ShowEnteredItems()
    {
        Console.WriteLine("Entered Items:");
        foreach (var item in enteredItems)
        {
            Console.WriteLine(item);
        }
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
        return chosenCategory;
    }

    public override bool IsFinished()
    {
        if (enteredItems.Count == 0)
        {
            Console.WriteLine("No items to delete.");
            return true;
        }

        Console.WriteLine("Items to delete:");
        ShowEnteredItems();

        Console.Write("Do you want to continue deleting items? (yes/no): ");
        string response = Console.ReadLine().ToLower();
        return response != "yes";
    }
}
