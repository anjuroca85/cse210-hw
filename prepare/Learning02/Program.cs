using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2005;
        job1._endYear = 2007;

        Job job2 = new Job();
        job2._company = "Apple";
        job2._jobTitle = "Senior Developer";
        job2._startYear = 2008;
        job2._endYear = 2019;

        // Console.WriteLine(job1._company);
        // Console.WriteLine(job2._company);

        // job1.DisplayJobInfo();
        // job2.DisplayJobInfo();

        Resume resume1 = new Resume();
        resume1._name = "Andres Rojas";
        resume1._jobs.Add(job1); // we add the instance or object that contains the info for job1
        resume1._jobs.Add(job2);

        //Console.WriteLine(resume1._jobs[0]._jobTitle); // index[0] refers to Job 1
        resume1.DisplayResumeDetail();

    }
}