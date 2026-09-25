namespace SunamoNumbers._sunamo.SunamoString;

/// <summary>
/// String helper class for common string operations.
/// </summary>
internal class SH
{
    /// <summary>
    /// Replaces only the first occurrence of a pattern in the text.
    /// </summary>
    /// <param name="text">The input text.</param>
    /// <param name="what">The pattern to search for.</param>
    /// <param name="replacement">The replacement text.</param>
    internal static string ReplaceOnce(string text, string what, string replacement)
    {
        return new Regex(what).Replace(text, replacement, 1);
    }
}
