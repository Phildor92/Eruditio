using System.Reactive.Disposables;
using ReactiveUI;

namespace Eruditio.WPF.UserControls.MenuBar;

public partial class MenuBarView
{
    public MenuBarView()
    {
        InitializeComponent();
        ViewModel = new();

        this.WhenActivated(disposableRegistration =>
        {
            this.OneWayBind(ViewModel, viewModel => viewModel.QuitCommand, view => view.QuitMenuItem.Command).DisposeWith(disposableRegistration);
        });
    }
}