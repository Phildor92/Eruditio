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
            this.OneWayBind(ViewModel, viewModel => viewModel.ChangeLanguageEnglishCommand, view => view.EnglishMenuItem.Command).DisposeWith(disposableRegistration);
            this.OneWayBind(ViewModel, viewModel => viewModel.ChangeLanguageDutchCommand, view => view.DutchMenuItem.Command).DisposeWith(disposableRegistration);
            this.OneWayBind(ViewModel, viewModel => viewModel.ChangeThemeDefaultCommand, view => view.DefaultMenuItem.Command).DisposeWith(disposableRegistration);
            this.OneWayBind(ViewModel, viewModel => viewModel.ChangeThemeVariantCommand, view => view.VariantMenuItem.Command).DisposeWith(disposableRegistration);
        });
    }
}