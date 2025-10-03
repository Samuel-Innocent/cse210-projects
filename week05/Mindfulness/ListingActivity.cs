using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Spirit this month?",
        "Who are some of your personal heroes?"
    };

    private Random _random = new Random();

    public ListingActivity() 
        : base("Listing Activity", 
            "This activity will help you reflect on the good things in your life by having you list as many things as you can.") { }

    public override void Run()
    {
        DisplayStartingMessage();
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine($"\n--- {prompt} ---");
        Console.WriteLine("Start listing items after the countdown.");
        ShowCountDown(5);

        int elapsed = 0;
        List<string> items = new List<string>();

        while (elapsed < GetDuration())
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            items.Add(input);
            elapsed += 3;
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");
        DisplayEndingMessage();
    }
}
