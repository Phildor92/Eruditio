using System.Windows.Input;
using ReactiveUI;
using Splat;

namespace Eruditio.WPF.UserControls.Home;

public class HomeViewModel : ReactiveObject, IRoutableViewModel
{
    public string? UrlPathSegment => "home";
    public IScreen? HostScreen { get; }
    
    public ICommand OpenAssignmentsCommand { get; set; }

    public HomeViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        OpenAssignmentsCommand = ReactiveCommand.Create(ExecuteOpenAssignments);
    }

    private void ExecuteOpenAssignments()
    {
    }
}