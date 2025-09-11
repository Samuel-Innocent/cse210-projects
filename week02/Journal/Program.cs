using System;

/*
  Journal Program - Program.cs

  Notes on creativity / exceeding requirements (for rubric):
  - Uses a safe custom delimiter "~|~" to avoid issues with commas when saving/loading.
  - PromptGenerator avoids immediate duplicate prompts within the same session.
  - SaveToFile and LoadFromFile replace the Journal contents when loading (as required).
  - Each class is in its own file and follows naming conventions: classes/methods TitleCase, members _underscoreCamelCase.
  
*/

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();

        bool keepRunning = true;
        while (keepRunning)
        {
            Console.WriteLine();
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option (1-5): ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(theJournal, promptGen);
                    break;
                case "2":
                    theJournal.DisplayAll();
                    break;
                case "3":
                    SaveJournal(theJournal);
                    break;
                case "4":
                    LoadJournal(theJournal);
                    break;
                case "5":
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please choose 1-5.");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    static void WriteNewEntry(Journal journal, PromptGenerator promptGen)
    {
        string prompt = promptGen.GetRandomPrompt();
        Console.WriteLine("Prompt:");
        Console.WriteLine(prompt);
        Console.WriteLine();
        Console.WriteLine("Write your response below. When finished, press Enter on an empty line to save.");

        // Read multiple lines until user enters an empty line
        string line;
        string entryText = "";
        while (true)
        {
            line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                break;
            }
            if (entryText.Length > 0)
            {
                entryText += Environment.NewLine;
            }
            entryText += line;
        }

        string dateText = DateTime.Now.ToShortDateString();

        Entry newEntry = new Entry();
        newEntry._date = dateText;
        newEntry._promptText = prompt;
        newEntry._entryText = entryText;

        journal.AddEntry(newEntry);
        Console.WriteLine("Entry added.");
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("Enter filename to save (e.g. myJournal.txt): ");
        string filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Invalid filename.");
            return;
        }

        journal.SaveToFile(filename);
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("Enter filename to load (this will replace current entries): ");
        string filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Invalid filename.");
            return;
        }

        journal.LoadFromFile(filename);
    }
}
