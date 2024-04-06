public class LoadFromFile
{
    public Budget[] Load(string filename)
    {
        // This will be updated later on.
        Console.WriteLine("Loading expenses from file...");
        List<Budget> loadedBudgets = new List<Budget>();

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {

            }
        }

        return loadedBudgets.ToArray();
    }
}
