public class SaveToFile
{
    public void Save(Budget budget, string filename)
    {
        Console.WriteLine("Saving expenses to file...");
        using (StreamWriter writer = new StreamWriter(filename, true)) // Append mode
        {
            if (budget is EnterItem enterItem)
            {
                // Write month and year only once
                writer.WriteLine($"Month: {enterItem.GetMonth()}, Year: {enterItem.GetYear()}");

                // Write categories only once
                HashSet<string> writtenCategories = new HashSet<string>();
                foreach (var category in enterItem.GetCategories())
                {
                    if (!writtenCategories.Contains(category))
                    {
                        writer.WriteLine($"\nCategory: {category}");
                        writtenCategories.Add(category);
                    }

                    // Iterate through items for the current category and write them to the file
                    HashSet<string> writtenItems = new HashSet<string>();
                    foreach (var item in enterItem.GetEnteredItemsForCategory(category))
                    {
                        if (!writtenItems.Contains(item))
                        {
                            // Prompt the user to enter the value for the item
                            Console.Write($"Enter value in USD for '{item}': $");
                            float value = float.Parse(Console.ReadLine());

                            // Write the formatted item with its value to the file
                            writer.WriteLine($"{item,-30}: ${value}");

                            writtenItems.Add(item);
                        }

                    }
                }
                Console.WriteLine("\nThe values will be store with the respective item. Thanks!");
            }
        }
    }
}