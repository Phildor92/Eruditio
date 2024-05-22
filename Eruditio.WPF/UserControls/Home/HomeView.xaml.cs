using System.Reactive.Disposables;
using ReactiveUI;

namespace Eruditio.WPF.UserControls.Home;

public partial class HomeView
{
    public HomeView()
    {
        InitializeComponent();
        ViewModel = new();

        this.WhenActivated(disposableRegistration =>
        {
            this.BindCommand(ViewModel, viewModel => viewModel.OpenAssignmentsCommand, view => view.AssignmentsTile).DisposeWith(disposableRegistration);
            this.OneWayBind(ViewModel, viewModel => viewModel.UrlPathSegment, view => view.PathTextBlock.Text).DisposeWith(disposableRegistration);
        });
    }
}