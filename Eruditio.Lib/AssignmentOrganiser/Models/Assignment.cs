namespace Eruditio.Lib.AssignmentOrganiser.Models;

public class Assignment
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Subject Subject { get; set; }
    public List<Task> Tasks { get; set; }
    /// <summary>
    /// Set externally
    /// </summary>
    public DateTime DueDate { get; set; }

    public Assignment(string name, string description, Subject subject, DateTime dueDate)
    {
        Name = name;
        Description = description;
        Subject = subject;
        Tasks = [];
        DueDate = dueDate;
    }
}