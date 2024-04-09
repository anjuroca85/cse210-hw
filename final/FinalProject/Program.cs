using System;
class Program
{
    static void Main(string[] args)
    {
        List<Budget> budgets = new List<Budget>();
        LoadFromFile loader = new LoadFromFile();

        Console.WriteLine("\nWelcome to the budget tool. Please select an option from the menu:");

        while (true)
        {
            DisplayMenu();

            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    EnterExpenses(budgets);
                    break;
                case "2":
                    DeleteItem deleter = new DeleteItem();
                    deleter.Delete(budgets);
                    break;
                case "3":
                    ViewEnteredItems(budgets);
                    break;
                case "4":
                    // Implement Analyze Expenses
                    break;
                case "5":
                    SaveToFile(budgets);
                    break;
                case "6":
                    LoadFromFile(budgets, loader);
                    break;
                case "7":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from the menu.");
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\nMenu:");
        Console.WriteLine("\t1. Enter Expenses");
        Console.WriteLine("\t2. Delete Expenses");
        Console.WriteLine("\t3. View Entered Items");
        Console.WriteLine("\t4. Analyze Expenses");
        Console.WriteLine("\t5. Save to File");
        Console.WriteLine("\t6. Load from File");
        Console.WriteLine("\t7. Exit");
    }

    static void EnterExpenses(List<Budget> budgets)
    {
        // Prompt the user for the month and year
        string month = GetMonthFromUser();
        int year = GetYearFromUser();

        // Create a new EnterItem instance for each entry
        EnterItem enterItem = new EnterItem(month, year);
        enterItem.AddCategory("Pleasure");
        enterItem.AddCategory("Essential");
        enterItem.AddCategory("Investment");

        Console.WriteLine("This option will allow you to enter your expenses.");

        // Loop to collect and add expenses
        while (true)
        {
            CollectAndAddExpense(enterItem, budgets);

            // Check if the user wants to continue entering expenses
            if (!WantsToContinueEnteringExpenses())
            {
                break; // Exit the loop if the user does not want to continue
            }
        }

        budgets.Add(enterItem);
    }

    static string GetMonthFromUser()
    {
        Console.Write("Enter month: ");
        string month = Console.ReadLine().Trim(); // Trim any leading or trailing whitespace
                                                  // Convert the input to lowercase for case-insensitive comparison
        return month.ToLower();
    }

    static int GetYearFromUser()
    {
        Console.Write("Enter year: ");
        return int.Parse(Console.ReadLine());
    }

    static void CollectAndAddExpense(EnterItem enterItem, List<Budget> budgets)
    {
        Console.Write("\nEnter item: ");
        string item = Console.ReadLine();

        string category = enterItem.CategorizeExpense(item);
        Console.WriteLine($"Item '{item}' is categorized as '{category}'");

        enterItem.AddEnteredItem(item, category); // Pass the category along with the item
    }


    static bool WantsToContinueEnteringExpenses()
    {
        Console.Write("Do you want to continue entering expenses? (yes/no): ");
        string response = Console.ReadLine().ToLower();
        return response == "yes";
    }


    static void ViewEnteredItems(List<Budget> budgets)
    {
        Console.WriteLine("Entered Items:");

        // Create a dictionary to store entered items grouped by month and year
        Dictionary<string, HashSet<string>> enteredItemsByMonthYear = new Dictionary<string, HashSet<string>>();

        foreach (var budget in budgets)
        {
            if (budget is EnterItem enterItem)
            {
                // Get the month and year for the current EnterItem instance
                string monthYearKey = $"{enterItem.GetMonth()}, Year: {enterItem.GetYear()}";

                // If the month and year key does not exist in the dictionary, add it
                if (!enteredItemsByMonthYear.ContainsKey(monthYearKey))
                {
                    enteredItemsByMonthYear[monthYearKey] = new HashSet<string>();
                }

                // Iterate through entered items of EnterItem instance and add them to the HashSet
                foreach (var item in enterItem.GetEnteredItems())
                {
                    enteredItemsByMonthYear[monthYearKey].Add(item);
                }
            }
        }

        // Output the grouped entered items
        foreach (var entry in enteredItemsByMonthYear)
        {
            Console.WriteLine($"Month: {entry.Key}");
            foreach (var item in entry.Value)
            {
                Console.WriteLine(item);
            }
        }
    }

    static void SaveToFile(List<Budget> budgets)
    {
        SaveToFile saver = new SaveToFile();

        foreach (var budget in budgets)
        {
            if (budget is EnterItem enterItem)
            {
                saver.Save(enterItem, $"Budget_{enterItem.GetYear()}-{enterItem.GetMonth()}.txt");
            }
        }
    }

    static void LoadFromFile(List<Budget> budgets, LoadFromFile loader)
    {
        Console.Write("Enter the file name to load: ");
        string fileName = Console.ReadLine();
        List<Budget> loadedBudgets = loader.Load(fileName);
        budgets.AddRange(loadedBudgets);
    }

}