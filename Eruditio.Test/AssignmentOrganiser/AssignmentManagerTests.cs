using Eruditio.Lib.AssignmentOrganiser;

namespace Eruditio.Test.AssignmentOrganiser;

[TestFixture]
public class AssignmentManagerTests
{
    private AssignmentManager _assignmentManager;
    
    [SetUp]
    public void Setup()
    {
        _assignmentManager = new();
    }
    
    [Test]
    public void AssignmentManagerAssignmentsReturnsTwoAssignmentsTest()
    {
        _assignmentManager.Assignments.Add(new("Assignment 1", new("Maths"), DateTime.Now.AddDays(1)));
        _assignmentManager.Assignments.Add(new("Assignment 2", new("History"), DateTime.Now.AddDays(-1)));

        var assignments = _assignmentManager.GetAssignments();
        
        Assert.That(assignments, Has.Count.EqualTo(2));
    }
    
    [Test]
    public void AssignmentManagerAssignmentsPastDueReturnsOneAssignmentTest()
    {
        _assignmentManager.Assignments.Add(new("Assignment 1", new("Maths"), DateTime.Now.AddDays(1)));
        _assignmentManager.Assignments.Add(new("Assignment 2", new("History"), DateTime.Now.AddDays(-1)));

        var assignments = _assignmentManager.GetAssignmentsPastDue();
        
        Assert.That(assignments, Has.Count.EqualTo(1));
    }
}