using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(assignment.GetSummary());

        MathAssignment mathassignment = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(mathassignment.GetSummary());
        Console.WriteLine(mathassignment.GetHomeworkList());

        WritingAssignment writingassignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writingassignment.GetSummary());
        Console.WriteLine(writingassignment.GetWritingInformation());
    }
}