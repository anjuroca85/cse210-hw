using System;

public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public Resume()//The constructor. It seems to me that Only needed if I am going to define 
    //attributes for Resume here.
    {
    }

    //Methods:
    public void DisplayResumeDetail()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs) // I used the custom data type job in this loop
        {
            job.DisplayJobInfo();

        }
    }

}