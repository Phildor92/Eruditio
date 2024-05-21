using Eruditio.Lib.AssignmentOrganiser.Models;

namespace Eruditio.Lib.AssignmentOrganiser;

public class AssignmentManager
{
    public List<Assignment> Assignments { get; set; } = [];

    public List<Assignment> GetAssignmentsPastDue()
    {
        return Assignments.Where(x=>x.DueDate < DateTime.Now).ToList();
    }

    public List<Assignment> GetAssignments()
    {
        return Assignments;
    }

    public List<Assignment> GetAssignmentsForSubject(Subject subject)
    {
        return GetAssignmentsForSubject(subject.Name);
    }

    public List<Assignment> GetAssignmentsForSubject(string subject)
    {
        return Assignments.Where(x => x.Subject.Name == subject).ToList();
    }
}