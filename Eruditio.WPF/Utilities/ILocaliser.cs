namespace Eruditio.WPF.Utilities;

public interface ILocaliser
{
    string GetLocalisedText(string key);
}

public static class Definitions
{
    public const string None = nameof(None);
}