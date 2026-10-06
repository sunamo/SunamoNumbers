namespace SunamoNumbers._sunamo.SunamoString;

internal class SH
{
    internal static string ReplaceOnce(string text, string what, string replacement)
    {
        return new Regex(what).Replace(text, replacement, 1);
    }
}
