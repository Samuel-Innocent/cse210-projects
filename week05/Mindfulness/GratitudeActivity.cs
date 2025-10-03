using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "List possessions you are grateful for.",
        "List people you are grateful for.",
        "List experiences you are grateful for."
    };

    public GratitudeActivity() 
        : base("Gratitude Activity", 
               "This activity will help you develop gratitude by listing things you are thankful for in life.") 
    { }

    public override void Run()
    {
        DisplayStartingMessage();

        // Pick a random prompt
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine($"\n--- {prompt} ---");

        Console.WriteLine("Begin listing items (type 'quit' or '0' to exit early):");

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            // Quit condition
            if (input.ToLower() == "quit" || input == "0")
            {
                Console.WriteLine("\nExiting Gratitude Activity early...");
                break;
            }

            // Only save valid entries
            if (!string.IsNullOrWhiteSpace(input))
            {
                items.Add(input);
            }
        }

        Console.WriteLine($"\nYou listed {items.Count} things you are grateful for.");
        DisplayEndingMessage();
    }
}
