using System.Reactive.Disposables;
using ReactiveUI;

namespace Eruditio.WPF.UserControls.Main;

public partial class MainView
{
    public MainView()
    {
        InitializeComponent();
        ViewModel = new();
        this.WhenActivated(disposableRegistration =>
        {
            this.OneWayBind(ViewModel, viewModel => viewModel.Router, window => window.RoutedViewHost.Router)
                .DisposeWith(disposableRegistration);
            this.BindCommand(ViewModel, viewModel => viewModel.GoNext, window => window.GoNextButton)
                .DisposeWith(disposableRegistration);
            this.BindCommand(ViewModel, viewModel => viewModel.GoBack, window => window.GoBackButton)
                .DisposeWith(disposableRegistration);
        });
    }
}