namespace SunamoNumbers._sunamo.SunamoExtensions;

/// <summary>
/// Provides extension methods for string cleaning operations.
/// </summary>
internal static class StringExtensions
{
    /// <summary>
    /// Removes invisible Unicode characters from the string.
    /// </summary>
    /// <param name="text">The input string to clean.</param>
    internal static string RemoveInvisibleChars(this string text)
    {
        int[] charactersToRemove = [8205];
        return new string(text.ToCharArray()
            .Where(character => !charactersToRemove.Contains((int)character))
            .ToArray());
    }

    /// <summary>
    /// Removes all types of whitespace characters from the string.
    /// </summary>
    /// <param name="text">The input string to clean.</param>
    internal static string RemoveWhitespaceChars(this string text)
    {
        int[] whitespaceCharactersToRemove = [9, 10, 11, 12, 13, 32, 160, 8192, 8193, 8194, 8195, 8196, 8197, 8198, 8199, 8200, 8201, 8202, 8239, 8287, 12288];
        return new string(text.ToCharArray()
            .Where(character => !whitespaceCharactersToRemove.Contains((int)character))
            .ToArray());
    }
}
