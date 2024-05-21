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
    public void AssignmentsReturnsTwoAssignmentsTest()
    {
        _assignmentManager.Assignments.Add(new("Assignment 1", "", new("Maths"), DateTime.Now.AddDays(1)));
        _assignmentManager.Assignments.Add(new("Assignment 2", "", new("History"), DateTime.Now.AddDays(-1)));

        var assignments = _assignmentManager.GetAssignments();
        
        Assert.That(assignments, Has.Count.EqualTo(2));
    }
    
    [Test]
    public void AssignmentsPastDueReturnsOneAssignmentTest()
    {
        _assignmentManager.Assignments.Add(new("Assignment 3", "", new("Maths"), DateTime.Now.AddDays(1)));
        _assignmentManager.Assignments.Add(new("Assignment 4", "", new("History"), DateTime.Now.AddDays(-1)));

        var assignments = _assignmentManager.GetAssignmentsPastDue();
        
        Assert.That(assignments, Has.Count.EqualTo(1));
        
        Assert.That(assignments.First().Name, Is.EqualTo("Assignment 4"));
    }

    [Test]
    public void AssignmentsForSubjectReturnsTwoAssignmentsTest()
    {
        _assignmentManager.Assignments.Add(new("Assignment 5", "", new("Maths"), DateTime.Now.AddDays(1)));
        _assignmentManager.Assignments.Add(new("Assignment 6", "", new("History"), DateTime.Now.AddDays(-1)));
        _assignmentManager.Assignments.Add(new("Assignment 7", "", new("Maths"), DateTime.Now.AddDays(-1)));

        var assignments = _assignmentManager.GetAssignmentsForSubject("Maths");
        
        Assert.That(assignments, Has.Count.EqualTo(2));
        
        Assert.That(assignments.First().Name, Is.EqualTo("Assignment 5"));
    }
}