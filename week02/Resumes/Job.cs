using System;

public class Job
{
    // Member variables (attributes)
    public string _jobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;

    // Method (behavior) to display job details
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}
