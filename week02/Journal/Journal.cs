using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    // List of Entry objects
    public List<Entry> _entries = new List<Entry>();

    // Add an entry to the journal
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // Display all entries by delegating to Entry.Display()
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        Console.WriteLine("Journal Entries:");
        Console.WriteLine("----------------");
        foreach (Entry e in _entries)
        {
            e.Display();
        }
    }

    // Save the journal to a file. Each entry is a single line using a safe separator.
    public void SaveToFile(string filename)
    {
        // I used a delimiter unlikely to appear in natural text: "~|~"
        string delimiter = "~|~";
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry e in _entries)
                {
                    // Replace newline characters in entry text so each saved entry is one line
                    string sanitizedText = e._entryText.Replace("\r\n", " ").Replace("\n", " ");
                    string line = $"{e._date}{delimiter}{e._promptText}{delimiter}{sanitizedText}";
                    outputFile.WriteLine(line);
                }
            }
            Console.WriteLine($"Journal saved to: {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving file: " + ex.Message);
        }
    }

    // Load the journal from a file; this replaces current entries
    public void LoadFromFile(string filename)
    {
        string delimiter = "~|~";
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File does not exist: " + filename);
                return;
            }

            string[] lines = File.ReadAllLines(filename);
            List<Entry> loaded = new List<Entry>();

            foreach (string line in lines)
            {
                string[] parts = line.Split(new string[] { delimiter }, StringSplitOptions.None);
                if (parts.Length >= 3)
                {
                    Entry e = new Entry();
                    e._date = parts[0];
                    e._promptText = parts[1];
                    // If the entry text contained the delimiter, the split may produce extra parts — join them back
                    e._entryText = string.Join(delimiter, parts, 2, parts.Length - 2);
                    loaded.Add(e);
                }
                else
                {
                    // Malformed line — ignore or log
                    Console.WriteLine("Skipping malformed line in file.");
                }
            }

            _entries = loaded; // replace journal contents
            Console.WriteLine($"Journal loaded from: {filename} ({_entries.Count} entries)");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading file: " + ex.Message);
        }
    }
}
