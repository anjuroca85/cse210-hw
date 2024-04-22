public class EnterItem : Budget
{
    private Dictionary<string, List<string>> enteredItemsByCategory; // Map category to its associated items
    private Dictionary<string, float> itemValues; // New: Map item names to their values

    public EnterItem(string month, int year) : base(month, year)
    {
        enteredItemsByCategory = new Dictionary<string, List<string>>();
        itemValues = new Dictionary<string, float>();//New
        SetMonth(month);
        SetYear(year);
    }

    public void AddItemValue(string item, float value) //new
    {
        itemValues[item] = value;
    }

    public float GetItemValue(string item) //new
    {
        if (itemValues.ContainsKey(item))
        {
            return itemValues[item];
        }
        else
        {
            // Handle case where item value is not found
            Console.WriteLine($"Error: Value not found for item '{item}'.");
            return 0; // or any default value
        }
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

    public void DeleteEnteredItem(string item, string category)
    {
        if (enteredItemsByCategory.ContainsKey(category))
        {
            enteredItemsByCategory[category].Remove(item);
        }
    }


    public float CalculateTotalSpending()
    {
        float totalSpending = 0;

        foreach (var itemList in enteredItemsByCategory.Values)
        {
            foreach (var item in itemList)
            {
                // Split the item string into its name and value parts
                string[] parts = item.Split(':');
                if (parts.Length == 2)
                {
                    // Extract the value part and parse it to a float
                    string valueString = parts[1].Trim().Replace("$", ""); // Remove $ sign and trim any whitespace if present
                    if (float.TryParse(valueString, out float value))
                    {
                        totalSpending += value; // Add the value to the total spending
                    }
                    else
                    {
                        Console.WriteLine($"Error: Unable to parse value for item '{parts[0].Trim()}'.");
                    }
                }
                else
                {
                    Console.WriteLine($"Error: Invalid item format '{item}'.");
                }
            }
        }

        return totalSpending;
    }

}