using System;

public class Entry
{
    // Member variables for the Entry abstraction
    public string _date = "";
    public string _promptText = "";
    public string _entryText = "";

    // Display the entry details 
    public void Display()
    {
        Console.WriteLine("Date: " + _date);
        Console.WriteLine("Prompt: " + _promptText);
        Console.WriteLine("Entry:");
        Console.WriteLine(_entryText);
        Console.WriteLine(); // blank line for spacing
    }
}
