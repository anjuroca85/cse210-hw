using System;
using System.Collections.Generic;

public class DeleteItem
{
    public void Delete(List<Budget> budgets)
    {
        Console.WriteLine("Delete an item:");

        // Prompt the user for the month, year, category, and item to delete
        Console.Write("Enter the month: ");
        string month = Console.ReadLine().Trim().ToLower();
        Console.Write("Enter the year: ");
        int year = int.Parse(Console.ReadLine().Trim());
        // Read the category input from the user
        Console.Write("Enter the category: ");
        string categoryInput = Console.ReadLine().Trim().ToLower();

        // Capitalize the first letter of the category
        string category = char.ToUpper(categoryInput[0]) + categoryInput.Substring(1);
        Console.Write("Enter the item to delete: ");
        string item = Console.ReadLine().Trim();

        // Find the budget with the specified month and year
        EnterItem budget = (EnterItem)budgets.Find(b => b is EnterItem && b.GetMonth().ToLower() == month && b.GetYear() == year);

        if (budget != null)
        {
            // Attempt to delete the entered item from the specified category
            budget.DeleteEnteredItem(item, category);
            Console.WriteLine("Item deleted successfully.");
        }
        else
        {
            Console.WriteLine("No budget found for the specified month and year.");
        }
    }
}