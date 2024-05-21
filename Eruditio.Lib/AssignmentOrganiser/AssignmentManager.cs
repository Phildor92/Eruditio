using Eruditio.Lib.AssignmentOrganiser.Models;

namespace Eruditio.Lib.AssignmentOrganiser;

public class AssignmentManager
{
    public List<Assignment> Assignments { get; set; }

    public AssignmentManager()
    {
        Assignments = [];
    }

    public List<Assignment> GetAssignmentsPastDue()
    {
        return [];
    }

    public List<Assignment> GetAssignments()
    {
        return Assignments;
    }
}