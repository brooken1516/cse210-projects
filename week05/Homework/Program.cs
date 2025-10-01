using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("George Washington", "Social Sciences");
        Console.WriteLine(assignment1.GetSummary());

        MathAssignment mathAssignment1 = new MathAssignment("Bastian Grandberry", "Addition", "7.3", "8-19");
        Console.WriteLine(mathAssignment1.GetSummary());
        Console.WriteLine(mathAssignment1.GetHomeWorkList());

        WritingAssignment writingAssignment1 = new WritingAssignment("Atreyu Grandbery", "Sentences", "Sentence Structure");
        Console.WriteLine(writingAssignment1.GetSummary());
        Console.WriteLine(writingAssignment1.GetWritingInformation());
    }
}