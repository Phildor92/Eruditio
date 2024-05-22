using System.IO;
using System.Reflection;
using System.Windows;
using Microsoft.Extensions.Configuration;
using ReactiveUI;
using Splat;

namespace Eruditio.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    public static string? TwoLetterLangKey { get; private set; }
    private ResourceDictionary? _currentLanguageDictionary;
    private ResourceDictionary? _currentThemeDictionary;
    
    public App()
    {
        Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetCallingAssembly());
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        var designDict = Resources.MergedDictionaries.FirstOrDefault(x =>
            x.MergedDictionaries.Any(k => k.Contains("DesignResourceDictionary")));
        if(designDict != null)
            Resources.MergedDictionaries.Remove(designDict);
        
        var engDict = Resources.MergedDictionaries.FirstOrDefault(x =>
            x.MergedDictionaries.Any(k => k.Contains("Assignments")));
        if(engDict != null)
            Resources.MergedDictionaries.Remove(engDict);


        var configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        //InitialiseAutofac();
        SetLanguageDictionary();
        SetThemeDictionary();
    }

    //TODO: move to reusable common library
    public void SetLanguageDictionary(string? culture = null)
    {
        if (_currentLanguageDictionary != null && Resources.MergedDictionaries.Contains(_currentLanguageDictionary))
            Resources.MergedDictionaries.Remove(_currentLanguageDictionary);
        if (!string.IsNullOrEmpty(culture))
            Thread.CurrentThread.CurrentCulture = new(culture);
        _currentLanguageDictionary = new();
        switch (Thread.CurrentThread.CurrentCulture.ToString())
        { 
            case "en-US":
            case "en-UK":
                _currentLanguageDictionary.Source = new(@"..\Resources\Localisation-en.xaml", UriKind.Relative);
                TwoLetterLangKey = "en";
                break;
            case "nl-BE":
            case "nl-NL":
                _currentLanguageDictionary.Source = new(@"..\Resources\Localisation-nl.xaml", UriKind.Relative);
                TwoLetterLangKey = "nl";
                break;
            default :
                _currentLanguageDictionary.Source = new(@"..\Resources\Localisation-en.xaml",UriKind.Relative);
                TwoLetterLangKey = "en";
                break;
        }
        Resources.MergedDictionaries.Add(_currentLanguageDictionary);
    }

    public void SetThemeDictionary(string? theme = null)
    {
        if (_currentThemeDictionary != null && Resources.MergedDictionaries.Contains(_currentThemeDictionary))
            Resources.MergedDictionaries.Remove(_currentThemeDictionary);
        
        _currentThemeDictionary = new();
        
        switch (theme)
        { 
            case "standard":
                _currentThemeDictionary.Source = new(@"..\Resources\Theme-standard.xaml", UriKind.Relative);
                break;
            case "variant":
                _currentThemeDictionary.Source = new(@"..\Resources\Theme-variant.xaml", UriKind.Relative);
                break;
            default :
                _currentThemeDictionary.Source = new(@"..\Resources\Theme-standard.xaml",UriKind.Relative);
                break;
        }
        
        Resources.MergedDictionaries.Add(_currentThemeDictionary);
    }
}