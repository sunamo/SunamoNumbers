namespace SunamoNumbers._sunamo.SunamoExtensions;

internal static class StringExtensions
{
    internal static string RemoveInvisibleChars(this string inputString)
    {
        int[] charactersToRemove = [8205];
        return new string(inputString.ToCharArray()
            .Where(character => !charactersToRemove.Contains((int)character))
            .ToArray());
    }
    internal static string RemoveWhitespaceChars(this string inputString)
    {
        // https://g.co/gemini/share/b47b0b16b54f
        int[] whitespaceCharactersToRemove = [9, 10, 11, 12, 13, 32, 160, 8192, 8193, 8194, 8195, 8196, 8197, 8198, 8199, 8200, 8201, 8202, 8239, 8287, 12288];
        return new string(inputString.ToCharArray()
            .Where(character => !whitespaceCharactersToRemove.Contains((int)character))
            .ToArray());
    }
}