using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };

    private Random _random = new Random();

    public ReflectingActivity() 
        : base("Reflecting Activity", 
            "This activity will help you reflect on times in your life when you have shown strength and resilience.") { }

    public override void Run()
    {
        DisplayStartingMessage();
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine($"\n--- {prompt} ---\n");
        ShowSpinner(3);

        int elapsed = 0;
        List<int> usedIndexes = new List<int>();
        while (elapsed < GetDuration())
        {
            if (usedIndexes.Count == _questions.Count) usedIndexes.Clear();
            int idx;
            do { idx = _random.Next(_questions.Count); } while (usedIndexes.Contains(idx));
            usedIndexes.Add(idx);

            Console.Write($"> {_questions[idx]} ");
            ShowSpinner(5);
            elapsed += 5;
        }

        DisplayEndingMessage();
    }
}
