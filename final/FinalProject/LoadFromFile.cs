using System;
using System.Collections.Generic;
using System.IO;

public class LoadFromFile
{
    public List<Budget> Load(string filename)
    {
        List<Budget> budgets = new List<Budget>();

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            EnterItem enterItem = null;
            string month = null;
            int year = 0;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("Month:"))
                {
                    string[] parts = line.Split(':');
                    string monthString = parts[1].Trim();
                    string[] monthYearParts = monthString.Split(',');
                    month = monthYearParts[0].Trim();
                    if (parts.Length >= 3)
                    {
                        year = int.Parse(parts[2].Trim());
                    }
                }
                else if (line.StartsWith("Category:"))
                {
                    string category = line.Split(':')[1].Trim();
                    enterItem = new EnterItem(month, year);
                    enterItem.AddCategory(category);
                    budgets.Add(enterItem);
                }
                else if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        string itemName = parts[0].Trim();
                        float value;
                        if (float.TryParse(parts[1].Trim().Replace("$", ""), out value))
                        {
                            enterItem.AddEnteredItem(itemName, ""); // Assuming no category information in the file
                            // Add value to the item
                            // You may need to modify this depending on your implementation
                        }
                        else
                        {
                            Console.WriteLine($"Error: Unable to parse value for item '{itemName}'.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error: Invalid item format '{line}'.");
                    }
                }
            }
        }

        return budgets;
    }
}


// public class LoadFromFile
// {
//     public List<Budget> Load(string filename)
//     {
//         List<Budget> budgets = new List<Budget>();

//         using (StreamReader reader = new StreamReader(filename))
//         {
//             string line;
//             EnterItem enterItem = null;
//             string month = null;
//             int year = 0;
//             while ((line = reader.ReadLine()) != null)
//             {
//                 if (line.StartsWith("Month:"))
//                 {
//                     string[] parts = line.Split(':');
//                     string monthString = parts[1].Trim();
//                     string[] monthYearParts = monthString.Split(',');
//                     month = monthYearParts[0].Trim();
//                     //year = int.Parse(parts[2].Trim());
//                     if (parts.Length >= 3)
//                     {
//                         year = int.Parse(parts[2].Trim());
//                     }

//                 }
//                 else if (line.StartsWith("Category:"))
//                 {
//                     string category = line.Split(':')[1].Trim();
//                     enterItem = new EnterItem(month, year);
//                     enterItem.AddCategory(category);
//                     budgets.Add(enterItem);
//                 }
//                 else if (!string.IsNullOrWhiteSpace(line))
//                 {
//                     string[] parts = line.Split(':');
//                     string itemName = parts[0].Trim();
//                     float value = float.Parse(parts[1].Trim().Replace("$", ""));
//                     enterItem.AddEnteredItem(itemName, "");
//                 }
//             }
//         }

//         return budgets;
//     }
// }
