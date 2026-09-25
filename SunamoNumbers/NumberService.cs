namespace SunamoNumbers;

/// <summary>
/// Provides number parsing services including interval and single value parsing.
/// </summary>
public class NumberService
{
    /// <summary>
    /// Parses the input string as either a single integer or an interval (range) of numbers.
    /// Handles en-dash, hyphen, whitespace, and invisible characters in the input.
    /// </summary>
    /// <param name="input">The string to parse, which may contain a single number or a range like "120000-150000".</param>
    public (int?, Interval?)? ParseInterval(string input)
    {
        input = HttpUtility.HtmlDecode(input).Replace(" ", "").RemoveInvisibleChars().RemoveWhitespaceChars();

        var enDash = (char)8211;
        var containsEnDash = input.Contains(enDash);
        if (input.Contains('-') || containsEnDash)
        {
            bool isNegative = false;
            if (input[0] == '-')
            {
                isNegative = true;
                input = input.Substring(1);
            }
            int firstNumber = 0;
            uint secondNumber = 0;
            var parts = input.Split('-', enDash);
            var firstPartChars = parts[0].Trim().ToCharArray();
            var firstParseSuccess = int.TryParse(new string(firstPartChars), out firstNumber);
            if (isNegative)
            {
                firstNumber *= -1;
            }
            var secondParseSuccess = uint.TryParse(parts[1].Trim(), out secondNumber);
            if (firstParseSuccess && secondParseSuccess)
            {
                return (null, new Interval { From = firstNumber, To = secondNumber });
            }
            return (null, null);
        }
        else
        {
            if (int.TryParse(input, out var parsedValue))
            {
                return (parsedValue, null);
            }
        }
        return null;
    }
}
