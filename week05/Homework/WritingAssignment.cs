public class WritingAssignment : Assignment
{
    private string _title;

    // Constructor
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    // Method specific to Writing
    public string GetWritingInformation()
    {
        // Accessing student name via base getter
        return $"{_title} by {GetStudentName()}";
    }
}
