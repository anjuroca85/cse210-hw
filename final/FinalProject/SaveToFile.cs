public class SaveToFile
{
    public void Save(Budget budget, string filename)
    {
        Console.WriteLine("Saving expenses to file...");
        using (StreamWriter writer = new StreamWriter(filename))
        {
            if (budget is EnterItem enterItem)
            {
                writer.WriteLine($"Month: {enterItem.GetMonth()}, Year: {enterItem.GetYear()}");

                // Iterate through each category and write the items associated with it
                foreach (var category in enterItem.GetCategories())
                {
                    writer.WriteLine($"Category: {category}");
                    //https://www.geeksforgeeks.org/hashset-in-c-sharp-with-examples/
                    HashSet<string> writtenItems = new HashSet<string>(); // Track written items for each category
                    foreach (var item in enterItem.GetEnteredItemsForCategory(category))
                    {
                        if (!writtenItems.Contains(item)) // Check if item is already written
                        {
                            writer.WriteLine(item);
                            writtenItems.Add(item); // Add item to writtenItems set
                        }
                    }
                }
            }
        }
    }
}