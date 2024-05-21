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
    private ResourceDictionary? _currentDictionary;
    
    public App()
    {
        Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetCallingAssembly());
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        //InitialiseAutofac();
        SetLanguageDictionary();
        SetThemeDictionary();
    }

    //TODO: move to reusable common library
    public void SetLanguageDictionary(string? culture = null)
    {
        if (!string.IsNullOrEmpty(culture))
            Thread.CurrentThread.CurrentCulture = new(culture);
        var dict = new ResourceDictionary();
        switch (Thread.CurrentThread.CurrentCulture.ToString())
        { 
            case "en-US":
            case "en-UK":
                dict.Source = new(@"..\Resources\Localisation-en.xaml", UriKind.Relative);
                TwoLetterLangKey = "en";
                break;
            case "nl-BE":
            case "nl-NL":
                dict.Source = new(@"..\Resources\Localisation-nl.xaml", UriKind.Relative);
                TwoLetterLangKey = "nl";
                break;
            default :
                dict.Source = new(@"..\Resources\Localisation-en.xaml",UriKind.Relative);
                TwoLetterLangKey = "en";
                break;
        }
        Resources.MergedDictionaries.Add(dict);
    }

    public void SetThemeDictionary(string? theme = null)
    {
        if (_currentDictionary != null && Resources.MergedDictionaries.Contains(_currentDictionary))
            Resources.MergedDictionaries.Remove(_currentDictionary);
        
        var designDict = Resources.MergedDictionaries.FirstOrDefault(x =>
            x.MergedDictionaries.Any(k => k.Contains("DesignResourceDictionary")));
        if(designDict != null)
            Resources.MergedDictionaries.Remove(designDict);
        
        _currentDictionary = new();
        
        switch (theme)
        { 
            case "standard":
                _currentDictionary.Source = new(@"..\Resources\Theme-standard.xaml", UriKind.Relative);
                break;
            case "variant":
                _currentDictionary.Source = new(@"..\Resources\Theme-variant.xaml", UriKind.Relative);
                break;
            default :
                _currentDictionary.Source = new(@"..\Resources\Theme-standard.xaml",UriKind.Relative);
                break;
        }
        
        Resources.MergedDictionaries.Add(_currentDictionary);
    }
}