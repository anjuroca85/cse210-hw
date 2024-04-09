public class EnterItem : Budget
{
    private Dictionary<string, List<string>> enteredItemsByCategory; // Map category to its associated items

    public EnterItem(string month, int year) : base(month, year)
    {
        enteredItemsByCategory = new Dictionary<string, List<string>>();
        SetMonth(month);
        SetYear(year);
    }

    public List<string> GetEnteredItems()
    {
        List<string> allItems = new List<string>();
        foreach (var items in enteredItemsByCategory.Values)
        {
            allItems.AddRange(items);
        }
        return allItems;
    }



    public void AddEnteredItem(string item, string category)
    {
        if (!enteredItemsByCategory.ContainsKey(category))
        {
            enteredItemsByCategory[category] = new List<string>();
        }
        //enteredItemsByCategory[category].Add(item);
        if (!enteredItemsByCategory[category].Contains(item))
        {
            enteredItemsByCategory[category].Add(item);
        }

    }

    public List<string> GetEnteredItemsForCategory(string category)
    {
        if (enteredItemsByCategory.ContainsKey(category))
        {
            return enteredItemsByCategory[category];
        }
        return new List<string>(); // Return an empty list if the category does not exist
    }


    public override string CategorizeExpense(string item)
    {
        Console.WriteLine("Available categories:");
        foreach (var cat in GetCategories())
        {
            Console.WriteLine(cat);
        }

        string chosenCategory;
        while (true)
        {
            Console.Write($"Enter category for '{item}': ");
            string enteredCategory = Console.ReadLine().Trim().ToLower(); // Convert entered category to lowercase

            // Convert available categories to lowercase for case-insensitive comparison
            List<string> lowerCategories = GetCategories().ConvertAll(cat => cat.ToLower());

            if (lowerCategories.Contains(enteredCategory))
            {
                chosenCategory = GetCategories()[lowerCategories.IndexOf(enteredCategory)]; // Retrieve the original casing
                break; // Exit loop if the entered category is valid
            }
            else
            {
                Console.WriteLine("Invalid category. Please choose from the available categories.");
            }
        }

        AddEnteredItem(item, chosenCategory); // Assign the entered item to its category
        return chosenCategory;
    }



    public override bool IsFinished()
    {
        Console.Write("Do you want to continue entering expenses? (yes/no): ");
        string response = Console.ReadLine().ToLower();
        return response != "yes";
    }
}
