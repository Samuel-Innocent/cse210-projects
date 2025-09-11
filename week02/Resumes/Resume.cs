using System;
using System.Collections.Generic; // Needed for List<T>

public class Resume
{
    // Member variables (attributes)
    public string _name;
    public List<Job> _jobs = new List<Job>();

    // Method (behavior) to display resume details
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        // Loop through each job and call its Display method
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}
