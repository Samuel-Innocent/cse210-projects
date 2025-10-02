using System;

class Program
{
    static void Main(string[] args)
    {
        // Base class test
        Assignment a1 = new Assignment("Samuel Innocent", "Multiplication");
        Console.WriteLine(a1.GetSummary());
        Console.WriteLine();

        // MathAssignment test
        MathAssignment m1 = new MathAssignment("Joshua Daniel", "Fractions", "7.3", "8-19");
        Console.WriteLine(m1.GetSummary());
        Console.WriteLine(m1.GetHomeworkList());
        Console.WriteLine();

        // WritingAssignment test
        WritingAssignment w1 = new WritingAssignment("Franklin Agba", "European History", "The Causes of World War II");
        Console.WriteLine(w1.GetSummary());
        Console.WriteLine(w1.GetWritingInformation());
    }
}
