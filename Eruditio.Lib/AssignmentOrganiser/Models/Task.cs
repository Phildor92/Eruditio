namespace Eruditio.Lib.AssignmentOrganiser.Models;

public class Task
{
    public string Name { get; set; }
    /// <summary>
    /// Set from app
    /// </summary>
    public DateTime DueDate { get; set; }

    public Task(string name, DateTime dueDate)
    {
        Name = name;
        DueDate = dueDate;
    }
}