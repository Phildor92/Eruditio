using System.IO;

namespace Eruditio.WPF.Utilities;

public class Localiser
{
    //TODO: temp localisation solution since it duplicates the localisation in the xaml and csv files
    private readonly Dictionary<string, Dictionary<string, string>> _dictionaries;

    public Localiser()
    {
        _dictionaries = new();
        var lines = File.ReadAllLines(@"Resources\LocalesPS.csv");

        var locales = lines[0].Split(',');
        
        for (var i = 1; i < locales.Length; i++)
        {
            var locale = locales[i];
            var keyWordPairs = new Dictionary<string, string>();
            foreach (var line in lines.Skip(1))
            {
                var parts = line.Split(',');
                var key = parts[0];
                var word = parts[i];
                keyWordPairs.Add(key, word);
            }
            _dictionaries.Add(locale, keyWordPairs);
        }
    }

    public string GetLocalisedText(string key)
    {
        var currentLocale = App.TwoLetterLangKey ?? "en";
        return _dictionaries[currentLocale][key];
    }
}