using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Samuel Bennett", "Multiplication");
        string student = assignment.GetSummary();
        Console.WriteLine(student);

        MathAssignment assignment1 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        string student2 = assignment1.GetSummary();
        string assignment2 = assignment1.GetHomeworkList();
        Console.WriteLine(student2);
        Console.WriteLine(assignment2);

        WritingAssignment assignment3 = new WritingAssignment("Mary Waters", "European History", "The causes of World war II");
        string student3 = assignment3.GetSummary();
        string assignment4 = assignment3.GetWritingInformation();
        Console.WriteLine(student3);
        Console.WriteLine(assignment4);

    }
}