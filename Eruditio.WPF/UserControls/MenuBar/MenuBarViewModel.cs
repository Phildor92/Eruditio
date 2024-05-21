using System.Windows;
using System.Windows.Input;
using ReactiveUI;

namespace Eruditio.WPF.UserControls.MenuBar;

public class MenuBarViewModel : ReactiveObject
{
    public ICommand QuitCommand { get; set; }
    public ICommand ChangeLanguageEnglishCommand { get; set; }
    public ICommand ChangeLanguageDutchCommand { get; set; }
    public ICommand ChangeThemeDefaultCommand { get; set; }
    public ICommand ChangeThemeVariantCommand { get; set; }

    public MenuBarViewModel()
    {
        QuitCommand = ReactiveCommand.Create(ExecuteQuit);
        ChangeLanguageEnglishCommand = ReactiveCommand.Create(ExecuteChangeEnglish);
        ChangeLanguageDutchCommand = ReactiveCommand.Create(ExecuteChangeDutch);
        ChangeThemeDefaultCommand = ReactiveCommand.Create(ExecuteChangeThemeDefault);
        ChangeThemeVariantCommand = ReactiveCommand.Create(ExecuteChangeThemeVariant);
    }

    private static void ExecuteQuit()
    {
        Environment.Exit(0);
    }

    private static void ExecuteChangeEnglish()
    {
        var app = Application.Current as App;
        app?.SetLanguageDictionary("en-UK");
        
    }

    private static void ExecuteChangeDutch()
    {
        var app = Application.Current as App;
        app?.SetLanguageDictionary("nl-NL");
    }

    private static void ExecuteChangeThemeDefault()
    {
        var app = Application.Current as App;
        app?.SetThemeDictionary("standard");
    }

    private static void ExecuteChangeThemeVariant()
    {
        var app = Application.Current as App;
        app?.SetThemeDictionary("variant");
    }
}