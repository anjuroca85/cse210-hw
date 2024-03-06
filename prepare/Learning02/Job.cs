using System;

public class Job
{
    public string _company = "";
    public string _jobTitle = "";
    public int _startYear;
    public int _endYear;

    public Job() //The constructor. It seems to me that it is Only needed if I am going to 
    //define attributes for Job here.
    {
    }

    //Methods:
    public void DisplayJobInfo()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }

}