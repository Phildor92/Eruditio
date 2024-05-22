using System.Collections.ObjectModel;
using Eruditio.Lib.AssignmentOrganiser.Models;
using ReactiveUI;

namespace Eruditio.WPF.UserControls.Assignments;

public class AssignmentsViewModel : ReactiveObject
{
    private ObservableCollection<Assignment> _assignments;

    public ObservableCollection<Assignment> Assignments
    {
        get => _assignments;
        set => this.RaiseAndSetIfChanged(ref _assignments, value);
    }

    public AssignmentsViewModel()
    {
        _assignments = [];
    }
}