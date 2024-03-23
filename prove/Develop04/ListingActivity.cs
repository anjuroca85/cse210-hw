public class ListingActivity
{
    //Setting up attributes below in private type. Doing so by not specifying a modifier.
    int _count;
    List<string> _prompts = new List<string>();//Just to remember that the parethesis creates a new object

    public ListingActivity() //The constructor for this class
    { }

    //Setting up the methods below:
    public void Run()
    {

    }

    public void GetRandomPrompt()
    {

    }

    public List<string> GetListFromUser()
    {
        string[] items = Console.ReadLine().Split(',');
        List<string> itemList = new List<string>(items);
        return itemList;
    }

}